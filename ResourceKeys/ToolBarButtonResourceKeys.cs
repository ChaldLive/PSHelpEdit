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
        #region ResourceKeyNames
        private static string ButtonStaticBackground    = "Button_Static_BackgroundName";
        private static string ButtonStaticBorder        = "Button_Static_BorderName";
        private static string ButtonMouseOverBackground = "Button_MouseOver_BackgroundName";
        private static string ButtonMouseOverBorder     = "Button_MouseOver_BorderName";
        private static string ButtonPressedBackground   = "Button_Pressed_BackgroundName";
        private static string ButtonPressedBorder       = "Button_Pressed_BorderName";
        private static string ButtonDisabledBackground  = "Button_Disabled_BackgroundName";
        private static string ButtonDisabledBorder      = "Button_Disabled_BorderName";
        private static string ButtonDisabledForeground  = "Button_Disabled_ForegroundName";
        #endregion
        //
        #region Instance members
        private static ResourceKey _buttonStaticBackgroundKey;
        private static ResourceKey _buttonStaticBorderKey;
        private static ResourceKey _buttonMouseOverBackgroundKey;
        private static ResourceKey _buttonMouseOverBorderKey;
        private static ResourceKey _buttonPressedBackgroundKey;
        private static ResourceKey _buttonPressedBorderKey;
        private static ResourceKey _buttonDisabledBackgroundKey;
        private static ResourceKey _buttonDisabledBorderKey;
        private static ResourceKey _buttonDisabledForegroundKey;
        #endregion
        //
        #region Public properties.
        public static ResourceKey ButtonStaticBackgroundKey
        {
            get
            {
                if (_buttonStaticBackgroundKey == null)
                    _buttonStaticBackgroundKey = CreateInstanceEx(ButtonStaticBackground);
                return _buttonStaticBackgroundKey;
            }
        }

        public static ResourceKey ButtonStaticBorderKey
        {
            get
            {
                if (_buttonStaticBorderKey == null)
                    _buttonStaticBorderKey = CreateInstanceEx(ButtonStaticBorder);
                return _buttonStaticBorderKey;
            }
        }

        public static ResourceKey ButtonMouseOverBackgroundKey
        {
            get
            {
                if (_buttonMouseOverBackgroundKey == null)
                    _buttonMouseOverBackgroundKey = CreateInstanceEx(ButtonMouseOverBackground);
                return _buttonMouseOverBackgroundKey;
            }
        }

        public static ResourceKey ButtonMouseOverBorderKey
        {
            get
            {
                if (_buttonMouseOverBorderKey == null)
                    _buttonMouseOverBorderKey = CreateInstanceEx(ButtonMouseOverBorder);
                return _buttonMouseOverBorderKey;
            }
        }

        public static ResourceKey ButtonPressedBackgroundKey
        {
            get
            {
                if (_buttonPressedBackgroundKey == null)
                    _buttonPressedBackgroundKey = CreateInstanceEx(ButtonPressedBackground);
                return _buttonPressedBackgroundKey;
            }
        }

        public static ResourceKey ButtonPressedBorderKey
        {
            get
            {
                if (_buttonPressedBorderKey == null)
                    _buttonPressedBorderKey = CreateInstanceEx(ButtonPressedBorder);
                return _buttonPressedBorderKey;
            }
        }

        public static ResourceKey ButtonDisabledBackgroundKey
        {
            get
            {
                if (_buttonDisabledBackgroundKey == null)
                    _buttonDisabledBackgroundKey = CreateInstanceEx(ButtonDisabledBackground);
                return _buttonDisabledBackgroundKey;
            }
        }

        public static ResourceKey ButtonDisabledBorderKey
        {
            get
            {
                if (_buttonDisabledBorderKey == null)
                    _buttonDisabledBorderKey = CreateInstanceEx(ButtonDisabledBorder);
                return _buttonDisabledBorderKey;
            }
        }

        public static ResourceKey ButtonDisabledForegroundKey
        {
            get
            {
                if (_buttonDisabledForegroundKey == null)
                    _buttonDisabledForegroundKey = CreateInstanceEx(ButtonDisabledForeground);
                return _buttonDisabledForegroundKey;
            }
        }
        #endregion
        //
    }
}
