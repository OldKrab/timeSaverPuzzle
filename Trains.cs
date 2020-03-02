using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSaver
{
    public class Trains
    {
        //список посещенных состояний
        public Node Target { get; set; }        //куда нужно прийти
        public List<Node> Nodes { get; set; }   //карта тупиков (граф)
        public List<Node> LonelyCars { get; set; }    //Все одиночные вагоны на карте
        public int CountVagons { get; set; }
        public List<Node> Train { get; set; }   //расположение поезда, первый - локомотив

        //ограничение для глубины рекурсии
        int maxLenghtWay;

        private List<CarsViewState> SuccessfulResult = new List<CarsViewState>();

        public List<CarsViewState> SolvePuzzle()
        {
            maxLenghtWay = CountVagons * Nodes.Count * 2;
            SuccessfulResult.Clear();

            SolvePuzzle(LonelyCars, Train, new List<CarsViewState>());

            if (SuccessfulResult.Count == 0)
                return null;
            return SuccessfulResult;
        }

        private void SolvePuzzle(List<Node> lonelyCars, List<Node> train, List<CarsViewState> states)
        {

            states = states.ToList();

            int step = states.Count;
            //ограничение на глубину реккурсии
            if (step > maxLenghtWay)
                return;
            //текущее состояние объектов
            CarsViewState cvs = new CarsViewState { Target = Target, Cars = lonelyCars, Train = train };
            int hash = cvs.GetHashCode();
            //если хэш-коды двух сотсояний совпадают - 
            //сравниваем сами состояния на случай, если хэш совпал у разных состояний
            if (states.Find(x => x.hash == hash) != null)
            {
                if (states.Find(x => x.hash == hash).Equals(cvs))
                    return;
            }
            // form.UpdateTrains(train, lonelyCars, new List<Node> ());
            //form.Refresh();
            //добавим текущее состояние и его хэш в результат
            states.Add(cvs);


            //если этот результат - решение задачи
            if (IsTarget(train))
            {
                if (states.Count < maxLenghtWay)
                {
                    maxLenghtWay = states.Count;
                    SuccessfulResult = states;      //сохранение текущего результата
                }
                return;
            }
            Node loko = train[0];
            //перебор вариантов, что может сделать поезд со стороны локомотива
            foreach (Node availableNode in loko.Friends)
                //если этот узел не помечен и там нет вагонов поезда
                if (!train.Contains(availableNode))
                {
                    var lonelyCarsCopy = lonelyCars.ToList();           //копии для данной иттерации
                    var trainCopy = train.ToList();

                    if (!lonelyCarsCopy.Contains(availableNode)) //если на пути нет свободных вагонов 
                    {
                        //то двигаемся сюда
                        MoveTrain(trainCopy, availableNode, isLokoForward: true);
                    }
                    else if (trainCopy.Count == 1)  //если там вагон, и локомотив один
                    {
                        //то прицепим его
                        lonelyCarsCopy.Remove(availableNode);
                        trainCopy.Add(availableNode);
                    }
                    else continue;
                    //спускаемся рекурсивно
                    SolvePuzzle(lonelyCarsCopy, trainCopy, states);
                }



            Node tail = train[train.Count - 1];
            if (train.Count != 1)   //если в поезде есть вагоны
            {
                //перебор вариантов, что может сделать поезд со стороны хвоста
                foreach (Node available in tail.Friends)

                    //если этот узел не помечен и там нет вагонов поезда
                    if (!train.Contains(available))
                    {
                        var lonelyCarsCopy = lonelyCars.ToList();           //копии для данной иттерации
                        var trainCopy = train.ToList();

                        if (lonelyCarsCopy.Contains(available))     //если на пути неприцепленный вагон
                        {
                            //то прицепим его
                            lonelyCarsCopy.Remove(available);
                            trainCopy.Add(available);
                        }
                        else
                        {
                            //иначе поедем сюда
                            MoveTrain(trainCopy, available, isLokoForward: false);
                        }
                        SolvePuzzle(lonelyCarsCopy, trainCopy, states);
                    }
            }
        }

        private bool IsTarget(List<Node> train)
        {
            if (train.Count == (CountVagons + 1) && train[0] == Target)
                return true;
            return false;
        }

        private void MoveTrain(List<Node> train, Node to, bool isLokoForward)
        {
            if (isLokoForward)
            {
                for (int i = train.Count - 1; i > 0; i--)
                    train[i] = train[i - 1];
                train[0] = to;
            }
            else
            {
                for (int i = 0; i < train.Count - 1; i++)
                    train[i] = train[i + 1];
                train[train.Count - 1] = to;
            }
        }
    }
}
