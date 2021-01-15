using Imagens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceBase service = new ServiceBase())
            {
                string path = @"C:\Conexao\teste.txt";
                string diretorio = @"C:\teste";

                service.CriarDiretorio(diretorio);

                var ar = service.Gravar(path, "Teste");

                var a1 = service.Buscar(path);


                var a3 = service.ListarDiretorios(@"C:\");

                var a4 = service.ListarArquivosDoDiretorio(@"C:\");

                var a5 = service.ListarArquivosDoDiretorio(@"C:\Conexao", "txt");

                var a6 = service.ListarArquivosDoDiretorioSubDiretório(@"C:\Cmder", "txt");

                var a7 = service.ExisteArquivo(path);

                var a8 = service.Copiar(diretorio, path);

                var a9 = service.ExcluirArquivo(path);

                var a10 = service.ExisteDiretorio(diretorio);

                var a11 = service.ExcluirDiretorio(diretorio);


            }
        }
    }
}
