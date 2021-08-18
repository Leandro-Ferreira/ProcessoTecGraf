using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Core;

namespace VerificadorNumeroSerie
{
    class Program
    {
        static void Main(string[] args)
        {
            var serieParaVerificar = @"C:\Users\Leandro\source\repos\ProcessoTecGraf\VerificadorNumeroSerie\App_Data\serieParaVerificar.txt";
            var serieVerificada = @"C:\Users\Leandro\source\repos\ProcessoTecGraf\VerificadorNumeroSerie\App_Data\serieVerificada.txt";
            
            Console.WriteLine("Análise do dígito verificador");
            
            var arquivo = new Arquivo();

            var calculadoraNumeroSerie = new CalculadoraDigitoVerificador();

            var registrosParaVerificar = arquivo.LerDoArquivo(serieParaVerificar);

            IList<string> seriesVerificadas = new List<string>();
            
            string digitoVerificador;
            foreach(string registroParaVerificar in registrosParaVerificar)
            {
               digitoVerificador = calculadoraNumeroSerie.CalcularDigitoVerificador(registroParaVerificar.Split("-")[0]);
               seriesVerificadas.Add(VerificarSeDigitoEValido(registroParaVerificar, digitoVerificador));
            }

            arquivo.EscreverNoArquivo(serieVerificada, seriesVerificadas.ToArray());

            var arquivoGerado = arquivo.LerDoArquivo(serieVerificada);

            Console.WriteLine("Saída.....");

            foreach(var registro in arquivoGerado)
            {
                Console.WriteLine(registro);
                Console.WriteLine();
            }

            Console.Read();
        
        }

        static string VerificarSeDigitoEValido(string registro, string digitoVerificador)
        {
            var digitoRegistro = registro.Split("-")[1];

            string verdadeiro = " verdadeiro";

            string falso = " falso";

            if (digitoRegistro.Equals(digitoVerificador))
            {
                registro += verdadeiro;

                return registro;
            }
            registro += falso;
            return registro;
        }
    }
}
