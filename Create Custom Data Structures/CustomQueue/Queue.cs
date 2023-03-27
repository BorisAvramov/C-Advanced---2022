using System;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class Queue<T>
    {
        private const int InitialCapacity = 4;

        private T[] elements;


        public Queue()
        {
            elements = new T[InitialCapacity];
        }


        public int Count { get; private set; }


        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }


        public void Enqueue(T element)
        {
            Resize();
            elements[Count] = element;

            Count++;
            Shrank();

        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            elements[0] = default;

            Count--;

            Shrank();
            return elements[0];


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
