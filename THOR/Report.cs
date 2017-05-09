using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR
{
    public class Report
    {
        private string ModelNumber;
        private string SerialNumber;
        private string Capacity;

        private string IDNumber;
        private List<Calibration> Cals = new List<Calibration>();

        private OWC OWC = new OWC();

        #region Accessors
        public string modelNumber
        {
            get
            {
                return ModelNumber;
            }

            set
            {
                ModelNumber = value;
            }
        }

        public string serialNumber
        {
            get
            {
                return SerialNumber;
            }

            set
            {
                SerialNumber = value;
            }
        }
        
        public string capacity
        {
            get
            {
                return Capacity;
            }
            set
            {
                Capacity = value;
            }
        }

        public string idNumber
        {
            get
            {
                return IDNumber;
            }

            set
            {
                IDNumber = value;
            }
        }

        public List<Calibration> cals
        {
            get
            {
                return Cals;
            }

            set
            {
                Cals = value;
            }
        }

        public OWC owc
        {
            get
            {
                return OWC;
            }

            set
            {
                OWC = value;
            }
        }
        #endregion
    }
}
