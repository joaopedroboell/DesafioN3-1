using System;
using System.IO;

namespace DesafioN3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var processador = new ProcessadorDeXml();
            var TotalvNF = processador.RetornaTotalXmls(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "arquivos"));
            Console.WriteLine("Valor Total dos xmls: " + TotalvNF);
            Console.ReadKey();
        }
    }
}
