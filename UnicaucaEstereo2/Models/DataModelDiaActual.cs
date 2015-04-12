using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicaucaEstereo2.Models
{
    public class DataModelDiaActual
    {
        public ObservableCollection<Programa> dataActual;
        public ObservableCollection<Programa> DataActual
        {
            get
            {
                if (dataActual == null)
                    dataActual = new ObservableCollection<Programa>();

                return dataActual;
            }
            set
            {
                dataActual = value;
            }
        }
    }
}
