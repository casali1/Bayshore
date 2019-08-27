using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bayshore.Service
{
    public interface IConverterService
    {
        string ConvertIntoWords(long number);
    }
}
