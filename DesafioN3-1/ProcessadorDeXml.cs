using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            foreach (var xml in Xmls)
            {
                if (String.IsNullOrEmpty(xml.GetElementsByTagName("vNF")[0].InnerXml))
                {
                    total += 0;
                }
                else
                {
                    total += decimal.Parse(xml.GetElementsByTagName("vNF")[0].InnerXml.Replace('.', ','));
                }
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
