using System.Collections.Generic;
using System.Text;

namespace Utils.Core
{
    public class CalculadoraDigitoVerificador
    {
        private readonly IDictionary<int, string> dic = new Dictionary<int, string>();
        
        public CalculadoraDigitoVerificador()
        {

            dic.Add(10, "A");
            dic.Add(11, "B");
            dic.Add(12, "C");
            dic.Add(13, "D");
            dic.Add(14, "E");
            dic.Add(15, "F");
        }

        private byte[] ExtrairCodigoASCIIDoArquivo(string linhaAquivo)
        {
            //Retornar os bytes
            return Encoding.ASCII.GetBytes(linhaAquivo);
        }

        public string CalcularDigitoVerificador(string linhaArquivo)
        {
            var codigosASCII = ExtrairCodigoASCIIDoArquivo(linhaArquivo);

            int    restoDivisao;
            string digito;

            int soma = 0;
            foreach (byte codigoASCII in codigosASCII)
            {
                soma += codigoASCII;
            }

            restoDivisao = soma % 16;

            if (restoDivisao > 9)
            {
                digito = dic[restoDivisao];
            }
            else
            {
                digito = restoDivisao.ToString();
            }

            return digito;
        }
        
    }
}
