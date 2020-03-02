using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSaver
{
    public class CarsViewState
    {
        //хэш-функция посещенных состояний 
        //учитывает текущее положение всех вагонов на карте
        public override int GetHashCode()
        {
            int size = Cars.Count + Train.Count - 1; //количество всех вагонов
            string result = "";

            for (int i = 0; i < Cars.Count; i++)
            {
                result += (Cars[i].Key.ToString() + "lonely");
            }
            for (int j = Train.Count; j > 0; j--)
            {
                result += (Train[j - 1].Key.ToString() + "train");

            }
            hash = result.GetHashCode();
            return hash;
        }
        public Node Target { get; set; }        //куда нужно прийти
        public List<Node> Cars { get; set; }    //Все одиночные вагоны на карте
        public List<Node> Train { get; set; }   //расположение поезда, первый - локомотив
        public int hash;
 
        public override bool Equals(object obj)
        {
           
            if (obj is CarsViewState)
            {
                var b = (CarsViewState)obj;

                if (this.Cars.Count != b.Cars.Count)
                    return false;

                for (int i = 0; i < Cars.Count; i++)
                {
                    if (Cars.ElementAt(i).Key != b.Cars.ElementAt(i).Key)
                        return false;
                }
                if (Train.Count != b.Train.Count)
                    return false;

                for (int i = 0; i < Train.Count; i++)
                {
                    if (Train.ElementAt(i).Key != b.Train.ElementAt(i).Key)
                        return false;
                }
                return true;

            }
            return false;
        }
    }
}

