using MyMovieServer.Models;
using MyMovieServer.Presentation_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieServer.Mapping
{
    public class KeyValueMap : IKeyValueMap
    {
        public List<KeyValuePM> GenerosMap(List<Genero> generos)
        {
            List<KeyValuePM> list = new List<KeyValuePM>();


            foreach (Genero gen in generos)
            {

                KeyValuePM temp = new KeyValuePM
                {
                    id = gen.IdGenero,
                    nombre = gen.Genero1
                };
                list.Add(temp);
            }

            return list;
        }

        public List<KeyValuePM> EstilosMap(List<Estilo> estilos)
        {
            List<KeyValuePM> list = new List<KeyValuePM>();


            foreach (Estilo est in estilos)
            {

                KeyValuePM temp = new KeyValuePM
                {
                    id = est.IdEstilo,
                    nombre = est.Estilo1
                };
                list.Add(temp);
            }

            return list;
        }

        public List<KeyValuePM> IdiomasMap(List<Idioma> idiomas)
        {
            List<KeyValuePM> list = new List<KeyValuePM>();


            foreach (Idioma idm in idiomas)
            {

                KeyValuePM temp = new KeyValuePM
                {
                    id = idm.IdIdioma,
                    nombre = idm.Idioma1
                };
                list.Add(temp);
            }

            return list;
        }
    }
}
