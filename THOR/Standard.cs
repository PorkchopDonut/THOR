using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR
{
    public class Standard
    {
        private string IDNumber;
        private string SerialNumber;
        private string TestLoad;

        #region Accessors
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

        public string testLoad
        {
            get
            {
                return TestLoad;
            }

            set
            {
                TestLoad = value;
            }
        }
        #endregion
    } 
}
