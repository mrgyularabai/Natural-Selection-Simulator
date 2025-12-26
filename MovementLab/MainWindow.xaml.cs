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

namespace Ozeki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OzMovingEntity[] _entities = new OzMovingEntity[5];
        public MainWindow()
        {
            InitializeComponent();
            _entities[0] = new OzMovingEntity(100, 100, 0, ref paper);
            _entities[1] = new OzMovingEntity(200, 200, 1, ref paper);
            _entities[2] = new OzMovingEntity(300, 300, 2, ref paper);
            _entities[3] = new OzMovingEntity(400, 400, 3, ref paper);
            _entities[4] = new OzMovingEntity(500, 500, 4, ref paper);
            OzEventSyncronizer.Start(_entities);
            CompositionTarget.Rendering += render;
        }

        void render(object o, EventArgs e)
        {
            OzEventSyncronizer.Render(ref paper);
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OzEventSyncronizer.SetGroupDestination(e.GetPosition(paper));
        }
    }
}
