﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasivaF24.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//   Informacion integrantes formulario 24 masiva.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Morales
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    using Sat.DeclaracionesAnuales.Attributes;
    using Sat.DeclaracionesAnuales.CargaMasiva.Models.Base;
    using Sat.DeclaracionesAnuales.TxtReader;

    #endregion

    /// <summary>
    ///     Informacion integrantes formulario 24 masiva.
    /// </summary>
    public class MasivaF24 : InformacionIntegrantesF24, IMasiva, IMasivaExtraccion<MasivaF24>
    {
        #region Fields

        /// <summary>
        /// RFC del integrante
        /// </summary>
        private string mas219556;

        /// <summary>
        /// Utilidad gravable
        /// </summary>
        private long? mas219557;

        /// <summary>
        /// Pérdida fiscal
        /// </summary>
        private long? mas219558;

        /// <summary>
        /// Impuesto sobre la renta del ejercicio
        /// </summary>
        private long? mas219559;

        /// <summary>
        /// Pagos provisionales efectuados por el coordinado
        /// </summary>
        private long? mas219560;

        /// <summary>
        /// ISR a cargo del ejercicio
        /// </summary>
        private long? mas219561;

        /// <summary>
        /// ISR a favor del ejercicio
        /// </summary>
        private long? mas219562;

        /// <summary>
        /// PTU por distribuir
        /// </summary>
        private long? mas219563;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        public MasivaF24()
        {
            this.ObtenerNombreAuxiliar();
        }

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">Valor del auxiliar.</param>
        public MasivaF24(string auxiliarValor)
            : base(auxiliarValor)
        {
            this.ObtenerNombreAuxiliar();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the concepto.
        /// </summary>
        [TxtReader(1)]
        [JsonIgnore]
        public string Concepto { get; set; }

        /// <summary>
        ///     Lista de elementos de carga masiva.
        /// </summary>
        public List<object> ListaDeElementos { get; private set; }

        /// <summary>
        ///     Lista de elementos de carga masiva.
        /// </summary>
        public List<MasivaF24> ListaElementosMasivos { get; set; }

        /// <summary>
        /// RFC del integrante
        /// </summary>
        [TxtReader(2)]
        public string MAS219556
        {
            get
            {
                return this.RfcDelIntegrante;
            }

            set
            {
                this.mas219556 = value;
                this.RfcDelIntegrante = this.mas219556;
                this.Rfc = this.RfcDelIntegrante;
            }
        }

        /// <summary>
        /// Utilidad gravable
        /// </summary>
        [TxtReader(3)]
        public long? MAS219557
        {
            get
            {
                return this.UtilidadGravable;
            }

            set
            {
                this.mas219557 = value;
                this.UtilidadGravable = this.mas219557;
            }
        }

        /// <summary>
        /// Pérdida fiscal
        /// </summary>
        [TxtReader(4)]
        public long? MAS219558
        {
            get
            {
                return this.PerdidaFiscal;
            }

            set
            {
                this.mas219558 = value;
                this.PerdidaFiscal = this.mas219558;
            }
        }

        /// <summary>
        /// Impuesto sobre la renta del ejercicio
        /// </summary>
        [TxtReader(5)]
        public long? MAS219559
        {
            get
            {
                return this.ImpuestoSobreLaRentaDelEjercicio;
            }

            set
            {
                this.mas219559 = value;
                this.ImpuestoSobreLaRentaDelEjercicio = this.mas219559;
            }
        }

        /// <summary>
        /// Pagos provisionales efectuados por el coordinado
        /// </summary>
        [TxtReader(6)]
        public long? MAS219560
        {
            get
            {
                return this.PagosProvisionalesEfectuadosPorElCoordinado;
            }

            set
            {
                this.mas219560 = value;
                this.PagosProvisionalesEfectuadosPorElCoordinado = this.mas219560;
            }
        }

        /// <summary>
        /// ISR a cargo del ejercicio
        /// </summary>
        [TxtReader(7)]
        public long? MAS219561
        {
            get
            {
                return this.IsrACargoDelEjercicio;
            }

            set
            {
                this.mas219561 = value;
                this.IsrACargoDelEjercicio = this.mas219561;
            }
        }

        /// <summary>
        /// ISR a favor del ejercicio
        /// </summary>
        [TxtReader(8)]
        public long? MAS219562
        {
            get
            {
                return this.IsrAFavorDelEjercicio;
            }

            set
            {
                this.mas219562 = value;
                this.IsrAFavorDelEjercicio = this.mas219562;
            }
        }

        /// <summary>
        /// PTU por distribuir
        /// </summary>
        [TxtReader(9)]
        public long? MAS219563
        {
            get
            {
                return this.PtuPorDistribuir;
            }

            set
            {
                this.mas219563 = value;
                this.PtuPorDistribuir = this.mas219563;
            }
        }

        /// <summary>
        /// Concepto RowIndex
        /// </summary>
        [TxtReader(0)]
        [JsonIgnore]
        public int RowIndex
        {
            get
            {
                return this.Indice;
            }

            set
            {
                this.Indice = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Crea la lista de elementos de carga masiva.
        /// </summary>
        /// <param name="txt">
        /// TxtReader a partir del archivo.
        /// </param>
        /// <param name="registrosFiltrados">
        /// registros filtrados.
        /// </param>
        public void CrearListaDeElementos(TxtReader txt, HashSet<string> registrosFiltrados)
        {
            this.ListaElementosMasivos = txt.ReadVariableLength<MasivaF24>(
                registrosFiltrados.ToArray(),
                this.PrimeraLineaEsEncabezado,
                this.Separador,
                this.EliminarEspaciosEnBlanco);

            this.ListaDeElementos = new List<object>(this.ListaElementosMasivos);
        }

        /// <summary>
        /// Ejecuta los calculos para la carga masiva.
        /// </summary>
        /// <param name="parametros">
        /// Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        /// SubRegimenes de la declaración
        /// </param>
        /// <returns>
        /// Un diccionario con el resultado de los calculos
        /// </returns>
        public Dictionary<string, string> EjecutarCalculos(
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            return HelpersMasivas.EjecutarCalculos(
                                        this.ListaElementosMasivos,
                                        parametros,
                                        subregimenes,
                                        this.ObtenerCalculos().ToArray(),
                                        this.AuxiliarNombre,
                                        this.AuxiliarValor);
        }

        /// <summary>
        /// Ejecuta los procesos de la carga masiva.
        /// </summary>
        /// <param name="parametros">
        /// Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        /// SubRegimenes de la declaración
        /// </param>
        public void EjecutarProcesos(Dictionary<string, string> parametros, HashSet<string> subregimenes)
        {
        }

        /// <summary>
        /// Obtiene los errores asociados a la ejecución de las reglas, si no hubo errores regresa nulo.
        /// </summary>
        /// <param name="parametros">
        /// Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        /// SubRegimenes de la declaración
        /// </param>
        /// <returns>
        /// Un mensaje con todos los errores que ocurrieron durante la ejecución de las reglas
        /// </returns>
        public string EjecutarReglas(Dictionary<string, string> parametros, HashSet<string> subregimenes)
        {
            return HelpersMasivas.GetAllErrorMessages(
                                                this.ListaElementosMasivos,
                                                parametros,
                                                subregimenes,
                                                this.ObtenerReglas().ToArray());
        }

        /// <summary>
        /// Obtiene los errores por registros
        /// </summary>
        /// <param name="parametros">
        /// Diccionario de propiedades externas
        /// </param>
        /// <param name="subregimenes">
        /// Lista de subregimenes
        /// </param>
        /// <returns>
        /// Lista de ErrorModel
        /// </returns>
        public List<ErrorModel> Errors(Dictionary<string, string> parametros, HashSet<string> subregimenes)
        {
            var result = new List<ErrorModel>();

            result.AddRange(this.ValidarRfc());
            result.AddRange(this.ValidarUtilidadGravable());
            result.AddRange(this.ValidarPerdidaFiscal());
            result.AddRange(this.ValidarImpuestoSobreLaRentaDelEjercicio());
            result.AddRange(this.ValidarPagosProvisionales());
            result.AddRange(this.ValidarIsrACargoDelEjercicio());
            result.AddRange(this.ValidarIsrAFavorDelEjercicio());
            result.AddRange(this.ValidarPtuPorDistribuir());

            return result;
        }

        /// <summary>
        /// Obtiene los calculos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los calculos a ejecutar
        /// </returns>
        public List<HelpersMasivas.Calculate<MasivaF24>> ObtenerCalculos()
        {
            return new List<HelpersMasivas.Calculate<MasivaF24>>
                       {
                           //CalculoC6,
                           //CalculoC7
                       };
        }

        /// <summary>
        /// Obtiene el nombre del auxiliar.
        /// </summary>
        public void ObtenerNombreAuxiliar()
        {
            this.AuxiliarNombre = "AUXINTG";
        }

        /// <summary>
        ///     Obtiene los procesos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los procesos a ejecutar
        /// </returns>
        public List<HelpersMasivas.ProcessExecute<MasivaF24>> ObtenerProcesos()
        {
            return null;
        }

        /// <summary>
        ///     Obtiene las reglas de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen las reglas a ejecutar
        /// </returns>
        public List<HelpersMasivas.Ruler<MasivaF24>> ObtenerReglas()
        {
            return new List<HelpersMasivas.Ruler<MasivaF24>> { ReglaRfcDuplicado };
        }

        #endregion

        #region Methods

        #region Calculos

        /// <summary>
        ///     Calculo C7 A CARGO ISR PERSONAS MORALES. RÉGIMEN DE LOS COORDINADOS. IMPUESTO DE SUS INTEGRANTES.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF24.
        /// </param>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        /// <returns>
        ///     C7 con la suma de todos los "A Cargo"
        /// </returns>
        private static Tuple<string, string> CalculoC7(
            IEnumerable<MasivaF24> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var suma = entrada.Sum(x => x.MAS219561 ?? 0);
            return new Tuple<string, string>("C7", suma.ToString());
        }

        /// <summary>
        ///     Calculo C6 A FAVOR ISR PERSONAS MORALES. RÉGIMEN DE LOS COORDINADOS. IMPUESTO DE SUS INTEGRANTES.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF24.
        /// </param>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        /// <returns>
        ///     C6 con la suma de todos los "A Favor"
        /// </returns>
        private static Tuple<string, string> CalculoC6(
            IEnumerable<MasivaF24> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var suma = entrada.Sum(x => x.MAS219562 ?? 0);
            return new Tuple<string, string>("C6", suma.ToString());
        }

        #endregion

        #region Reglas

        /// <summary>
        /// Busca RFC Duplicados
        /// </summary>
        /// <param name="entrada">
        /// Lista de objetos MasivaF24
        /// </param>
        /// <param name="parametros">
        /// Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        /// SubRegimenes de la declaración
        /// </param>
        /// <returns>
        /// Lista de ErrorModel
        /// </returns>
        private static List<ErrorModel> ReglaRfcDuplicado(
            IEnumerable<MasivaF24> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            return HelpersMasivas.EvaluarRfcDuplicado(entrada, parametros, subregimenes);
        }

        #endregion

        #endregion
    }
}