using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR
{
    public class Calibration
    {
        private string Technician;
        private Standard Standard = new Standard();
        private int Temperature;
        private int Humidity;
        private double ExcitationVoltage;
        private string DateCal;
        private string DateDue;
        private string CalTO;

        private List<Step> Steps = new List<Step>();

        #region Accessors
        public string technician
        {
            get
            {
                return Technician;
            }

            set
            {
                Technician = value;
            }
        }

        public Standard standard
        {
            get
            {
                return Standard;
            }

            set
            {
                Standard = value;
            }
        }

        public int temperature
        {
            get
            {
                return Temperature;
            }

            set
            {
                Temperature = value;
            }
        }

        public int humidity
        {
            get
            {
                return Humidity;
            }

            set
            {
                Humidity = value;
            }
        }

        public double excitationVoltage
        {
            get
            {
                return ExcitationVoltage;
            }

            set
            {
                ExcitationVoltage = value;
            }
        }

        public string dateCal
        {
            get
            {
                return DateCal;
            }

            set
            {
                DateCal = value;
            }
        }

        public List<Step> steps
        {
            get
            {
                return Steps;
            }

            set
            {
                Steps = value;
            }
        }

        public string dateDue
        {
            get
            {
                return DateDue;
            }

            set
            {
                DateDue = value;
            }
        }

        public string calTO
        {
            get
            {
                return CalTO;
            }

            set
            {
                CalTO = value;
            }
        }
        #endregion
    }
}
