// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasivaBase.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//   Clase base abstracta para las cargas masivas
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Base
{
    /// <summary>
    ///     Clase base abstracta para las cargas masivas
    /// </summary>
    public abstract class MasivaBase : MasivaDestructible
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        protected MasivaBase()
        {
            this.AuxiliarValor = "1";
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">
        /// Valor del auxiliar.
        /// </param>
        protected MasivaBase(string auxiliarValor)
        {
            this.AuxiliarValor = auxiliarValor;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Nombre del auxiliar.
        /// </summary>
        public string AuxiliarNombre { get; set; }

        /// <summary>
        ///     Valor del auxiliar.
        /// </summary>
        public string AuxiliarValor { get; private set; }

        /// <summary>
        ///     Indica si se eliminaran espacios en blanco.
        /// </summary>
        public bool EliminarEspaciosEnBlanco
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///     Indice del elemento.
        /// </summary>
        public int Indice { get; set; }

        /// <summary>
        ///     Indica si la primera linea es el encabezado.
        /// </summary>
        public bool PrimeraLineaEsEncabezado
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        ///     RFC Contribuyente.
        /// </summary>
        public string Rfc { get; set; }

        /// <summary>
        ///     Establece el separador de los elementos del archivo de texto.
        /// </summary>
        public char Separador
        {
            get
            {
                return '|';
            }
        }

        #endregion
    }
}