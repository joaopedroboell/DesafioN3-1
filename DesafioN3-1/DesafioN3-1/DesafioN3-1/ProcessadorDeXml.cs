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
            //Essa funcionalidade apresentada um erro de validação, onde caso o xml não estivesse a tag vNF e retornasse null
            //  a função não rodava, utilizado nesse caso, a função String.IsNullOrEmpty onde caso o valor entregue seja null, ele retorna um true, e caso seja
            //  um valor valido ele retorna um false, utilizado um operador ternario para caso o valor seja true ele some ao valor do total como 0 caso contrario
            //  somando o valor correto.
            //Outra problema era referente ao retorno, estava apenas retornando o valor de um dos xmls na minha maquina, creio que seja pela utilização de 
            //  do parallel.ForEach, como nesse exemplo haviam poucos xmls, me senti livre para utilizar um foreach, mas teria que ser reavaliado, pela questão de 
            //  desempenho.
            //O terceiro ponto a ser corrigido, foi a utilização do decimal.Parse, pois em meus testes ele estava retornado o valor da string 
            //  sem o ponto das casas decimais, tratando tudo como um int, apenas utilizei o Replace para ele considerar . e , no decimal. 


            /*
            Creio que a utilização de uma função nesse formato já resolveria o problema do desempenho, mas teria que ser testado em outras maquinas para validação
            se o problema de retornar apenas um dos valores do xmls é um problema local. 

            **
                var total = (decimal)0;
            Parallel.ForEach(Xmls, (x) =>
            {
                total += String.IsNullOrEmpty(xml.GetElementsByTagName("vNF")[0].InnerXml) ? 0 :
                                decimal.Parse(xml.GetElementsByTagName("vNF")[0].InnerXml.Replace('.', ',')); ;
            });
            
             **

            //Função antiga do sistema
            /*
            var total = (decimal)0;
            Parallel.ForEach(Xmls, (x) =>
            {
                total += decimal.Parse(x.GetElementsByTagName("vNF")[0].InnerXml);
            });

            */

            var total = (decimal)0;
             foreach (var xml in Xmls)
                {

                    total += String.IsNullOrEmpty(xml.GetElementsByTagName("vNF")[0].InnerXml) ? 0 :
                                decimal.Parse(xml.GetElementsByTagName("vNF")[0].InnerXml.Replace('.', ',')); ;
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
