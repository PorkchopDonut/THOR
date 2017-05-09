using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR
{
    public class Step
    {
        private string Name;
        private string Comments;
        private string Directon;
        private double Output;
        private double NonLinearity;
        private double Hysteresis;
        private double SEBOutput;
        private double SEB;
        private double CEB;
        private double NonRepeatability;

        private List<TestPoint> TestPoints = new List<TestPoint>();

        #region Accessors
        public string name
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public string comments
        {
            get
            {
                return Comments;
            }

            set
            {
                Comments = value;
            }
        }

        public string directon
        {
            get
            {
                return Directon;
            }

            set
            {
                Directon = value;
            }
        }

        public List<TestPoint> testPoints
        {
            get
            {
                return TestPoints;
            }

            set
            {
                TestPoints = value;
            }
        }

        public double output
        {
            get
            {
                return Output;
            }

            set
            {
                Output = value;
            }
        }

        public double nonLinearity
        {
            get
            {
                return NonLinearity;
            }

            set
            {
                NonLinearity = value;
            }
        }

        public double hysteresis
        {
            get
            {
                return Hysteresis;
            }

            set
            {
                Hysteresis = value;
            }
        }

        public double sebOutput
        {
            get
            {
                return SEBOutput;
            }

            set
            {
                SEBOutput = value;
            }
        }

        public double seb
        {
            get
            {
                return SEB;
            }

            set
            {
                SEB = value;
            }
        }

        public double ceb
        {
            get
            {
                return CEB;
            }

            set
            {
                CEB = value;
            }
        }

        public double nonRepeatability
        {
            get
            {
                return NonRepeatability;
            }

            set
            {
                NonRepeatability = value;
            }
        }
        #endregion
    }
}
