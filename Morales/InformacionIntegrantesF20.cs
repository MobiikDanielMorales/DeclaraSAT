// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformacionIntegrantesF20.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//   Informacion integrantes formulario 20.
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
    ///     Informacion integrantes formulario 20.
    /// </summary>
    public abstract class InformacionIntegrantesF20 : InformacionIntegrantesF24
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        protected InformacionIntegrantesF20() : base()
        {
        }

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">Valor del auxiliar.</param>
        protected InformacionIntegrantesF20(string auxiliarValor)
            : base(auxiliarValor)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Base gravable para IETU
        /// </summary>
        protected long? BaseGravableParaIetu { get; set; }

        /// <summary>
        /// Deducciones autorizadas para IETU
        /// </summary>
        protected long? DeduccionesAutorizadasParaIetu { get; set; }

        /// <summary>
        /// Deducciones que exceden a los ingresos
        /// </summary>
        protected long? DeduccionesQueExcedenALosIngresos { get; set; }

        /// <summary>
        /// IETU a cargo
        /// </summary>
        protected long? IetuACargo { get; set; }

        /// <summary>
        /// IMPAC a cargo
        /// </summary>
        protected long? ImpacACargo { get; set; }

        /// <summary>
        /// IMPAC a favor
        /// </summary>
        protected long? ImpacAFavor { get; set; }

        /// <summary>
        /// IETU a favor - Impuesto Consolidado Del Ejercicio
        /// </summary>
        protected long? ImpuestoConsolidadoDelEjercicio { get; set; }

        /// <summary>
        /// Ingresos gravados para IETU
        /// </summary>
        protected long? IngresosGravadosParaIetu { get; set; }

        /// <summary>
        /// VALOR DEL ACTIVO (BASE GRAVABLE)
        /// </summary>
        protected long? ValorDelActivo { get; set; }

        /// <summary>
        /// Ejercicio de la declaración.
        /// </summary>
        protected long Ejercicio { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Valida el campo Base Gravable IETU.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarBaseGravableIetu()
        {
            const string NombrePropiedad = "Base gravable para IETU";

            var erroresBaseGravableIetu = new List<ErrorModel>();

            if (this.BaseGravableParaIetu != null)
            {
                erroresBaseGravableIetu = this.ValidarCampoDosMilOcho(this.BaseGravableParaIetu, NombrePropiedad);

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.BaseGravableParaIetu),
                        this.DeduccionesQueExcedenALosIngresos == null))
                {
                    var msjErr = new StringBuilder();
                    msjErr.Append("Linea {0:#,###}: Si La <b>{1}</b> es mayor o igual a cero ");
                    msjErr.Append("las Deducciones que exceden a los ingresos no deben estar presentes");

                    erroresBaseGravableIetu.Add(new ErrorModel(msjErr.ToString(), this.Indice, NombrePropiedad));
                }
            }

            return erroresBaseGravableIetu;
        }

        /// <summary>
        ///     Valida el campo Deducciones autorizadas para IETU.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarDeduccAutorizIetu()
        {
            const string NombrePropiedad = "Deducciones autorizadas para IETU";

            var erroresDeduccAutorizIetu = new List<ErrorModel>();

            if (this.DeduccionesAutorizadasParaIetu != null)
            {
                erroresDeduccAutorizIetu = this.ValidarCampoDosMilOcho(
                                                this.DeduccionesAutorizadasParaIetu,
                                                NombrePropiedad);
            }

            return erroresDeduccAutorizIetu;
        }

        /// <summary>
        ///     Valida el campo Deducciones que exceden a los ingresos.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarDeduccExcedenIngresos()
        {
            const string NombrePropiedad = "Deducciones que exceden a los ingresos";

            var erroresDeduccExcedenIngresos = new List<ErrorModel>();

            if (this.DeduccionesQueExcedenALosIngresos != null)
            {
                erroresDeduccExcedenIngresos = this.ValidarCampoDosMilOcho(
                    this.DeduccionesQueExcedenALosIngresos,
                    NombrePropiedad);

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.DeduccionesQueExcedenALosIngresos),
                        this.BaseGravableParaIetu == null))
                {
                    var msjErr = new StringBuilder();
                    msjErr.Append("Linea {0:#,###}: Si Las <b>{1}</b> son mayores o iguales a cero ");
                    msjErr.Append("la Base gravable para IETU no debe estar presente");

                    erroresDeduccExcedenIngresos.Add(new ErrorModel(msjErr.ToString(), this.Indice, NombrePropiedad));
                }
            }

            return erroresDeduccExcedenIngresos;
        }

        /// <summary>
        ///     Valida el campo IETU a cargo.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarIetuCargo()
        {
            const string NombrePropiedad = "IETU a cargo";

            var erroresIetuCargo = new List<ErrorModel>();

            if (this.IetuACargo != null)
            {
                erroresIetuCargo = this.ValidarCampoDosMilOcho(this.IetuACargo, NombrePropiedad);

                if (HelpersMasivas.MutuamenteExcluyentes(
                    HelpersMasivas.ValorEsMayorIgualAcero(this.IetuACargo),
                    this.ImpuestoConsolidadoDelEjercicio == null))
                {
                    var msjErr = new StringBuilder();
                    msjErr.Append("Linea {0:#,###}: Si el <b>{1}</b> es mayor o igual a cero ");
                    msjErr.Append("el Impuesto Consolidado Del Ejercicio no debe estar presente");

                    erroresIetuCargo.Add(new ErrorModel(msjErr.ToString(), this.Indice, NombrePropiedad));
                }
            }

            return erroresIetuCargo;
        }

        /// <summary>
        ///     Valida el campo IMPAC a cargo.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpacACargo()
        {
            const string NombrePropiedad = "IMPAC a Cargo";

            var erroresImpacCargo = new List<ErrorModel>();

            if (this.ImpacACargo != null)
            {
                var errors = this.ValidarCampoDosMilSiete(this.ImpacACargo, NombrePropiedad);

                var huboErrores = errors.Any();

                if (huboErrores)
                {
                    erroresImpacCargo.AddRange(errors);
                }

                if (!huboErrores && HelpersMasivas.MutuamenteExcluyentes(
                                                    HelpersMasivas.ValorEsMayorIgualAcero(this.ImpacACargo),
                                                    this.ImpacAFavor == null))
                {
                    var msjErr = new StringBuilder();

                    msjErr.Append("Linea {0:#,###}: Si el <b>{1}</b> es mayor igual a cero, ");
                    msjErr.Append("el IMPAC a Favor debe ser nulo");

                    var err = new ErrorModel(msjErr.ToString(), this.Indice, NombrePropiedad);

                    erroresImpacCargo.Add(err);
                }
            }

            return erroresImpacCargo;
        }

        /// <summary>
        ///     Valida el campo IMPAC a favor.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpacAFavor()
        {
            const string NombrePropiedad = "IMPAC a Favor";

            var erroresImpacFavor = new List<ErrorModel>();

            if (this.ImpacAFavor != null)
            {
                var errors = this.ValidarCampoDosMilSiete(this.ImpacAFavor, NombrePropiedad);

                var huboErrores = errors.Any();

                if (huboErrores)
                {
                    erroresImpacFavor.AddRange(errors);
                }

                if (!huboErrores && HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.ImpacAFavor),
                        this.ImpacACargo == null))
                {
                    var msjErr = new StringBuilder();

                    msjErr.Append("Linea {0:#,###}: Si el <b>{1}</b> es mayor igual a cero, ");
                    msjErr.Append("el IMPAC a Cargo debe ser nulo");

                    var err = new ErrorModel(msjErr.ToString(), this.Indice, NombrePropiedad);

                    erroresImpacFavor.Add(err);
                }
            }

            return erroresImpacFavor;
        }

        /// <summary>
        ///     Valida el campo Impuesto Consolidado Del Ejercicio.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpuestoConsolidadoEjercicio()
        {
            const string NombrePropiedad = "Impuesto Consolidado Del Ejercicio";

            var erroresImpuestoConsolidadoEjercicio = new List<ErrorModel>();

            if (this.ImpuestoConsolidadoDelEjercicio != null)
            {
                erroresImpuestoConsolidadoEjercicio = this.ValidarCampoDosMilOcho(
                                                    this.ImpuestoConsolidadoDelEjercicio,
                                                    NombrePropiedad);

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.ImpuestoConsolidadoDelEjercicio),
                        this.IetuACargo == null))
                {
                    var msjErr = new StringBuilder();
                    msjErr.Append("Linea {0:#,###}: Si el <b>{1}</b> es mayor o igual a cero ");
                    msjErr.Append("el IETU a cargo no debe estar presente");

                    erroresImpuestoConsolidadoEjercicio.Add(new ErrorModel(msjErr.ToString(), this.Indice, NombrePropiedad));
                }
            }

            return erroresImpuestoConsolidadoEjercicio;
        }

        /// <summary>
        /// Valida el campo Ingresos gravados para IETU.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarIngresoGravIetu()
        {
            const string NombrePropiedad = "Ingresos gravados para IETU";

            var erroresIngresoGravIetu = new List<ErrorModel>();

            if (this.IngresosGravadosParaIetu != null)
            {
                erroresIngresoGravIetu = this.ValidarCampoDosMilOcho(this.IngresosGravadosParaIetu, NombrePropiedad);
            }

            return erroresIngresoGravIetu;
        }

        /// <summary>
        /// Valida el campo Valor del activo.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarValorDelActivo()
        {
            const string NombrePropiedad = "Valor Del Activo";

            var erroresValorActivo = new List<ErrorModel>();

            if (this.ValorDelActivo != null)
            {
                erroresValorActivo = this.ValidarCampoDosMilSiete(this.ValorDelActivo, NombrePropiedad);
            }

            return erroresValorActivo;
        }

        /// <summary>
        ///     Valida un campo que solo aplican para ejercicio 2008.
        /// </summary>
        /// <param name="valor">
        ///     Valor a evaluar.
        /// </param>
        /// <param name="nombrePropiedad">
        ///     Nombre de la propiedad que se evalua.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private List<ErrorModel> ValidarCampoDosMilOcho(long? valor, string nombrePropiedad)
        {
            var errores = new List<ErrorModel>();

            var validarEjercicio = this.ValidarEjercicioDosMilOcho(valor, nombrePropiedad);

            if (validarEjercicio != null)
            {
                errores.Add(validarEjercicio);
            }

            if (!errores.Any() && valor != null)
            {
                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                    valor,
                    "Linea {0:#,###}: El <b>@NombrePropiedad</b> debe ser un valor entero mayor o igual que cero.".Replace("@NombrePropiedad", nombrePropiedad),
                    this.Indice);

                if (validarEnteroPositivo != null)
                {
                    errores.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 12;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                    valor,
                    longMin,
                    longMax,
                    "Linea {0:#,###}: El <b>@NombrePropiedad</b> debe tener una longitud entre 0 y 12 caracteres.".Replace("@NombrePropiedad", nombrePropiedad),
                    this.Indice);

                if (validarLongitud != null)
                {
                    errores.Add(validarLongitud);
                }
            }

            return errores;
        }

        /// <summary>
        ///     Valida un campo que solo aplican para ejercicio 2007.
        /// </summary>
        /// <param name="valor">
        ///     Valor a evaluar.
        /// </param>
        /// <param name="nombrePropiedad">
        ///     Nombre de la propiedad que se evalua.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private List<ErrorModel> ValidarCampoDosMilSiete(long? valor, string nombrePropiedad)
        {
            var errores = new List<ErrorModel>();

            var validarEjercicio = this.ValidarEjercicioDosMilSiete(valor, nombrePropiedad);

            if (validarEjercicio != null)
            {
                errores.Add(validarEjercicio);
            }

            if (!errores.Any() && valor != null)
            {
                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                    valor,
                    "Linea {0:#,###}: El <b>@NombrePropiedad</b> debe ser un valor entero mayor o igual que cero.".Replace("@NombrePropiedad", nombrePropiedad),
                    this.Indice);

                if (validarEnteroPositivo != null)
                {
                    errores.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 12;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                    valor,
                    longMin,
                    longMax,
                    "Linea {0:#,###}: El <b>@NombrePropiedad</b> debe tener una longitud entre 0 y 12 caracteres.".Replace("@NombrePropiedad", nombrePropiedad),
                    this.Indice);

                if (validarLongitud != null)
                {
                    errores.Add(validarLongitud);
                }
            }

            return errores;
        }

        /// <summary>
        ///     Valida que el campo solo aplique en el ejercicio 2008.
        /// </summary>
        /// <param name="valor">
        ///     Valor a evaluar.
        /// </param>
        /// <param name="nombrePropiedad">
        ///     Nombre de la propiedad que se evalua.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private ErrorModel ValidarEjercicioDosMilOcho(long? valor, string nombrePropiedad)
        {
            const int EjercicioValidar = 2008;

            ErrorModel error = null;

            if (this.Ejercicio >= EjercicioValidar && valor == null)
            {
                error =
                    new ErrorModel(
                        string.Format(
                            "Linea {0:#,###}: <b>{1}</b> es requerido para ejercicios 2008 y posteriores",
                            this.Indice,
                            nombrePropiedad));
            }

            if (this.Ejercicio < EjercicioValidar && valor != null)
            {
                error =
                    new ErrorModel(
                        string.Format(
                            "Linea {0:#,###}: <b>{1}</b> Sólo aplica para ejercicios 2008 y posteriores",
                            this.Indice,
                            nombrePropiedad));
            }

            return error;
        }

        /// <summary>
        ///     Valida que el campo solo aplique en el ejercicio 2007.
        /// </summary>
        /// <param name="valor">
        ///     Valor a evaluar.
        /// </param>
        /// <param name="nombrePropiedad">
        ///     Nombre de la propiedad que se evalua.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private ErrorModel ValidarEjercicioDosMilSiete(long? valor, string nombrePropiedad)
        {
            const int EjercicioValidar = 2007;

            ErrorModel error = null;

            if (this.Ejercicio <= EjercicioValidar && valor == null)
            {
                error =
                    new ErrorModel(
                        string.Format(
                            "Linea {0:#,###}: <b>{1}</b> es requerido para ejercicios 2007 y anteriores",
                            this.Indice,
                            nombrePropiedad));
            }

            if (this.Ejercicio > EjercicioValidar && valor != null)
            {
                error =
                    new ErrorModel(
                        string.Format(
                            "Linea {0:#,###}: <b>{1}</b> Sólo aplica para ejercicios 2007 y anteriores",
                            this.Indice,
                            nombrePropiedad));
            }

            return error;
        }

        #endregion
    }
}