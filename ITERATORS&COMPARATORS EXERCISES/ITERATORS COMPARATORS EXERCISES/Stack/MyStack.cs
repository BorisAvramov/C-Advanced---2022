using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class MyStack <T> : IEnumerable<T>
    {
        private List<T> elements;


        public MyStack()
        {
            this.elements = new List<T>();

        }

        public int Count => elements.Count;
        public void Push(List<T> elementsOut)
        {
            int index = 0;
            for (int i = elementsOut.Count - 1; i >= 0; i--)
            {
                elements.Insert(index, elementsOut[i]);
                index++;
            }
        }

        public void Pop()
        {
            
            elements.RemoveAt(0);
            
            

            
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
