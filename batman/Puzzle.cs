using System;

namespace batman
{
    internal class Puzzle
    {
        public Card[] spots = new Card[9];
        public int active_index
        {
            get;set;
        }
        public void Print()
        {
            for (int i =0; i< 9; i++)
            {
                if (spots[i] == null)
                {
                    Console.Write("| empty |");
                }
                else
                {
                    spots[i].Print();
                }
                if ((i + 1)%3 ==0)
                {
                    Console.WriteLine("\n");
                }
            }
        }
    }
}