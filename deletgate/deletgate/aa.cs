using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deletgate
{
    class aa
    {
        public delegate String dele(String ss);
        public event dele dele1;
           public String asd(String ss)
            {
                dele1(ss);
                return ss;
            }
    }
}
