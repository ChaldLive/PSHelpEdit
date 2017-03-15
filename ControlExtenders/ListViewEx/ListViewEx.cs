using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PSHelpEdit.ControlExtenders
{

    public class ListViewEx : ListView
    {



        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ListViewItemEx();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ListViewItemEx;
        }


    }
}
