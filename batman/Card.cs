using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batman
{
    class Card
    {
        public Card(string a, string b, string c, string d, int n)
        {
            values[0] = a;
            values[1] = b;
            values[2] = c;
            values[3] = d;
            card_number = n;
        }
        public string[] values = new string[4];

        public void rotate()
        {
            string[] temp = new string[4];
            temp[0] = values[0];
            temp[1] = values[1];
            temp[2] = values[2];
            temp[3] = values[3];
            values[0] = temp[3];
            values[1] = temp[0];
            values[2] = temp[1];
            values[3] = temp[2];
        }
        public int card_number
        {
            get;
            set;
        }
        public string convertString(string str)
        {
            if(str=="1a")
            {
                return "Momma";
            }
            if (str == "1b")
            {
                return "Baby";
            }
            if (str == "2a")
            {
                return "Fish";
            }
            if (str == "2b")
            {
                return "Fish Wing";
            }
            if (str == "3a")
            {
                return "Black";
            }
            if (str == "3b")
            {
                return "Black Wing";
            }
            if (str == "4a")
            {
                return "Tongue";
            }
            if (str == "4b")
            {
                return "Tongue Legs";
            }
            return str;
        }

        public void Print()
        {
            Console.Write("| left:" + convertString(values[0]) + ", top:" + convertString(values[3]) + " number: "+card_number+" |");
        }
    }
}
