using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NatrualSelectionSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instence; 
        public MainWindow()
        {
            InitializeComponent();
            Instence = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OzEventSyncroniser.Instance.Start(int.Parse(PlantNum.Text),int.Parse(Daylen.Text),int.Parse(w.Text),int.Parse(h.Text));
        }
    }
}
