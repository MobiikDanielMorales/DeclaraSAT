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

    using hp = HelpersMasivas;
    using resx = RecursosMasivaMorales;

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

        #endregion

        #region Methods

        /// <summary>
        ///     Valida el campo ISR a favor del ejercicio.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected override List<ErrorModel> ValidarIsrAFavorDelEjercicio()
        {
            var erroresIsrAFavorDelEjercicio = new List<ErrorModel>();

            if (this.IsrAFavorDelEjercicio != null)
            {
                var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(
                                                            resx.IsrAFavorDelEjercicio,
                                                            this.IsrAFavorDelEjercicio);

                if (validarEnteroPositivo != null)
                {
                    erroresIsrAFavorDelEjercicio.Add(validarEnteroPositivo);
                }

                var validarLongitud = this.ErrorLongitud(resx.IsrAFavorDelEjercicio, this.IsrAFavorDelEjercicio, 0, 12);

                if (validarLongitud != null)
                {
                    erroresIsrAFavorDelEjercicio.Add(validarLongitud);
                }

                if (
                    hp.MutuamenteExcluyentes(
                        hp.ValorEsMayorIgualAcero(this.IsrAFavorDelEjercicio),
                        this.IsrACargoDelEjercicio == null))
                {
                    erroresIsrAFavorDelEjercicio.Add(this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.IsrAFavorDelEjercicio),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.IsrACargoDelEjercicio)));
                }
            }

            return erroresIsrAFavorDelEjercicio;
        }

        /// <summary>
        ///     Valida el campo PTU por distribuir.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected override List<ErrorModel> ValidarPtuPorDistribuir()
        {
            var erroresPtuPorDistribuir = new List<ErrorModel>();

            if (this.PtuPorDistribuir != null)
            {
                var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(
                                                                resx.PtuPorDistribuir,
                                                                this.PtuPorDistribuir);

                if (validarEnteroPositivo != null)
                {
                    erroresPtuPorDistribuir.Add(validarEnteroPositivo);
                }

                var validarLongitud = this.ErrorLongitud(resx.PtuPorDistribuir, this.PtuPorDistribuir, 0, 12);

                if (validarLongitud != null)
                {
                    erroresPtuPorDistribuir.Add(validarLongitud);
                }
            }

            return erroresPtuPorDistribuir;
        }

        /// <summary>
        ///     Valida el campo Base Gravable IETU.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarBaseGravableIetu()
        {
            var erroresBaseGravableIetu = new List<ErrorModel>();

            if (this.BaseGravableParaIetu != null)
            {
                erroresBaseGravableIetu = this.ValidarCampoDosMilOcho(this.BaseGravableParaIetu, resx.BaseGravableParaIetu);

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                                            HelpersMasivas.ValorEsMayorIgualAcero(this.BaseGravableParaIetu),
                                            this.DeduccionesQueExcedenALosIngresos == null) &&
                        this.Ejercicio >= 2008)
                {
                    erroresBaseGravableIetu.Add(this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.BaseGravableParaIetu),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.DeduccionesQueExcedenALosIngresos)));
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
            var erroresDeduccAutorizIetu = new List<ErrorModel>();

            if (this.DeduccionesAutorizadasParaIetu != null)
            {
                erroresDeduccAutorizIetu = this.ValidarCampoDosMilOcho(
                                                this.DeduccionesAutorizadasParaIetu,
                                                resx.DeduccionesAutorizadasParaIetu);
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
            var erroresDeduccExcedenIngresos = new List<ErrorModel>();

            if (this.DeduccionesQueExcedenALosIngresos != null)
            {
                erroresDeduccExcedenIngresos = this.ValidarCampoDosMilOcho(
                                                        this.DeduccionesQueExcedenALosIngresos,
                                                        resx.DeduccionesQueExcedenALosIngresos);

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.DeduccionesQueExcedenALosIngresos),
                        this.BaseGravableParaIetu == null))
                {
                    erroresDeduccExcedenIngresos.Add(this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.DeduccionesQueExcedenALosIngresos),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.BaseGravableParaIetu)));
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
            var erroresIetuCargo = new List<ErrorModel>();

            if (this.IetuACargo != null)
            {
                erroresIetuCargo = this.ValidarCampoDosMilOcho(this.IetuACargo, resx.IetuACargo);

                if (HelpersMasivas.MutuamenteExcluyentes(
                    HelpersMasivas.ValorEsMayorIgualAcero(this.IetuACargo),
                    this.ImpuestoConsolidadoDelEjercicio == null))
                {
                    erroresIetuCargo.Add(this.Error(
                                            resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.IetuACargo),
                                            resx.LaPropDebeSerNula.Replace("@Propiedad", resx.ImpuestoConsolidadoDelEjercicio)));
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
            var erroresImpacCargo = new List<ErrorModel>();

            if (this.ImpacACargo != null)
            {
                var errors = this.ValidarCampoDosMilSiete(this.ImpacACargo, resx.ImpacACargo);

                var huboErrores = errors.Any();

                if (huboErrores)
                {
                    erroresImpacCargo.AddRange(errors);
                }

                if (!huboErrores && HelpersMasivas.MutuamenteExcluyentes(
                                                    HelpersMasivas.ValorEsMayorIgualAcero(this.ImpacACargo),
                                                    this.ImpacAFavor == null))
                {
                    erroresImpacCargo.Add(this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.ImpacACargo),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.ImpacAFavor)));
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
            var erroresImpacFavor = new List<ErrorModel>();

            if (this.ImpacAFavor != null)
            {
                var errors = this.ValidarCampoDosMilSiete(this.ImpacAFavor, resx.ImpacAFavor);

                var huboErrores = errors.Any();

                if (huboErrores)
                {
                    erroresImpacFavor.AddRange(errors);
                }

                if (!huboErrores && HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.ImpacAFavor),
                        this.ImpacACargo == null))
                {
                    erroresImpacFavor.Add(this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.ImpacAFavor),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.ImpacACargo)));
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
            var erroresImpuestoConsolidadoEjercicio = new List<ErrorModel>();

            if (this.ImpuestoConsolidadoDelEjercicio != null)
            {
                erroresImpuestoConsolidadoEjercicio = this.ValidarCampoDosMilOcho(
                                                    this.ImpuestoConsolidadoDelEjercicio,
                                                    resx.ImpuestoConsolidadoDelEjercicio);

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.ImpuestoConsolidadoDelEjercicio),
                        this.IetuACargo == null))
                {
                    erroresImpuestoConsolidadoEjercicio.Add(this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.ImpuestoConsolidadoDelEjercicio),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.IetuACargo)));
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
            var erroresIngresoGravIetu = new List<ErrorModel>();

            if (this.IngresosGravadosParaIetu != null)
            {
                erroresIngresoGravIetu = this.ValidarCampoDosMilOcho(this.IngresosGravadosParaIetu, resx.IngresosGravadosParaIetu);
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
            var erroresValorActivo = new List<ErrorModel>();

            if (this.ValorDelActivo != null)
            {
                erroresValorActivo = this.ValidarCampoDosMilSiete(this.ValorDelActivo, resx.ValorDelActivo);
            }

            return erroresValorActivo;
        }

        /// <summary>
        ///     Valida un campo que solo aplican para ejercicio 2008.
        /// </summary>
        /// <param name="valor">
        ///     Valor a evaluar.
        /// </param>
        /// <param name="propiedad">
        ///     Nombre de la propiedad que se evalua.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private List<ErrorModel> ValidarCampoDosMilOcho(long? valor, string propiedad)
        {
            return this.ValidarCampoFormulario24(valor, propiedad, 2008);
        }

        /// <summary>
        ///     Valida un campo que solo aplican para ejercicio 2007.
        /// </summary>
        /// <param name="valor">
        ///     Valor a evaluar.
        /// </param>
        /// <param name="propiedad">
        ///     Nombre de la propiedad que se evalua.
        /// </param>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        private List<ErrorModel> ValidarCampoDosMilSiete(long? valor, string propiedad)
        {
            return this.ValidarCampoFormulario24(valor, propiedad, 2007);
        }

        private List<ErrorModel> ValidarCampoFormulario24(long? valor, string propiedad, int ejercicio)
        {
            var errores = new List<ErrorModel>();

            ErrorModel validarEjercicio = null;

            switch (ejercicio)
            {
                case 2007:
                    validarEjercicio = this.ValidarEjercicioDosMilSiete(valor, propiedad);
                    break;
                case 2008:
                    validarEjercicio = this.ValidarEjercicioDosMilOcho(valor, propiedad);
                    break;
            }

            if (validarEjercicio != null)
            {
                errores.Add(validarEjercicio);
            }

            if (!errores.Any() && valor != null)
            {
                var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(propiedad, valor);

                if (validarEnteroPositivo != null)
                {
                    errores.Add(validarEnteroPositivo);
                }

                var validarLongitud = this.ErrorLongitud(propiedad, valor, 0, 12);

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
                error = this.ErrorRequeridoParaElEjercicio(nombrePropiedad, EjercicioValidar);
            }

            if (this.Ejercicio < EjercicioValidar && valor != null)
            {
                error = this.ErrorSoloAplicaParaElEjercicio(nombrePropiedad, EjercicioValidar);
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
                error = this.ErrorRequeridoParaElEjercicio(nombrePropiedad, EjercicioValidar, true);
            }

            if (this.Ejercicio > EjercicioValidar && valor != null)
            {
                error = this.ErrorSoloAplicaParaElEjercicio(nombrePropiedad, EjercicioValidar, true);
            }

            return error;
        }

        private ErrorModel ErrorRequeridoParaElEjercicio(string propiedad, int ejercicio, bool anterior = false)
        {
            var antPos = anterior ? "anteriores" : "posteriores";

            var msjError = string.Format("{0} para ejercicios {1} y {2}.", resx.Requerido, ejercicio, antPos);

            return this.Error(propiedad, msjError);
        }

        private ErrorModel ErrorSoloAplicaParaElEjercicio(string propiedad, int ejercicio, bool anterior = false)
        {
            var antPos = anterior ? "anteriores" : "posteriores";

            var msjError = string.Format("Sólo aplica para ejercicios {0} y {1}", ejercicio, antPos);

            return this.Error(propiedad, msjError);
        }

        #endregion
    }
}