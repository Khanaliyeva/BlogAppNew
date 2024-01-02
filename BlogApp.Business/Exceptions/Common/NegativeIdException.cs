using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Common
{
    public class NegativeIdException:Exception
    {
        public NegativeIdException():base("menfi ve ya sifir id olmaz")
        {
            
        }
    }
}
