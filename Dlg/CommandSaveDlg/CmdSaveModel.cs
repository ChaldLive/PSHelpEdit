using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PSHelpEdit.Models;

namespace PSHelpEdit.Dlg.CommandSaveDlg
{
    public class CmdSaveModel : ModelBase
    {
        #region Dependency properties decleration.
        public static DependencyProperty DlgResultProperty;
        #endregion
        //
        #region Private fields
        private string _headerInfo;
        private string _oldCommandName;
        private string _newCommandName;
        #endregion
        //
        #region static CmdSaveModel()
        static CmdSaveModel()
        {
            DlgResultProperty = DependencyProperty.Register
            (
                "DlgResult",
                typeof(bool?),
                typeof(CmdSaveModel), new FrameworkPropertyMetadata(null)
            );

        }
        #endregion
        //
        #region public CmdSaveModel()
        public CmdSaveModel()
        {
        }
        #endregion
        //
        #region Public properties
        public string HeaderInfo
        {
            get{return _headerInfo;}
            set
            {
                OnPropertyChanging();
                _headerInfo = value;
                OnPropertyChanged();
            }
        }

        public string OldCommandName
        {
            get{return _oldCommandName;}
            set
            {
                OnPropertyChanging();
                _oldCommandName = value;
                OnPropertyChanged();
            }
        }

        public string NewCommandName
        {
            get{return _newCommandName;}
            set
            {
                OnPropertyChanging();
                _newCommandName = value;
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region Dependency properties getters and setters.
        /// <summary>
        /// Gets the dialog result.
        /// </summary>
        /// <value>The dialog result.</value>
        public bool? DlgResult
        {
            get { return (bool?)GetValue(DlgResultProperty); }
            set { SetValue(DlgResultProperty, value); }
        }
        #endregion
    }
}
