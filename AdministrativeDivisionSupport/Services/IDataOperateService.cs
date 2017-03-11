using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdministrativeDivisionSupport.Services
{
    interface IDataOperateService
    {
        void CreateDataDocument();

        void InsertDataItem();

        void DeleteDataItem();

        void QueryDataItem();

        void ModifyDataItem();
    }
}
