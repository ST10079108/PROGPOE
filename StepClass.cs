using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class StepClass
    {
        public StepClass() { }
        public StepClass(double stepNum, string desc)
        {
            StepNum = stepNum;
            Desc = desc;

        }

        public double StepNum { get; set; }
        public string Desc { get; set; }
    }
}
//<summary>
//In this code I created a deafault constructor as well as a constructor with arguments for step number and step description
//This class is used to store steps instances
//</summary>
