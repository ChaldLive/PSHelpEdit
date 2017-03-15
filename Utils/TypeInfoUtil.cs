using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;

namespace PSHelpEdit.Utils
{
    public class TypeInfoUtil
    {
        #region ♦ Private fields ♦
        private static TypeInfoUtil _instance;
        private List<string> _typeInfoNames;
        #endregion
        //
        #region ♦ Constructors ♦
        /// <summary>
        /// 
        /// </summary>
        protected TypeInfoUtil()
        {

        }
        #endregion
        //
        #region ♦ Public properties. ♦
        public static TypeInfoUtil Instance
        {
            get
            {
                if (TypeInfoUtil._instance == null)
                    TypeInfoUtil._instance = new TypeInfoUtil();
                return TypeInfoUtil._instance;
            }
        }

        public List<string> TypeInfoNames
        {
            get
            {
                if (_typeInfoNames == null)
                {
                    _typeInfoNames = LoadOrMapTypeInfoNames();
                }
                return _typeInfoNames;
            }
        }
        #endregion
        //
        #region ♦ Private Methods. ♦
        private List<string> LoadOrMapTypeInfoNames()
        {
            List<string> typeInfoNames = TryLoadFromFileOfInfotypes();
            return typeInfoNames;
        }
        private List<string> TryLoadFromFileOfInfotypes()
        {
            List<string> result = new List<string>();
            string stdTypesFileName = string.Empty;
            if (!DoesStdTypesFileExist(out stdTypesFileName))
            {
                foreach (string parameterValueType in Defines.ParameterValueTypes)
                {
                    result.Add(parameterValueType);
                }
            }
            else
            {
                try
                {
                    XDocument doc = XDocument.Load(stdTypesFileName);
                    XElement rootElement = doc.Root;
                    if (rootElement != null)
                    {
                        foreach (XElement element in rootElement.Elements())
                        {
                            string definedValue = element.Value.ToString();
                            result.Add(definedValue);
                        }
                    }
                }
                catch (Exception)
                {
                    foreach (string parameterValueType in Defines.ParameterValueTypes)
                    {
                        result.Add(parameterValueType);
                    }
                }
            }
            return result;
        }

        private bool DoesStdTypesFileExist(out string result)
        {
            bool tmpResult = false;
            result = string.Empty;
            Assembly ass = Assembly.GetExecutingAssembly();
            if (ass != null)
            {
                string path = ass.Location;
                string fileName = string.Format(@"{0}\{1}", System.IO.Path.GetDirectoryName(ass.Location), Defines.DotNetTypesFileName);
                if (System.IO.File.Exists(fileName))
                {
                    result = fileName;
                    tmpResult = true;
                }
            }
            return tmpResult;
        }

        #endregion
        //
        #region ♦ Abstract virtual methods. ♦
        #endregion
    }
}
