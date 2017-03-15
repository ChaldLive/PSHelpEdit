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

namespace PSHelpEdit.Controls
{
    /// <summary>
    /// Interaction logic for CommandsCtrl.xaml
    /// </summary>
    public partial class CommandsCtrl : UserControl
    {
        public CommandsCtrl()
        {
            InitializeComponent();
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            CommandsModel currentModel = DataContext as CommandsModel;
            if(currentModel != null)
            {
                FrameworkElement fe = e.OriginalSource as FrameworkElement;
                currentModel.OnModelKeyDown(fe.DataContext, e);
            }
        }
    }
}
