using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PSHelpEdit.Utils
{
    /// <summary>
    /// Class ParamUtil.
    /// </summary>
    public static class ParamUtil
    {
        /// <summary>
        /// Static hjælper metode, der teset om en tekst streng er korrekt udfyldt eller null.
        /// Er værdien null kastes der en Exception af type ArgumentNullEception
        /// </summary>
        /// <param name="value">
        /// Værdien der skal testes
        /// </param>
        /// <param name="param">
        /// Navnet på den in parameter, på en metode, der testes.
        /// </param>
        /// <param name="msg">
        /// En string.Format ting, der gør det lidt nemmere at tilføje 
        /// </param>
        /// <param name="par">
        /// En list af parametre, der kan formateres til en streng som string.Format
        /// f.eks string.Format("en værdi:{0} en anden værdi:{1}", enværdi, enandenværdi);
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsNull(string value, string param, string msg, params object[] par)
        {
            if (string.IsNullOrEmpty(value))
            {
                string local = string.Format(msg, par);
                throw new ArgumentNullException(param, local);
            }
        }
        /// <summary>
        /// Static hjælper metode, der teset om en tekst streng er korrekt udfyldt eller null.
        /// Er værdien null kastes der en Exception af type ArgumentNullEception
        /// </summary>
        /// <param name="value">
        /// Værdien der skal testes
        /// </param>
        /// <param name="param">
        /// Navnet på den in parameter, på en metode, der testes.
        /// </param>
        /// <param name="msg">
        /// En string.Format ting, der gør det lidt nemmere at tilføje 
        /// </param>
        /// <param name="par">
        /// En list af parametre, der kan formateres til en streng som string.Format
        /// f.eks string.Format("en værdi:{0} en anden værdi:{1}", enværdi, enandenværdi);
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsNull(object value, string param, string msg, params object[] par)
        {
            if (value == null)
            {
                string local = string.Format(msg, par);
                throw new ArgumentNullException(param, local);
            }
        }
        /// <summary>
        /// Determines whether the specified value is true.
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <param name="param">
        /// </param>
        /// <param name="msg">
        /// </param>
        /// <param name="par">
        /// </param>
        public static void IsTrue(bool value, string param, string msg, params object[] par)
        {
            if (value == true)
            {
                string local = string.Format(msg, par);
                throw new ArgumentException(param, local);
            }
        }
        /// <summary>
        /// Determines whether the specified value is false.
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <param name="param">
        /// </param>
        /// <param name="msg">
        /// </param>
        /// <param name="par">
        /// </param>
        public static void IsFalse(bool value, string param, string msg, params object[] par)
        {
            if (value == false)
            {
                string local = string.Format(msg, par);
                throw new ArgumentException(param, local);
            }
        }

        /// <summary>
        /// Static hjælper metode, der teset om en tekst streng er korrekt udfyldt eller null.
        /// Er værdien null kastes der en Exception af type ArgumentNullEception
        /// </summary>
        /// <param name="value">
        /// Værdien der skal testes
        /// </param>
        /// <param name="param">
        /// Navnet på den in parameter, på en metode, der testes.
        /// </param>
        /// <param name="msg">
        /// En string.Format ting, der gør det lidt nemmere at tilføje 
        /// </param>
        /// <param name="par">
        /// En list af parametre, der kan formateres til en streng som string.Format
        /// f.eks string.Format("en værdi:{0} en anden værdi:{1}", enværdi, enandenværdi);
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsNull(DateTime value, string param, string msg, params object[] par)
        {
            if (value == DateTime.MaxValue || value == DateTime.MinValue)
            {
                string local = string.Format(msg, par);
                throw new ArgumentOutOfRangeException(param, local);
            }
        }
        /// <summary>
        /// Static hjælper metode, der teset om en tekst streng er korrekt udfyldt og er navnet på en fil.
        /// Er værdien null kastes der en Exception af type ArgumentNullEception, og findes der ikke en fil
        /// med dette navn i systemet, kastes der en Exception af typen ArgumentException.
        /// </summary>
        /// <param name="value">
        /// Værdien der skal testes
        /// </param>
        /// <param name="param">
        /// Navnet på den in parameter, på en metode, der testes.
        /// </param>
        /// <param name="msg">
        /// En string.Format ting, der gør det lidt nemmere at tilføje 
        /// </param>
        /// <param name="par">
        /// En list af parametre, der kan formateres til en streng som string.Format
        /// f.eks string.Format("en værdi:{0} en anden værdi:{1}", enværdi, enandenværdi);
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsFile(string value, string param, string msg, params object[] par)
        {
            IsNull(value, param, msg, par);
            if (!File.Exists(value))
            {
                string local = string.Format(msg, par);
                throw new ArgumentException(local, param);
            }
        }
        /// <summary>
        /// Static hjælper metode, der teset om en tekst streng er korrekt udfyldt og er navnet på en folder sti.
        /// Er værdien null kastes der en Exception af type ArgumentNullEception, og findes der ikke en sti
        /// med dette navn i systemet, kastes der en Exception af typen ArgumentException.
        /// </summary>
        /// <param name="value">
        /// Værdien der skal testes
        /// </param>
        /// <param name="param">
        /// Navnet på den in parameter, på en metode, der testes.
        /// </param>
        /// <param name="msg">
        /// En string.Format ting, der gør det lidt nemmere at tilføje 
        /// </param>
        /// <param name="par">
        /// En list af parametre, der kan formateres til en streng som string.Format
        /// f.eks string.Format("en værdi:{0} en anden værdi:{1}", enværdi, enandenværdi);
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsDir(string value, string param, string msg, params object[] par)
        {
            IsNull(value, param, msg, par);
            if (!Directory.Exists(value))
            {
                string local = string.Format(msg, par);
                throw new ArgumentException(local, param);
            }
        }
    }
}
