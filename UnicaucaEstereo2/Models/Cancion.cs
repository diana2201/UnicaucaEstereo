using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicaucaEstereo2.Models
{
    public class Cancion : INotifyPropertyChanged
    {
        private String nombre;
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
                }
            }
        }


        private String autor;
        public String Autor
        {
            get
            {
                return autor;
            }
            set
            {
                autor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Autor"));
                }
            }
        }

        private String genero;
        public String Genero
        {
            get
            {
                return genero;
            }
            set
            {
                genero = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Genero"));
                }
            }
        }

        private int tiempo;
        public int Tiempo
        {
            get
            {
                return tiempo;
            }
            set
            {
                tiempo = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Tiempo"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
