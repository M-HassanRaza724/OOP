using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    public class Calculator
    {
        public float no1;
        public float no2;
        public Calculator(float n1,float n2)
        {
            no1 = n1;
            no2 = n2;
        }

        public float add()
        {
            return no1 + no2;
        }
        public float sub()
        {
            return no1 - no2;
        }
        public float quotient()
        {
            return no1 / no2;
        }
        public float mul()
        {
            return no1 * no2;
        }
    }
}
