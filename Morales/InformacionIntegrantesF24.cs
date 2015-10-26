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
    using System.Text;

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

        #endregion

        #region Methods

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
                erroresIsrEjercicio.Add(
                    new ErrorModel(
                        string.Format(
                            "Linea {0:#,###}: El <b>Impuesto Sobre La Renta Del Ejercicio</b> es requerido.",
                            this.Indice)));
            }
            else
            {
                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                this.ImpuestoSobreLaRentaDelEjercicio,
                "Linea {0:#,###}: El <b>Impuesto Sobre La Renta Del Ejercicio</b> debe ser un valor entero mayor o igual que cero.",
                this.Indice);

                if (validarEnteroPositivo != null)
                {
                    erroresIsrEjercicio.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 12;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                                                this.ImpuestoSobreLaRentaDelEjercicio,
                                                longMin,
                                                longMax,
                                                "Linea {0:#,###}: El <b>Impuesto Sobre La Renta Del Ejercicio</b> debe tener una longitud entre 0 y 12 caracteres.",
                                                this.Indice);

                if (validarLongitud != null)
                {
                    erroresIsrEjercicio.Add(validarLongitud);
                }
            }

            return erroresIsrEjercicio;
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

            StringBuilder msjErr;

            if (!(impSobreLaRenta >= pagProvEfecCoord)
                && this.IsrACargoDelEjercicio != null)
            {
                msjErr = new StringBuilder();
                msjErr.Append("Linea {0:#,###}: El <b>ISR a cargo del ejercicio</b> solo puede estar presente ");
                msjErr.Append("si el Impuesto Sobre La Renta Del Ejercicio es mayor o igual a ");
                msjErr.Append(" los Pagos Provisionales Efectuados Por El Coordinado");

                erroresIsrACargoDelEjercicio.Add(new ErrorModel(string.Format(msjErr.ToString(), this.Indice)));
            }
            else if (this.IsrACargoDelEjercicio != null)
            {
                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                                                            this.IsrACargoDelEjercicio,
                                                            "Linea {0:#,###}: El <b>ISR A Cargo Del Ejercicio</b> debe ser un valor entero mayor o igual que cero.",
                                                            this.Indice);

                if (validarEnteroPositivo != null)
                {
                    erroresIsrACargoDelEjercicio.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 12;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                                                        this.IsrACargoDelEjercicio,
                                                        longMin,
                                                        longMax,
                                                        "Linea {0:#,###}: El <b>ISR A Cargo Del Ejercicio</b> debe tener una longitud entre 0 y 12 caracteres.",
                                                        this.Indice);

                if (validarLongitud != null)
                {
                    erroresIsrACargoDelEjercicio.Add(validarLongitud);
                }

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.IsrACargoDelEjercicio),
                        this.IsrAFavorDelEjercicio == null))
                {
                    msjErr = new StringBuilder();

                    msjErr.Append("Linea {0:#,###}: Si el <b>ISR a cargo del ejercicio</b> es mayor igual a cero, ");
                    msjErr.Append("el ISR a favor del ejercicio debe ser nulo");

                    erroresIsrACargoDelEjercicio.Add(new ErrorModel(string.Format(msjErr.ToString(), this.Indice)));
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
        protected List<ErrorModel> ValidarIsrAFavorDelEjercicio()
        {
            var erroresIsrAFavorDelEjercicio = new List<ErrorModel>();

            StringBuilder msjErr;

            var impSobreLaRenta = this.ImpuestoSobreLaRentaDelEjercicio ?? 0;
            var pagProvEfecCoord = this.PagosProvisionalesEfectuadosPorElCoordinado ?? 0;

            if (!(pagProvEfecCoord > impSobreLaRenta) && this.IsrAFavorDelEjercicio != null)
            {
                msjErr = new StringBuilder();
                msjErr.Append("Linea {0:#,###}: El <b>ISR A Favor Del Ejercicio</b> solo puede estar presente ");
                msjErr.Append("si los Pagos Provisionales Efectuados Por El Coordinado es mayor a ");
                msjErr.Append(" el Impuesto Sobre La Renta Del Ejercicio");

                erroresIsrAFavorDelEjercicio.Add(new ErrorModel(string.Format(msjErr.ToString(), this.Indice)));
            }
            else if (this.IsrAFavorDelEjercicio != null)
            {
                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                    this.IsrAFavorDelEjercicio,
                    "Linea {0:#,###}: El <b>ISR A Favor Del Ejercicio</b> debe ser un valor entero mayor o igual que cero.",
                    this.Indice);

                if (validarEnteroPositivo != null)
                {
                    erroresIsrAFavorDelEjercicio.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 12;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                    this.IsrAFavorDelEjercicio,
                    longMin,
                    longMax,
                    "Linea {0:#,###}: El <b>ISR A Favor Del Ejercicio</b> debe tener una longitud entre 0 y 12 caracteres.",
                    this.Indice);

                if (validarLongitud != null)
                {
                    erroresIsrAFavorDelEjercicio.Add(validarLongitud);
                }

                if (
                    HelpersMasivas.MutuamenteExcluyentes(
                        HelpersMasivas.ValorEsMayorIgualAcero(this.IsrAFavorDelEjercicio),
                        this.IsrACargoDelEjercicio == null))
                {
                    msjErr = new StringBuilder();
                    msjErr.Append("Linea {0:#,###}: Si el <b>ISR A Favor Del Ejercicio</b> es mayor igual a cero, ");
                    msjErr.Append("el ISR a cargo del ejercicio debe ser nulo");

                    erroresIsrAFavorDelEjercicio.Add(new ErrorModel(string.Format(msjErr.ToString(), this.Indice)));
                }
            }

            return erroresIsrAFavorDelEjercicio;
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
                    HelpersMasivas.ValidarEnteroPositivo(
                        this.PagosProvisionalesEfectuadosPorElCoordinado,
                        "Linea {0:#,###}: Los <b>Pagos Provisionales Efectuados Por El Coordinado</b> deben ser un valor entero mayor o igual que cero.",
                        this.Indice);

                if (validarEnteroPositivo != null)
                {
                    erroresPagosProvisionales.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 12;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                                                this.PagosProvisionalesEfectuadosPorElCoordinado,
                                                longMin,
                                                longMax,
                                                "Linea {0:#,###}: Los <b>Pagos Provisionales Efectuados Por El Coordinado</b> deben tener una longitud entre 0 y 12 caracteres.",
                                                this.Indice);

                if (validarLongitud != null)
                {
                    erroresPagosProvisionales.Add(validarLongitud);
                }
            }

            return erroresPagosProvisionales;
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
                if (HelpersMasivas.MutuamenteExcluyentes(
                                HelpersMasivas.ValorEsMayorIgualAcero(this.PerdidaFiscal),
                                this.UtilidadGravable == null))
                {
                    var msjErr = new StringBuilder();

                    msjErr.Append("Linea {0:#,###}: Si la <b>Perdida Fiscal</b> es mayor igual a cero, ");
                    msjErr.Append("la Utilidad Gravable debe ser nula");

                    erroresPerdidaFiscal.Add(new ErrorModel(msjErr.ToString(), this.Indice));
                }
                else if (this.PerdidaFiscal == null && HelpersMasivas.MutuamenteExcluyentes(
                                                            HelpersMasivas.ValorEsMayorIgualAcero(this.UtilidadGravable),
                                                            this.PerdidaFiscal == null))
                {
                    erroresPerdidaFiscal.Add(
                                    new ErrorModel(
                                        "Linea {0:#,###}: La <b>Perdida Fiscal</b> es requerido si el RFC tiene un dato valido",
                                        this.Indice));
                }
                else
                {
                    if (this.PerdidaFiscal != null)
                    {
                        var erroresPerdFis = this.ErroresPerdidaFiscal();

                        if (erroresPerdFis.Any())
                        {
                            erroresPerdidaFiscal.AddRange(erroresPerdFis);
                        }
                    }
                }
            }

            return erroresPerdidaFiscal;
        }

        /// <summary>
        ///     Valida el campo PTU por distribuir.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarPtuPorDistribuir()
        {
            var erroresPtuPorDistribuir = new List<ErrorModel>();

            if (this.PtuPorDistribuir != null)
            {
                var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                    this.PtuPorDistribuir,
                    "Linea {0:#,###}: El <b>PTU por distribuir</b> debe ser un valor entero mayor o igual que cero.",
                    this.Indice);

                if (validarEnteroPositivo != null)
                {
                    erroresPtuPorDistribuir.Add(validarEnteroPositivo);
                }

                var longMin = 0;
                var longMax = 13;

                var validarLongitud = HelpersMasivas.ValidarLongitud(
                    this.PtuPorDistribuir,
                    longMin,
                    longMax,
                    "Linea {0:#,###}: El <b>PTU por distribuir</b> debe tener una longitud entre 0 y 13 caracteres.",
                    this.Indice);

                if (validarLongitud != null)
                {
                    erroresPtuPorDistribuir.Add(validarLongitud);
                }
            }

            return erroresPtuPorDistribuir;
        }

        /// <summary>
        ///     Validaciones del RFC.
        /// </summary>
        /// <returns>
        ///     Lista de ErrorModel
        /// </returns>
        protected List<ErrorModel> ValidarRfc()
        {
            var erroresRfc = new List<ErrorModel>();

            var rfcPresente = string.IsNullOrWhiteSpace(this.RfcDelIntegrante);

            if (rfcPresente)
            {
                erroresRfc.Add(
                    new ErrorModel(string.Format("Linea {0:#,###}: El <b>RFC</b> es requerido.", this.Indice)));
            }

            if (rfcPresente)
            {
                var validarLongitudRfc = HelpersMasivas.ValidarLongitud(
                                                        this.RfcDelIntegrante,
                                                        LongitudMinimaRfc,
                                                        LongitudMaximaRfc,
                                                        "Linea {0:#,###}: El <b>RFC</b> debe tener una longitud entre 10 y 13 caracteres.",
                                                        this.Indice);

                if (validarLongitudRfc != null)
                {
                    erroresRfc.Add(validarLongitudRfc);
                }

                if (!Runtime.Runtime.RFCMORALES(this.RfcDelIntegrante))
                {
                    erroresRfc.Add(
                        new ErrorModel(
                            string.Format("Linea {0:#,###}: El <b>RFC</b> no cumple con el formato.", this.Indice)));
                }
            }

            if (!erroresRfc.Any())
            {
                this.RfcDelIntegranteValido = true;
            }

            return erroresRfc;
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
                if (HelpersMasivas.MutuamenteExcluyentes(
                            HelpersMasivas.ValorEsMayorIgualAcero(this.UtilidadGravable),
                            this.PerdidaFiscal == null))
                {
                    var msjError =
                        "Linea {0:#,###}: Si la <b>Utilidad gravable</b> es mayor igual a cero, la perdida fiscal debe ser nula";

                    erroresUtilidadGravable.Add(new ErrorModel(msjError, this.Indice));
                }
                else if (this.UtilidadGravable == null && HelpersMasivas.MutuamenteExcluyentes(
                                                            HelpersMasivas.ValorEsMayorIgualAcero(this.PerdidaFiscal),
                                                            this.UtilidadGravable == null))
                {
                    erroresUtilidadGravable.Add(
                                    new ErrorModel(
                                        "Linea {0:#,###}: La <b>Utilidad Gravable</b> es requerido si el RFC tiene un dato valido",
                                        this.Indice));
                }
                else
                {
                    if (this.UtilidadGravable != null)
                    {
                        var erroresUtilidGrav = this.ErroresUtilidadGravable();

                        if (erroresUtilidGrav.Any())
                        {
                            erroresUtilidadGravable.AddRange(erroresUtilidGrav);
                        }
                    }
                }
            }

            return erroresUtilidadGravable;
        }

        protected List<ErrorModel> ErroresUtilidadGravable()
        {
            var erroresUtilidadGravable = new List<ErrorModel>();

            var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                this.UtilidadGravable,
                "Linea {0:#,###}: La <b>Utilidad Gravable</b> debe ser un valor entero mayor o igual que cero.",
                this.Indice);

            if (validarEnteroPositivo != null)
            {
                erroresUtilidadGravable.Add(validarEnteroPositivo);
            }

            var longMin = 0;
            var longMax = 12;

            var validarLongitud = HelpersMasivas.ValidarLongitud(
                this.UtilidadGravable,
                longMin,
                longMax,
                "Linea {0:#,###}: La <b>Utilidad Gravable</b> debe tener una longitud entre 0 y 12 caracteres.",
                this.Indice);

            if (validarLongitud != null)
            {
                erroresUtilidadGravable.Add(validarLongitud);
            }

            return erroresUtilidadGravable;
        }

        protected List<ErrorModel> ErroresPerdidaFiscal()
        {
            var erroresPerdidaFiscal = new List<ErrorModel>();

            var validarEnteroPositivo = HelpersMasivas.ValidarEnteroPositivo(
                                        this.PerdidaFiscal,
                                        "Linea {0:#,###}: La <b>Perdida Fiscal</b> debe ser un valor entero mayor que cero.",
                                        this.Indice);

            if (validarEnteroPositivo != null && this.PerdidaFiscal == 0)
            {
                erroresPerdidaFiscal.Add(validarEnteroPositivo);
            }

            var longMin = 0;
            var longMax = 12;

            var validarLongitud = HelpersMasivas.ValidarLongitud(
                                this.PerdidaFiscal,
                                longMin,
                                longMax,
                                "Linea {0:#,###}: La <b>Perdida Fiscal</b> debe tener una longitud entre 0 y 12 caracteres.",
                                this.Indice);

            if (validarLongitud != null)
            {
                erroresPerdidaFiscal.Add(validarLongitud);
            }

            return erroresPerdidaFiscal;
        }

        #endregion
    }
}