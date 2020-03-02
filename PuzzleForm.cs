using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TimeSaver
{
    enum State
    {
        MoveNode, DeletingNode, SetLinkFirst, SetLinkSecond,
        SelectLoko, SelectCar, SelectTarget, Run, Default
    }
    public partial class PuzzleForm : Form
    {
        private List<Node> allNodes = new List<Node>();       //все узлы

        private List<Node> StartCars = new List<Node>();  //начальное расположение
        private List<Node> StartTrain = new List<Node>();

        private Node Target;
        private List<Node> ViewCars = new List<Node>();  //Все вагоны на карте
        private List<Node> ViewTrain = new List<Node>(); //расположение поезда, первый - локомотив
        private List<CarsViewState> Views;
        private int IndexView;

        private State state = State.Default;         //состояние программы
        private bool IsDelState = false;
        private Node MoveNode;
        private Node firstLink;

        public void UpdateTrains(List<Node> train, List<Node> vagons)
        {
            ViewTrain = train;
            ViewCars = vagons;
        }
        public PuzzleForm()
        {
            InitializeComponent();
            try
            {
                Random rand = new Random();
                StreamReader input = new StreamReader("input.dat");
                String[] words;

                int countNodes = Int32.Parse(input.ReadLine());
                for (int i = 1; i <= countNodes; i++)    //ввод узлов
                {
                    words = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Node node = new Node(i);
                    node.SetPos(Int32.Parse(words[0]), Int32.Parse(words[1]));
                    allNodes.Add(node);
                }

                words = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String word in words)
                    ViewTrain.Add(allNodes.Find(x => x.Key.ToString() == word));

                words = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String word in words)
                    ViewCars.Add(allNodes.Find(x => x.Key.ToString() == word));

                String target = input.ReadLine();
                if (target != "")
                    Target = allNodes.Find(x => x.Key.ToString() == target);

                while (!input.EndOfStream)      //ввод связей
                {
                    words = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int i = Int32.Parse(words[0]) - 1;
                    int j = Int32.Parse(words[1]) - 1;
                    allNodes[i].AddFriend(allNodes[j]);
                    allNodes[j].AddFriend(allNodes[i]);
                }
                input.Close();
            }
            catch (Exception)
            {
                allNodes.Clear();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (state == State.MoveNode)
            {
                //изменить расположение ноды и перерисовать все
                MoveNode.SetPos(e.X, e.Y);
                this.Invalidate();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //рисуем связи
            foreach (Node curr in allNodes)
                foreach (Node friend in curr.Friends)
                    if (curr.X != friend.X || curr.Y != friend.Y)
                    {
                        int width = 2;
                        if (ViewTrain.Contains(curr) && ViewTrain.Contains(friend) &&
                            ViewTrain.IndexOf(curr) - ViewTrain.IndexOf(friend) == 1)
                            width = 7;
                        Pen pen = new Pen(Color.Black, width);
                        e.Graphics.DrawLine(pen, curr.X, curr.Y, friend.X, friend.Y);
                    }
            //рисуем узлы
            foreach (Node nodeVis in allNodes)
                if (nodeVis == firstLink)                   //при выделении связи первый узел
                    nodeVis.Draw(e.Graphics, Color.YellowGreen);
                else if (ViewTrain.IndexOf(nodeVis) == 0)           //локомотив
                    nodeVis.Draw(e.Graphics, Color.DarkRed, 0);
                else if (ViewTrain.Contains(nodeVis))               //вагоны поезда
                    nodeVis.Draw(e.Graphics, Color.Red, ViewTrain.IndexOf(nodeVis));
                else if (ViewCars.Contains(nodeVis))              //свободные вагоны
                    nodeVis.Draw(e.Graphics, Color.Blue);
                else if (nodeVis == Target)                          //цель
                    nodeVis.Draw(e.Graphics, Color.Yellow);
                else                                        //остальные узлы
                    nodeVis.Draw(e.Graphics, Color.Beige);
        }
        private void AddNodeBtn_Click(object sender, EventArgs e)
        {
            int key = allNodes.Count == 0 ? 1 : allNodes.Last().Key + 1;
            for (int i = 0; i < allNodes.Count - 1; i++)
                if (allNodes[i + 1].Key - allNodes[i].Key > 1)
                {
                    key = allNodes[i].Key + 1;
                    break;
                }

            MoveNode = new Node(key);
            allNodes.Insert(key - 1, MoveNode);     //добавим узел в список узлов
            MessageLabel.Text = "Разместите вершину";
            state = State.MoveNode;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = allNodes.Count - 1; i >= 0; i--) //найдем, какой узел нажали
            {
                Node node = allNodes[i];
                int dx = node.X - e.X;
                int dy = node.Y - e.Y;
                double dist = Math.Sqrt(dx * dx + dy * dy);
                if (dist < node.Radius)     //нажали на него
                {
                    if (state == State.SetLinkFirst)        //выбор первого узла
                    {
                        firstLink = node;
                        state = State.SetLinkSecond;
                        MessageLabel.Text = "Выберите вторую вершину";
                    }
                    else if (state == State.SetLinkSecond && node != firstLink) //выбор второго узла
                    {
                        if (IsDelState && firstLink.Friends.Contains(node))      //если это удаление связи
                        {
                            firstLink.DelFriend(node);
                            node.DelFriend(firstLink);
                        }
                        else                //если добавление связи
                        {
                            if (firstLink.Friends.Contains(node))
                                MessageBox.Show("Связь между выбранными вершинами уже есть", "Ошибка");
                            else
                            {
                                firstLink.AddFriend(node);
                                node.AddFriend(firstLink);
                            }
                        }
                        firstLink = null;
                        state = State.Default;
                        MessageLabel.Text = "";
                    }
                    else if (state == State.DeletingNode)  //когда удаляем узел
                    {
                        MessageLabel.Text = "";
                        foreach (Node another in allNodes)
                            if (another.Friends.Contains(node))
                                another.DelFriend(node);
                        allNodes.Remove(node);
                        state = State.Default;
                    }
                    else if (state == State.SelectLoko)
                    {
                        if (ViewTrain.Count == 0)
                            ViewTrain.Add(node);
                        else
                            ViewTrain[0] = node;
                        MessageLabel.Text = "";
                        state = State.Default;

                    }
                    else if (state == State.SelectCar)
                    {
                        if (!IsDelState && !ViewCars.Contains(node))
                            ViewCars.Add(node);
                        else if (ViewCars.Contains(node))
                            ViewCars.Remove(node);
                        MessageLabel.Text = "";
                        state = State.Default;

                    }
                    else if (state == State.SelectTarget)
                    {
                        Target = node;
                        MessageLabel.Text = "";
                        state = State.Default;

                    }
                    else if (state == State.Default)
                    {
                        MoveNode = node;
                        state = State.MoveNode;
                        MessageLabel.Text = "Разместите вершину";
                    }
                    break;

                }
            }
            this.Invalidate();
            return;

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == State.MoveNode)
            {
                state = State.Default;
                MessageLabel.Text = "";
            }
        }

        private void AddLinkBtn_Click(object sender, EventArgs e)
        {
            //добавление связи
            if (allNodes.Count < 2)
            {
                MessageLabel.Text = "Недостаточно вершин";
                return;
            }
            state = State.SetLinkFirst;
            MessageLabel.Text = "Выберите первую вершину";
            IsDelState = false;
        }

        private void DelNodeBtn_Click(object sender, EventArgs e)
        {
            state = State.DeletingNode;
            MessageLabel.Text = "Выберите вершину для удаления";
        }

        private void DelLinkBtn_Click(object sender, EventArgs e)
        {
            state = State.SetLinkFirst;
            MessageLabel.Text = "Выберите первую вершину";
            IsDelState = true;
        }

        private void WorkBtn_Click(object sender, EventArgs e)
        {
            if (ViewTrain.Count == 0)
            {
                MessageBox.Show("Поезд пуст!");
                return;
            }
            if (ViewTrain[0] == null)
            {
                MessageBox.Show("Нет локомотива!");
                return;
            }
            if (ViewCars.Count == 0)
            {
                MessageBox.Show("Нет вагонов!");
                return;
            }
            if (Target == null)
            {
                MessageBox.Show("Нет конечной станции!");
                return;
            }
            Trains trains = new Trains
            {
                Target = this.Target,
                Nodes = allNodes,
                Train = this.ViewTrain,
                LonelyCars = this.ViewCars,
                CountVagons = this.ViewCars.Count,
            };
            Views = trains.SolvePuzzle();
            if (Views != null)
            {
                MessageBox.Show("Решение найдено! Сложность: " + (Views.Count - 1)
                    + "\nНажмите 'ОК' для просмотра результата");
                StartTrain = ViewTrain;
                StartCars = ViewCars;
                timerUpdateView.Start();
                IndexView = 0;
                toolStrip.Enabled = false;
            }
            else
                MessageBox.Show("Необходимого решения нет");
        }

        private void SaveState()
        {
            StreamWriter writer = new StreamWriter("input.dat");
            writer.WriteLine(allNodes.Count);
            foreach (Node node in allNodes)
                writer.WriteLine(node.X + " " + node.Y);

            String train = "";
            foreach (Node car in ViewTrain)
                train += car?.Key + " ";
            writer.WriteLine(train);

            String cars = "";
            foreach (Node car in ViewCars)
                cars += car?.Key + " ";
            writer.WriteLine(cars);

            writer.WriteLine(Target == null ? "" : Target.Key.ToString());

            for (int i = 0; i < allNodes.Count; i++)
                foreach (Node friend in allNodes[i].Friends)
                    if (friend.Key > i)
                        writer.WriteLine((i + 1) + " " + friend.Key);
            writer.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }

        private void timerUpdateView_Tick(object sender, EventArgs e)
        {
            if (IndexView == Views.Count)
            {
                timerUpdateView.Stop();
                MessageBox.Show("Приехали на конечную станцию");
                ViewCars = StartCars;
                ViewTrain = StartTrain;
                toolStrip.Enabled = true;
                Refresh();
                return;
            }
            UpdateTrains(Views[IndexView].Train, Views[IndexView].Cars);
            IndexView++;
            Refresh();
        }

        private void AddCarBtn_Click(object sender, EventArgs e)
        {
            state = State.SelectCar;
            IsDelState = false;
            MessageLabel.Text = "Выберите вершину для вагона";
        }

        private void AddLokoBtn_Click(object sender, EventArgs e)
        {
            state = State.SelectLoko;
            MessageLabel.Text = "Выберите вершину для локомотива";
        }

        private void DelCarBtn_Click(object sender, EventArgs e)
        {
            state = State.SelectCar;
            IsDelState = true;
            MessageLabel.Text = "Выберите вершину c вагоном";
        }

        private void DelLokoBtn_Click(object sender, EventArgs e)
        {
            ViewTrain[0] = null;
        }

        private void AddTargetBtn_Click(object sender, EventArgs e)
        {
            state = State.SelectTarget;
            MessageLabel.Text = "Выберите конечную станцию";
        }

        private void DelTargetBtn_Click(object sender, EventArgs e)
        {
            Target = null;
        }



    }
}
