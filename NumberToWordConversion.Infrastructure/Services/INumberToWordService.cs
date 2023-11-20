using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConversion.Infrastructure.Services
{
    public interface INumberToWordService
    {
        public  string Convert(decimal value);
    }
}
