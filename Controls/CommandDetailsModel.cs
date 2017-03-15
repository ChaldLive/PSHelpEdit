using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSHelpEdit.Models;

namespace PSHelpEdit.Controls
{
    /// <summary>
    /// Class CommandDetailsModel.
    /// </summary>
    /// <seealso cref="PSHelpEdit.Models.ModelBase" />
    public class CommandDetailsModel : ModelBase
    {
        #region Private fields
        private DescriptionItem _descriptionItem;
        private CopyrightItem _copyrightItem;
        private VersionItem _versionItem;
        private DescriptionItem _commandDescriptionItem;
        #endregion
        //
        #region public CommandDetailsModel()
        public CommandDetailsModel()
        {

        }
        #endregion
        //
        #region Public properties.
        public string DescriptionValue
        {
            get
            {
                if(DescriptionItem != null && DescriptionItem.ParaValue != null)
                    return DescriptionItem.ParaValue;
                return string.Empty;
            }
            set
            {
                OnPropertyChanging();
                DescriptionItem.ParaValue = value;
                OnPropertyChanged();
            }
        }

        public string CopyrightValue
        {
            get
            {
                if (CopyrightItem != null && CopyrightItem.Value != null)
                    return CopyrightItem.Value.ToString();
                return string.Empty;
            }
            set
            {
                OnPropertyChanging();
                CopyrightItem.Value = value;
                OnPropertyChanged();
            }
        }

        public string VersionValue
        {
            get
            {
                if (VersionItem != null && VersionItem.Value != null)
                    return VersionItem.Value.ToString();
                return string.Empty;
            }
            set
            {
                OnPropertyChanging();
                VersionItem.Value = value;
                OnPropertyChanged();
            }
        }
        public string CommandDescriptionValue
        {
            get
            {
                if (CommandDescriptionItem != null && CommandDescriptionItem.ParaValue != null)
                    return CommandDescriptionItem.ParaValue;
                return string.Empty;
            }
            set
            {
                OnPropertyChanging();
                CommandDescriptionItem.ParaValue = value;
                OnPropertyChanged();
            }
        }

        public DescriptionItem DescriptionItem
        {
            get
            {
                return _descriptionItem;
            }
            set
            {
                OnPropertyChanging();
                _descriptionItem = value;
                OnPropertyChanged();
            }
        }

        public CopyrightItem CopyrightItem
        {
            get{return _copyrightItem;}
            set
            {
                OnPropertyChanging();
                _copyrightItem = value;
                OnPropertyChanged();
            }
        }

        public VersionItem VersionItem
        {
            get{return _versionItem;}
            set
            {
                OnPropertyChanging();
                _versionItem = value;
                OnPropertyChanged();
            }
        }
        public DescriptionItem CommandDescriptionItem
        {
            get{return _commandDescriptionItem;}
            set
            {
                OnPropertyChanging();
                _commandDescriptionItem = value;
                OnPropertyChanged();
            }
        }
        #endregion
        //
        #region MyRegion
        public void UpdateData(CommandItem currentCmd)
        {
            if (currentCmd == null)
                return;
            //
            DetailsItem di = currentCmd.GetChildWidthName<DetailsItem>(Defines.HelpItemTypeName(HelpItemTypes.details));
            if(di != null)
            {
                DescriptionItem = di.GetChildWidthName<DescriptionItem>(Defines.HelpItemTypeName(HelpItemTypes.description));
                CopyrightItem = di.GetChildWidthName<CopyrightItem>(Defines.HelpItemTypeName(HelpItemTypes.copyright));
                VersionItem = di.GetChildWidthName<VersionItem>(Defines.HelpItemTypeName(HelpItemTypes.version));
            }
            CommandDescriptionItem = currentCmd.GetChildWidthName<DescriptionItem>(Defines.HelpItemTypeName(HelpItemTypes.description));

            OnPropertyChangedForAll();
        }
        #endregion
        //
        #region MyRegion
        private void OnPropertyChangedForAll()
        {
            OnPropertyChanged("VersionValue");
            OnPropertyChanged("CopyrightValue");
            OnPropertyChanged("DescriptionValue");
            OnPropertyChanged("CommandDescriptionValue");
        }
        #endregion
    }
}
