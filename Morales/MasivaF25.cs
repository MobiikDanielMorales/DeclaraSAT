﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasivaF25.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//   Informacion integrantes formulario 25 masiva.
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
    ///     Informacion integrantes formulario 25 masiva.
    /// </summary>
    public class MasivaF25 : InformacionIntegrantesF25, IMasiva, IMasivaExtraccion<MasivaF25>
    {
        #region Fields

        /// <summary>
        /// RFC del integrante
        /// </summary>
        private string mas219778;

        /// <summary>
        /// UTILIDAD GRAVABLE
        /// </summary>
        private long? mas219779;

        /// <summary>
        /// PÉRDIDA FISCAL
        /// </summary>
        private long? mas219780;

        /// <summary>
        /// IMPUESTO SOBRE LA RENTA POR EL QUE SE APLICA LA REDUCCIÓN
        /// </summary>
        private long? mas219781;

        /// <summary>
        /// PAGOS PROVISIONALES EFECTUADOS POR LA PERSONA MORAL
        /// </summary>
        private long? mas219782;

        /// <summary>
        /// ISR A CARGO DEL EJERCICIO
        /// </summary>
        private long? mas219783;

        /// <summary>
        /// ISR A FAVOR DEL EJERCICIO
        /// </summary>
        private long? mas219784;

        /// <summary>
        /// PTU POR DISTRIBUIR
        /// </summary>
        private long? mas219785;

        /// <summary>
        /// UTILIDAD GRAVABLE POR LA QUE SE APLICA LA REDUCCIÓN DEL ISR
        /// </summary>
        private long? mas219808;

        /// <summary>
        /// REDUCCIONES DEL ISR
        /// </summary>
        private long? mas219809;

        /// <summary>
        /// IMPUESTO REDUCIDO
        /// </summary>
        private long? mas219810;

        /// <summary>
        /// UTILIDAD GRAVABLE POR LA QUE NO SE APLICA LA REDUCCIÓN DEL ISR
        /// </summary>
        private long? mas219811;

        /// <summary>
        /// IMPUESTO SOBRE LA RENTA POR EL QUE NO SE APLICA LA REDUCCIÓN
        /// </summary>
        private long? mas219812;

        /// <summary>
        /// IMPUESTO CAUSADO EN EL EJERCICIO
        /// </summary>
        private long? mas219813;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        public MasivaF25()
        {
            this.ObtenerNombreAuxiliar();
        }

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">Valor del auxiliar.</param>
        public MasivaF25(string auxiliarValor)
            : base(auxiliarValor)
        {
            this.ObtenerNombreAuxiliar();
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
        public string MAS219778
        {
            get
            {
                return this.RfcDelIntegrante;
            }

            set
            {
                this.mas219778 = value;
                this.RfcDelIntegrante = this.mas219778;
            }
        }

        /// <summary>
        /// UTILIDAD GRAVABLE
        /// </summary>
        [TxtReader(3)]
        public long? MAS219779
        {
            get
            {
                return this.UtilidadGravable;
            }

            set
            {
                this.mas219779 = value;
                this.UtilidadGravable = this.mas219779;
            }
        }

        /// <summary>
        /// PÉRDIDA FISCAL
        /// </summary>
        [TxtReader(4)]
        public long? MAS219780
        {
            get
            {
                return this.PerdidaFiscal;
            }

            set
            {
                this.mas219780 = value;
                this.PerdidaFiscal = this.mas219780;
            }
        }


        /// <summary>
        /// UTILIDAD GRAVABLE POR LA QUE SE APLICA LA REDUCCIÓN DEL ISR
        /// </summary>
        [TxtReader(5)]
        public long? MAS219808
        {
            get
            {
                return this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr;
            }

            set
            {
                this.mas219808 = value;
                this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr = this.mas219808;
            }
        }

        /// <summary>
        /// IMPUESTO SOBRE LA RENTA POR EL QUE SE APLICA LA REDUCCIÓN
        /// </summary>
        [TxtReader(6)]
        public long? MAS219781
        {
            get
            {
                return this.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion;
            }

            set
            {
                this.mas219781 = value;
                this.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion = this.mas219781;
            }
        }

        /// <summary>
        /// REDUCCIONES DEL ISR
        /// </summary>
        [TxtReader(7)]
        public long? MAS219809
        {
            get
            {
                return this.ReduccionesDelIsr;
            }

            set
            {
                this.mas219809 = value;
                this.ReduccionesDelIsr = this.mas219809;
            }
        }

        /// <summary>
        /// IMPUESTO REDUCIDO , no va en el layout del archivo es calculado como sigue: 219810 = 219781 - 219809
        /// </summary>
        public long? MAS219810
        {
            get
            {
                return this.ImpuestoReducido;
            }

            set
            {
                this.mas219810 = value;
                this.ImpuestoReducido = this.mas219810;
            }
        }

        /// <summary>
        /// UTILIDAD GRAVABLE POR LA QUE NO SE APLICA LA REDUCCIÓN DEL ISR, no va en el layout del archivo es calculado como sigue: 219811 = 219779 - 219808
        /// </summary>
        public long? MAS219811
        {
            get
            {
                return this.UtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr;
            }

            set
            {
                this.mas219811 = value;
                this.UtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr = this.mas219811;
            }
        }

        /// <summary>
        /// IMPUESTO SOBRE LA RENTA POR EL QUE NO SE APLICA LA REDUCCIÓN
        /// </summary>
        [TxtReader(8)]
        public long? MAS219812
        {
            get
            {
                return this.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion;
            }

            set
            {
                this.mas219812 = value;
                this.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion = this.mas219812;
            }
        }

        /// <summary>
        /// IMPUESTO CAUSADO EN EL EJERCICIO, no va en el layout del archivo es calculado como sigue: 219813 =  219810 + 219812
        /// </summary>
        public long? MAS219813
        {
            get
            {
                return this.ImpuestoCausadoEnElEjercicio;
            }

            set
            {
                this.mas219813 = value;
                this.ImpuestoCausadoEnElEjercicio = this.mas219813;
            }
        }

        /// <summary>
        /// PAGOS PROVISIONALES EFECTUADOS POR LA PERSONA MORAL
        /// </summary>
        [TxtReader(9)]
        public long? MAS219782
        {
            get
            {
                return this.PagosProvisionalesEfectuadosPorElCoordinado;
            }

            set
            {
                this.mas219782 = value;
                this.PagosProvisionalesEfectuadosPorElCoordinado = this.mas219782;
            }
        }

        /// <summary>
        /// ISR A CARGO DEL EJERCICIO
        /// </summary>
        [TxtReader(10)]
        public long? MAS219783
        {
            get
            {
                return this.IsrACargoDelEjercicio;
            }

            set
            {
                this.mas219783 = value;
                this.IsrACargoDelEjercicio = this.mas219783;
            }
        }

        /// <summary>
        /// ISR A FAVOR DEL EJERCICIO
        /// </summary>
        [TxtReader(11)]
        public long? MAS219784
        {
            get
            {
                return this.IsrAFavorDelEjercicio;
            }

            set
            {
                this.mas219784 = value;
                this.IsrAFavorDelEjercicio = this.mas219784;
            }
        }

        /// <summary>
        /// PTU POR DISTRIBUIR
        /// </summary>
        [TxtReader(12)]
        public long? MAS219785
        {
            get
            {
                return this.PtuPorDistribuir;
            }

            set
            {
                this.mas219785 = value;
                this.PtuPorDistribuir = this.mas219785;
            }
        }

        #endregion

        /// <summary>
        ///     Lista de elementos de carga masiva.
        /// </summary>
        public List<object> ListaDeElementos { get; private set; }

        /// <summary>
        ///     Lista de elementos de carga masiva.
        /// </summary>
        public List<MasivaF25> ListaElementosMasivos { get; set; }

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
            this.ListaElementosMasivos = txt.ReadVariableLength<MasivaF25>(
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
            HelpersMasivas.EjecutarProcesos(
                                        this.ListaElementosMasivos,
                                        parametros,
                                        subregimenes,
                                        this.ObtenerProcesos().ToArray());
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

            //result.AddRange(this.ValidarRfc());
            //result.AddRange(this.ValidarUtilidadGravable());
            //result.AddRange(this.ValidarPerdidaFiscal());
            //result.AddRange(this.ValidarUtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr());
            //result.AddRange(this.ValidarImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion());
            //result.AddRange(this.ValidarReduccionesDelIsr());
            //result.AddRange(this.ValidarImpuestoReducido());
            //result.AddRange(this.ValidarUtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr());
            //result.AddRange(this.ValidarImpuestoSobreLaRentaPorElNoQueSeAplicaLaReduccion());
            //result.AddRange(this.ValidarImpuestoCausadoEnElEjercicio());
            //result.AddRange(this.ValidarPagosProvisionales());
            //result.AddRange(this.ValidarIsrACargoDelEjercicio());
            //result.AddRange(this.ValidarIsrAFavorDelEjercicio());
            //result.AddRange(this.ValidarPtuPorDistribuir());

            return result;
        }

        /// <summary>
        /// Obtiene los calculos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los calculos a ejecutar
        /// </returns>
        public List<HelpersMasivas.Calculate<MasivaF25>> ObtenerCalculos()
        {
            return new List<HelpersMasivas.Calculate<MasivaF25>>
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
            this.AuxiliarNombre = "AUXINTF";
        }

        /// <summary>
        ///     Obtiene los procesos de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen los procesos a ejecutar
        /// </returns>
        public List<HelpersMasivas.ProcessExecute<MasivaF25>> ObtenerProcesos()
        {
            return new List<HelpersMasivas.ProcessExecute<MasivaF25>>
                       {
                           ProcesoMas219810,
                           ProcesoMas219811,
                           ProcesoMas219813
                       };
        }

        /// <summary>
        ///     Obtiene las reglas de la carga masiva.
        /// </summary>
        /// <returns>
        ///     Una lista de delegados que obtienen las reglas a ejecutar
        /// </returns>
        public List<HelpersMasivas.Ruler<MasivaF25>> ObtenerReglas()
        {
            return new List<HelpersMasivas.Ruler<MasivaF25>> { ReglaRfcDuplicado };
        }

        #endregion

        #region Methods

        #region

        #region Calculos

        /// <summary>
        ///     Calculo C7 A CARGO ISR PERSONAS MORALES. RÉGIMEN DE LOS COORDINADOS. IMPUESTO DE SUS INTEGRANTES.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF25.
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
            IEnumerable<MasivaF25> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var suma = entrada.Sum(x => x.MAS219783 ?? 0);
            return new Tuple<string, string>("C7", suma.ToString());
        }

        /// <summary>
        ///     Calculo C6 A FAVOR ISR PERSONAS MORALES. RÉGIMEN DE LOS COORDINADOS. IMPUESTO DE SUS INTEGRANTES.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF25.
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
            IEnumerable<MasivaF25> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            var suma = entrada.Sum(x => x.MAS219784 ?? 0);
            return new Tuple<string, string>("C6", suma.ToString());
        }

        #endregion

        #endregion

        #region Procesos

        /// <summary>
        ///     Proceso que establece el valor del campo MAS219810 es decir el Impuesto Reducido.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF25.
        /// </param>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        private static void ProcesoMas219810(
                                    IEnumerable<MasivaF25> entrada,
                                    Dictionary<string, string> parametros,
                                    HashSet<string> subregimenes)
        {
            entrada.Where(
                x =>
                    {
                        var isrPorElQueSeAplicaLaReduc = x.MAS219781;
                        var reduccionesIsr             = x.MAS219809;

                        var isrPorElQueSeAplicaLaReducEsMayorQueCero = (isrPorElQueSeAplicaLaReduc ?? 0) > 0;

                        var isrPorElQueSeAplicaLaReducEsMayorQueReduccionesIsr = isrPorElQueSeAplicaLaReduc > reduccionesIsr;

                        return isrPorElQueSeAplicaLaReducEsMayorQueCero
                               && isrPorElQueSeAplicaLaReducEsMayorQueReduccionesIsr;
                    }).ToList().ForEach(x => x.MAS219810 = x.MAS219781 - x.MAS219809);
        }

        /// <summary>
        ///     Proceso que establece el valor del campo MAS219811 es decir la utilidad gravable por la que no se aplica la reducción del ISR.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF25.
        /// </param>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        private static void ProcesoMas219811(
                                    IEnumerable<MasivaF25> entrada,
                                    Dictionary<string, string> parametros,
                                    HashSet<string> subregimenes)
        {
            entrada.Where(
                x =>
                    {
                        var utilidadGravable                           = x.MAS219779;
                        var utilidadGravablePorLaQueSeAplicaLaReducIsr = x.MAS219808;

                        var utilidadGravableMayorQueCero = (utilidadGravable ?? 0) > 0;

                        var utilGravAplicaLaReducIsrEsMayorQueUtilidadGravable =
                            utilidadGravablePorLaQueSeAplicaLaReducIsr > utilidadGravable;

                        return utilidadGravableMayorQueCero && utilGravAplicaLaReducIsrEsMayorQueUtilidadGravable;
                    }).ToList().ForEach(x => x.MAS219811 = x.MAS219779 - x.MAS219808);
        }

        /// <summary>
        ///     Proceso que establece el valor del campo MAS219813 es decir el Impuesto causado en el ejercicio.
        /// </summary>
        /// <param name="entrada">
        ///     Lista de objetos MasivaF25.
        /// </param>
        /// <param name="parametros">
        ///     Parametros de la declaración
        /// </param>
        /// <param name="subregimenes">
        ///     SubRegimenes de la declaración
        /// </param>
        private static void ProcesoMas219813(
            IEnumerable<MasivaF25> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            entrada.ToList().ForEach(x => { x.MAS219813 = (x.MAS219810 ?? 0) + (x.MAS219812 ?? 0); });
        }

        #endregion

        #region Reglas

        /// <summary>
        /// Busca RFC Duplicados
        /// </summary>
        /// <param name="entrada">
        /// Lista de objetos MasivaF25
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
            IEnumerable<MasivaF25> entrada,
            Dictionary<string, string> parametros,
            HashSet<string> subregimenes)
        {
            return HelpersMasivas.EvaluarRfcDuplicado(entrada, parametros, subregimenes);
        }

        #endregion

        #endregion
    }
}