using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class EqualityScale<T>
        // where T : class
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            // Equals -> left == right (class)
            // Equals -> byte-to-byte (struct)
            return left.Equals(right);
        }
    }
}
