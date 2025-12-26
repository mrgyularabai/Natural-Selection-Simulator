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

namespace NatrualSelectionSim
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SimulationWindow : Window
    {
        bool firstResize = true;
        int givenWidth;
        int givenHeight;
        int marginX;
        int marginY;
        bool waveUp = true;
        int wavelenght;
        int maxwavelenght = 20; 
        int origSW;
        int origSH;
        bool notCalled = true;
        Thickness origB;
        public SimulationWindow(int w, int height)
        {
            InitializeComponent();
            givenWidth = w;
            givenHeight = height;
            this.Background = new SolidColorBrush(Colors.Blue);
            Paper.Background = new SolidColorBrush(Colors.LightGreen);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (firstResize) 
            {
                firstResize = false;
                this.Height = givenHeight;
                this.Width = givenWidth;
                sand.Height += givenHeight;
                sand.Width += givenWidth;
                Paper.MaxWidth = Paper.ActualWidth;
                Paper.MaxHeight = Paper.ActualHeight;
                origSW += (int)sand.Width;
                origSH += (int)sand.Height;
                origB = sand.BorderThickness;
                return; 
            }
            if(this.Height <= givenHeight && this.Width <= givenWidth)
            {
                background.Background = null;
            }
            else
            {
                LightUpCtrlPanel();
            }
            getX(e);
            getY(e);
            var old = DayCount.Margin;
            DayCount.Margin = new Thickness(this.ActualWidth / 2 - DayCount.ActualWidth / 2, marginY + old.Top, 0, 0);
        }
        private void LightUpCtrlPanel()
        {
            background.Background = new SolidColorBrush(Color.FromArgb(155, 255, 255, 255));
        }

        private void getX(SizeChangedEventArgs e)
        {
            marginX = (int)((e.NewSize.Width - e.PreviousSize.Width) / 2);
        }

        private void getY(SizeChangedEventArgs e)
        {
            marginY = (int)((e.NewSize.Height - e.PreviousSize.Height) / 2);
        }

        public void RefreshDayCount(int num)
        {
            var i = "Day: " + (num+1).ToString();
            DayCount.Content = i.ToString();
        }

        public void Wave()
        {
            if(wavelenght < maxwavelenght && waveUp)
            {
                wavelenght++;
                if (wavelenght == maxwavelenght) waveUp = false;
                return;
            }
            wavelenght--;
            if (wavelenght <= 0) waveUp = true;
        }
        public void GfxWave()
        {
            if(this.WindowState == WindowState.Maximized && notCalled)
            {
                LightUpCtrlPanel();
            }
            sand.Width = wavelenght + origSW;
            sand.Height = wavelenght + origSH;
            if (waveUp)
                sand.BorderThickness = new Thickness(origB.Bottom + wavelenght / 4);
            if (!waveUp)
                sand.BorderThickness = new Thickness(wavelenght / 4 + origB.Bottom);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
            this.Height = givenHeight;
            this.Width = givenWidth;
        }
    }
}
