using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculation
{
    public class ResultSingleton
    {
        private static ResultSingleton instance;
        public int Result { get; set; }

        private ResultSingleton() { }

        public static ResultSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ResultSingleton();
            }
            return instance;
        }
    }
}
