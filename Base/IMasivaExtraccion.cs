using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Base
{
    public interface IMasivaExtraccion<T>
    {
        List<T> ListaElementosMasivos { get; set; }

        /// <summary>
        ///     Obtiene los calculos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los calculos a ejecutar
        /// </returns>
        List<HelpersMasivas.Calculate<T>> ObtenerCalculos();


        /// <summary>
        /// Obtiene los procesos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los procesos a ejecutar
        /// </returns>
        List<HelpersMasivas.ProcessExecute<T>> ObtenerProcesos();

        /// <summary>
        /// Obtiene las reglas de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen las reglas a ejecutar
        /// </returns>
        List<HelpersMasivas.Ruler<T>> ObtenerReglas();

    }
}
