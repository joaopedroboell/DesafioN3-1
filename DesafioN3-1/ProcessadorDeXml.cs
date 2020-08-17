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

            //Parallel.ForEach(Xmls, (x) => //Em testes, retornou um valor total diferente por cada execução.
            foreach (var x in Xmls)
            {
                //total += decimal.Parse(x.GetElementsByTagName("vNF")[0].InnerXml);
                decimal.TryParse(x.GetElementsByTagName("vNF")[0].InnerXml.Replace('.', ','), out decimal valorNF);
                total += valorNF;
            };
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
