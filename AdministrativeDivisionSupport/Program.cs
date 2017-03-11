using AdministrativeDivisionSupport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdministrativeDivisionSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============== 点击开始 ==============");

            Console.ReadKey();

            Console.WriteLine("============== 正在生成 ==============");

            XMLOperateService xmlOperateService = new XMLOperateService(new XDeclaration("1.0", "utf-8", "yes"),
                                                                        new XComment("\r\n" +
                                                                                     "  @author   intMinor" +
                                                                                     "\r\n" +
                                                                                     "  @email    gaotaomo@live.com" +
                                                                                     "\r\n" +
                                                                                     "  @version  v1.0 数据来源: 中华人民共和国国家统计局 截止2015年9月30日" +
                                                                                     "\r\n"),
                                                                        new XElement("Country", new XAttribute("code", "86"), new XAttribute("name", "中国")),
                                                                        "..\\..\\Data\\国家行政区划代码.xml", 
                                                                        new SerializeAdministrativeDivisionFromDocumentService().Serialize());

            xmlOperateService.CreateDataDocument();

            Console.WriteLine("============== 生成成功 ==============");

            Console.ReadKey();
        }
    }
}
