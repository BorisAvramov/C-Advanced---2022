using System;

namespace CustomList
{
    public class CustomList
    {

        private const int initialCapacity = 2;
        private int[] elements;
        private int internalCounter;


        public CustomList()
        {
            elements = new int[initialCapacity];
            internalCounter = 0;
        }

        

        public int Count => internalCounter;

        //public int Count
        //{
        //    get { return iternalCounter; }
        //}

        public int this[int index]
        {
            get
            {
                EnsureIsInRange(index);

                return elements[index];
            }

            set 
            {
                EnsureIsInRange(index);
                

                elements[index] = value;
            }


        }

        public void Insert(int index, int element)
        {
            EnsureIsInRange(index);

            ReSize();
            //1 2 3 4
                 
            int elementAtIndex = elements[index];

            internalCounter++;
            //1 6 2 3 4
                    
            int[] newArr = new int[internalCounter];

            for (int i = 0; i < internalCounter; i++)
            {
                if (i == index)
                {
                    newArr[i] = element;
                }
                else if (i == 0)
                {
                    newArr[i] = elements[i];
                }
                else
                {
                    newArr[i] = elements[i - 1];
                }
            }
            elements = newArr;
            Shrink();



        }


        public void Shrink() 
        {

            int[] newArr = new int[internalCounter];

            for (int i = 0; i < internalCounter; i++)
            {
                newArr[i] = elements[i];
            }

            elements = newArr;
        }

        public int RemoveAt(int index)
        {

            EnsureIsInRange(index);
            //123

            var element = elements[index];
            //103
            elements[index] = 0;

            internalCounter--;

            for (int i = index; i < internalCounter; i++)
            {
                elements[i] = elements[i + 1];
            }

            Shrink();

            return element;

        }

        internal void Swap(int firstIndex, int secondIndex)
        {
            EnsureIsInRange(firstIndex);
            EnsureIsInRange(secondIndex);

            var firstElement = elements[firstIndex];

            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;

  
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (element == elements[i])
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(int element)
        {
            ReSize();

            elements[internalCounter] = element;

            internalCounter++;

            Shrink();


        }

        private void ReSize()
        {
            if (internalCounter == elements.Length)
            {
                int[] copyArr = new int[elements.Length * 2];


                for (int i = 0; i < elements.Length; i++)
                {
                    copyArr[i] = elements[i];
                }

                elements = copyArr;
            }
        }

        private void EnsureIsInRange(int index)
        {
            if (index < 0 || index >= internalCounter)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

}