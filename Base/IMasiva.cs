// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMasiva.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//   Interface para la carga Masiva.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Base
{
    #region using

    using System.Collections.Generic;

    using Sat.DeclaracionesAnuales.TxtReader;

    #endregion

    /// <summary>
    ///     Interface para la carga Masiva.
    /// </summary>
    public interface IMasiva
    {
        #region Public Properties

        /// <summary>
        ///     Lista de elementos de carga masiva.
        /// </summary>
        List<object> ListaDeElementos { get; }

        /// <summary>
        /// Gets or sets the row index.
        /// </summary>
        int RowIndex { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///  Crea la lista de elementos de carga masiva.
        /// </summary>
        /// <param name="txt">
        ///     TxtReader a partir del archivo.
        /// </param>
        /// <param name="registrosFiltrados">
        ///     registros filtrados.
        /// </param>
        void CrearListaDeElementos(TxtReader txt, HashSet<string> registrosFiltrados);

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

        /// <summary>
        ///     Obtiene los errores de las validaciones.
        /// </summary>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        List<ErrorModel> Errors(Dictionary<string, string> parametros, HashSet<string> subregimenes);

        /// <summary>
        /// Obtiene el nombre del auxiliar.
        /// </summary>
        void ObtenerNombreAuxiliar();

        #endregion
    }
}