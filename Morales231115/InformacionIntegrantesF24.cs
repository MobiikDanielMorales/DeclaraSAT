// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InformacionIntegrantesF24.cs" company="SAT">
//   Copyright (c) 2015 SAT
// </copyright>
// <summary>
//      Informacion integrantes formulario 24.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Morales
{
    #region using

    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using hp = HelpersMasivas;
    using resx = RecursosMasivaMorales;

    #endregion

    /// <summary>
    ///      Informacion integrantes formulario 24.
    /// </summary>
    public abstract class InformacionIntegrantesF24 : Base.MasivaBase
    {
        #region Constants

        /// <summary>
        ///     Longitud maxima RFC
        /// </summary>
        private const int LongitudMaximaRfc = 13;

        /// <summary>
        ///     Longitud minima RFC
        /// </summary>
        private const int LongitudMinimaRfc = 10;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        protected InformacionIntegrantesF24() : base()
        {
        }

        /// <summary>
        ///     Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="auxiliarValor">Valor del auxiliar.</param>
        protected InformacionIntegrantesF24(string auxiliarValor)
            : base(auxiliarValor)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Impuesto sobre la renta del ejercicio.
        /// </summary>
        protected long? ImpuestoSobreLaRentaDelEjercicio { get; set; }

        /// <summary>
        ///     ISR a cargo del ejercicio.
        /// </summary>
        protected long? IsrACargoDelEjercicio { get; set; }

        /// <summary>
        ///     ISR a favor del ejercicio.
        /// </summary>
        protected long? IsrAFavorDelEjercicio { get; set; }

        /// <summary>
        ///     Pagos provisionales efectuados por el coordinado.
        /// </summary>
        protected long? PagosProvisionalesEfectuadosPorElCoordinado { get; set; }

        /// <summary>
        /// Perdida Fiscal.
        /// </summary>
        protected long? PerdidaFiscal { get; set; }

        /// <summary>
        ///     PTU por distribuir.
        /// </summary>
        protected long? PtuPorDistribuir { get; set; }

        /// <summary>
        /// RFC del integrante.
        /// </summary>
        protected string RfcDelIntegrante { get; set; }

        /// <summary>
        /// Indica si el RFC del integrante es valido.
        /// </summary>
        protected bool RfcDelIntegranteValido { get; set; }

        /// <summary>
        ///     Utilidad Gravable.
        /// </summary>
        protected long? UtilidadGravable { get; set; }

        /// <summary>
        /// Establece el Mensaje de error de la validación.
        /// </summary>
        protected string MensajeError { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Validaciones del RFC.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarRfc()
        {
            var erroresRfc = new List<ErrorModel>();

            var rfcPresente = !string.IsNullOrWhiteSpace(this.RfcDelIntegrante);

            if (!rfcPresente)
            {
                erroresRfc.Add(this.Error(resx.Rfc, resx.Requerido));
            }

            if (rfcPresente)
            {
                var validarLongitudRfc = this.ErrorLongitud(
                                                        resx.Rfc,
                                                        this.RfcDelIntegrante,
                                                        LongitudMinimaRfc,
                                                        LongitudMaximaRfc);

                if (validarLongitudRfc != null)
                {
                    erroresRfc.Add(validarLongitudRfc);
                }
                else if (this.RfcDelIntegrante.Length == 10)
                {
                    if (!Runtime.Runtime.RfcSinHomoClave(this.RfcDelIntegrante))
                    {
                        erroresRfc.Add(this.Error(resx.Rfc, resx.NoCumpleFormatoRfc));
                    }
                }
                else if (this.RfcDelIntegrante.Length > 10)
                {
                    if (!Runtime.Runtime.RFCMORALES(this.RfcDelIntegrante))
                    {
                        erroresRfc.Add(this.Error(resx.Rfc, resx.NoCumpleFormatoRfc));
                    }
                }
            }

            if (!erroresRfc.Any())
            {
                this.RfcDelIntegranteValido = true;
            }

            return erroresRfc;
        }

        protected ErrorModel ErrorLongitud(string propiedad, object propiedadValidar, int minLong, int maxLong)
        {
            this.MensajeError = string.Format(resx.MsjErr, resx.Linea, propiedad, resx.MsjErrLongitud);

            this.MensajeError = this.MensajeError.Replace("@MinLong", minLong.ToString());
            this.MensajeError = this.MensajeError.Replace("@MaxLong", maxLong.ToString());

            return hp.ValidarLongitud(
                                    propiedadValidar,
                                    minLong,
                                    maxLong,
                                    this.MensajeError,
                                    this.Indice);
        }

        protected ErrorModel ErrorValidacionEnteroPositivo(string propiedad, object propiedadValidar)
        {
            this.MensajeError = string.Format(
                                            resx.MsjErr,
                                            resx.Linea,
                                            propiedad,
                                            resx.ValorMayorIgualCero);

            var validarEnteroPositivo = hp.ValidarEnteroPositivo(propiedadValidar, this.MensajeError, this.Indice);

            return validarEnteroPositivo;
        }

        protected ErrorModel ErrorSoloPuedeEstarPresenteSi(string propiedadPresente, string propiedadCondicion, string condicion, string propiedadCondicional)
        {
            var soloPuedeEstarPresenteSi = resx.SoloPuedeEstarPresenteSi;
            soloPuedeEstarPresenteSi = soloPuedeEstarPresenteSi.Replace("@PropiedadCondicional", propiedadCondicional);
            soloPuedeEstarPresenteSi = soloPuedeEstarPresenteSi.Replace("@PropiedadCondicion", propiedadCondicion);
            soloPuedeEstarPresenteSi = soloPuedeEstarPresenteSi.Replace("@Condicion", condicion);

            this.MensajeError = string.Format(resx.MsjErr, resx.Linea, propiedadPresente, soloPuedeEstarPresenteSi);

            return new ErrorModel(this.MensajeError, this.Indice);
        }

        protected ErrorModel ErrorNoPuedeEstarPresenteSi(string propiedad, string propiedadCondicion, string condicion)
        {
            var noDebeEstarPresenteSi = resx.NoDebeEstarPresenteSi.Replace(
                                                           "@PropiedadCondicion",
                                                           propiedadCondicion);

            noDebeEstarPresenteSi = noDebeEstarPresenteSi.Replace(
                                                    "@Condicion",
                                                    condicion);

            this.MensajeError = string.Format(resx.MsjErr, resx.Linea, propiedad, noDebeEstarPresenteSi);

            return new ErrorModel(this.MensajeError, this.Indice);
        }

        protected ErrorModel ErrorSiCondicionDebeSerNulo(string propiedad, string condicion, string propiedadDebeSerNula)
        {
            var msj1 = string.Format("Si {0} {1}", propiedad, condicion);
            var msj2 = string.Format(" {0} {1}", propiedadDebeSerNula, resx.NoDebeEstarPresente);

            this.MensajeError = string.Format(resx.MsjErr, resx.Linea, msj1, msj2);

            return new ErrorModel(string.Format(this.MensajeError, this.Indice));
        }

        protected ErrorModel Error(string propiedad, string mensajeError)
        {
            this.MensajeError = string.Format(resx.MsjErr, resx.Linea, propiedad, mensajeError);
            return new ErrorModel(string.Format(this.MensajeError, this.Indice));
        }

        /// <summary>
        ///     Valida el campo Utilidad Gravable.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarUtilidadGravable()
        {
            var erroresUtilidadGravable = new List<ErrorModel>();

            if (this.RfcDelIntegranteValido)
            {
                if (this.UtilidadGravable != null)
                {
                    if (this.UtilidadGravable < 0)
                    {
                        erroresUtilidadGravable.Add(this.Error(resx.UtilidadGravable, resx.NoMenorCero));
                    }
                    else if (
                        hp.MutuamenteExcluyentes(
                            hp.ValorEsMayorIgualAcero(this.UtilidadGravable),
                            this.PerdidaFiscal == null))
                    {
                        erroresUtilidadGravable.Add(
                            this.Error(
                                resx.SiPropEsMayorIgualCero.Replace("@Propiedad", resx.UtilidadGravable),
                                resx.LaPropDebeSerNula.Replace("@Propiedad", resx.PerdidaFiscal)));
                    }

                    var erroresUtilidGrav = this.ErroresUtilidadGravable();

                    if (erroresUtilidGrav.Any())
                    {
                        erroresUtilidadGravable.AddRange(erroresUtilidGrav);
                    }
                }
                else if (this.UtilidadGravable == null && hp.MutuamenteExcluyentes(
                                                          hp.ValorEsMayorIgualAcero(this.PerdidaFiscal),
                                                          this.UtilidadGravable == null))
                {
                    erroresUtilidadGravable.Add(
                        this.Error(resx.UtilidadGravable, resx.EsRequeridoSi.Replace("@Propiedad", resx.Rfc)));
                }
            }

            return erroresUtilidadGravable;
        }

        /// <summary>
        ///     Valida el campo Perdida Fiscal.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarPerdidaFiscal()
        {
            var erroresPerdidaFiscal = new List<ErrorModel>();

            if (this.RfcDelIntegranteValido)
            {
                if (this.PerdidaFiscal != null)
                {
                    if (HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.PerdidaFiscal),
                        this.UtilidadGravable == null))
                    {
                        erroresPerdidaFiscal.Add(
                                        this.Error(
                                            resx.SiPropEsMayorCero.Replace("@Propiedad", resx.PerdidaFiscal),
                                            resx.LaPropDebeSerNula.Replace("@Propiedad", resx.UtilidadGravable)));
                    }

                    var erroresPerdFis = this.ErroresPerdidaFiscal();

                    if (erroresPerdFis.Any())
                    {
                        erroresPerdidaFiscal.AddRange(erroresPerdFis);
                    }
                }
                else if (this.PerdidaFiscal == null && HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.UtilidadGravable),
                        this.PerdidaFiscal == null))
                {
                    erroresPerdidaFiscal.Add(
                        this.Error(resx.PerdidaFiscal, resx.EsRequeridoSi.Replace("@Propiedad", resx.Rfc)));
                }
            }

            return erroresPerdidaFiscal;
        }

        /// <summary>
        ///     Valida el campo Impuesto Sobre la Renta del Ejercicio.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarImpuestoSobreLaRentaDelEjercicio()
        {
            var erroresIsrEjercicio = new List<ErrorModel>();

            if (this.ImpuestoSobreLaRentaDelEjercicio == null)
            {
                erroresIsrEjercicio.Add(this.Error(resx.ImpuestoSobreLaRentaEjercicio, resx.Requerido));
            }
            else
            {
                var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(
                                                        resx.ImpuestoSobreLaRentaEjercicio,
                                                        this.ImpuestoSobreLaRentaDelEjercicio);

                if (validarEnteroPositivo != null)
                {
                    erroresIsrEjercicio.Add(validarEnteroPositivo);
                }

                var validarLongitud = this.ErrorLongitud(
                                                resx.ImpuestoSobreLaRentaEjercicio,
                                                this.ImpuestoSobreLaRentaDelEjercicio,
                                                0,
                                                12);

                if (validarLongitud != null)
                {
                    erroresIsrEjercicio.Add(validarLongitud);
                }
            }

            return erroresIsrEjercicio;
        }

        /// <summary>
        ///     Valida el campo Pagos Provisionales.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarPagosProvisionales()
        {
            var erroresPagosProvisionales = new List<ErrorModel>();

            if (this.PagosProvisionalesEfectuadosPorElCoordinado != null)
            {
                var validarEnteroPositivo =
                                    this.ErrorValidacionEnteroPositivo(
                                        resx.PagosProvisionalesEfectuadosPorElCoordinado,
                                        this.PagosProvisionalesEfectuadosPorElCoordinado);

                if (validarEnteroPositivo != null)
                {
                    erroresPagosProvisionales.Add(validarEnteroPositivo);
                }

                var validarLongitud = this.ErrorLongitud(
                                                resx.PagosProvisionalesEfectuadosPorElCoordinado,
                                                this.PagosProvisionalesEfectuadosPorElCoordinado,
                                                0,
                                                12);

                if (validarLongitud != null)
                {
                    erroresPagosProvisionales.Add(validarLongitud);
                }
            }

            return erroresPagosProvisionales;
        }

        /// <summary>
        /// Validars the isr a cargo delete ejercicio.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarIsrACargoDelEjercicio()
        {
            var erroresIsrACargoDelEjercicio = new List<ErrorModel>();

            var impSobreLaRenta = this.ImpuestoSobreLaRentaDelEjercicio ?? 0;
            var pagProvEfecCoord = this.PagosProvisionalesEfectuadosPorElCoordinado ?? 0;

            if (!(impSobreLaRenta >= pagProvEfecCoord)
                && this.IsrACargoDelEjercicio != null)
            {
                erroresIsrACargoDelEjercicio.Add(
                    this.ErrorSoloPuedeEstarPresenteSi(
                        resx.IsrACargoDelEjercicio,
                        resx.ImpuestoSobreLaRentaEjercicio,
                        resx.MayorIgualA,
                        resx.PagosProvisionalesEfectuadosPorElCoordinado));
            }
            else if (this.IsrACargoDelEjercicio != null)
            {
                var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(
                                                    resx.IsrACargoDelEjercicio,
                                                    this.IsrACargoDelEjercicio);

                if (validarEnteroPositivo != null)
                {
                    erroresIsrACargoDelEjercicio.Add(validarEnteroPositivo);
                }

                var validarLongitud = this.ErrorLongitud(resx.IsrACargoDelEjercicio, this.IsrACargoDelEjercicio, 0, 12);

                if (validarLongitud != null)
                {
                    erroresIsrACargoDelEjercicio.Add(validarLongitud);
                }

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.IsrACargoDelEjercicio),
                        this.IsrAFavorDelEjercicio == null))
                {
                    erroresIsrACargoDelEjercicio.Add(
                                        this.ErrorSiCondicionDebeSerNulo(
                                                            resx.IsrACargoDelEjercicio,
                                                            resx.MayorIgualA + " cero",
                                                            resx.IsrAFavorDelEjercicio));
                }
            }

            return erroresIsrACargoDelEjercicio;
        }

        /// <summary>
        ///     Valida el campo ISR a favor del ejercicio.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected virtual List<ErrorModel> ValidarIsrAFavorDelEjercicio()
        {
            var erroresIsrAFavorDelEjercicio = new List<ErrorModel>();

            var impSobreLaRenta = this.ImpuestoSobreLaRentaDelEjercicio ?? 0;
            var pagProvEfecCoord = this.PagosProvisionalesEfectuadosPorElCoordinado ?? 0;

            if (!(pagProvEfecCoord > impSobreLaRenta) && this.IsrAFavorDelEjercicio != null)
            {
                erroresIsrAFavorDelEjercicio.Add(
                    this.ErrorSoloPuedeEstarPresenteSi(
                                            resx.IsrAFavorDelEjercicio,
                                            resx.PagosProvisionalesEfectuadosPorElCoordinado,
                                            resx.MayorA,
                                            resx.ImpuestoSobreLaRentaEjercicio));
            }
            else if (this.IsrAFavorDelEjercicio != null)
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
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.IsrAFavorDelEjercicio),
                        this.IsrACargoDelEjercicio == null))
                {
                    erroresIsrAFavorDelEjercicio.Add(
                        this.ErrorSiCondicionDebeSerNulo(
                                                resx.IsrAFavorDelEjercicio,
                                                resx.MayorIgualA + " cero",
                                                resx.IsrACargoDelEjercicio));
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
        protected virtual List<ErrorModel> ValidarPtuPorDistribuir()
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

                var validarLongitud = this.ErrorLongitud(resx.PtuPorDistribuir, this.PtuPorDistribuir, 0, 13);

                if (validarLongitud != null)
                {
                    erroresPtuPorDistribuir.Add(validarLongitud);
                }
            }

            return erroresPtuPorDistribuir;
        }

        protected List<ErrorModel> ErroresUtilidadGravable()
        {
            var erroresUtilidadGravable = new List<ErrorModel>();

            var validarEnteroPositivo = this.ErrorValidacionEnteroPositivo(resx.UtilidadGravable, this.UtilidadGravable);

            if (validarEnteroPositivo != null)
            {
                erroresUtilidadGravable.Add(validarEnteroPositivo);
            }

            var validarLongitud = this.ErrorLongitud(resx.UtilidadGravable, this.UtilidadGravable, 0, 13);

            if (validarLongitud != null)
            {
                erroresUtilidadGravable.Add(validarLongitud);
            }

            return erroresUtilidadGravable;
        }

        protected List<ErrorModel> ErroresPerdidaFiscal()
        {
            var erroresPerdidaFiscal = new List<ErrorModel>();

            if (this.PerdidaFiscal == 0)
            {
                erroresPerdidaFiscal.Add(new ErrorModel("Linea {0:#,###}: La <b>Perdida Fiscal</b> debe ser un valor entero mayor que cero.", this.Indice));
            }
            else
            {
                var validarLongitud = this.ErrorLongitud(resx.PerdidaFiscal, this.PerdidaFiscal, 0, 12);

                if (validarLongitud != null)
                {
                    erroresPerdidaFiscal.Add(validarLongitud);
                }
            }

            return erroresPerdidaFiscal;
        }

        #endregion
    }
}