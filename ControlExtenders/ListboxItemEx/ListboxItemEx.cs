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

    public class ListBoxItemEx : ListBoxItem
    {
        #region Dependency properties declaration
        public static DependencyProperty EditmodeProperty;
        #endregion
        //            
        #region Static initializer
        static ListBoxItemEx()
        {
            #region Apply initial template data.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListBoxItemEx), new FrameworkPropertyMetadata(typeof(ListBoxItemEx)));
            #endregion
            //
            #region Register DependencyProperties.
            EditmodeProperty = DependencyProperty.Register
            (
                "EditMode",
                typeof(bool),
                typeof(ListBoxItemEx), new FrameworkPropertyMetadata(false)
            );
            #endregion
        }
        #endregion
        //
        #region ListboxItemEx()
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
            CommandItem cmdItem = DataContext as CommandItem;
            if (cmdItem != null)
            {
                Binding editModeBinding = new Binding("EditMode");
                editModeBinding.Source = cmdItem;
                this.SetBinding(ListBoxItemEx.EditmodeProperty, editModeBinding);
            }
        }
        #endregion
    }
}
