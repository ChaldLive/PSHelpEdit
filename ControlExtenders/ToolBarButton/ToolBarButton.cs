using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace PSHelpEdit.ControlExtenders
{
    public class ToolBarButton : Button
    {
        #region Dependency properties declaration
        public static readonly DependencyProperty HeaderProperty;
        public static readonly DependencyProperty ImageSourceProperty;
        #endregion
        //
        #region Static initialisation
        static ToolBarButton()
        {
            #region Apply initial template data.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarButton), new FrameworkPropertyMetadata(typeof(ToolBarButton)));
            #endregion
            //
            #region Register DependencyProperties.
            HeaderProperty = DependencyProperty.Register
            (
                "Header",
                typeof(string),
                typeof(ToolBarButton), new FrameworkPropertyMetadata("")
            );
            ImageSourceProperty = DependencyProperty.Register
            (
                "ImageSource",
                typeof(ImageSource),
                typeof(ToolBarButton), new FrameworkPropertyMetadata(null)
            );
            #endregion
        }
        #endregion
        //
        #region Dynamic initialisation
        public ToolBarButton()
        {
        }
        #endregion
        //
        #region Dependency property getters and setters
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion
    }
}
