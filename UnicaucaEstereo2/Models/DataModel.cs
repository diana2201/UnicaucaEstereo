using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicaucaEstereo2.Models
{
    public class DataModel
    {
        public ObservableCollection<Musica> data;
        public ObservableCollection<Musica> Data
        {
            get
            {
                if (data == null)
                    data = new ObservableCollection<Musica>();

                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}
