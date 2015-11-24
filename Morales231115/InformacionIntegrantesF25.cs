// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformacionIntegrantesF25.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//      Informacion integrantes formulario 25.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Morales
{
    #region using

    using System.Collections.Generic;
    using System.Linq;

    using hp = HelpersMasivas;
    using resx = RecursosMasivaMorales;

    #endregion

    /// <summary>
    /// The informacion integrantes f 25.
    /// </summary>
    public abstract class InformacionIntegrantesF25 : InformacionIntegrantesF24
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        protected InformacionIntegrantesF25() : base()
        {
        }

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">Valor del auxiliar.</param>
        protected InformacionIntegrantesF25(string auxiliarValor)
            : base(auxiliarValor)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Impuesto causado en el ejercicio
        /// </summary>
        protected long? ImpuestoCausadoEnElEjercicio { get; set; }

        /// <summary>
        ///     Impuesto Reducido
        /// </summary>
        protected long? ImpuestoReducido { get; set; }

        /// <summary>
        ///     Impuesto sobre la renta por el que no se aplica la reducción
        /// </summary>
        protected long? ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion { get; set; }

        /// <summary>
        ///     Impuesto sobre la renta por el que se aplica la reducción
        /// </summary>
        protected long? ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion { get; set; }

        /// <summary>
        ///     Reducciones del ISR
        /// </summary>
        protected long? ReduccionesDelIsr { get; set; }

        /// <summary>
        ///     Utilidad gravable por la que no se aplica la reduccion del ISR
        /// </summary>
        protected long? UtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr { get; set; }

        /// <summary>
        ///     Utilidad Gravable Por La Que Se Aplica La Reducción Del ISR
        /// </summary>
        protected long? UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Valida el campo Impuesto causado en el ejercicio.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpuestoCausadoEnElEjercicio()
        {
            var errores = new List<ErrorModel>();

            if (this.ImpuestoCausadoEnElEjercicio != null)
            {
                errores = this.ValidarCampoFormulario25(this.ImpuestoCausadoEnElEjercicio, resx.ImpuestoCausadoEnElEjercicio, 0, 12);
            }

            return errores;
        }

        /// <summary>
        ///     Valida el campo Impuesto Reducido.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpuestoReducido()
        {
            var errores = new List<ErrorModel>();

            if (this.ImpuestoReducido != null)
            {
                errores = this.ValidarCampoFormulario25(this.ImpuestoReducido, resx.ImpuestoReducido, 0, 12);
            }

            return errores;
        }

        /// <summary>
        ///     Valida el campo Impuesto sobre la renta por el que no se aplica la reducción.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpuestoSobreLaRentaPorElNoQueSeAplicaLaReduccion()
        {
            var errores = this.ValidarCampoFormulario25(
                                            this.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion,
                                            resx.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion,
                                            0,
                                            12,
                                            true);

            return errores;
        }

        /// <summary>
        ///     Valida el campo Utilidad gravable por la que se aplica la reduccion del ISR.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarUtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr()
        {
            var errores = new List<ErrorModel>();

            var utilidadGravable = this.UtilidadGravable ?? -1;

            if (utilidadGravable >= 0)
            {
                if (this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr != null)
                {
                    if (!(this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr <= this.UtilidadGravable))
                    {
                        var msj = string.Format("{0} a {1}", resx.DebeSerMenorIgual, resx.UtilidadGravable);

                        errores.Add(this.Error(resx.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr, msj));
                    }

                    var erroresF25 =
                        this.ValidarCampoFormulario25(
                                                    this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr,
                                                    resx.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr,
                                                    0,
                                                    13);

                    if (erroresF25.Any())
                    {
                        errores.AddRange(erroresF25);
                    }
                }
            }
            else
            {
                if (this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr != null)
                {
                    errores.Add(
                        this.ErrorNoPuedeEstarPresenteSi(
                            resx.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr,
                            resx.UtilidadGravable,
                            resx.MenorIgualCero + " " + resx.OEsNula));
                }
            }

            return errores;
        }

        /// <summary>
        /// Valida el campo Impuesto sobre la renta por el que se aplica la reducción.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion()
        {
            var errores = new List<ErrorModel>();

            var utilidadGravablePorLaQueSeAplicaLaReduccionDelIsr =
                this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr ?? -1;

            if (utilidadGravablePorLaQueSeAplicaLaReduccionDelIsr >= 0)
            {
                if (this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion != null)
                {
                    var erroresF25 = this.ValidarCampoFormulario25(
                                                    this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                                                    resx.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                                                    0,
                                                    12);

                    if (erroresF25.Any())
                    {
                        errores.AddRange(erroresF25);
                    }
                }
            }
            else
            {
                if (this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion != null)
                {
                    errores.Add(
                       this.ErrorNoPuedeEstarPresenteSi(
                           resx.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                           resx.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr,
                           resx.MenorIgualCero + " " + resx.OEsNula));
                }
            }

            return errores;
        }

        /// <summary>
        ///     Valida el campo Reducciones del ISR.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarReduccionesDelIsr()
        {
            var errores = new List<ErrorModel>();

            var impuestoSobreLaRentaPorElQueSeAplicaLaReduccion = this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion ?? -1;

            if (impuestoSobreLaRentaPorElQueSeAplicaLaReduccion > 0)
            {
                if (this.ReduccionesDelIsr != null)
                {
                    if (!(this.ReduccionesDelIsr <= impuestoSobreLaRentaPorElQueSeAplicaLaReduccion))
                    {
                        var msj = string.Format(
                                        "deben ser menores o iguales a {0}",
                                        resx.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion);

                        this.Error(resx.ReduccionesDelIsr, msj);
                    }

                    var erroresF25 = this.ValidarCampoFormulario25(
                                                        this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                                                        resx.ReduccionesDelIsr,
                                                        0,
                                                        12);

                    if (erroresF25.Any())
                    {
                        errores.AddRange(erroresF25);
                    }
                }
                else if (!(impuestoSobreLaRentaPorElQueSeAplicaLaReduccion <= 0 && this.ReduccionesDelIsr == null))
                {
                    errores.Add(
                                this.Error(
                                    resx.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                                    string.Format("es cero o nulo {0} no debe estar presente", resx.ReduccionesDelIsr)));
                }
            }
            else
            {
                if (this.ReduccionesDelIsr != null)
                {
                    errores.Add(
                       this.ErrorNoPuedeEstarPresenteSi(
                           resx.ReduccionesDelIsr,
                           resx.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                           resx.MenorIgualCero + " " + resx.OEsNula));
                }
            }

            return errores;
        }

        /// <summary>
        ///     Validaciones generales para un campo del formulario 25.
        /// </summary>
        /// <param name="valor">
        ///     Valor que se evalua.
        /// </param>
        /// <param name="propiedad">
        ///     Descripción de la propiedad que se evalua.
        /// </param>
        /// <param name="longMin">
        ///     longitud minima a evaluar.
        /// </param>
        /// <param name="longMax">
        ///     longitud maxima a evaluar.
        /// </param>
        /// <param name="valorEsRequerido">
        ///     Indica si el valor es obligatorio.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private List<ErrorModel> ValidarCampoFormulario25(
            long? valor,
            string propiedad,
            int longMin,
            int longMax,
            bool valorEsRequerido = false)
        {
            var errores = new List<ErrorModel>();

            if (valorEsRequerido)
            {
                if (valor == null)
                {
                    errores.Add(this.Error(propiedad, resx.Requerido));
                }
            }

            if (valor != null)
            {
                var validarLongitud = this.ErrorLongitud(propiedad, valor.Value, longMin, longMax);

                if (validarLongitud != null)
                {
                    errores.Add(validarLongitud);
                }

                var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(propiedad, valor);

                if (validarEnteroPositivo != null)
                {
                    errores.Add(validarEnteroPositivo);
                }
            }

            return errores;
        }

        #endregion
    }
}