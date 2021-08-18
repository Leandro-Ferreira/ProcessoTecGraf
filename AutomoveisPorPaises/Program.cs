using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutomoveisPorPaises
{
    class Program
    {
        static void Main(string[] args)
        {
            var paises = @"C:\Users\Leandro\source\repos\ProcessoTecGraf\AutomoveisPorPaises\App_Data\paises.txt";
            var serie = @"C:\Users\Leandro\source\repos\ProcessoTecGraf\AutomoveisPorPaises\App_Data\serieParaRelatorio.txt";
            
            string[] arquivoPaises = new string[] { };

            string[] arquivoSerie = new string[] { };

            List<Retorno> retornos = new List<Retorno>();

            IDictionary<string, string> dic = new Dictionary<string, string>();

            if (File.Exists(paises))
            {
                arquivoPaises = File.ReadAllLines(paises);
            }

            if(File.Exists(serie))
            {
               arquivoSerie = File.ReadAllLines(serie);
            }


            foreach(string linha in arquivoPaises)
            {
                var array = linha.Split(";");
                var sigla = array[0] + "XX";
                var pais = array[1];
                dic.Add(sigla, pais);
               
            }

            foreach(string linha in arquivoSerie)
            {
                foreach(KeyValuePair<string,string> item in dic)
                {
                    if(linha.IndexOf(item.Key) > -1)
                    {
                        var ret = new Retorno(item.Value, item.Key);

                        retornos.Add(ret);
                    }
                }
            }

            var monstro = retornos.GroupBy(c => c.Pais)
                .Select(group => new { Pais = group.Key, Contador = group.Count()});
     
            foreach(var result in monstro)
            {
                Console.WriteLine("{0},{1}",  result.Pais,result.Contador);
            }

            Console.Read();
        }

        public class Retorno
        {
            public string Pais { get; set; }

            public string Codigo { get; set; }

            public int Contador { get; set; }

            public Retorno(string pais, string codigo)
            {
                Pais = pais;
                Codigo = codigo;
            }

            public Retorno(string pais, int contador)
            {
                Pais = pais;
                Contador = contador;
            }
        }
    }
}
