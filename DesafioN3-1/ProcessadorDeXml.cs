using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace DesafioN3_1
{
    public class ProcessadorDeXml
    {
        public List<XmlDocument> Xmls { get; set; }

        public ProcessadorDeXml()
        {
            Xmls = new List<XmlDocument>();
        }

        public decimal RetornaTotalXmls(string caminho)
        {
            CarregaXmls(caminho);
            return SomaTotalXml();
        }

        public decimal SomaTotalXml()
        {
            var total = (decimal)0;
            var valorNF = (decimal)0;
            decimal auxDecimal = 0;
            
            foreach (XmlDocument x in Xmls)
            {               
                valorNF = decimal.TryParse(x.GetElementsByTagName("vNF")[0].InnerXml.Replace('.', ','), out auxDecimal) ? auxDecimal : (decimal)-1;
                total += valorNF;
            }
        
            return total;
        }

        public void CarregaXmls(string caminho)
        {
            var xmlsNaPasta = new DirectoryInfo(caminho)
                .GetFiles()
                .OrderBy(x => x.Name)
                .ToArray();
            for (var i = 0; i < xmlsNaPasta.Length; i++)
            {
                var xml = new XmlDocument();
                xml.Load(xmlsNaPasta[i].FullName);
                Xmls.Add(xml);
            }
        }
    }
}
