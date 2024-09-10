using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryOfLaba4_1;
using castlelib;

namespace ProjectOfSumMoney
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        SumOfMoney sumOfMoney = new SumOfMoney();
        Special special = new Special();
        Prime prime = new Prime();
        private void ButtonChoose_Click(object sender, RoutedEventArgs e)
        {
            Window1 w2 = Owner as Window1;

            TBMoney.Text = "";
            TBTerm.Text = "";
            TBPersent.Text = "";
            LabelPersent.Content = "";
            TBMoney.IsEnabled = true;
            ButtonTermSet.IsEnabled = true;
            ButttonPersent.IsEnabled = true;
            CBType.Items.Refresh();

            //дать доступ к дальнейшим дейсвиям со вкладом
            switch (CBType.SelectedIndex)
            {
                case 0:
                    if (w2.lstsumOfMoney.Count / 4 == 1)
                    {
                        TBMoney.Text = Convert.ToString(sumOfMoney.Money);
                        TBTerm.Text = Convert.ToString(sumOfMoney.Term);
                        TBPersent.Text = Convert.ToString(sumOfMoney.Persent());
                    }
                    break;

                case 1:
                    if (w2.lstspecial.Count / 4 == 1)
                    {
                        TBMoney.Text = Convert.ToString(special.Money);
                        TBTerm.Text = Convert.ToString(special.Term);
                        TBPersent.Text = Convert.ToString(special.Persent());
                    }
                    break;
                case 2:
                    if (w2.lstprime.Count / 4 == 1)
                    {
                        TBMoney.Text = Convert.ToString(prime.Money);
                        TBTerm.Text = Convert.ToString(prime.Term);
                        TBPersent.Text = Convert.ToString(prime.Persent());
                    }
                    break;
            }
        }

        private void ButttonTermSet_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = Owner as Window1;

            switch (CBType.SelectedIndex)
            {
                case 0:
                    sumOfMoney.Term = Convert.ToInt32(TBTerm.Text);
                    MessageBox.Show("Будет изменен статус вклада!");
                    w1.minimum1.Clear();
                    w1.minimum1.Add(Convert.ToInt32(TBTerm.Text));
                    TBPersent.Text = Convert.ToString(sumOfMoney.Persent());
                    break;

                case 1:
                    special.Term = Convert.ToInt32(TBTerm.Text);
                    MessageBox.Show("Будет изменен статус вклада!");
                    w1.minimum2.Clear();
                    w1.minimum2.Add(Convert.ToInt32(TBTerm.Text));
                    TBPersent.Text = Convert.ToString(special.Persent());
                    break;
                case 2:
                    prime.Term = Convert.ToInt32(TBTerm.Text);
                    MessageBox.Show("Будет изменен статус вклада!");
                    w1.minimum3.Clear();
                    w1.minimum3.Add(Convert.ToInt32(TBTerm.Text));
                    TBPersent.Text = Convert.ToString(prime.Persent());
                    break;
            }
        }

        private void ButtonUnite_Click(object sender, RoutedEventArgs e)

        {
            Window1 w1 = Owner as Window1;

            int cnt = 0;
            w1.lstgeneral.Clear();
            ListBox2.Items.Clear();

            if (w1.lstsumOfMoney.Count / 4 >= 1)
            {
                //TB1.Text = Convert.ToString(minimum1.Count);
                double b = 0;
                int c = 0;
                double d = 0;
                //подсчет общего для первого вклада
                foreach (object i in Enumerable.Range(0, w1.lstsumOfMoney.Count() / 4))
                {
                    b += Convert.ToDouble(w1.lstsumOfMoney[cnt + 1]);
                    cnt += 4;
                }
                int min = w1.minimum1[0];   //миним срок
                for (int k = 0; k < w1.minimum1.Count(); k++)
                {
                    if (w1.minimum1[k] < min)
                    {
                        min = w1.minimum1[k];
                    }
                }
                w1.minimum1.Clear();
                c = min;
                w1.minimum1.Add(c);
                sumOfMoney.Money = b;
                sumOfMoney.Term = c;
                d = Convert.ToDouble(sumOfMoney.Persent());
                w1.lstsumOfMoney.Clear();
                w1.lstsumOfMoney.Add(sumOfMoney.Name());
                w1.lstsumOfMoney.Add(b);
                w1.lstsumOfMoney.Add(c);
                w1.lstsumOfMoney.Add(d);
                cnt = 0;
                foreach (int i in Enumerable.Range(0, w1.lstsumOfMoney.Count() / 4))
                {
                    ListBox2.Items.Add("Вклад Первый " + " Cумма: " + b + " Срок: " + c + " Процент: " + d + "\n");
                }
                w1.lstgeneral.Add("Вклад Первый " + " Cумма: " + w1.lstsumOfMoney[cnt + 1] + " Срок: " + w1.lstsumOfMoney[cnt + 2] + " Процент: " + w1.lstsumOfMoney[cnt + 3] + "\n");
            }

            if (w1.lstspecial.Count / 5 >= 1)
            {

                double sp2 = 0;
                int sp3 = 0;
                double sp4 = 0;
                double sp5 = 0;
                //подсчет общего для особого вклада
                foreach (int i in Enumerable.Range(0, w1.lstspecial.Count() / 5))

                {
                    sp2 += Convert.ToDouble(w1.lstspecial[cnt + 1]);
                    cnt += 5;
                }
                int min = w1.minimum2[0];   //миним срок
                for (int k = 0; k < w1.minimum2.Count(); k++)
                {
                    if (w1.minimum2[k] < min)
                    {
                        min = w1.minimum2[k];
                    }
                }
                w1.minimum2.Clear();
                sp3 = min;
                w1.minimum2.Add(sp3);
                special.Money = sp2;
                special.Term = sp3;

                sp4 = Convert.ToDouble(special.Persent());
                sp5 = Convert.ToInt32(special.MinimumB());
                special.MoneyB = sp5;
               w1.lstspecial.Clear();
                w1.lstspecial.Add(special.Name());
                w1.lstspecial.Add(sp2);
                w1.lstspecial.Add(sp3);
                w1.lstspecial.Add(sp4);
                w1.lstspecial.Add(sp5);

                cnt = 0;
                foreach (int i in Enumerable.Range(0, w1.lstspecial.Count() / 5))
                {

                    ListBox2.Items.Add("Вклад Особый " + " Cумма: " + sp2 + " Срок: " + sp3 + " Процент: " + sp4 + "Н.О. " + sp5 + "\n");
                }
                w1.lstgeneral.Add("Вклад Особый " + " Cумма: " + sp2 + " Срок: " + sp3 + " Процент: " + sp4 + "Н.О. " + sp5 + "\n");

            }
            if (w1.lstprime.Count / 5 >= 1)
            {
                double pr2 = 0;
                int pr3 = 0;
                double pr4 = 0;
                double pr5 = 0;
                {
                    //подсчет общего для особого вклада
                    foreach (int i in Enumerable.Range(0, w1.lstprime.Count() / 5))
                    {
                        pr2 += Convert.ToDouble(w1.lstprime[cnt + 1]);
                        cnt += 5;
                    }
                    int min = w1.minimum3[0];
                    for (int k = 0; k < w1.minimum3.Count(); k++)
                    {
                        if (w1.minimum3[k] < min)
                        {
                            min = w1.minimum3[k];
                        }
                    }
                    w1.minimum3.Clear();
                    pr3 = min;
                    w1.minimum3.Add(pr3);
                    prime.Money = pr2;
                    prime.Term = pr3;
                    pr4 = Convert.ToDouble(prime.Persent());
                    pr5 = Convert.ToInt32(prime.MinimumCash());
                    prime.Cashback = pr5;
                    w1.lstprime.Clear();
                    w1.lstprime.Add(prime.Name());
                    w1.lstprime.Add(pr2);
                    w1.lstprime.Add(pr3);
                    w1.lstprime.Add(pr4);
                    w1.lstprime.Add(pr5);

                    cnt = 0;
                    foreach (int i in Enumerable.Range(0, w1.lstprime.Count() / 5))
                    {
                        ListBox2.Items.Add("Вклад Премьер " + " Cумма: " + pr2 + " Срок: " + pr3 + " Процент: " + pr4 + "Кэшбек " + pr5 + "\n");
                    }
                    w1.lstgeneral.Add("Вклад Премьер " + " Cумма: " + pr2 + " Срок: " + pr3 + " Процент: " + pr4 + "Кэшбек " + pr5 + "\n");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
