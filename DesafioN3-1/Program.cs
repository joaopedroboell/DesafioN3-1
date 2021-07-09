using System;
using System.IO;

namespace DesafioN3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var processador = new ProcessadorDeXml();
            var totalVnf = processador.RetornaTotalXmls(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "arquivos"));
            Console.WriteLine("Valor Total dos xmls: " + totalVnf);
            Console.ReadKey();
        }
    }
}
