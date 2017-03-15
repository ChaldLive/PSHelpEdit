using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PSHelpEdit.Models;

namespace PSHelpEdit.ControlExtenders.ExpanderEx
{
    public class ExpanderEx : Expander
    {
        #region Static initialisation
        static ExpanderEx()
        {
            #region Apply initial template data.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpanderEx), new FrameworkPropertyMetadata(typeof(ExpanderEx)));
            #endregion
        }
        #endregion
        //
        #region Dynamic initialization
        public ExpanderEx()
        {
        }
        #endregion
    }
}
