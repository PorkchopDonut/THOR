using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR
{
    public class OWC
    {
        private string Code;
        private string Description;
        private string OfficeSymbol;
        private string Contact;
        private string PhoneNumber;
        private string Address;

        #region Accessors
        public string code
        {
            get
            {
                return Code;
            }

            set
            {
                Code = value;
            }
        }

        public string description
        {
            get
            {
                return Description;
            }

            set
            {
                Description = value;
            }
        }

        public string officeSymbol
        {
            get
            {
                return OfficeSymbol;
            }

            set
            {
                OfficeSymbol = value;
            }
        }

        public string contact
        {
            get
            {
                return Contact;
            }

            set
            {
                Contact = value;
            }
        }

        public string phoneNumber
        {
            get
            {
                return PhoneNumber;
            }

            set
            {
                PhoneNumber = value;
            }
        }

        public string address
        {
            get
            {
                return Address;
            }

            set
            {
                Address = value;
            }
        }
        #endregion
    }
}
