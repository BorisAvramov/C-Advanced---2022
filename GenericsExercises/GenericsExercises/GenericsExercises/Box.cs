using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExercises
{


    public class Box<T>
    where T : IComparable
    {
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }


        public void Add(T element)
        {
            elements.Add(element);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < elements.Count; i++)
            {

                sb.AppendLine($"{typeof(T)}: " + $"{elements[i].ToString()}");

            }

            return sb.ToString().TrimEnd();
        }
        public void Swap(int index1, int index2)
        {
            T first = elements[index1];
            T second = elements[index2];
            elements[index1] = second;
            elements[index2] = first;


        }

        public int Compare(T elementToCompare)
        {
            int count = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }


            return count;
        }

       
    }
}
