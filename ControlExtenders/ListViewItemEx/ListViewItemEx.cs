using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PSHelpEdit.Models;

namespace PSHelpEdit.ControlExtenders
{

    public class ListViewItemEx  : ListViewItem
    {
        #region Pependency property decleration
        public static DependencyProperty EditmodeProperty;
        #endregion
        #region Static initialisation
        static ListViewItemEx()
        {
            #region Apply initial template data.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewItemEx), new FrameworkPropertyMetadata(typeof(ListViewItemEx)));
            #endregion
            //
            #region Register DependencyProperties.
            EditmodeProperty = DependencyProperty.Register
            (
                "EditMode",
                typeof(bool),
                typeof(ListViewItemEx), new FrameworkPropertyMetadata(false)
            );
            #endregion
        }
        #endregion
        //
        #region Dynamic initialisation
        public ListViewItemEx()
        {
            int x = 0;
            x++;
        }
        #endregion
        //
        #region Dependency properties getters and setters
        /// <summary>
        /// Gets or sets a value indicating whether [edit mode].
        /// </summary>
        /// <value><c>true</c> if [edit mode]; otherwise, <c>false</c>.</value>
        public bool EditMode
        {
            get { return (bool)GetValue(EditmodeProperty); }
            set { SetValue(EditmodeProperty, value); }
        }
        #endregion
        //
        #region public override void OnApplyTemplate()
        /// <summary>
        /// Naar man skifter template, mens programmet koerer er man lige saa 
        /// venlig at sørge for at Datacontext er vedligeholdt. Der sker jo 
        /// ny binding når der kommer ny control template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //
            ParameterItem paramItem = DataContext as ParameterItem;
            if (paramItem != null)
            {
                Binding editModeBinding = new Binding("EditMode");
                editModeBinding.Source = paramItem;
                this.SetBinding(ListBoxItemParam.EditmodeProperty, editModeBinding);
            }
        }
        #endregion

    }
}
