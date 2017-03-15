using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSHelpEdit.Interfaces;

namespace PSHelpEdit.Models
{

    public class HelpItemEqualityComparer : IEqualityComparer<HelpItemBase>
    {
        public bool Equals(HelpItemBase x, HelpItemBase y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            string xValue = x.NameValue;
            string yValue = y.NameValue;

            return xValue == yValue;

        }

        public int GetHashCode(HelpItemBase obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;
            //            
            int hashItemTitle = obj.NameValue.GetHashCode();
            int hashItemValue = string.IsNullOrEmpty(obj.Name) ? 0 : obj.Name.GetHashCode();
            //
            return hashItemTitle ^ hashItemValue;
        }
    }
}
