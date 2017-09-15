using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSHelpEdit.Interfaces;

namespace PSHelpEdit.Models
{
    public class HelpItemAttribute : IHelpItemAttribute
    {
        #region Private fields
        private string _name;
        private object _value;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public HelpItemAttribute()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpItemProperty"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public HelpItemAttribute(string name, object value)
        {
            _name = name;
            _value = value;
        }
        #endregion
        //
        #region IHelpItemProperty Members

        public virtual string Name
        {
            get{return _name;}
            set{_name = value;}
        }

        public virtual object Value
        {
            get{return _value;}
            set{_value = value;}
        }

        public string ValueText
        {
            get
            {
                if (Value == null)
                {
                    throw new InvalidOperationException("Value property er ikke initialiseret");
                }
                return Value.ToString();
            }
        }

        #endregion
    }
}
