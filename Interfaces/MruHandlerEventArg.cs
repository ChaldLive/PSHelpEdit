using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSHelpEdit.General
{


    public class MruHandlerEventArg
    {
        #region MurEventkodes.
        public enum MruHandlerEventKodes : int
        {
            evtLoding,
            evtLoaded,
            evtSaving,
            evtSaved,
            evtFileAdded,
            evtFileRemoved,
        }
        #endregion
        //
        #region Private fields
        private string _info;
        private MruHandlerEventKodes _kode;
        #endregion
        //
        #region MruHandlerEventArg
        public MruHandlerEventArg(string info, MruHandlerEventKodes kode)
        {
            Info = info;
            Kode = kode;
        }
        #endregion
        //
        #region Public propeties
        public string Info
        {
            get{return _info;}
            set{_info = value;}
        }

        public MruHandlerEventKodes Kode
        {
            get{return _kode;}
            set{_kode = value;}
        }
        #endregion
    }
}
