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
    using System.Text;

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
            const string Propiedad = "El <b>Impuesto causado en el ejercicio</b>";

            var errores = new List<ErrorModel>();

            if (this.ImpuestoCausadoEnElEjercicio != null)
            {
                errores = this.ValidarCampoFormulario25(this.ImpuestoCausadoEnElEjercicio, Propiedad, 0, 12);
            }

            // ToDo: verificar inhabilitado y su calculo
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
                const string Propiedad = "El <b>Impuesto Reducido</b>";

                errores = this.ValidarCampoFormulario25(this.ImpuestoReducido, Propiedad, 0, 12);
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
            const string Propiedad = "El <b>Impuesto sobre la renta por el que no se aplica la reducción</b>";

            var errores = this.ValidarCampoFormulario25(
                                            this.ImpuestoSobreLaRentaPorElQueNoSeAplicaLaReduccion,
                                            Propiedad,
                                            0,
                                            12,
                                            true);

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
            const string Propiedad = "El <b>Impuesto Sobre la Renta por el que se aplica la reducción</b>";

            var errores = new List<ErrorModel>();

            var utilidadGravablePorLaQueSeAplicaLaReduccionDelIsr =
                this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr ?? 0;

            if (utilidadGravablePorLaQueSeAplicaLaReduccionDelIsr >= 0)
            {
                if (this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion != null)
                {
                    var erroresF25 = this.ValidarCampoFormulario25(
                        this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                        Propiedad,
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
                    var sb = new StringBuilder();
                    sb.Append("Linea {0:#,###}: {1} no deben estar presente si ");
                    sb.Append("la Utilidad Gravable Por La Que Se Aplica La Reduccion Del ISR ");
                    sb.Append("es menor o igual a cero o es nula");

                    errores.Add(new ErrorModel(sb.ToString(), this.Indice, Propiedad));
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
            const string Propiedad = "Las <b>Reducciones del ISR</b>";

            var errores = new List<ErrorModel>();

            var impuestoSobreLaRentaPorElQueSeAplicaLaReduccion = this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion ?? 0;

            if (impuestoSobreLaRentaPorElQueSeAplicaLaReduccion >= 0)
            {
                if (!(impuestoSobreLaRentaPorElQueSeAplicaLaReduccion == 0 && this.ReduccionesDelIsr == null))
                {
                    var sb = new StringBuilder();
                    sb.Append("Linea {0:#,###}: Si el Impuesto Sobre la Renta por el que se aplica la reducción ");
                    sb.Append("es cero o nulo {1} no debe estar presente");

                    errores.Add(new ErrorModel("Linea {0:#,###}: "));
                }
                else if (this.ReduccionesDelIsr != null)
                {
                    if (!(this.ReduccionesDelIsr <= this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion))
                    {
                        var sb = new StringBuilder();
                        sb.Append("Linea {0:#,###}: {1} deben ser menores o iguales a ");
                        sb.Append("el Impuesto Sobre la Renta por el que se aplica la reducción ");

                        var msj = string.Format(sb.ToString(), this.Indice, Propiedad);

                        errores.Add(new ErrorModel(msj));
                    }

                    var erroresF25 = this.ValidarCampoFormulario25(
                                                        this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion,
                                                        Propiedad,
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
                if (this.ReduccionesDelIsr != null)
                {
                    var sb = new StringBuilder();
                    sb.Append("Linea {0:#,###}: {1} no deben estar presentes si ");
                    sb.Append("el Impuesto Sobre la Renta por el que se aplica la reducción ");
                    sb.Append("es menor o igual a cero o es nulo");

                    var msj = string.Format(sb.ToString(), this.Indice, Propiedad);

                    errores.Add(new ErrorModel(msj));
                }
            }

            if (!(this.ImpuestoSobreLaRentaPorElQueSeAplicaLaReduccion == 0 && this.ReduccionesDelIsr == null))
            {
                var sb = new StringBuilder();
                sb.Append("Linea {0:#,###}: Si el Impuesto Sobre la Renta por el que se aplica la reducción ");
                sb.Append("es igual a cero {1} debe ser nulo");

                errores.Add(new ErrorModel(sb.ToString(), this.Indice, Propiedad));
            }

            return errores;
        }

        /// <summary>
        ///     Valida el campo Utilidad gravable por la que no se aplica la reduccion del ISR.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarUtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr()
        {
            const string Propiedad = "Utilidad gravable por la que no se aplica la reduccion del ISR";

            var errores = new List<ErrorModel>();

            if (this.UtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr != null)
            {
                if (!(this.UtilidadGravable <= 0 && this.UtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr == null))
                {
                    var sb = new StringBuilder();
                    sb.Append("Linea {0:#,###}: Si la Utilidad gravable es menor igual a cero ");
                    sb.Append("{1} debe ser nulo");

                    errores.Add(new ErrorModel(sb.ToString(), this.Indice, Propiedad));
                }
                else
                {
                    errores.AddRange(
                        this.ValidarCampoFormulario25(
                            this.UtilidadGravablePorLaQueNoSeAplicaLaReduccionDelIsr,
                            Propiedad,
                            0,
                            13));
                }
            }

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
            const string Propiedad = "La <b>Utilidad Gravable Por La Que Se Aplica La Reduccion Del ISR</b>";

            var errores = new List<ErrorModel>();

            var utilidadGravable = this.UtilidadGravable ?? -1;

            if (utilidadGravable >= 0)
            {
                if (this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr != null)
                {
                    if (!(this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr <= this.UtilidadGravable))
                    {
                        var msj = string.Format(
                            "Linea {0:#,###}: {1} debe ser menor o igual a la utilidad gravable",
                            this.Indice,
                            Propiedad);

                        errores.Add(new ErrorModel(msj));
                    }

                    var erroresF25 =
                        this.ValidarCampoFormulario25(
                            this.UtilidadGravablePorLaQueSeAplicaLaReduccionDelIsr,
                            Propiedad,
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
                    var msj = string.Format(
                            "Linea {0:#,###}: {1} no debe estar presente si la utilidad gravable es menor o igual a cero o es nula",
                            this.Indice,
                            Propiedad);

                    errores.Add(new ErrorModel(msj));
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
                    var msjErrorRequerido = "Linea {0:#,###}: @Propiedad es requerido.";
                    msjErrorRequerido = msjErrorRequerido.Replace("@Propiedad", propiedad);

                    errores.Add(new ErrorModel(string.Format(msjErrorRequerido, this.Indice)));
                }
            }

            if (valor != null)
            {
                var longMsjError =
                    "Linea {0:#,###}: @Propiedad debe tener una longitud entre @LongMin y @LongMax caracteres.";

                var entPosMsjError = "Linea {0:#,###}: @Propiedad deben ser un valor entero mayor o igual que cero.";

                longMsjError = longMsjError.Replace("@Propiedad", propiedad);
                longMsjError = longMsjError.Replace("@LongMin", longMin.ToString());
                longMsjError = longMsjError.Replace("@LongMax", longMax.ToString());

                var validarLongitud = HelpersMasivas.ValidarLongitud(valor, longMin, longMax, longMsjError, this.Indice);

                if (validarLongitud != null)
                {
                    errores.Add(validarLongitud);
                }

                entPosMsjError = entPosMsjError.Replace("@Propiedad", propiedad);

                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(valor, entPosMsjError, this.Indice);

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