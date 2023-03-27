﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    internal class EqualityScale <T>
       where T : struct
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
            return left.Equals(right);
        }
      
    }
}