namespace Sat.DeclaracionesAnuales.CargaMasiva.Models.Base
{
    using System;
    using System.Collections.Generic;

    using Sat.DeclaracionesAnuales.TxtReader;

    public class MasivaProcesador<T> : IMasivaProcesador where T : IMasiva
    {
        private readonly T masiva;

        public MasivaProcesador()
        {
            this.masiva = (T)Activator.CreateInstance(typeof(T));
        }

        public MasivaProcesador(string args = null)
        {
            this.masiva = (T)Activator.CreateInstance(typeof(T), args);
        }

        public void CrearListaDeElementos(TxtReader txt, HashSet<string> registrosFiltrados)
        {
            this.masiva.CrearListaDeElementos(txt, registrosFiltrados);
        }

        public Dictionary<string, string> EjecutarCalculos(Dictionary<string, string> parametros, HashSet<string> subregimenes)
        {
            return this.masiva.EjecutarCalculos(parametros, subregimenes);
        }

        public void EjecutarProcesos(Dictionary<string, string> parametros, HashSet<string> subregimenes)
        {
            this.masiva.EjecutarProcesos(parametros, subregimenes);
        }

        public string EjecutarReglas(Dictionary<string, string> parametros, HashSet<string> subregimenes)
        {
            return this.masiva.EjecutarReglas(parametros, subregimenes);
        }

        public List<object> ObtenerListaDeElementos()
        {
            return this.masiva.ListaDeElementos;
        }
    }
}