using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PSHelpEdit.Models;


namespace PSHelpEdit.ControlExtenders
{

    public class ListBoxParam  : ListBox
    {
        #region Dependency properties decleration
        #endregion


        #region Static initialisation
        static ListBoxParam()
        {
        }
        #endregion
        //
        #region Dynamic initialisation
        public ListBoxParam()
        {

        }
        #endregion
        //
        #region protected override DependencyObject GetContainerForItemOverride()
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ListBoxItemParam();
        }
        #endregion
        //
        #region protected override bool IsItemItsOwnContainerOverride(object item)
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ListBoxItemParam;
        }
        #endregion

    }
}
