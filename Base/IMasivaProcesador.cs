using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Base
{
    public interface IMasivaProcesador
    {
         /// <summary>
        ///  Crea la lista de elementos de carga masiva.
        /// </summary>
        /// <param name="txt">
        ///     TxtReader a partir del archivo.
        /// </param>
        /// <param name="registrosFiltrados">
        ///     registros filtrados.
        /// </param>
        void CrearListaDeElementos(TxtReader.TxtReader txt, HashSet<string> registrosFiltrados);

        /// <summary>
        ///     Ejecuta los calculos para la carga masiva.
        /// </summary>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        /// <returns>
        ///     Un diccionario con el resultado de los calculos
        /// </returns>
        Dictionary<string, string> EjecutarCalculos(Dictionary<string, string> parametros, HashSet<string> subregimenes);

        /// <summary>
        ///     Ejecuta los procesos de la carga masiva.
        /// </summary>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        void EjecutarProcesos(Dictionary<string, string> parametros, HashSet<string> subregimenes);

        /// <summary>
        ///     Obtiene los errores asociados a la ejecución de las reglas, si no hubo errores regresa nulo.
        /// </summary>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        /// <returns>
        ///     Un mensaje con todos los errores que ocurrieron durante la ejecución de las reglas
        /// </returns>
        string EjecutarReglas(Dictionary<string, string> parametros, HashSet<string> subregimenes);

        List<object> ObtenerListaDeElementos();

    }
}
