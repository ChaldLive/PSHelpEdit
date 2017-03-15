using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PSHelpEdit.Keys
{
    public static partial class ResourceKeys
    {
        #region Private resourcekey names.
        private static string DlgBackgroundName = "DlgBackgroundName";
        private static string DlgBumpForegroundName = "DlgBumpForegroundName";
        private static string DlgBumpBackgroundName = "DlgBumpBackgroundName";
        #endregion
        //
        #region Resource key instances
        private static ResourceKey _dlgBackgroundKey;
        private static ComponentResourceKey _dlgBumpForegroundKey;
        private static ComponentResourceKey _dlgBumpBackgroundKey;
        #endregion
        //
        #region Dialog keys declerations. 
        public static ResourceKey DlgBackgroundKey
        {
            get
            {
                if(_dlgBackgroundKey == null)
                    _dlgBackgroundKey = CreateInstance(DlgBackgroundName);
                return _dlgBackgroundKey;
            }
        }
        public static ComponentResourceKey DlgBumpForegroundKey
        {
            get
            {
                if (_dlgBumpForegroundKey == null)
                    _dlgBumpForegroundKey = CreateInstanceEx(DlgBumpForegroundName);
                return _dlgBumpForegroundKey;
            }
        }
        public static ComponentResourceKey DlgBumpBackgroundKey
        {
            get
            {
                if (_dlgBumpBackgroundKey == null)
                    _dlgBumpBackgroundKey = CreateInstanceEx(DlgBumpBackgroundName);
                return _dlgBumpBackgroundKey;
            }
        }
        #endregion

    }
}
