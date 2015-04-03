using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicaucaEstereo2.Models
{
    public class Canciones
    {
        //data es la propiedad de la clase libros 
        ObservableCollection<Cancion> data;

        //Data son los atributos de estas propiedades
        public ObservableCollection<Cancion> Data
        {
            get
            {
                if (data == null)
                {
                    data = new ObservableCollection<Cancion>();
                    Cancion cancion1 = new Cancion()
                    {
                        Autor = "Silvestre Dangond",
                        Genero = "Vallenato",
                        Nombre = "Pasado es pasado",
                        Tiempo = 210
                    };

                    Cancion cancion2 = new Cancion()
                    {
                        Autor = "Ñejo Flow",
                        Genero = "Regue",
                        Nombre = "Mujeres Talentosas",
                        Tiempo = 185
                    };
                    Cancion cancion3 = new Cancion()
                    {
                        Autor = "Jowell y Randy",
                        Genero = "Regue",
                        Nombre = "Shorty",
                        Tiempo = 205
                    };
                    Cancion cancion4 = new Cancion()
                    {
                        Autor = "Vicente Fernandez",
                        Genero = "Ranchera",
                        Nombre = "Mujeres divinas",
                        Tiempo = 205
                    };
                    Cancion cancion5 = new Cancion()
                    {
                        Autor = "Vicente Fernandez",
                        Genero = "Ranchera",
                        Nombre = "Celos",
                        Tiempo = 205
                    };
                    Cancion cancion6 = new Cancion()
                    {
                        Autor = "Vicente Fernandez",
                        Genero = "Ranchera",
                        Nombre = "La derrot",
                        Tiempo = 205
                    };
                    data.Add(cancion1);
                    data.Add(cancion2);
                    data.Add(cancion3);
                    data.Add(cancion4);
                    data.Add(cancion5);
                    data.Add(cancion6);
                }
                return data;
            }

            set
            {
                data = value;
            }
        }
    }
}
