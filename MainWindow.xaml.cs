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
using PSHelpEdit.Utils;

namespace PSHelpEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MainWindow()
        public MainWindow()
        {
            InitializeComponent();
            //
            MainWindowModel mainWnd = new MainWindowModel();
            mainWnd.ModelEvent += MainWnd_ModelEvent;
            DataContext = mainWnd;
        }
        #endregion
        //
        #region public static MainWindow GetMainWndInstance()
        public static MainWindow GetMainWndInstance()
        {
            return App.Current.MainWindow as MainWindow;
        }
        #endregion
        //
        #region private void MainWnd_ModelEvent(General.ModelEventArg evtArg)
        private void MainWnd_ModelEvent(General.ModelEventArg evtArg)
        {
            if(evtArg.EventKode == General.ModelEventArg.EventTypeKode.evtLoaded)
            {
                MenuItem recentFilesItem = GetRecentFilesListItem();
                MruHandler.Instance.InitializeMenu(recentFilesItem, RecentFileMenuItemClick);
            }
        }
        #endregion
        //
        #region protected MenuItem GetRecentFilesListItem()

        protected MenuItem GetRecentFilesListItem()
        {
            MenuItem result = null;
            foreach(MenuItem mnuItem in _mainMenu.Items)
            {
                string menuItemHeader = mnuItem.Header as string;
                if(!string.IsNullOrEmpty(menuItemHeader) && menuItemHeader == "File")
                {
                    foreach (object objMenuItem in mnuItem.Items)
                    {
                        MenuItem fileMenuItem = objMenuItem as MenuItem;
                        if(fileMenuItem != null)
                        {
                            menuItemHeader = fileMenuItem.Header as string;
                            if (menuItemHeader.Equals("Recent Files",StringComparison.InvariantCultureIgnoreCase))
                            {
                                result = fileMenuItem;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        #endregion
        //
        #region private void RecentFileMenuItemClick(object sender, RoutedEventArgs e)
        private void RecentFileMenuItemClick(object sender, RoutedEventArgs e)
        {
            MainWindowModel mdl = GetMainWindowModel();
            MenuItem mnuCurrent = e.Source as MenuItem;
            if((mdl != null) && (mnuCurrent != null))
            {
                MruItem currentMruItem = mnuCurrent.Tag as MruItem;
                if(currentMruItem != null)
                {
                    mdl.OpenDocumentationFile(currentMruItem.FullFileName());
                }
            }
        }
        #endregion
        //
        #region MyRegion
        protected MainWindowModel GetMainWindowModel()
        {
            return DataContext as MainWindowModel;
        }
        #endregion
        
    }
}
