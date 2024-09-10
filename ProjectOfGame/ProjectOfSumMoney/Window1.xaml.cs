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
using LibraryOfLaba4_1;
using castlelib;


namespace ProjectOfSumMoney
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
       public List<object> lstsumOfMoney = new List<object>();  //создание списка
        public List<object> lstspecial = new List<object>();  //создание списка
        public List<object> lstprime = new List<object>();  //создание списка
        public List<string> lstgeneral = new List<string>();  //создание списка
        public List<int> minimum1 = new List<int>();  //список минимального срока
        public List<int> minimum2 = new List<int>();  //список минимального срока
        public List<int> minimum3 = new List<int>();  //список минимального срока

        
        Window3 MonastBank = new Window3();
        
        

        public SumOfMoney sumOfMoney = new SumOfMoney();
        public Special special = new Special();
        public Prime prime = new Prime();
        int cnt = 0;

        private void ButtonOpen1_Click(object sender, RoutedEventArgs e)
        {
          
            switch (CBType1.SelectedIndex)
            {

                case 0:
                    if (TBMoney1.Text == "" || (CBTerm1.Text == ""))
                    {
                        MessageBox.Show("Не хватает данных!");
                    }
                    else
                    {
                        //ввод данных инициализация полей класс
                        sumOfMoney.Money = Convert.ToDouble(TBMoney1.Text);
                        // CBTerm.Items.Refresh();
                        sumOfMoney.Term = Convert.ToInt32(CBTerm1.Text);                  //SOM1
                        TBPersent1.Text = Convert.ToString(sumOfMoney.Persent());
                        TBCondition1.IsEnabled = false;
                        ButtonTermSet1.IsEnabled = true;
                        TBMoney1.IsEnabled = false;
                        ButttonOperation1.IsEnabled = true;
                        ButtonAdd.IsEnabled = true;
                        ButtonOpen1.IsEnabled = false;
                        TBCount1.IsEnabled = true;
                        CBOperation1.IsEnabled = true;

                    }
                    break;

                case 1:
                    if (TBMoney1.Text == "" || (TBCondition1.Text == "") || (CBTerm1.Text == ""))
                    {
                        MessageBox.Show("Не хватает данных!");
                    }
                    else
                    {
                        //ввод данных инициализация полей класса
                        special.Money = Convert.ToDouble(TBMoney1.Text);
                        //  CBTerm.Items.Refresh();
                        special.Term = Convert.ToInt32(CBTerm1.Text);             //Sp1
                        TBPersent1.Text = Convert.ToString(special.Persent());
                        special.MoneyB = Convert.ToDouble(TBCondition1.Text);

                        TBCondition1.IsEnabled = false;
                        ButtonTermSet1.IsEnabled = true;
                        TBMoney1.IsEnabled = false;
                        ButttonOperation1.IsEnabled = true;
                        ButtonAdd.IsEnabled = true;
                        TBCount1.IsEnabled = true;
                        ButtonOpen1.IsEnabled = false;
                        CBOperation1.IsEnabled = true;

                    }
                    break;

                case 2:
                    if (TBMoney1.Text == "" || (TBCondition1.Text == "") || (CBTerm1.Text == ""))
                    {
                        MessageBox.Show("Не хватает данных!");
                    }
                    else
                    {
                        //ввод данных инициализация полей класса
                        prime.Money = Convert.ToDouble(TBMoney1.Text);
                        //    CBTerm.Items.Refresh();
                        prime.Term = Convert.ToInt32(CBTerm1.Text);
                        TBPersent1.Text = Convert.ToString(prime.Persent());
                        prime.Cashback = Convert.ToDouble(TBCondition1.Text);
                        ButttonOperation1.IsEnabled = true;
                        ButtonTermSet1.IsEnabled = true;
                        TBMoney1.IsEnabled = false;
                        ButtonAdd.IsEnabled = true;
                        ButtonOpen1.IsEnabled = false;
                        TBCount1.IsEnabled = true;
                        CBOperation1.IsEnabled = true;
                    }
                    break;
            }
        }
        private void ButtonType_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow w = Owner as MainWindow;
            TBMoney1.Text = "";
            TBCondition1.Text = "";
            CBTerm1.Text = "";
            TBPersent1.Text = "";

            ButttonOperation1.IsEnabled = false;
            ButtonTermSet1.IsEnabled = false;
            ButtonAdd.IsEnabled = false;

            List<string> letsumOfMoney = new List<string>();
            List<string> letspecial = new List<string>();
            List<string> letprime = new List<string>();
            List<char> ListResult = new List<char>();

            string alphabet1 = "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            string alphabet2 = "йцукенгшщзхъфывапролджэячсмитьбюёЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ\"- ";
            string tb = TB.Text;
            for (int i = 0; i < tb.Length; i++)
            {
                for (int k = 0; k < alphabet1.Length; k++)
                {
                    if (tb[i] == alphabet1[k])
                    {
                        ListResult.Add(tb[i]);
                        TBMoney1.IsEnabled = true;
                        CBType1.SelectedIndex = 0;
                        ButtonOpen1.IsEnabled = true;
                        TBlock1.Text = "";
                        //TBCondition1.Visibility = 0;
                        TBCondition1.IsEnabled = false;
                        ButtonOpen1.IsEnabled = true;
                        TBMoney1.IsEnabled = true;
                        CBTerm1.IsEnabled = true;
                        break;
                    }
                }
            }
            letsumOfMoney.Add(Convert.ToString(tb)); ;


            if (ListResult.Count != tb.Length)
            {
                letsumOfMoney.Clear();
                ListResult.Clear();
                string sample2 = "Особый \"";
                if (Convert.ToString(tb.Last()) == "\"" && tb.Length >= 9)
                {
                    for (int l = 0; l < tb.Count() - (tb.Count() - sample2.Length); l++)
                    {
                        if (tb[l] == sample2[l])
                            ListResult.Add(tb[l]);
                    }
                    for (int i = 8; i < tb.Length; i++)
                    {
                        for (int k = 0; k < alphabet2.Length; k++)
                        {
                            if (tb[i] == alphabet2[k])
                            {
                                ListResult.Add(tb[i]);
                                TBMoney1.IsEnabled = true;
                                CBType1.SelectedIndex = 1;
                                ButtonOpen1.IsEnabled = true;
                                TBlock1.Text = "Установите размер неснимаемого остатка";
                                TBCondition1.Text = "";
                                TBCondition1.IsEnabled = true;
                                ButtonOpen1.IsEnabled = true;
                                TBMoney1.IsEnabled = true;
                                CBTerm1.IsEnabled = true;
                                break;
                            }
                        }
                    }
                    letspecial.Add(Convert.ToString(tb));
                }
            }

            if (ListResult.Count != tb.Length && tb.Length >= 9)
            {
                letspecial.Clear();
                ListResult.Clear();
                string sample3 = "-Премьер";
                int s = 0;

                for (int i = 0; i < tb.Length - 8; i++)
                {
                    for (int k = 0; k < alphabet2.Length; k++)
                    {
                        if (tb[i] == alphabet2[k])
                        {
                            ListResult.Add(tb[i]);
                            TBMoney1.IsEnabled = true;
                            ButtonOpen1.IsEnabled = true;
                            CBType1.SelectedIndex = 2;
                            TBlock1.Text = "Установите размер кэшбека";
                            TBCondition1.IsEnabled = true;
                            ButtonOpen1.IsEnabled = true;
                            TBMoney1.IsEnabled = true;
                            CBTerm1.IsEnabled = true;
                            TBCondition1.Text = "";
                            break;
                        }
                    }
                }
                for (int i = tb.Count() - sample3.Count(); i < tb.Count(); i++)
                {
                    if (tb[i] == sample3[s])
                        ListResult.Add(tb[i]);
                    s++;
                }

                letprime.Add(Convert.ToString(tb));
            }

            if (ListResult.Count != tb.Length)
            {
                letprime.Clear();
                ListResult.Clear();
                TBMoney1.IsEnabled = false;
                TBCondition1.IsEnabled = false;
                ButtonOpen1.IsEnabled = false;
                CBType1.SelectedIndex = -1;
                MessageBox.Show("Формат вклада неверен!");
            }
        }



        private void ButttonOperation1_Click(object sender, RoutedEventArgs e)
        {

            switch (CBOperation1.SelectedIndex)
            {
                case 0:
                    switch (CBType1.SelectedIndex)
                    {
                        case 0:
                            double m = Convert.ToDouble(TBCount1.Text);
                            LabelResult1.Content = sumOfMoney.PlusSum(m);
                            TBMoney1.Text = Convert.ToString(sumOfMoney.Money);
                            break;
                        case 1:
                            double n = Convert.ToDouble(TBCount1.Text);
                            LabelResult1.Content = special.PlusSum(n);
                            TBMoney1.Text = Convert.ToString(special.Money);
                            break;
                        case 2:
                            double k = Convert.ToDouble(TBCount1.Text);
                            LabelResult1.Content = prime.PlusSum(k);
                            TBMoney1.Text = Convert.ToString(prime.Money);
                            break;

                    }
                    break;
                case 1:
                    //вычисление операции начисления суммы1
                    switch (CBType1.SelectedIndex)
                    {
                        case 0:
                            double m = Convert.ToDouble(TBCount1.Text);
                            LabelResult1.Content = sumOfMoney.MinusSum(m);
                            TBMoney1.Text = Convert.ToString(sumOfMoney.Money);
                            break;
                        case 1:
                            double n = Convert.ToDouble(TBCount1.Text);
                            TBMoney1.Text = Convert.ToString(special.Money);
                            LabelResult1.Content = special.MinusSum(n);
                            TBMoney1.Text = Convert.ToString(special.Money);
                            break;
                        case 2:
                            double k = Convert.ToDouble(TBCount1.Text);
                            prime.Cashback = Convert.ToDouble(TBCondition1.Text);
                            LabelResult1.Content = prime.MinusSum(k);
                            TBMoney1.Text = Convert.ToString(prime.Money);
                            break;
                    }
                    break;
                case 2:

                    switch (CBType1.SelectedIndex)
                    {
                        case 0:
                            LabelResult1.Content = sumOfMoney.CalculatingThePercentage();
                            TBMoney1.Text = Convert.ToString(sumOfMoney.Money);
                            break;
                        case 1:
                            LabelResult1.Content = special.CalculatingThePercentage();
                            TBMoney1.Text = Convert.ToString(special.Money);
                            break;
                        case 2:
                            LabelResult1.Content = prime.CalculatingThePercentage();
                            TBMoney1.Text = Convert.ToString(prime.Money);
                            break;

                    }
                    break;
            }
        }


        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //  Window2 w2 = Owner as Window2;
            //Window1 w1= Owner as Window1;

            //  MainWindow w2 = Owner as MainWindow;
            //foreach (string i in List.Items)
            //{
            //    w2.ListBox2.Items.Add(i);
            //}

            Application app = new Application();
            Window2 w2 = new Window2();
            app.MainWindow = w2;


            //  Window2 ainWindow1; w2 = (Window2)Application.Current.Windows;

            ButtonAdd.IsEnabled = false;
            TBCount1.IsEnabled = false;
            ButtonTermSet1.IsEnabled = false;
            ButttonOperation1.IsEnabled = false;

            switch (CBType1.SelectedIndex)
            {

                case 0:
                    if (TBMoney1.Text == "" || (CBTerm1.Text == ""))
                    {
                        MessageBox.Show("Не хватает данных!");
                    }
                    else
                    {
                        cnt = lstsumOfMoney.Count;
                        //ввод данных инициализация полей класс
                        sumOfMoney.Money = Convert.ToDouble(TBMoney1.Text);
                        sumOfMoney.Term = Convert.ToInt32(CBTerm1.Text);
                        TBPersent1.Text = Convert.ToString(sumOfMoney.Persent());
                        TBMoney1.IsEnabled = false;
                        lstsumOfMoney.Add(sumOfMoney.Name());
                        lstsumOfMoney.Add(Convert.ToString(sumOfMoney.Money));
                        lstsumOfMoney.Add(CBTerm1.Text);
                        minimum1.Add(Convert.ToInt32(CBTerm1.Text));
                        lstsumOfMoney.Add(TBPersent1.Text);

                        lstgeneral.Add("Вклад Первый " + " Cумма: " + lstsumOfMoney[cnt + 1] + " Срок: " + lstsumOfMoney[cnt + 2] + " Процент: " + lstsumOfMoney[cnt + 3] + "\n");
                        // ListBox.SelectedItem = "";
                        w2.ListBox2.Items.Clear();
                        List.Items.Clear();
                        cnt = 0;
                        foreach (string i in lstgeneral)
                        {
                          
                          w2.ListBox2.Items.Add(i + "\n");
                           List.Items.Add(i + "\n");
                            cnt += 4;
                        }
                    }
                    break;

                case 1:
                    if (TBCondition1.Text == "" || CBTerm1.Text == "")
                    {
                        MessageBox.Show("Не хватает данных!");
                    }

                    else
                    {

                        cnt = lstspecial.Count;
                        //ввод данных инициализация полей класс
                        special.Money = Convert.ToDouble(TBMoney1.Text);
                        special.Term = Convert.ToInt32(CBTerm1.Text);
                        TBPersent1.Text = Convert.ToString(special.Persent());
                        TBMoney1.IsEnabled = false;
                        ButttonOperation1.IsEnabled = false;
                        lstspecial.Add(special.Name());
                        lstspecial.Add(Convert.ToString(special.Money));
                        lstspecial.Add(CBTerm1.Text);
                        minimum2.Add(Convert.ToInt32(CBTerm1.Text));
                        lstspecial.Add(TBPersent1.Text);
                        lstspecial.Add(TBCondition1.Text);
                        lstgeneral.Add("Вклад Особый " + " Cумма: " + lstspecial[cnt + 1] + " Срок: " + lstspecial[cnt + 2] + " Процент: " + lstspecial[cnt + 3] + "Н.О. " + lstspecial[cnt + 4] + "\n");
                        //  ListBox.SelectedItem = "";
                        w2.ListBox2.Items.Clear();
                        List.Items.Clear();
                        cnt = 0;
                        foreach (string i in lstgeneral)
                        {
                            w2.ListBox2.Items.Add(i + "\n");
                            List.Items.Add(i + "\n");
                            cnt += 5;
                        }
                    }
                    break;

                case 2:
                    if (TBMoney1.Text == "" || (TBCondition1.Text == "") || (CBTerm1.Text == ""))
                    {
                        MessageBox.Show("Не хватает данных!");
                    }
                    else
                    {
                        cnt = lstprime.Count;
                        //ввод данных инициализация полей класса
                        prime.Money = Convert.ToDouble(TBMoney1.Text);
                        prime.Term = Convert.ToInt32(CBTerm1.Text);
                        // prime.Cashback = Convert.ToInt32(TBCashback1.Text);
                        TBPersent1.Text = Convert.ToString(prime.Persent());
                        prime.Cashback = Convert.ToDouble(TBCondition1.Text);
                        TBMoney1.IsEnabled = false;
                        TBMoney1.IsEnabled = false;
                        ButttonOperation1.IsEnabled = false;
                        lstprime.Add(prime.Name());
                        lstprime.Add(Convert.ToDouble(prime.Money));
                        lstprime.Add(CBTerm1.Text);
                        minimum3.Add(Convert.ToInt32(CBTerm1.Text));
                        lstprime.Add(TBPersent1.Text);
                        lstprime.Add(TBCondition1.Text);

                        w2.ListBox2.Items.Clear();
                        List.Items.Clear();
                        lstgeneral.Add("Вклад Премьер " + " Cумма: " + lstprime[cnt + 1] + " Срок: " + lstprime[cnt + 2] + " Процент: " + lstprime[cnt + 3] + "Кэшбек " + lstprime[cnt + 4] + "\n");
                        // int excerpt = Convert.ToInt32(lstgeneral[lstgeneral.Count-1]);
                        cnt = 0;
                        foreach (string i in lstgeneral)
                        {
                            w2.ListBox2.Items.Add(i + "\n");
                            List.Items.Add(i + "\n");
                            cnt += 5;
                        }
                    }
                    break;
            }
            CBType1.SelectedIndex = -1;
            TB.Text = "";
            TBMoney1.Text = "";
            CBTerm1.SelectedIndex = -1;
            TBPersent1.Text = "";
            CBOperation1.SelectedIndex = -1;
            TBCondition1.Text = "";
            LabelResult1.Content = "";
            TBCondition1.Text = "";
            CBOperation1.IsEnabled = false;

        }

        //private void ButttonPlusM_Click(object sender, RoutedEventArgs e)
        //{
        //    //ввод данных инициализация полей класса
        //    double np1 = Convert.ToDouble(TBPlusSum.Text);
        //    switch (CBType.SelectedIndex)
        //    {
        //        case 0:
        //            LabelPlusSum.Content = sumOfMoney.PlusSum(np1);
        //            TBMoney.Text = Convert.ToString(sumOfMoney.Money);
        //            break;
        //        case 1:
        //            LabelPlusSum.Content = special.PlusSum(np1);
        //            TBMoney.Text = Convert.ToString(special.Money);
        //            break;
        //        case 2:
        //            LabelPlusSum.Content = prime.PlusSum(np1);
        //            TBMoney.Text = Convert.ToString(prime.Money);
        //            break;
        //    }
        //}

        //private void ButttonMinusM_Click(object sender, RoutedEventArgs e)
        //{
        //    double m = Convert.ToDouble(TBMinusM.Text);
        //    switch (CBType.SelectedIndex)
        //    {
        //        case 0:
        //            LabelMinus.Content = sumOfMoney.MinusSum(m);
        //            TBMoney.Text = Convert.ToString(sumOfMoney.Money);

        //            break;
        //        case 1:
        //            TBMoneyB.Text = Convert.ToString(special.MoneyB);
        //            LabelMinus.Content = special.MinusSum(m);
        //            TBMoney.Text = Convert.ToString(special.Money);
        //            break;
        //        case 2:
        //            TBCashback.Text = Convert.ToString(prime.Cashback);
        //            LabelMinus.Content = prime.MinusSum(m);
        //            TBMoney.Text = Convert.ToString(prime.Money);
        //            break;
        //    }
        //}
        //private void ButttonPersent_Click(object sender, RoutedEventArgs e)
        //{
        //    switch (CBType.SelectedIndex)
        //    {
        //        case 0:
        //            //вычисление операции начисления процента
        //            LabelPersent.Content = Math.Round(sumOfMoney.CalculatingThePercentage(), 2);
        //            TBMoney.Text = Convert.ToString(sumOfMoney.Money);
        //            break;
        //        case 1:
        //            //вычисление операции начисления процента
        //            LabelPersent.Content = Math.Round(special.CalculatingThePercentage(), 2);
        //            TBMoney.Text = Convert.ToString(special.Money);
        //            break;
        //        case 2:
        //            //вычисление операции начисления процента
        //            LabelPersent.Content = Math.Round(prime.CalculatingThePercentage(), 2);
        //            TBMoney.Text = Convert.ToString(prime.Money);
        //            break;
        //    }
        //}
        private void ButtonButtonUpgrate_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = Owner as Window2;
            int cnt = 0;
            lstgeneral.Clear();
            w2.ListBox2.SelectedItem = "";
            List.SelectedItem = "";

            if (lstsumOfMoney.Count / 4 == 1)
            {
                double b = 0;
                int c = 0;
                double d = 0;
                //подсчет общего для первого вклада
                b = Convert.ToDouble(sumOfMoney.Money);
                c = sumOfMoney.Term;
                d = Convert.ToDouble(sumOfMoney.Persent());

                lstsumOfMoney.Clear();
                lstsumOfMoney.Add(sumOfMoney.Name());
                lstsumOfMoney.Add(b);
                lstsumOfMoney.Add(c);
                lstsumOfMoney.Add(d);
                w2.ListBox2.Items.Add("Вклад Первый " + " Cумма: " + b + " Срок: " + c + " Процент: " + d + "\n");
                List.Items.Add("Вклад Первый " + " Cумма: " + b + " Срок: " + c + " Процент: " + d + "\n");
                lstgeneral.Add("Вклад Первый " + " Cумма: " + lstsumOfMoney[cnt + 1] + " Срок: " + lstsumOfMoney[cnt + 2] + " Процент: " + lstsumOfMoney[cnt + 3] + "\n");
            }
            if (lstspecial.Count / 5 == 1)
            {
                double sp2 = 0;
                int sp3 = 0;
                double sp4 = 0;
                double sp5 = 0;
                //подсчет общего для особого вклада
                sp2 = Convert.ToDouble(special.Money);
                sp3 = Convert.ToInt32(special.Term);
                sp4 = Convert.ToDouble(special.Persent());
                sp5 = Convert.ToDouble(TBMoneyB.Text);
                lstspecial.Clear();
                lstspecial.Add(special.Name());
                lstspecial.Add(sp2);
                lstspecial.Add(sp3);
                lstspecial.Add(sp4);
                lstspecial.Add(sp5);
                w2.ListBox2.Items.Add("Вклад Особый " + " Cумма: " + sp2 + " Срок: " + sp3 + " Процент: " + sp4 + " Н.О. " + sp5 + "\n");
                List.Items.Add("Вклад Особый " + " Cумма: " + sp2 + " Срок: " + sp3 + " Процент: " + sp4 + " Н.О. " + sp5 + "\n");
                lstgeneral.Add("Вклад Особый " + " Cумма: " + sp2 + " Срок: " + sp3 + " Процент: " + sp4 + " Н.О. " + sp5 + "\n");
            }
            if (lstprime.Count / 5 >= 1)
            {
                double pr2 = 0;
                int pr3 = 0;
                double pr4 = 0;
                double pr5 = 0;
                {
                    //подсчет общего для особого вклада
                    pr2 += Convert.ToDouble(prime.Money);
                    pr5 = Convert.ToInt32(prime.Cashback);
                    pr3 = Convert.ToInt32(prime.Term);
                    pr4 = Convert.ToDouble(prime.Persent());
                    lstprime.Clear();
                    lstprime.Add(prime.Name());
                    lstprime.Add(pr2);
                    lstprime.Add(pr3);
                    lstprime.Add(pr4);
                    lstprime.Add(pr5);
                    w2.ListBox2.Items.Add("Вклад Премьер " + " Cумма: " + pr2 + " Срок: " + pr3 + " Процент: " + pr4 + " Кэшбек " + pr5 + "\n");
                    List.Items.Add("Вклад Премьер " + " Cумма: " + pr2 + " Срок: " + pr3 + " Процент: " + pr4 + " Кэшбек " + pr5 + "\n");
                    lstgeneral.Add("Вклад Премьер " + " Cумма: " + pr2 + " Срок: " + pr3 + " Процент: " + pr4 + " Кэшбек " + pr5 + "\n");
                }
            }
        }

        private void ButtonTermSet1_Click(object sender, RoutedEventArgs e)
        {
            switch (CBType1.SelectedIndex)
            {
                case 0:
                    sumOfMoney.Term = Convert.ToInt32(CBTerm1.Text);
                    MessageBox.Show("Будет изменен статус вклада!");
                    minimum1.Clear();
                    minimum1.Add(Convert.ToInt32(CBTerm1.Text));
                    TBPersent1.Text = Convert.ToString(sumOfMoney.Persent());
                    break;

                case 1:
                    special.Term = Convert.ToInt32(CBTerm1.Text);
                    MessageBox.Show("Будет изменен статус вклада!");
                    minimum2.Clear();
                    minimum2.Add(Convert.ToInt32(CBTerm1.Text));
                    TBPersent1.Text = Convert.ToString(special.Persent());
                    break;
                case 2:
                    prime.Term = Convert.ToInt32(CBTerm1.Text);
                    MessageBox.Show("Будет изменен статус вклада!");
                    minimum3.Clear();
                    minimum3.Add(Convert.ToInt32(CBTerm1.Text));
                    TBPersent1.Text = Convert.ToString(prime.Persent());
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 Contribution = new Window2();
            Contribution.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

            
       
