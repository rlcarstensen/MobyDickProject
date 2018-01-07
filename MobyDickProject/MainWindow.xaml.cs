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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MobyDickProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //String bookPath = @"C:\Users\Robert\Documents\visual studio 2017\Projects\MobyDickProject\mobydick.txt";
            //String stopWordsPath = @"C:\Users\Robert\Documents\visual studio 2017\Projects\MobyDickProject\stop-words";

            //List<String> stopWords = File.ReadAllLines(stopWordsPath).ToList();

            //Console.ReadLine();
        }
    }
}
