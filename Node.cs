using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSaver
{
    public class Node
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; }
        public int Key { get; }
        public List<Node> Friends { get; }

        public Node(int key)
        {
            Key = key;
            X = 0;
            Y = 0;
            Radius = 20;
            Friends = new List<Node>();
        }

        public void AddFriend(Node node)
        {
            Friends.Add(node);
        }
        public void DelFriend(Node node)
        {
            Friends.Remove(node);
        }
        public void SetPos(int x, int y)
        {
            X = x;
            Y = y;
        }

        //отрисовка узел
        public void Draw(Graphics gr, Color backColor)
        {
            gr.FillEllipse(new SolidBrush(backColor), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            gr.DrawEllipse(new Pen(Color.Blue), X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }

        public void Draw(Graphics gr, Color backColor, int key)
        {
            Draw(gr, backColor);
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            gr.DrawString(key.ToString(), drawFont, drawBrush, X, Y, stringFormat);

        }
    }
}
