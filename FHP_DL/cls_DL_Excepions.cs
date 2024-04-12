using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public class cls_DL_Excepions:Exception
    {
        public cls_DL_Excepions(string message, Exception innerException)
                : base(message, innerException)
        {
        }
    }
}
