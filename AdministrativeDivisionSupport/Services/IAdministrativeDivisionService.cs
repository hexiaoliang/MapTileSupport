using AdministrativeDivisionSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeDivisionSupport.Services
{
    interface IAdministrativeDivisionService
    {
        List<Province> Serialize();
        void Deserialize();
    }
}
