using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Core;

namespace GeradorNumeroSerie
{
    class Program
    {
        static void Main(string[] args)
        {
            var seriesemDV = @"C:\Users\Leandro\source\repos\ProcessoTecGraf\GeradorNumeroSerie\App_Data\serieSemDV.txt";
            var seriesComDV = @"C:\Users\Leandro\source\repos\ProcessoTecGraf\GeradorNumeroSerie\App_Data\serieComDV.txt";

            Console.WriteLine("Iniciando o calculo do digito verificador.....");

            var arquivo = new Arquivo();
         
            var calculadoraDigitoVerificador = new CalculadoraDigitoVerificador();

            IList<string> registrosComDigitoVerificador = new List<string>();

            var registros = arquivo.LerDoArquivo(seriesemDV);
            
            foreach (var registro in registros)
            {
                var digitoVerificador =  
                    calculadoraDigitoVerificador.CalcularDigitoVerificador(registro);

                var registroComDigitoVerificador = GerarSerieComDigitoVerificador(registro, digitoVerificador);

                registrosComDigitoVerificador.Add(registroComDigitoVerificador);
            }

            arquivo.EscreverNoArquivo(seriesComDV, registrosComDigitoVerificador.ToArray());

            Console.WriteLine("Calculo finalizado....");
            Console.WriteLine("Arquivo gerado");
            Console.WriteLine();
            var registroComDigito = arquivo.LerDoArquivo(seriesComDV);

            foreach (var serie in registroComDigito)
            {
                Console.WriteLine(serie);
                Console.WriteLine();
            }

            Console.Read();
        }

        static string GerarSerieComDigitoVerificador(string registro, string digitoVerificador)
        {
            return registro + "-" + digitoVerificador;
        }
    }
}
