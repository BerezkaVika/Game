using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfLaba4_1
{
    public class SumOfMoney
    {
        protected double money; //денежный вклад
        protected double persent; //процент по вкладу;
        protected int term;  //срок вклада



        //List<string> letsumOfMoney = new List<string>();
        //protected List<string> letspecial = new List<string>();
        //protected List<string> letprime = new List<string>();
        ////protected List<char> ListResult = new List<char>();


        //protected List<object> lstsumOfMoney = new List<object>();  //создание списка
        //protected List<object> lstspecial = new List<object>();  //создание списка
        //protected List<object> lstprime = new List<object>();  //создание списка
        //protected List<string> lstgeneral = new List<string>();  //создание списка
        //protected List<int> minimum1 = new List<int>();  //список минимального срока
        //protected List<int> minimum2 = new List<int>();  //список минимального срока
        //protected List<int> minimum3 = new List<int>();  //список минимального срока


        public virtual string Name()
        {
            return "Первый ";
        }
        public int Term
        {
            get { return term; }
            
            set
            {
                term = value;
            }
        }
        public double Money
        {
            get { return money; }
            set
            {
                money = Math.Round(value, 2);
            }
        }
        /// <summary>
        /// Метод вычисляющий процент взависимости от срока
        /// </summary>
        /// <returns></returns>
        public double Persent()
        {
            if (money < 10000)
            {
                if (term == 1)
                    return persent = 2.5;
                else if (term == 2)
                    return persent = 3.5;
                else if (term >= 3 && term < 6)
                    return persent = 4;
                else if (term >= 6 && term < 12)
                    return persent = 5.7;
                else if (term >= 12 && term < 24)
                    return persent = 8;
                else if (term >= 24 && term <= 36)
                    return persent = 10;
            }

            if (money >= 10000)
            {

                if (term == 1)
                    return persent = 12;
                else if (term == 2)
                    return persent = 14;
                else if (term >= 3 && term < 6)
                    return persent = 16;
                else if (term >= 6 && term < 12)
                    return persent = 18;
                else if (term >= 12 && term < 24)
                    return persent = 20;
                else if (term >= 24 && term <= 36)
                    return persent = 25;
            }


                return persent = 0;
        }
        /// <summary>
        /// метод начисления процента
        /// </summary>
        /// <returns></returns>
        public double CalculatingThePercentage()
        {

            return money += money * persent / 100;
        }
        /// <summary>
        /// Метод начисления указанной суммы1
        /// </summary>
        /// <param name="np1">Сумма начисления1</param>
        /// <returns></returns>
        public double PlusSum(double np1)
        {
            return money += np1;
        }
        public virtual double MinusSum(double m)
        {

            return money -= m;

        }

        //public void LetSumOfMoney(string s)
        //{
        //    letsumOfMoney.Add(s);

        //}

        //public void LstSumOfMoney(string s)
        //{
        //    lstsumOfMoney.Add(s);
        //}

        ////public void ListResultAdd(string s)
        ////{
        ////    ListResult.Add(s);

        ////}
        //public void Minimum1Add(int num)
        //{
        //    minimum2.Add(num);
        //}

        //public void Minimum1Clear(int num)
        //{
        //    minimum1.Clear();
        //}

        //public bool LstSunOfMoneyCount()
        //{
        //    if (lstsumOfMoney.Count / 4 == 1)
        //        return true;
        //    else return false;
        //}
    }
    public class Special : SumOfMoney
    {
        double moneyB;  //размер неснимаемого остатка
        List<double> minimumB = new List<double>();

   
        public double MoneyB
        {
            get { return moneyB; }
            set
            {
                minimumB.Add(value);
                moneyB = value;

            }
        }
        public override string Name()
        {
            return "Особый ";
        }
        /// <summary>
        /// Метод снятия указанной суммы, учитывая неснижаемый остаток
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override double MinusSum(double m)
        {
            return money -= Math.Min(money - moneyB, m);
        }
    
    public  double MinimumB()
        {
            double minValue = minimumB[0];
            for (int k = 0; k < minimumB.Count(); k++)
            {
                if (minimumB[k] < minValue)
                {
                    minValue = minimumB[k];
                }
            }
            minimumB.Clear();
            return minValue;
        }

        //public void LetSpecial(string s)
        //{
        //    letspecial.Add(s);

        //}

        //public void LstPrime(string s)
        //{
        //    lstprime.Add(s);
        //}

        //public void Minimum2Add(int num)
        //{
        //    minimum2.Add(num);
        //}

        //public void Minimum2Clear(int num)
        //{
        //    minimum2.Clear();
        //}

        //public bool LstSpecialCount()
        //{
        //    if (lstspecial.Count / 4 == 1)
        //        return true;
        //    else return false;
        //}
    }
    public class Prime : SumOfMoney
    {
        double cashback;  //размер кэшбека (от снимаемой суммы в %)
        List<double> minimumCash = new List<double>();

        public double Cashback
        {
            get { return cashback; }
            set
            {
                cashback = value;
                minimumCash.Add(cashback);
            }
        }

        public double Return_Cashback(double m)
        {
            return m * cashback / 100;
        }

        public override string Name()
        {
            return "Премьер ";
        }
        /// <summary>
        /// Информация об истории снятия вклада "Премьер"
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>

        public override double MinusSum(double m)
        {
            return money -= (m - Return_Cashback (m));
        }

        public double MinimumCash()
        {
            double minValue = minimumCash[0];
            // double number = term;
            for (int k = 0; k < minimumCash.Count(); k++)
            {
                if (minimumCash[k] < minValue)
                {
                    minValue = minimumCash[k];
                }
            }
            minimumCash.RemoveRange(0, minimumCash.Count);
            return minValue;
        }

        //public void LetPrime(string s)
        //{
        //    letprime.Add(s);
        //}

        //public void LstSpecial(string s)
        //{
        //    lstspecial.Add(s);
        //}

        //public void Minimum3Add(int num)
        //{
        //    minimum3.Add(num);
        //}

        //public void Minimum3Clear(int num)
        //{
        //    minimum3.Clear();
        //}

        //public bool LstPrimeCount()
        //{
        //    if (lstprime.Count / 4 == 1)
        //        return true;
        //    else return false;
        //}
    }


}
