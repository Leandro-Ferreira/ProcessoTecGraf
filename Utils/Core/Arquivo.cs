using System.IO;

namespace Utils.Core
{
    public class Arquivo
    {

        public string[] LerDoArquivo(string caminho)
        {
            if(File.Exists(caminho))
            {
                //Retorno
                return File.ReadAllLines(caminho);

            }

            return new string[] { };
        }

        public void EscreverNoArquivo(string caminho, string[] registros)
        {
            File.WriteAllLines(caminho, registros);
        }
    }
}
