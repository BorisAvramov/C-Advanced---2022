using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {

        private int curruntIndex;

        private readonly List<Book> books;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => books[curruntIndex];

        object IEnumerator.Current => Current;

       

        public bool MoveNext() 
        {
            curruntIndex++;
            return curruntIndex < books.Count;
        }

        public void Reset()
        {
            curruntIndex = -1;
        }
        public void Dispose()
        {
        }
    }
}
