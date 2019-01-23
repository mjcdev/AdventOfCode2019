using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Nine
{
    public static class LinkedListNodeExtensions
    {
        public static LinkedListNode<T> MoveNextNode<T>(this LinkedListNode<T> node)
        {
            return node.Next ?? node.List.First;
        }

        public static LinkedListNode<T> MovePreviousNode<T>(this LinkedListNode<T> node)
        {
            return node.Previous ?? node.List.Last;
        }
    }
}
