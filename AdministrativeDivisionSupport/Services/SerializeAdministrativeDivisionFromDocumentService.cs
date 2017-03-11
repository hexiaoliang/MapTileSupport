using AdministrativeDivisionSupport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministrativeDivisionSupport.Services
{
    class SerializeAdministrativeDivisionFromDocumentService : IAdministrativeDivisionService
    {
        public void Deserialize()
        {
        }

        public List<Province> Serialize()
        {
            int provinceCount = 0;
            int cityCount = 0;
            int countyCount = 0;

            List<Province> provinceCollection = new List<Province>();
            List<City> cityCollection = new List<City>();
            List<County> countyCollection = new List<County>();
            List<Material> materialCollection = new List<Material>();

            Province province;
            City city;
            County county;
            Material material;

            string documentName = @"Data\国家行政区划代码.txt";
            StreamReader streamReader = new StreamReader(documentName, Encoding.Default);

            string dataItem = String.Empty;

            while (streamReader.Peek() != -1)
            {
                dataItem = streamReader.ReadLine().Trim();

                province = new Province();

                material = new Material();

                switch (CaluateCharShowCount(dataItem, ' '))
                {
                    case 1:
                        provinceCount++;
                        province.Code = int.Parse(dataItem.Split(' ')[0]);
                        province.Name = dataItem.Split(' ')[1];
                        province.Index = provinceCount + cityCount + countyCount;
                        provinceCollection.Add(province);

                        material.Code = int.Parse(dataItem.Split(' ')[0]);
                        material.Name = dataItem.Split(' ')[1];
                        material.Level = 1;
                        material.Index = provinceCount + cityCount + countyCount;
                        materialCollection.Add(material);
                        break;
                    case 2:
                        cityCount++;
                        material.Code = int.Parse(new Regex("  ").Split(dataItem)[0]);
                        material.Name = new Regex("  ").Split(dataItem)[1];
                        material.Level = 2;
                        material.Index = provinceCount + cityCount + countyCount;
                        materialCollection.Add(material);
                        break;
                    case 3:
                        countyCount++;
                        material.Code = int.Parse(new Regex("   ").Split(dataItem)[0]);
                        material.Name = new Regex("   ").Split(dataItem)[1];
                        material.Level = 3;
                        material.Index = provinceCount + cityCount + countyCount;
                        materialCollection.Add(material);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < provinceCollection.Count; i++)
            {
                cityCollection.Clear();

                if (i == provinceCollection.Count - 1)
                {
                    for (int j = provinceCollection[i].Index; j < materialCollection.Count; j++)
                    {
                        city = new City();
                        county = new County();

                        if (materialCollection[j].Level == 2)
                        {
                            countyCollection.Clear();

                            city.Index = materialCollection[j].Index;
                            city.Name = materialCollection[j].Name;
                            city.Code = materialCollection[j].Code;
                            cityCollection.Add(city);
                        }
                        else
                        {
                            county.Index = materialCollection[j].Index;
                            county.Name = materialCollection[j].Name;
                            county.Code = materialCollection[j].Code;
                            countyCollection.Add(county);

                            cityCollection[cityCollection.Count - 1].CountyCollection = new List<County>(countyCollection);  //深复制
                        }
                    }
                }
                else
                {
                    for (int j = provinceCollection[i].Index; j < provinceCollection[i + 1].Index - 1; j++)
                    {
                        city = new City();
                        county = new County();

                        if (materialCollection[j].Level == 2)
                        {
                            countyCollection.Clear();

                            city.Index = materialCollection[j].Index;
                            city.Name = materialCollection[j].Name;
                            city.Code = materialCollection[j].Code;
                            cityCollection.Add(city);
                        }
                        else
                        {
                            county.Index = materialCollection[j].Index;
                            county.Name = materialCollection[j].Name;
                            county.Code = materialCollection[j].Code;
                            countyCollection.Add(county);

                            cityCollection[cityCollection.Count - 1].CountyCollection = new List<County>(countyCollection);  //深复制
                        }
                    }
                }

                provinceCollection[i].CityCollection = new List<City>(cityCollection);  //深复制
            }

            return provinceCollection;
        }

        /// <summary>
        /// 使用递归统计文本中某一字符出现的次数
        /// </summary>
        /// <param name="str">文本字符串</param>
        /// <param name="c">指定字符</param>
        /// <returns></returns>
        public int CaluateCharShowCount(string str, char c)
        {
            if (str.Length == 0)
                return 0;
            if (str.Length == 1)
            {
                if (str == c.ToString())
                    return 1;
                else
                    return 0;
            }
            if (str.Length == 2)
                return CaluateCharShowCount(str.Substring(0, 1), c) + CaluateCharShowCount(str.Substring(1, 1), c);
            else
                return CaluateCharShowCount(str.Substring(0, 1), c) + CaluateCharShowCount(str.Substring(1), c);
        }
    }
}
