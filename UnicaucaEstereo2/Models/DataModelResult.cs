/*
 *Desarrollado por:
 * Hamilton Andrés Urbano Benavides
 * h.a.u.r1993@gmail.com
 * Diana Marcela Samboní
 * dianasamboni22@gmail.com
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnicaucaEstereo2.Models
{
    public class DataModelResult
    {
        public ObservableCollection<Musica> dataR;
        public ObservableCollection<Musica> DataR
        {
            get
            {
                if (dataR == null)
                    dataR = new ObservableCollection<Musica>();

                return dataR;
            }
            set
            {
                dataR = value;
            }
        }
    }
}
