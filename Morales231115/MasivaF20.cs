﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasivaF20.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//   Informacion integrantes formulario 20 masiva.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Morales
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Newtonsoft.Json;

    using Sat.DeclaracionesAnuales.Attributes;
    using Sat.DeclaracionesAnuales.CargaMasiva.Models.Base;
    using Sat.DeclaracionesAnuales.Exeptions;
    using Sat.DeclaracionesAnuales.TxtReader;

    #endregion

    /// <summary>
    ///     Informacion integrantes formulario 20 masiva.
    /// </summary>
    public class MasivaF20 : InformacionIntegrantesF20, IMasiva, IMasivaExtraccion<MasivaF20>
    {
        #region Constants

        private const string C7IsrACargo   = "SUMA111119";
        private const string C6IsrAFavor   = "SUMA111159";
        private const string C7ImpacACargo = "SUMA121105";
        private const string C6ImpacAFavor = "SUMA121125";
        private const string C7IetuACargo  = "SUMA195179";
        private const string C6IetuAFavor  = "SUMA195180";

        #endregion

        #region Fields

        /// <summary>
        /// ISR a cargo
        /// </summary>
        private long? mas111119;

        /// <summary>
        /// ISR a favor
        /// </summary>
        private long? mas111159;

        /// <summary>
        /// Pérdida fiscal
        /// </summary>
        private long? mas111175;

        /// <summary>
        /// IMPAC a cargo
        /// </summary>
        private long? mas121105;

        /// <summary>
        /// IMPAC a favor
        /// </summary>
        private long? mas121125;

        /// <summary>
        /// Ingresos gravados para IETU
        /// </summary>
        private long? mas195175;

        /// <summary>
        /// Deducciones autorizadas para IETU
        /// </summary>
        private long? mas195176;

        /// <summary>
        /// Base gravable para IETU
        /// </summary>
        private long? mas195177;

        /// <summary>
        /// Deducciones que exceden a los ingresos
        /// </summary>
        private long? mas195178;

        /// <summary>
        /// IETU a cargo
        /// </summary>
        private long? mas195179;

        /// <summary>
        /// IETU a favor - Impuesto Consolidado Del Ejercicio
        /// </summary>
        private long? mas195180;

        /// <summary>
        /// PTU por distribuir
        /// </summary>
        private long? mas201025;

        /// <summary>
        /// Valor del activo (base gravable)
        /// </summary>
        private long? mas201041;

        /// <summary>
        /// Utilidad gravable
        /// </summary>
        private long? mas201307;

        /// <summary>
        /// RFC del integrante
        /// </summary>
        private string mas205194;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        public MasivaF20()
        {
            this.InicializaCampos();
        }

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">Valor del auxiliar.</param>
        public MasivaF20(string auxiliarValor)
            : base(auxiliarValor)
        {
            this.InicializaCampos();
        }

        #endregion

        #region Public Properties

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

        /// <summary>
        /// Gets or sets the concepto.
        /// </summary>
        [TxtReader(1)]
        [JsonIgnore]
        public string Concepto { get; set; }

        #region Propiedades masivas

        /// <summary>
        /// RFC del integrante
        /// </summary>
        [TxtReader(2)]
        public string MAS205194
        {
            get
            {
                return this.RfcDelIntegrante;
            }

            set
            {
                this.mas205194        = value.ToUpper();
                this.RfcDelIntegrante = this.mas205194;
                this.Rfc              = this.RfcDelIntegrante;
            }
        }

        /// <summary>
        /// Utilidad gravable
        /// </summary>
        [TxtReader(3)]
        public long? MAS201307
        {
            get
            {
                return this.UtilidadGravable;
            }

            set
            {
                this.mas201307 = value;
                this.UtilidadGravable = this.mas201307;
            }
        }

        /// <summary>
        /// Pérdida fiscal
        /// </summary>
        [TxtReader(4)]
        public long? MAS111175
        {
            get
            {
                return this.PerdidaFiscal;
            }

            set
            {
                this.mas111175 = value;
                this.PerdidaFiscal = this.mas111175;
            }
        }

        /// <summary>
        /// ISR a cargo
        /// </summary>
        [TxtReader(5)]
        public long? MAS111119
        {
            get
            {
                return this.IsrACargoDelEjercicio;
            }

            set
            {
                this.mas111119 = value;
                this.IsrACargoDelEjercicio = this.mas111119;
            }
        }

        /// <summary>
        /// ISR a favor
        /// </summary>
        [TxtReader(6)]
        public long? MAS111159
        {
            get
            {
                return this.IsrAFavorDelEjercicio;
            }

            set
            {
                this.mas111159 = value;
                this.IsrAFavorDelEjercicio = this.mas111159;
            }
        }

        /// <summary>
        /// PTU por distribuir
        /// </summary>
        [TxtReader(7)]
        public long? MAS201025
        {
            get
            {
                return this.PtuPorDistribuir;
            }

            set
            {
                this.mas201025 = value;
                this.PtuPorDistribuir = this.mas201025;
            }
        }

        /// <summary>
        /// Valor del activo (base gravable)
        /// </summary>
        [TxtReader(8)]
        public long? MAS201041
        {
            get
            {
                return this.ValorDelActivo;
            }

            set
            {
                this.mas201041 = value;
                this.ValorDelActivo = this.mas201041;
            }
        }

        /// <summary>
        /// IMPAC a cargo
        /// </summary>
        [TxtReader(9)]
        public long? MAS121105
        {
            get
            {
                return this.ImpacACargo;
            }

            set
            {
                this.mas121105 = value;
                this.ImpacACargo = this.mas121105;
            }
        }

        /// <summary>
        /// IMPAC a favor
        /// </summary>
        [TxtReader(10)]
        public long? MAS121125
        {
            get
            {
                return this.ImpacAFavor;
            }

            set
            {
                this.mas121125 = value;
                this.ImpacAFavor = this.mas121125;
            }
        }

        /// <summary>
        /// Ingresos gravados para IETU
        /// </summary>
        [TxtReader(11)]
        public long? MAS195175
        {
            get
            {
                return this.IngresosGravadosParaIetu;
            }

            set
            {
                this.mas195175 = value;
                this.IngresosGravadosParaIetu = this.mas195175;
            }
        }

        /// <summary>
        /// Deducciones autorizadas para IETU
        /// </summary>
        [TxtReader(12)]
        public long? MAS195176
        {
            get
            {
                return this.DeduccionesAutorizadasParaIetu;
            }

            set
            {
                this.mas195176 = value;
                this.DeduccionesAutorizadasParaIetu = this.mas195176;
            }
        }

        /// <summary>
        /// Base gravable para IETU
        /// </summary>
        [TxtReader(13)]
        public long? MAS195177
        {
            get
            {
                return this.BaseGravableParaIetu;
            }

            set
            {
                this.mas195177 = value;
                this.BaseGravableParaIetu = this.mas195177;
            }
        }

        /// <summary>
        /// Deducciones que exceden a los ingresos
        /// </summary>
        [TxtReader(14)]
        public long? MAS195178
        {
            get
            {
                return this.DeduccionesQueExcedenALosIngresos;
            }

            set
            {
                this.mas195178 = value;
                this.DeduccionesQueExcedenALosIngresos = this.mas195178;
            }
        }

        /// <summary>
        /// IETU a cargo
        /// </summary>
        [TxtReader(15)]
        public long? MAS195179
        {
            get
            {
                return this.IetuACargo;
            }

            set
            {
                this.mas195179 = value;
                this.IetuACargo = this.mas195179;
            }
        }

        /// <summary>
        /// Impuesto Consolidado Del Ejercicio
        /// </summary>
        [TxtReader(16)]
        public long? MAS195180
        {
            get
            {
                return this.ImpuestoConsolidadoDelEjercicio;
            }

            set
            {
                this.mas195180 = value;
                this.ImpuestoConsolidadoDelEjercicio = this.mas195180;
            }
        }

        #endregion

        /// <summary>
        /// Diccionario de datos, contiene las definiciones de las propiedades con su descripción.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> DiccionarioDeDatos { get; set; }

        /// <summary>
        ///     Diccionario de calculos, contiene los calculos que son ejecutados durante la carga masiva.
        /// </summary>
        /// <value>
        ///     Diccionario con los calculos de la carga masiva.
        /// </value>
        [JsonIgnore]
        public Dictionary<string, string> DiccionarioDeCalculos { get; set; }

        /// <summary>
        /// Gets the lista de elementos.
        /// </summary>
        public List<object> ListaDeElementos { get; private set; }

        /// <summary>
        ///     Lista de elementos de carga masiva.
        /// </summary>
        public List<MasivaF20> ListaElementosMasivos { get; set; }

        /// <summary>
        ///     Errores de las validaciones.
        /// </summary>
        [JsonIgnore]
        public List<ErrorModel> Errores { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Crea la lista de elementos de carga masiva.
        /// </summary>
        /// <param name="txt">
        ///     TxtReader a partir del archivo.
        /// </param>
        /// <param name="registrosFiltrados">
        ///     registros filtrados.
        /// </param>
        /// <param name="ejercicio">
        ///     Ejercicio de la declaración
        /// </param>
        public void CrearListaDeElementos(TxtReader txt, HashSet<string> registrosFiltrados, int? ejercicio = null)
        {
            var listaElementos = new List<MasivaF20>();

            try
            {
                listaElementos = txt.ReadVariableLength<MasivaF20>(
                                                            registrosFiltrados.ToArray(),
                                                            this.PrimeraLineaEsEncabezado,
                                                            this.Separador,
                                                            this.EliminarEspaciosEnBlanco);

                if (ejercicio != null)
                {
                    listaElementos.ForEach(l => l.Ejercicio = ejercicio.Value);
                }
            }
            catch (DataTypeCreationException e)
            {
                var msjErr = e.Message;
                msjErr = msjErr.Replace(e.NombrePropiedad, string.Format("<b>{0}</b>", this.DiccionarioDeDatos[e.NombrePropiedad]));

                this.Errores.Add(new ErrorModel(msjErr));
            }

            this.ListaElementosMasivos = listaElementos;
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
        /// <param name="valorDelAuxiliar">
        ///     El valor del Auxiliar indica si al ejecutar los calculos seran para el borrado.
        /// </param>
        /// <returns>
        /// Un diccionario con el resultado de los calculos
        /// </returns>
        public Dictionary<string, string> EjecutarCalculos(
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes,
            string valorDelAuxiliar = "")
        {
            const string SumaIsr = "SUMAMASAUXISR";

            const string SumaImpac = "SUMAMASAUXIMPAC";

            const string SumaIetu = "SUMAMASAUXIETU";

            var calculos = HelpersMasivas.EjecutarCalculos(
                                            this.ListaElementosMasivos,
                                            parametros,
                                            subregimenes,
                                            this.ObtenerCalculos().ToArray(),
                                            this.AuxiliarNombre,
                                            this.AuxiliarValor);

            calculos = calculos.Where(c => !c.Key.Contains("NoValido")).ToDictionary(d => d.Key, d => d.Value);

            var dicCalcResult = new Dictionary<string, string>
                                    {
                                        { SumaIsr, "0" },
                                        { SumaImpac, "0" },
                                        { SumaIetu, "0" }
                                    };

            var elementoMasivo       = this.ListaElementosMasivos.FirstOrDefault();
            var ejercicioDeclaracion = elementoMasivo == null ? DateTime.Today.Year : elementoMasivo.Ejercicio;

            var calcSeccPago = calculos.Where(d => d.Value != "0" && d.Key != this.AuxiliarNombre).Select(n => n.Key).ToList();

            if (calcSeccPago.Any())
            {
                if (calcSeccPago.Contains(C7IsrACargo) || calcSeccPago.Contains(C6IsrAFavor))
                {
                    dicCalcResult[SumaIsr] = "1";
                }

                if (calcSeccPago.Contains(C7ImpacACargo) || calcSeccPago.Contains(C6ImpacAFavor))
                {
                    dicCalcResult[SumaImpac] = "1";
                }

                if (calcSeccPago.Contains(C7IetuACargo) || calcSeccPago.Contains(C6IetuAFavor))
                {
                    dicCalcResult[SumaIetu] = "1";
                }

                foreach (var cr in dicCalcResult)
                {
                    if (cr.Key.Equals(SumaIsr))
                    {
                        calculos.Add(cr.Key, cr.Value);
                    }
                    else if (cr.Key.Equals(SumaImpac) && ejercicioDeclaracion <= 2007)
                    {
                        calculos.Add(cr.Key, cr.Value);
                    }
                    else if (cr.Key.Equals(SumaIetu) && ejercicioDeclaracion >= 2008)
                    {
                        calculos.Add(cr.Key, cr.Value);
                    }
                }
            }

            this.DiccionarioDeCalculos = calculos;

            if (valorDelAuxiliar.Equals("0"))
            {
                foreach (var v in dicCalcResult)
                {
                    this.DiccionarioDeCalculos.Add(v.Key, v.Value);
                }

                this.ReiniciarAuxiliares();
            }

            return this.DiccionarioDeCalculos;
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
            string errorMsj;

            if (this.Errores.Any())
            {
                var msjesError = new StringBuilder();

                foreach (var error in this.Errores)
                {
                    msjesError.AppendFormat("{0} <br> <br>", error.Message);
                }

                errorMsj = msjesError.ToString();
            }
            else
            {
                errorMsj = HelpersMasivas.GetAllErrorMessages(
                                                    this.ListaElementosMasivos,
                                                    parametros,
                                                    subregimenes,
                                                    this.ObtenerReglas().ToArray());
            }

            return errorMsj;
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
            result.AddRange(this.ValidarIsrACargoDelEjercicio());
            result.AddRange(this.ValidarIsrAFavorDelEjercicio());
            result.AddRange(this.ValidarPtuPorDistribuir());
            result.AddRange(this.ValidarValorDelActivo());
            result.AddRange(this.ValidarImpacACargo());
            result.AddRange(this.ValidarImpacAFavor());
            result.AddRange(this.ValidarIngresoGravIetu());
            result.AddRange(this.ValidarDeduccAutorizIetu());
            result.AddRange(this.ValidarBaseGravableIetu());
            result.AddRange(this.ValidarDeduccExcedenIngresos());
            result.AddRange(this.ValidarIetuCargo());
            result.AddRange(this.ValidarImpuestoConsolidadoEjercicio());

            return result;
        }

        /// <summary>
        /// Obtiene los calculos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los calculos a ejecutar
        /// </returns>
        public List<HelpersMasivas.Calculate<MasivaF20>> ObtenerCalculos()
        {
            var listaCalculos = new List<HelpersMasivas.Calculate<MasivaF20>>
                                    {
                                        CalculoC6Isr,
                                        CalculoC7Isr,
                                        CalculoC6Impac,
                                        CalculoC7Impac,
                                        CalculoC6Ietu,
                                        CalculoC7Ietu
                                    };

            return listaCalculos;
        }

        /// <summary>
        /// Obtiene el nombre del auxiliar.
        /// </summary>
        public void ObtenerNombreAuxiliar()
        {
            this.AuxiliarNombre = "AUXINTI";
        }

        /// <summary>
        ///     Obtiene los procesos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los procesos a ejecutar
        /// </returns>
        public List<HelpersMasivas.ProcessExecute<MasivaF20>> ObtenerProcesos()
        {
            return null;
        }

        /// <summary>
        ///     Obtiene las reglas de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen las reglas a ejecutar
        /// </returns>
        public List<HelpersMasivas.Ruler<MasivaF20>> ObtenerReglas()
        {
            return new List<HelpersMasivas.Ruler<MasivaF20>> { ReglaRfcDuplicado };
        }

        /// <summary>
        /// Inicializa el diccionario de datos.
        /// </summary>
        public void InicializaDiccionarioDeDatos()
        {
            this.DiccionarioDeDatos = new Dictionary<string, string>
                                          {
                                              { "MAS205194", "RFC del integrante" },
                                              { "MAS201307", "Utilidad gravable" },
                                              { "MAS111175", "Pérdida fiscal" },
                                              { "MAS111119", "ISR a cargo" },
                                              { "MAS111159", "ISR a favor" },
                                              { "MAS201025", "PTU por distribuir" },
                                              { "MAS201041", "Valor del activo (base gravable)" },
                                              { "MAS121105", "IMPAC a cargo" },
                                              { "MAS121125", "IMPAC a favor" },
                                              { "MAS195175", "Ingresos gravados para IETU" },
                                              { "MAS195176", " Deducciones autorizadas para IETU" },
                                              { "MAS195177", "Base gravable para IETU" },
                                              { "MAS195178", "Deducciones que exceden a los ingresos" },
                                              { "MAS195179", "IETU a cargo" },
                                              { "MAS195180", "Impuesto Consolidado Del Ejercicio" }
                                          };
        }

        /// <summary>
        ///     Inicializa la lista de errores.
        /// </summary>
        public void InicializaListaDeErrores()
        {
            this.Errores = new List<ErrorModel>();
        }

        /// <summary>
        ///     Reinicia los auxiliares de los calculos.
        /// </summary>
        public void ReiniciarAuxiliares()
        {
            if (this.DiccionarioDeCalculos.Any())
            {
                var dicAux =
                    this.DiccionarioDeCalculos
                        .Select((t, i) => this.DiccionarioDeCalculos.ElementAt(i))
                        .ToDictionary(calculo => calculo.Key, calculo => "0");

                this.DiccionarioDeCalculos = dicAux;
            }
        }

        #endregion

        #region Methods

        #region Calculos

        #region ISR

        /// <summary>
        ///     Calculo C7 A CARGO ISR PERSONAS MORALES. RÉGIMEN DE LOS COORDINADOS. IMPUESTO DE SUS INTEGRANTES.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF20.
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
        private static Tuple<string, string> CalculoC7Isr(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var suma = entrada.Sum(x => x.MAS111119 ?? 0);
            return new Tuple<string, string>(C7IsrACargo, suma.ToString());
        }

        /// <summary>
        ///     Calculo C6 A FAVOR ISR PERSONAS MORALES. RÉGIMEN DE LOS COORDINADOS. IMPUESTO DE SUS INTEGRANTES.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF20.
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
        private static Tuple<string, string> CalculoC6Isr(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var suma = entrada.Sum(x => x.MAS111159 ?? 0);
            return new Tuple<string, string>(C6IsrAFavor, suma.ToString());
        }

        #endregion

        #region IMPAC

        private const string C7ImpacNoValido = "C7ImpacNoValido";
        private const string C6ImpacNoValido = "C6ImpacNoValido";

        /// <summary>
        ///     Calculo C7 A CARGO IMPUESTO AL ACTIVO. IMPUESTO DE LOS INTEGRANTES DE PERSONAS MORALES DEL RÉGIMEN SIMPLIFICADO.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF20.
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
        private static Tuple<string, string> CalculoC7Impac(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var calculo = new Tuple<string, string>(C7ImpacNoValido, "0");

            if (entrada.Any())
            {
                var elementoMasivo = entrada.FirstOrDefault();

                var ejercicioDeclaracion = elementoMasivo == null ? DateTime.Today.Year : elementoMasivo.Ejercicio;

                if (ejercicioDeclaracion <= 2007)
                {
                    var suma = entrada.Sum(x => x.MAS121105 ?? 0);
                    calculo = new Tuple<string, string>(C7ImpacACargo, suma.ToString());
                }
            }

            return calculo;
        }

        /// <summary>
        ///     Calculo C6 A FAVOR IMPUESTO AL ACTIVO. IMPUESTO DE LOS INTEGRANTES DE PERSONAS MORALES DEL RÉGIMEN SIMPLIFICADO.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF20.
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
        private static Tuple<string, string> CalculoC6Impac(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var calculo = new Tuple<string, string>(C6ImpacNoValido, "0");

            if (entrada.Any())
            {
                var elementoMasivo = entrada.FirstOrDefault();

                var ejercicioDeclaracion = elementoMasivo == null ? DateTime.Today.Year : elementoMasivo.Ejercicio;

                if (ejercicioDeclaracion <= 2007)
                {
                    var suma = entrada.Sum(x => x.MAS121125 ?? 0);
                    calculo = new Tuple<string, string>(C6ImpacAFavor, suma.ToString());
                }
            }

            return calculo;
        }

        #endregion

        #region IETU A CARGO / IMPUESTO CONSOLIDADO DEL EJERCICIO

        private const string C7IetuNoValido = "C7IetuNoValido";
        private const string C6IetucNoValido = "C6IetucNoValido";

        /// <summary>
        ///     Calculo C7 A CARGO IETU IMPUESTO DE LOS INTEGRANTES DE PERSONAS  MORALES. RÉGIMEN SIMPLIFICADO.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF20.
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
        private static Tuple<string, string> CalculoC7Ietu(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var calculo = new Tuple<string, string>(C7IetuNoValido, "0");

            if (entrada.Any())
            {
                var elementoMasivo = entrada.FirstOrDefault();

                var ejercicioDeclaracion = elementoMasivo == null ? DateTime.Today.Year : elementoMasivo.Ejercicio;

                if (ejercicioDeclaracion >= 2008)
                {
                    var suma = entrada.Sum(x => x.MAS195179 ?? 0);
                    calculo = new Tuple<string, string>(C7IetuACargo, suma.ToString());
                }
            }

            return calculo;
        }

        /// <summary>
        ///     Calculo C6 A FAVOR IETU IMPUESTO DE LOS INTEGRANTES DE PERSONAS  MORALES. RÉGIMEN SIMPLIFICADO.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF20.
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
        private static Tuple<string, string> CalculoC6Ietu(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var calculo = new Tuple<string, string>(C6IetucNoValido, "0");

            if (entrada.Any())
            {
                var elementoMasivo = entrada.FirstOrDefault();

                var ejercicioDeclaracion = elementoMasivo == null ? DateTime.Today.Year : elementoMasivo.Ejercicio;

                if (ejercicioDeclaracion >= 2008)
                {
                    var suma = entrada.Sum(x => x.MAS195180 ?? 0);
                    calculo = new Tuple<string, string>(C6IetuAFavor, suma.ToString());
                }
            }

            return calculo;
        }

        #endregion

        #endregion

        #region Reglas

        /// <summary>
        /// Busca RFC Duplicados
        /// </summary>
        /// <param name="entrada">
        /// Lista de objetos MasivaF20
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
        /// <returns>
        /// Lista de ErrorModel
        /// </returns>
        private static List<ErrorModel> ReglaRfcDuplicado(
            IEnumerable<MasivaF20> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            return HelpersMasivas.EvaluarRfcDuplicado(entrada, parametros, subregimenes);
        }

        #endregion

        /// <summary>
        /// Inicializas the campos.
        /// </summary>
        private void InicializaCampos()
        {
            this.ObtenerNombreAuxiliar();
            this.InicializaDiccionarioDeDatos();
            this.InicializaListaDeErrores();
        }
        #endregion
    }
}