using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batman
{
    class Program
    {
        public static List<Puzzle> solutions = new List<Puzzle>();
        public static int i = 0;
        static void Main(string[] args)
        {
            Random rnd = new Random();
            while (true)
            {
                
                List<Card> card = IntializeCards();
                card = Shuffle(card);
                int i = rnd.Next(1, 4);
                for (int j = 0; j < i; j++)
                {
                    card.First().rotate();
                }
                Puzzle p = new Puzzle();
                batmanSolver(p, card);
            }
            //batmanSolver(p, Shuffle(card));
            Console.WriteLine("done");
        }

        private static List<Card> IntializeCards()
        {
            List<Card> results = new List<Card>();
            results.Add(new Card("3a", "1a", "3b", "4b",1));
            results.Add(new Card("3a", "2a", "1b", "3b", 2));
            results.Add(new Card("4a", "1a", "3b", "2b", 3));
            results.Add(new Card("1b", "3b", "2b", "4a", 4));
            results.Add(new Card("4b", "2b", "1b", "4b", 5));
            results.Add(new Card("1a", "4b", "2a", "3a", 6));
            results.Add(new Card("4b", "1b", "2b", "2b", 7));
            results.Add(new Card("4b", "1a", "3a", "2a", 8));
            results.Add(new Card("3b", "1a", "4a", "2b", 9));
            return results;
        }

        private static bool batmanSolver(Puzzle p, List<Card> cards)
        {    
            //i++;
            //Console.WriteLine("i = "+i);
            foreach(Card c in cards.ToList())
            {
                int rotate_counter = 0;
                while (rotate_counter < 4)
                {
                    if (isValid(c, p))
                    {
                        p.spots[p.active_index] = c;
                        cards.Remove(c);
                        p.active_index++;
                        if (cards.Count == 0 && WholePuzzleValid(p))
                        {
                            solutions.Add(p);
                            Console.WriteLine("------------SOLUTION LIST-----------");
                            int f = 0;
                            foreach (Puzzle pu in solutions.Distinct().ToList())
                            {
                                f++;
                                Console.WriteLine("#####   Solution "+ f +"  ######");
                                pu.Print();
                                Console.WriteLine("");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            return true;
                        }
                        if (batmanSolver(p, cards))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        c.rotate();
                        rotate_counter++;
                    }
                    //card failed, try next card.
                }
            }
            return false; 
        }

        private static bool isValid(Card c, Puzzle p)
        {
            if (p.active_index == 0 )
            {
                return true;
            }
            else if (p.active_index == 1)
            {
                if (batEquals(c.values[0], p.spots[0].values[2]))
                { 
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 2)
            {
                if (batEquals(c.values[0], p.spots[1].values[2]))
                {
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 3)
            {
                if (batEquals(c.values[3] , p.spots[0].values[1]))
                {
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 4)
            {
                if (batEquals(c.values[3] , p.spots[1].values[1]) && batEquals(c.values[0] , p.spots[3].values[2]))
                {
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 5)
            {
                if (batEquals(c.values[3] , p.spots[2].values[1]) && batEquals(c.values[0] , p.spots[4].values[2]))
                {
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 6)
            {
                if (batEquals(c.values[3] , p.spots[3].values[1]))
                {
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 7)
            {
                if (batEquals(c.values[3] , p.spots[4].values[1]) && batEquals(c.values[0] , p.spots[6].values[2]))
                {
                    return true;
                }
                else return false;
            }
            else if (p.active_index == 8)
            {
                if (batEquals(c.values[3] , p.spots[5].values[1]) && batEquals(c.values[0] , p.spots[7].values[2]))
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        private static bool WholePuzzleValid(Puzzle p)
        {
            for(int i=0; i< 9; i++)
            {
                p.active_index = i;
                if(!isValid(p.spots[i],p))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool batEquals(string s1, string s2)
        {
            if(s1[0] == s2[0])
            {
                if(s1[1]!= s2[1])
                {
                    return true;
                }
            }
            return false;
        }
        private static List<Card> ShiftLeft(List<Card> list, int shiftBy)
        {
            if (list.Count <= shiftBy)
            {
                return list;
            }

            var result = list.GetRange(shiftBy, list.Count - shiftBy);
            result.AddRange(list.GetRange(0, shiftBy));
            return result;
        }

        private static List<Card> Shuffle(List<Card> list)
        {
            List<Card> result = new List<Card>();
            var rnd = new Random();
            result = list.OrderBy(item => rnd.Next()).ToList();
            return result;
        }

    }
}
