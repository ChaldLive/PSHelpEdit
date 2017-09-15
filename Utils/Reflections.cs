using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace PSHelpEdit.Utils
{
    /// <summary>
    /// Class Reflections.
    /// </summary>
    public class Reflections
    {
        #region Private fields
        private static Reflections _instance;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Reflections"/> class.
        /// </summary>
        protected Reflections()
        {
        }
        #endregion
        //
        #region Public properties.
        public static Reflections Instance
        {
            get
            {
                if (Reflections._instance == null)
                    Reflections._instance = new Reflections();
                return Reflections._instance;
            }
        }
        #endregion
        //
        #region Public static Methods.
        /// <summary>
        /// Gets all system types.
        /// </summary>
        /// <returns>
        ///  IEnumerable&lt;Type&gt;.
        /// </returns>
        public IEnumerable<Type> GetAllSystemTypes()
        {
            Assembly mscorlib = typeof(string).Assembly;
            return mscorlib.GetTypes().Where(t => t.Namespace == "System");
        }
        /// <summary>
        /// Gets the system type names.
        /// </summary>
        /// <returns>
        ///  IEnumerable&lt;System.String&gt;.
        /// </returns>
        public IEnumerable<string> GetSystemTypeNames()
        {
            IEnumerable<Type> types = GetAllSystemTypes();
            return types.Select(t => t.Name);
        }
        #endregion
        //
        #region Protected Methods.
        #endregion
        //
        #region Private Methods.
        #endregion
        //
        #region Abstract virtual methods.
        #endregion
    }
}
