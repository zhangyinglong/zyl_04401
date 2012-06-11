using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfApplicationTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            my_init();
        }

        private void my_init()
        {
            this.MyText = "10";
        }

        public string mytext;
        public string MyText 
        {
            set
            {
                if (this.MyText != value)
                {
                    this.mytext = value;
                    NotifyPropertyChanged("MyText");
                }
            }
            get
            {
                return this.mytext;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.MyText = "20";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
