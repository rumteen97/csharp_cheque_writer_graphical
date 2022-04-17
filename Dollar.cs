namespace cheque_writer_graphical
{
    class Dollar
    {
        static string[] one = new string[10] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] teen = new string[10] { "", "eleven", "twelve", "thirteen", "forteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] ten = new string[10] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "senety", "eighty", "ninety" };
        static string[] hundred = new string[10] { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred",
            "seven hundred", "eight hundred", "nine hundred" };
        static string[] values = new string[8] { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sixtillion" };
        //******************************************************************
        static string OneTothree(string[] num)
        {

            string num_word = "";
            string x = num[0];

            if (x.Length == 3)
            {
                int number3 = (int)char.GetNumericValue(x[0]);
                int number2 = (int)char.GetNumericValue(x[1]);
                int number1 = (int)char.GetNumericValue(x[2]);

                if (number3 == 0 & number2 == 0)
                {
                    num_word = one[number1];
                }
                else if (number2 == 1 & number1 == 0)
                {
                    num_word = hundred[number3] + " and ten";
                }
                else if (number2 == 0 & number1 == 0)
                {
                    num_word = hundred[number3];
                }
                else if (number2 == 0)
                {
                    num_word = hundred[number3] + " and " + one[number1];
                }
                else if (number2 == 1)
                {
                    num_word = hundred[number3] + " and " + teen[number1];
                }
                else if (number1 == 0)
                {
                    num_word = hundred[number3] + " and " + ten[number2];
                }

                else
                {
                    num_word = hundred[number3] + " and " + ten[number2] + " " + one[number1];
                }
            }

            else if (x.Length == 2)
            {
                int number2 = (int)char.GetNumericValue(x[0]);
                int number1 = (int)char.GetNumericValue(x[1]);


                if (number2 == 1 & number1 == 0)
                {
                    num_word = "ten";
                }
                else if (number2 == 0)
                {
                    num_word = one[number1];
                }
                else if (number2 == 1)
                {
                    num_word = teen[number1];
                }
                else if (number1 == 0)
                {
                    num_word = ten[number2];
                }
                else
                {
                    num_word = ten[number2] + " " + one[number1];
                }
            }
            else if (x.Length == 1)
            {
                int number1 = (int)char.GetNumericValue(x[0]);
                num_word = one[number1];
            }
            return num_word;
        }
        //***************************************************************
        //**************************************
        public static string Write(string[] num)
        {
            string num_word = "";
            if (num.Length == 1)
            {
                num_word = OneTothree(num);
            }
            else
            {
                for (int i = num.Length - 1; i >= 0; i--)
                {
                    num_word = num_word + " " + OneTothree(new[] { num[i] }) + " " + values[i] + " and ";
                    if ((num.Length >= 3) & (num[i] == "000") & (values[i].Length >= 1))
                    {
                        num_word = num_word.Remove(num_word.Length - (values[i].Length + 6));
                    }
                }
                num_word = num_word.TrimEnd();


                while (num_word.EndsWith(" and"))
                {
                    num_word = num_word.Substring(0, num_word.Length - 4);
                    num_word = num_word.TrimEnd();

                }


            }

            return num_word;
        }




        //***********************************************************
        public static string NumToArray(string x)
        {
            int length = x.Length;
            string[] num = new string[] { };

            if (length % 3 == 0)
            {
                num = new string[length / 3];
                int counter = length / 3;
                for (int i = 0; i < counter; i -= -1)
                {

                    string tmp = x.Substring(x.Length - 3, 3);
                    num[i] = tmp;
                    x = x.Remove(x.Length - 3);
                }
            }
            else if (length % 3 == 1)
            {
                num = new string[(length / 3) + 1];
                int counter = (length / 3) + 1;
                num[counter - 1] = x.Substring(0, 1);
                x = x.Remove(0, 1);
                for (int i = 0; i < counter - 1; i -= -1)
                {

                    string tmp = x.Substring((x.Length - 3), 3);
                    num[i] = tmp;
                    x = x.Remove(x.Length - 3, 3);
                }
            }
            else if (length % 3 == 2)
            {
                num = new string[(length / 3) + 1];
                int counter = (length / 3) + 1;
                num[counter - 1] = x.Substring(0, 2);
                x = x.Remove(0, 2);
                for (int i = 0; i < counter - 1; i -= -1)
                {

                    string tmp = x.Substring(x.Length - 3, 3);
                    num[i] = tmp;
                    x = x.Remove(x.Length - 3, 3);
                }

            }


            Write(num);

            return (Write(num));
        }
        //***********************************************************************************
    }
}