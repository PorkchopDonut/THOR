using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR
{
    public class TestPoint
    {
        private string Load;
        private string Test;
        private string Normal;

        #region Accessors
        public string load
        {
            get
            {
                return Load;
            }

            set
            {
                Load = value;
            }
        }

        public string test
        {
            get
            {
                return Test;
            }

            set
            {
                Test = value;
            }
        }

        public string normal
        {
            get
            {
                return Normal;
            }

            set
            {
                Normal = value;
            }
        }
        #endregion
    }
}
