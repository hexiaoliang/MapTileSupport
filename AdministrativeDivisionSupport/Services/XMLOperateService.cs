using AdministrativeDivisionSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdministrativeDivisionSupport.Services
{
    class XMLOperateService : IDataOperateService
    {
        public XDeclaration XDeclaration { get; private set; }
        public XComment xComment { get; private set; }
        public XElement RootElement { get; private set; }
        public string SavaPath { get; private set; }
        public List<Province> ProvinceCollection { get; private set; }

        public XMLOperateService(XDeclaration xDeclaration, XComment xComment, XElement rootElement, string savaPath, List<Province> provinceCollection) {
            this.XDeclaration = xDeclaration;
            this.xComment = xComment;
            this.RootElement = rootElement;
            this.SavaPath = savaPath;
            this.ProvinceCollection = provinceCollection;
        }

        public void CreateDataDocument()
        {
            XDocument xDocumentAdministrativeDivision = new XDocument(this.XDeclaration, this.xComment, this.RootElement);

            XElement xElementProvince;
            XElement xElementCity;
            XElement xElementCounty;

            foreach (var province in this.ProvinceCollection)
            {
                xElementProvince = new XElement("Province", new XAttribute("code", province.Code), new XAttribute("name", province.Name));

                if (province.CityCollection != null)
                {
                    foreach (var city in province.CityCollection)
                    {
                        xElementCity = new XElement("City", new XAttribute("code", city.Code), new XAttribute("name", city.Name));

                        if (city.CountyCollection != null)
                        {
                            foreach (var county in city.CountyCollection)
                            {
                                xElementCounty = new XElement("County", new XAttribute("code", county.Code), new XAttribute("name", county.Name));

                                xElementCity.Add(xElementCounty);
                            }
                        }

                        xElementProvince.Add(xElementCity);
                    }
                }

                xDocumentAdministrativeDivision.Root.Add(xElementProvince);
            }

            xDocumentAdministrativeDivision.Save(this.SavaPath);
        }

        public void DeleteDataItem()
        {
            throw new NotImplementedException();
        }

        public void InsertDataItem()
        {
            throw new NotImplementedException();
        }

        public void ModifyDataItem()
        {
            throw new NotImplementedException();
        }

        public void QueryDataItem()
        {
            throw new NotImplementedException();
        }
    }
}
