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
        private static string GridSplitterBackgroundBrushName = "GridSplitterBackgroundBrushName";
        #endregion
        //
        #region Private fields
        private static ResourceKey _gridSplitterBackgroundBrushKey;
        #endregion
        //
        #region Dialog keys declerations. 
        public static ResourceKey GridSplitterBackgroundBrushKey
        {
            get
            {
                if (_gridSplitterBackgroundBrushKey == null)
                    _gridSplitterBackgroundBrushKey = CreateInstance(GridSplitterBackgroundBrushName);
                return _gridSplitterBackgroundBrushKey;
            }
        }
        #endregion

    }
}
