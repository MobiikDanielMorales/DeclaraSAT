using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Base
{
    public abstract class MasivaDestructible : IDisposable
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Finalizador / Destructor
        /// </summary>
        ~MasivaDestructible()
        {
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Obtiene un valor que indica si se hace el dispose
        /// </summary>
        protected bool Disposed { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Realiza tareas definidas por la aplicación asociadas con la liberación de recursos
        /// </summary>
        public void Dispose()
        {
            this.Dispose(false);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Libera los recursos del objeto.
        /// </summary>
        /// <param name="disposing">
        /// Se esta haciendo Dispose? de lo contrario finalizamos
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            this.Disposed = true;
        }

        #endregion
    }
}
