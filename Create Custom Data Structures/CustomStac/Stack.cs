using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T>
    {
        private T[] elements;
        private const int InitialCapacity = 4;

        public Stack()
        {
            elements = new T[InitialCapacity];

        }
        public int Count { get; private set; }

        //1 2 3 4


        


        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }

            

        }


        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = elements[Count - 1];

            elements[Count - 1] = default;

            Count--;

            Shrank();
            
            return element;

        }
        public void Push(T element)
        {
            Resize();

            elements[Count] = element;

            Count++;

            Shrank();

        }

        private void Shrank()
        {
            T[] newArr = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                newArr[i] = elements[i];
            }

            elements = newArr;

            
        }

        private void Resize()
        {
            if (Count == elements.Length)
            {
                T[] newArr = new T[InitialCapacity * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    newArr[i] = elements[i];
                }

                elements = newArr;

            }
        }
    }
}
