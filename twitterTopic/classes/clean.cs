using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace twitterTopic.classes
{
    public class clean
    {
        // Stemming 
        string[] Alphabet = { "ا", "ة", "ئ", "ي", "ت", "ى", "و", "أ", "إ", "م", "ن", "ل", "س", "ه" };
        double[] AlphabetWeight = { 5, 5, 3.5, 3.5, 3, 3, 3, 2, 2, 2, 2, 1, 1, 1 };
        string[] MyWordAlphabet;
        double[] MyWordAlphabetWeight;
        double[] MyWordAlphabetRank;
        double[] MyWordAlphabetProduct;
        double[,] RootProduct = new double[3, 2];


        // Stemming 
        public string GetRoot(string word)
        {
            // if length of word is less then 4 char return word without edit as root
            if (word.Length == 2 || word.Length == 3)
            {
                return word;
            }

            string Root = " ";

            this.MyWordAlphabet = new string[word.Length];
            this.MyWordAlphabetWeight = new double[word.Length];
            this.MyWordAlphabetRank = new double[word.Length];
            this.MyWordAlphabetProduct = new double[word.Length];

            // get Weight
            for (int i = 0; i < MyWordAlphabet.Length; i++)
            {
                MyWordAlphabet[i] = word[i].ToString();
                MyWordAlphabetWeight[i] = GetAlphabetWeight(MyWordAlphabet[i]);
            }
            // get Rank
            if (word.Length % 2 == 1)
            {
                Root = "Word is odd :";
                for (int position = 0; position < word.Length / 2; position++)
                {
                    MyWordAlphabetRank[position] = word.Length - position;
                }
                MyWordAlphabetRank[word.Length / 2] = word.Length / 2;
                int j = 1;
                for (int position = (word.Length / 2) + 1; position < word.Length; position++)
                {
                    MyWordAlphabetRank[position] = (word.Length / 2) + j++ - 0.5;
                }
            }
            else
            {
                Root = "Word is even :";
                for (int position = 0; position < word.Length / 2; position++)
                {
                    MyWordAlphabetRank[position] = word.Length - position;
                }
                int j = 1;
                for (int position = (word.Length / 2); position < word.Length; position++)
                {
                    MyWordAlphabetRank[position] = (word.Length / 2) + j++ - 0.5;
                }
            }
            // get Product
            for (int i = 0; i < MyWordAlphabet.Length; i++)
            {
                MyWordAlphabetProduct[i] = MyWordAlphabetRank[i] * MyWordAlphabetWeight[i];
            }
            //get root from Product
            RootProduct[0, 0] = 0;
            RootProduct[1, 0] = 1;
            RootProduct[2, 0] = 2;
            RootProduct[0, 1] = MyWordAlphabetProduct[0];
            RootProduct[1, 1] = MyWordAlphabetProduct[1];
            RootProduct[2, 1] = MyWordAlphabetProduct[2];
            for (int i = 3; i < word.Length; i++)
            {
                if (MyWordAlphabetProduct[i] < RootProduct[0, 1] || MyWordAlphabetProduct[i] < RootProduct[1, 1] || MyWordAlphabetProduct[i] < RootProduct[2, 1])
                {
                    if ((RootProduct[0, 1] > RootProduct[1, 1] && RootProduct[0, 1] > RootProduct[2, 1])/* && RootProduct[0, 1] < RootProduct[1, 1] && RootProduct[0, 1] < RootProduct[2, 1]*/)
                    {
                        RootProduct[0, 0] = i;
                        RootProduct[0, 1] = MyWordAlphabetProduct[i];
                    }
                    else if ((RootProduct[1, 1] > RootProduct[0, 1] && RootProduct[1, 1] > RootProduct[2, 1]))
                    {
                        RootProduct[1, 0] = i;
                        RootProduct[1, 1] = MyWordAlphabetProduct[i];
                    }
                    else //if (RootProduct[2, 1] > RootProduct[0, 1] && RootProduct[2, 1] > RootProduct[1, 1])
                    {
                        RootProduct[2, 0] = i;
                        RootProduct[2, 1] = MyWordAlphabetProduct[i];
                    }
                }
            }
            // Sort Root

            double Temp1;
            double Temp2;
            for (int i = 0; i < 3; i++)
            {
                if (RootProduct[0, 0] > RootProduct[1, 0])
                {
                    Temp1 = RootProduct[1, 0];
                    Temp2 = RootProduct[1, 1];
                    RootProduct[1, 0] = RootProduct[0, 0];
                    RootProduct[1, 1] = RootProduct[0, 1];
                    RootProduct[0, 0] = Temp1;
                    RootProduct[0, 1] = Temp2;
                }
                if (RootProduct[1, 0] > RootProduct[2, 0])
                {
                    Temp1 = RootProduct[2, 0];
                    Temp2 = RootProduct[2, 1];
                    RootProduct[2, 0] = RootProduct[1, 0];
                    RootProduct[2, 1] = RootProduct[1, 1];
                    RootProduct[1, 0] = Temp1;
                    RootProduct[1, 1] = Temp2;
                }
            }

            string MyRoot = MyWordAlphabet[Convert.ToInt32(RootProduct[0, 0])] + MyWordAlphabet[Convert.ToInt32(RootProduct[1, 0])] + MyWordAlphabet[Convert.ToInt32(RootProduct[2, 0])];
            //prnt
            Root = Root + "{";
            for (int i = 0; i < MyWordAlphabet.Length; i++)
            {
                Root = Root + "\n";
                Root = Root + " " + MyWordAlphabet[i] + " = " + MyWordAlphabetWeight[i].ToString() + " * " + MyWordAlphabetRank[i] + " = " + MyWordAlphabetProduct[i] + ",";

            }
            Root = Root + "}";
            Root = Root + "\n" + MyRoot;
            return MyRoot;
        }
        // Get Weight for one Alphabet from "AlphabetWeight" array
        double GetAlphabetWeight(string alphabet)
        {
            int index = -1;
            for (int i = 0; i < this.Alphabet.Length; i++)
            {
                if (alphabet.Equals(this.Alphabet[i]))
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                return this.AlphabetWeight[index];
            }
            else
            {
                return 0;
            }
        }


        //////////////////////////////////////
        //////////////////////////////////////
        ///////  khalid Remove Stop word  ////
        //////////////////////////////////////
        //////////////////////////////////////

        //// import stopword from file
        static string stopwordList;

        //// counter of number stopword removed
        static int intNumWordRmov = 0;

        public int getNumWordRmov() { return intNumWordRmov; }
        

        //!!!!!!!!!!!!!!!!!!!  ONLY CALL THIS FUNCTION  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //==============================================================================
        //######  START ###################### REMOVE STOPWORDS ########################
        public string stopwordsRemove(string strTXT)
        {
            intNumWordRmov = 0;

            //// read stopword.txt file
            stopwordList = File.ReadAllText("C:/Users/kal/Documents/GitHub/twitterTopic/twitterTopic/extra/stopword.txt");

            //// removing hash and http and non arabic word from input txt
            strTXT = hashRemove(strTXT);
            strTXT = httpRemove(strTXT);
            strTXT = removeNonArabic(strTXT);

            //// replising lines and spaces with # and split each word into array
            strTXT = strTXT.Replace(Environment.NewLine, "#");
            strTXT = strTXT.Replace(" ", "#");
            string[] arrIN = strTXT.Split('#');

            //// spliting stopword string inro array
            stopwordList = stopwordList.Replace(Environment.NewLine, "#");
            string[] arrLST = stopwordList.Split('#');

            //// comper each input with all stopword if equl removit and add 1 to counter
            for (int i = 0; i < arrIN.Length; i++)
            {
                for (int j = 0; j < arrLST.Length; j++)
                {
                    if (arrIN[i] == arrLST[j]) { arrIN[i] = ""; intNumWordRmov++; }
                }
            }

            //// join input array into out string with speace and return
            string strOUT = "";
            strOUT = string.Join(" ", arrIN);
            strOUT = Regex.Replace(strOUT, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            return strOUT;
        }
        //######  END ###################### REMOVE STOPWORDS ########################
        //============================================================================
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



        //############################ REMOVE HASH ##############################
        static string hashRemove(string strIN)
        {
            strIN = strIN.Replace(Environment.NewLine, " ");
            string[] arrIN = strIN.Split(' ');

            for (int i = 0; i < arrIN.Length; i++)
            {
                if (arrIN[i].StartsWith("#")) { arrIN[i] = ""; }
            }


            string strOUT = "";
            strOUT = string.Join(" ", arrIN);
            return strOUT;
        }




        //############################ REMOVE HTTP ##############################
        static string httpRemove(string strIN)
        {
            strIN = strIN.Replace(Environment.NewLine, " ");
            string[] arrIN = strIN.Split(' ');

            for (int i = 0; i < arrIN.Length; i++)
            {
                if (arrIN[i].StartsWith("http://")) { arrIN[i] = ""; }
            }


            string strOUT = "";
            strOUT = string.Join(" ", arrIN);
            return strOUT;
        }




        //############################ REMOVE NONE ARABIC ########################
        static string removeNonArabic(string strIN)
        {

            strIN = strIN.Replace(" ", "#");
            strIN = strIN.Replace(Environment.NewLine, "#");
            string strArabicChrcts = "ءاأإآىئؤبتةثجحخدذرزسشصضطظعغفقكلمنهوي";

            // convert strIN to array char
            char[] buffer = strIN.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                //char letter = buffer[i];
                if (!(buffer[i] == '#'))
                {
                    if (!(strArabicChrcts.Contains(buffer[i])))
                    {
                        buffer[i] = '&';
                    }
                }

            }


            //removing 
            // buffer = buffer.Except('&');

            string strOUT = new string(buffer);
            strOUT = strOUT.Replace("&", "");
            strOUT = strOUT.Replace("#", Environment.NewLine);
            // strIN = strIN.Replace("%", Environment.NewLine);
            return strOUT;

        }



    }
}