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

namespace PSHelpEdit.Dlg.CommandSaveDlg
{
    /// <summary>
    /// Interaction logic for CmdSaveWnd.xaml
    /// </summary>
    public partial class CmdSaveWnd : Window
    {
        #region public CmdSaveWnd()
        public CmdSaveWnd()
        {
            InitializeComponent();
        }
        #endregion
        //
        #region public static CmdSaveWnd CreateInstance(string header, string commandInfo, string statusInfo)
        public static CmdSaveWnd CreateInstance(string header, string oldName, string newName)
        {
            CmdSaveWnd result = new CmdSaveWnd();
            CmdSaveModel mdl = new CmdSaveModel();
            //
            mdl.HeaderInfo = header;
            mdl.NewCommandName = newName;
            mdl.OldCommandName = oldName;
            result.DataContext = mdl;
            return result;
        }
        #endregion

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            
        }
    }
}
