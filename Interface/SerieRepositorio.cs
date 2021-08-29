using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<serie>
    {
        private List<serie> listaSerie = new List<serie>();
        public void Atualiza(int id, serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}