using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TSUtility
{
    public sealed class GlobalVariables
    {

        static ArrayList glbPageNames;

        static string glbString;
        public static ArrayList GlobalPageNames
        {
            get { return glbPageNames; }
            set { glbPageNames = value; }
        }

        public static string GlobalString
        {
            get { return glbString; }
            set { glbString = value; }
        }

    }
}
