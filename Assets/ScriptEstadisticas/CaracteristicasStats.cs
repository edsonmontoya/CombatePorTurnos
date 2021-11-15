using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

    [Serializable]

    public class CaracteristicasStats
    {
        //Valor Base de Inicio del Jugador
        public float ValorBase;
        public virtual float Valor
        {
            get
            {
                if (isSucio || ValorBase != ultimaBaseValor)
                {
                    ultimaBaseValor = ValorBase;
                    _Valor = CalcularFinalValor();
                    isSucio = false;
                }
                return _Valor;

            }
        }

        protected bool isSucio = true;
        
    
       //Valor Para el combate
        public float _Valor;


        protected float ultimaBaseValor = float.MinValue;
        protected readonly List<ModificadorEstadisticas> modificadorEstadisticas;
        public readonly ReadOnlyCollection<ModificadorEstadisticas> ModificadorEstadisticas;
        public CaracteristicasStats()
        {

            modificadorEstadisticas = new List<ModificadorEstadisticas>();
            ModificadorEstadisticas = modificadorEstadisticas.AsReadOnly();
        }

        public CaracteristicasStats(float valorBase) : this()
        {
            ValorBase = valorBase;
        }
       //Esta funcion es para agregar una modificacion segun la que se necesite
        public virtual void AgregarModificador(ModificadorEstadisticas mod)
        {
            isSucio = true;
            modificadorEstadisticas.Add(mod);
            modificadorEstadisticas.Sort(ComparandoModificadorOrden);
        }
        protected virtual int ComparandoModificadorOrden(ModificadorEstadisticas a, ModificadorEstadisticas b)
        {
            if (a.Orden < b.Orden)
            
                return -1;
            
            else if (a.Orden > b.Orden)
            
                return 1;

            
            return 0;
        }
        //Esta funcion es para quitar las modificaciones
        public virtual bool QuitarModificador(ModificadorEstadisticas mod)
        {

            if (modificadorEstadisticas.Remove(mod))
            {
                isSucio = true;
            return true;
            }
            return false;
        }
       //Esta funcion se llama cuando el objeto es desquipado
        public virtual bool QuitandoTodosLosModificadores(object fuente)
        {
            bool seRemovera = false;
            for (int i = modificadorEstadisticas.Count - 1; i >= 0; i--)
            {
                if (modificadorEstadisticas[i].Fuente == fuente)
                {
                    isSucio = true;
                    seRemovera = true;
                    modificadorEstadisticas.RemoveAt(i);
                }
            }
        return seRemovera;
        }
      //Esta funcion calcula el valor final segun el modificador (entero,porcentaje)
        protected virtual float CalcularFinalValor()
        {
            float valorFinal = ValorBase;
            float sumAgregandoPorcentaje = 0;
            for (int i = 0; i < modificadorEstadisticas.Count; i++)
            {
                ModificadorEstadisticas mod = modificadorEstadisticas[i];
                if (mod.Tipo == TipoModoEstadistica.Entero)
                {
                    valorFinal += +mod.Valor;
                }
                else if (mod.Tipo == TipoModoEstadistica.PorcentajeMultiple)
                {
                    valorFinal *= 1 + mod.Valor;
                }
                else if (mod.Tipo == TipoModoEstadistica.PorcentajeAgregado)
                {
                    sumAgregandoPorcentaje += mod.Valor;
                    if (i + 1 >= modificadorEstadisticas.Count || modificadorEstadisticas[i + 1].Tipo != TipoModoEstadistica.PorcentajeAgregado)
                    {
                        valorFinal *= 1 + sumAgregandoPorcentaje;
                        sumAgregandoPorcentaje = 0;
                    }

                }
                
            }
            return (int)Math.Round(valorFinal, 4);
        }
    }
