using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Bills
{
    internal class BillsManager
    {
        static string[] codes = new string[] { "RSSMRA58T43S234B", "VRDMRC80E45R321A" };

        internal static bool CheckCode(string code)
        {
            //if (codes.Contains(code))
            //    return true;

            ////fuori dall'if
            //    return false;

            return codes.Contains(code);

            //foreach (string c in codes)
            //{
            //    if (c == code)
            //        return true;
            //}

            //return false;
        }
    }
}
