using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class Mytuple <Item1, Item2>
    {
        
        public Mytuple(Item1 item1, Item2 item2)
        {
            Left = item1;
            Right = item2;



        }

        public Item1 Left { get; set; }
        public Item2 Right { get; set; }

        public string GetItem()
        {
            return $"{Left} -> {Right}";
        }
    }
}
