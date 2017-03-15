using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSHelpEdit.General
{
    
    public class ModelEventArg
    {
        #region Public event type
        public enum EventTypeKode : int
        {
            evtNone = 0,
            evtLoaded = 1,
            evtSaveFileAs = 2,
            evtLodFile = 3
        }
        #endregion

        #region Private fields
        private string _eventInfo;
        private EventTypeKode _eventKode;
        #endregion
        //
        #region ModelEventArg
        public ModelEventArg(string info, EventTypeKode kode)
        {
            EventInfo = info;
            EventKode = kode;
        }
        #endregion
        //
        #region Public properties
        public string EventInfo
        {
            get{return _eventInfo;}
            set{_eventInfo = value;}
        }

        public EventTypeKode EventKode
        {
            get{return _eventKode; }
            set{ _eventKode = value;}
        }
        #endregion
   }
}
