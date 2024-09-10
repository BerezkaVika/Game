using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using LibraryOfLaba4_1;
using castlelib;



namespace ProjectOfSumMoney
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        Castle castle;
        Fort fort;
        Monastery monastery;


        private void BtnFix_Click(object sender, RoutedEventArgs e)
        {
            BtnFix.IsEnabled = false;
            switch (TypeOfObject.SelectedIndex)
            {
               
                case 0:
                    {
                        BlockName.Text = "Имя замка:";
                        BlockCash.Text = "Сумма в замке:";
                       
                    }
                    break;

                case 1:
                    {
                        BlockName.Text = "Имя форта:";
                        BlockCash.Text = "Сумма в форте:";
                        BlockDop.Text = "Кол-во орудий:";
                        BlockDop.Visibility = 0;
                        TBDop.Visibility = 0;
                    }
                    break;

                case 2:
                    {
                        BlockName.Text = "Имя монастыря:";
                        BlockCash.Text = "Сумма в мон-ре:";
                        BlockDop.Text = "Кол-во монахов:";
                        BlockDop.Visibility = 0;
                        TBDop.Visibility = 0;
                    }
                    break;
            }
            TBName.Visibility = 0;
            TBCash.Visibility = 0;
            TBCashUp.Visibility = 0;
            TBCashDown.Visibility = 0;
            BlockName.Visibility = 0;
            BlockCash.Visibility = 0;
            BlockCashUp.Visibility = 0;
            BlockCashDown.Visibility = 0;
            BlockCashUp.Text = "Заработок:";
            BlockCashDown.Text = "Затраты:";
            BtnApply.Visibility = 0;
            BtnStatus.Visibility = 0;
            BtnGotoBank.Visibility = 0;


        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TBName.IsEnabled = false;
                TBCash.IsEnabled = false;
                TBCashUp.IsEnabled = false;
                TBCashDown.IsEnabled = false;

                switch (TypeOfObject.SelectedIndex)
                {

                    case 0:
                        {

                            castle = new Castle(Convert.ToString(TBName.Text), Convert.ToDouble(TBCash.Text), Convert.ToDouble(TBCashUp.Text), Convert.ToDouble(TBCashDown.Text));
                           // BtnApply.IsEnabled = true;

                            if (Convert.ToDouble(TBCash.Text) < 0 || Convert.ToDouble(TBCashUp.Text) < 0 || Convert.ToDouble(TBCashDown.Text) < 0)
                            {

                                TBCash.IsEnabled = true;
                                TBCashUp.IsEnabled = true;
                                TBCashDown.IsEnabled = true;
                                TBCash.Text = "Error";
                                TBCashDown.Text = "Error";
                                TBCashDown.Text = "Error";
                                BtnApply.IsEnabled = true;
                            }

                        }
                        break;

                    case 1:
                        {
                            fort = new Fort(Convert.ToString(TBName.Text), Convert.ToDouble(TBCash.Text), Convert.ToDouble(TBCashUp.Text), Convert.ToDouble(TBCashDown.Text), Convert.ToInt32(TBDop.Text));
                            //BtnApply.IsEnabled = false;
                            TBDop.IsEnabled = false;
                            if (Convert.ToDouble(TBCash.Text) < 0 || Convert.ToDouble(TBCashUp.Text) < 0 || Convert.ToDouble(TBCashDown.Text) < 0 || Convert.ToDouble(TBDop.Text) < 0)
                            {

                                TBCash.IsEnabled = true;
                                TBCashUp.IsEnabled = true;
                                TBCashDown.IsEnabled = true;
                                TBDop.IsEnabled = true;
                                TBCash.Text = "Error";
                                TBCashUp.Text = "Error";
                                TBCashDown.Text = "Error";
                                TBDop.Text = "Error";
                                BtnApply.IsEnabled = true;
                            }
                        }
                        break;

                    case 2:
                        {
                            monastery = new Monastery(Convert.ToString(TBName.Text), Convert.ToDouble(TBCash.Text), Convert.ToDouble(TBCashUp.Text), Convert.ToDouble(TBCashDown.Text), Convert.ToInt32(TBDop.Text));
                            // Монастырь (Имя, сумма в монастыре, заработок монастыря, расход монастыря, кол-во монахов);
                            TBDop.IsEnabled = false;
                        }
                        break;
                }
            }
            catch
            {
                TBCash.IsEnabled = true;
                TBCashUp.IsEnabled = true;
                TBCashDown.IsEnabled = true;
                TBCash.Text = "Error";
                TBCashUp.Text = "Error";
                TBCashDown.Text = "Error";
                BtnApply.IsEnabled = true;
                switch (TypeOfObject.SelectedIndex)
                {
                    case 1:
                    case 2:
                        {
                            TBDop.Text = "Error";
                        }
                        break;
                 }

                MessageBox.Show("Ошибка ввода данных!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TBName.IsEnabled = false;
                TBCash.IsEnabled = false;
                TBCashUp.IsEnabled = false;
                TBCashDown.IsEnabled = false;

                switch (TypeOfObject.SelectedIndex)
                {

                    case 0:
                        {
                            if (Convert.ToDouble(TBCashUp.Text) >= Convert.ToDouble(TBCashDown.Text))
                            {
                                if (Convert.ToDouble(TBCashUp.Text) > Convert.ToDouble(TBCashDown.Text))
                                {
                                    BlockStatus.Text = "Прибыльный";
                                }
                                else
                                {
                                    BlockStatus.Text = "Не меняется";
                                }
                            }
                            else
                            {
                                BlockStatus.Text = "Убыточный";
                            }
                        }
                        break;
                    case 1:
                        {
                            if (Convert.ToDouble(TBCashUp.Text) >= Convert.ToDouble(TBCashDown.Text) - fort.cashforgun())
                            {
                                if (Convert.ToDouble(TBCashUp.Text) > Convert.ToDouble(TBCashDown.Text) - fort.cashforgun())
                                {
                                    BlockStatus.Text = "Прибыльный";
                                }
                                else
                                {
                                    BlockStatus.Text = "Не меняется";
                                }
                            }
                            else
                            {
                                BlockStatus.Text = "Убыточный";
                            }
                        }
                        break;

                    case 2:
                        {
                            if (Convert.ToDouble(TBCashUp.Text) + monastery.cashformonah() >= Convert.ToDouble(TBCashDown.Text))
                            {
                                if (Convert.ToDouble(TBCashUp.Text) + monastery.cashformonah() > Convert.ToDouble(TBCashDown.Text))
                                {
                                    BlockStatus.Text = "Прибыльный";
                                }
                                else
                                {
                                    BlockStatus.Text = "Не меняется";
                                }
                            }
                            else
                            {
                                BlockStatus.Text = "Убыточный";
                            }
                        }
                        break;
                }
            }
            catch
            {
                BlockStatus.Text = "error";

                MessageBox.Show("Некоректные данные", "Ошибка Замка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private void BtnSbros_Click(object sender, RoutedEventArgs e)
        //{
        //    castlecash.IsEnabled = true;
        //    castlecashup.IsEnabled = true;
        //    castlecashdown.IsEnabled = true;
        //    Fortcash.IsEnabled = true;
        //    Fortcashup.IsEnabled = true;
        //    Fortcashdown.IsEnabled = true;
        //    gunnum.IsEnabled = true;
        //    Moncash.IsEnabled = true;
        //    Moncashup.IsEnabled = true;
        //    Moncashdown.IsEnabled = true;
        //    monnum.IsEnabled = true;
        //    b1.IsEnabled = true;
        //    b2.IsEnabled = true;
        //    b3.IsEnabled = true;
        //}

        private void BtnGotoBank_Click(object sender, RoutedEventArgs e)
        {
            Window1 Bank = new Window1();
            Bank.Show();
        }

    }
}





