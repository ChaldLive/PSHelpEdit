using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PSHelpEdit.ControlExtenders
{
    /// <summary>
    /// Class ListBoxEx.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ListBox" />
    public class ListBoxEx : ListBox
    {
        #region Dependency property declerations
        public static DependencyProperty EditmodeProperty;
        #endregion
        //
        #region static ListBoxEx()
        static ListBoxEx()
        {
        }
        #endregion
        //
        #region public ListBoxEx()
        public ListBoxEx()
            :base()
        {

        }
        #endregion
        //
        #region protected override DependencyObject GetContainerForItemOverride()
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ListBoxItemEx();
        }
        #endregion
        //
        #region protected override bool IsItemItsOwnContainerOverride(object item)
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ListBoxItemEx;
        }
        #endregion
    }
}
