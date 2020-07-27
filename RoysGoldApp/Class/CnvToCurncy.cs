using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RoysGold
{

    public class CnvToCurncy
    {
        System.Collections.Hashtable AmountHT = new System.Collections.Hashtable();
        int _count = 0;



        public CnvToCurncy()
        {
            //AmountHT.Add("0", "Zero");
            AmountHT.Add("1", "One");
            AmountHT.Add("2", "Two");
            AmountHT.Add("3", "Three");
            AmountHT.Add("4", "Four");
            AmountHT.Add("5", "Five");
            AmountHT.Add("6", "Six");
            AmountHT.Add("7", "Seven");
            AmountHT.Add("8", "Eight");
            AmountHT.Add("9", "Nine");
            AmountHT.Add("10", "Ten");
            AmountHT.Add("11", "Eleven");
            AmountHT.Add("12", "Twelve");
            AmountHT.Add("13", "Thirteen");
            AmountHT.Add("14", "Fourteen");
            AmountHT.Add("15", "Fifteen");
            AmountHT.Add("16", "Sixteen");
            AmountHT.Add("17", "Seventeen");
            AmountHT.Add("18", "Eighteen");
            AmountHT.Add("19", "Nineteen");
            AmountHT.Add("20", "Twenty");
            AmountHT.Add("30", "Thirty");
            AmountHT.Add("40", "Forty");
            AmountHT.Add("50", "Fifty");
            AmountHT.Add("60", "Sixty");
            AmountHT.Add("70", "Seventy");
            AmountHT.Add("80", "Eighty");
            AmountHT.Add("90", "Ninety");  
        }

        public string get(double TotalAmount)
        {
            System.Collections.Hashtable FigHT = new System.Collections.Hashtable();


            FigHT.Add(0, "Rupees");
            FigHT.Add(1, "Hundred");
            FigHT.Add(2, "Thousand");
            FigHT.Add(3, "Lakh");
            FigHT.Add(4, "Crore");

            String Words = string.Empty;
            String amount = TotalAmount.ToString();

            if (amount != string.Empty)
            {
                decimal rs = Math.Truncate(System.Convert.ToDecimal(amount));
                string ps = (((System.Convert.ToDecimal(amount)).ToString("F2")).Split('.')[1]).ToString();
                amount = rs.ToString();

                int wdLength = amount.Length;
                if (wdLength > 2)
                {

                    for (int i = 0; i < amount.Length; i++)
                    {

                        if (wdLength == 0)
                            break;



                        if (i == 0)
                        {
                            String temWrd = amount.Substring(amount.Length - 3, 3);
                            String frstLtr = temWrd.Substring(0, 1);
                            String secLtr = temWrd.Substring(1, 2);


                            String wd = CnvToStr(AmountHT[frstLtr]);
                            if (wd != string.Empty)
                                Words = CnvToStr(AmountHT[frstLtr]) + " hundred ";


                            wd = this.getLetter(secLtr);
                            if (wd != string.Empty)
                                Words += " AND " + wd;

                            wdLength -= 3;

                            _count = 2;
                        }
                        else
                        {
                            String temWrd = string.Empty;
                            if (wdLength == 1)
                            {
                                temWrd = amount.Substring(wdLength - 1, 1);
                                wdLength -= 1;
                            }
                            else
                            {
                                temWrd = amount.Substring(wdLength - 2, 2);
                                wdLength -= 2;
                            }


                            String wd = this.getLetter(temWrd);
                            if (wd != string.Empty)
                                Words = wd + " " + CnvToStr(FigHT[_count]) + " " + Words;


                            _count++;

                        }


                    }
                }
                else
                    Words = CnvToStr(this.getLetter(TotalAmount.ToString()));


                amount = ps;
                if (PLABS.Utils.CnvToDouble(ps) == 0)
                {
                    Words += " Rs";
                }
                else 
                {
                    Words += " Rs And " + CnvToStr(getLetter(amount)) + " Ps.";
                }
             

            }


            return Words.ToString();
        } 
        private string getLetter(string secLtr)
        {


            String word = string.Empty;
            int temWord = CnvToInt(secLtr);


            if (temWord > 20)
            {

                String firstLtr = secLtr.Substring(0, 1);
                String SecLtr = secLtr.Substring(1, 1);


                word = CnvToStr(AmountHT[firstLtr + "0"]) + " ";
                word += CnvToStr(AmountHT[SecLtr]);

            }
            else
            {
                return CnvToStr(AmountHT[temWord.ToString()]);
            }


            return word;
        }

        public string CnvToStr(object Data)
        {
            try
            {
                return Data.ToString();
            }
            catch
            {
                return "";
            }
        }
        public Int32 CnvToInt(object Data)
        {
            try
            {
                return System.Convert.ToInt32(Data);
            }
            catch
            {
                return 0;
            }
        }
    }
}

