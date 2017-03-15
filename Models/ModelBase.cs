using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PSHelpEdit.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ModelBase : Freezable, INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Public events 
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion
        //
        #region Constructors 
        /// <summary>
        /// 
        /// </summary>
        public ModelBase()
        {
        }
        #endregion
        //
        #region protected override Freezable CreateInstanceCore()
        /// <summary>
        /// Creates the instance core.
        /// </summary>
        /// <returns>
        ///  System.Windows.Freezable.
        /// </returns>
        protected override Freezable CreateInstanceCore()
        {
            return new ModelBase();
        }
        #endregion
        //            
        #region Property changed implementation
        /// <summary>
        /// Called when [property notify changed].
        /// </summary>
        /// <param name="propertyName">
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Called when [property notify changing].
        /// </summary>
        /// <param name="propertyName">
        /// </param>
        protected virtual void OnPropertyChanging([CallerMemberName]string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
        #endregion
        //
        #region public virtual void OnModelKeyDown(object model, System.Windows.Input.KeyEventArgs e)

        /// <summary>
        /// Handles the <see cref="E:ModelKeyDown" /> event.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs" /> instance containing the event data.</param>
        public virtual void OnModelKeyDown(object model, System.Windows.Input.KeyEventArgs e)
        {

        }
        #endregion
    }
}
