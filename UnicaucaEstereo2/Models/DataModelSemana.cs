using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicaucaEstereo2.Models
{
   public class DataModelSemana
    {

        public ObservableCollection<Programa> dataLunes;
        public ObservableCollection<Programa> DataLunes
        {
            get
            {
                if (dataLunes == null)
                    dataLunes = new ObservableCollection<Programa>();

                return dataLunes;
            }
            set
            {
                dataLunes = value;
            }
        }

        public ObservableCollection<Programa> dataMartes;
        public ObservableCollection<Programa> DataMartes
        {
            get
            {
                if (dataMartes == null)
                    dataMartes = new ObservableCollection<Programa>();

                return dataMartes;
            }
            set
            {
                dataMartes = value;
            }
        }

        public ObservableCollection<Programa> dataMiercoles;
        public ObservableCollection<Programa> DataMiercoles
        {
            get
            {
                if (dataMiercoles == null)
                    dataMiercoles = new ObservableCollection<Programa>();

                return dataMiercoles;
            }
            set
            {
                dataMiercoles = value;
            }
        }

        public ObservableCollection<Programa> dataJueves;
        public ObservableCollection<Programa> DataJueves
        {
            get
            {
                if (dataJueves == null)
                    dataJueves = new ObservableCollection<Programa>();

                return dataJueves;
            }
            set
            {
                dataJueves = value;
            }
        }

        public ObservableCollection<Programa> dataViernes;
        public ObservableCollection<Programa> DataViernes
        {
            get
            {
                if (dataViernes == null)
                    dataViernes = new ObservableCollection<Programa>();

                return dataViernes;
            }
            set
            {
                dataViernes = value;
            }
        }

        public ObservableCollection<Programa> dataSabado;
        public ObservableCollection<Programa> DataSabado
        {
            get
            {
                if (dataSabado == null)
                    dataSabado = new ObservableCollection<Programa>();

                return dataSabado;
            }
            set
            {
                dataSabado = value;
            }
        }

        public ObservableCollection<Programa> dataDomingo;
        public ObservableCollection<Programa> DataDomingo
        {
            get
            {
                if (dataDomingo == null)
                    dataDomingo = new ObservableCollection<Programa>();

                return dataDomingo;
            }
            set
            {
                dataDomingo = value;
            }
        }
    
    }

 }
