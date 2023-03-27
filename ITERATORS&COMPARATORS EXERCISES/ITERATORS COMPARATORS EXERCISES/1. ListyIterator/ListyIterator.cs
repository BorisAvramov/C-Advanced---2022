using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator <T> : IEnumerable<T>
    {
        private readonly List<T> list;
        private int internalIndex;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            internalIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                internalIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext() 
        {

            return internalIndex + 1 < list.Count;
        }
        public void Print()
        {
            if (list.Any())
            {
                Console.WriteLine(list[internalIndex]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            
        }

        public void PrintAll()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {

            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
