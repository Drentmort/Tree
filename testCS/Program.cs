using System;

namespace testCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(8);
            int[] arr = { 5, 12, 2, 6, 15, 24, 21, 54, 11, 1, 36 };
            tree.AddByArr(arr);
            tree.Print();
        }
    }
}
