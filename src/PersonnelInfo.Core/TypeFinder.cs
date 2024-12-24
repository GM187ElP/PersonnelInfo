using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core;
public class TypeFinder
{
    public static string FindType(string entityName, string operation)
    {
        return $"{entityName}{operation}Dto";
    }
}
