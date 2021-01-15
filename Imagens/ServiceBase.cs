using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagens
{
    public class ServiceBase : IDisposable
    {
        /// <summary>
        /// Cria um diretório se não existir.
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório</param>
        public virtual void CriarDiretorio(string caminhoDiretorio)
        {
            try
            {
                if (!Directory.Exists(caminhoDiretorio))
                {
                    Directory.CreateDirectory(caminhoDiretorio);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Listar todas as pastas do diretório expecificado.
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório</param>
        public virtual List<string> ListarDiretorios(string caminhoDiretorio)
        {
            try
            {
                List<string> diretorios = new List<string>();

                if (Directory.Exists(caminhoDiretorio))
                {
                    DirectoryInfo di = new DirectoryInfo(caminhoDiretorio);
                    DirectoryInfo[] diArr = di.GetDirectories();

                    foreach (DirectoryInfo dri in diArr)
                        diretorios.Add(dri.Name);
                }

                return diretorios;
            }
            catch (Exception)
            {

                throw;
            }
        } 
        
        /// <summary>
        /// Listar todos os arquivos do diretório expecificado.
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório</param>
        public virtual List<string> ListarArquivosDoDiretorio(string caminhoDiretorio)
        {
            try
            {
                List<string> arquivos = new List<string>();

                if (Directory.Exists(caminhoDiretorio))
                {
                    string[] fileArray = Directory.GetFiles(caminhoDiretorio);
                    arquivos.AddRange(fileArray);
                }

                return arquivos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista todos os arquivos do diretório com tipo do arquivo expecificado.
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório</param>
        /// <param name="tipoArquivo">Tipos exemplo (jpeg, jpg, png, pdf, ppt, png, gif, svg, xml, sql, txt, exe, zip, rar, html)</param>
        public virtual List<string> ListarArquivosDoDiretorio(string caminhoDiretorio, string tipoArquivo)
        {
            try
            {
                List<string> arquivos = new List<string>();

                if (Directory.Exists(caminhoDiretorio))
                {
                    string[] fileArray = Directory.GetFiles(caminhoDiretorio, $"*.{tipoArquivo}");
                    arquivos.AddRange(fileArray);
                }

                return arquivos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista trará de volta TODOS os arquivos no diretório especificado, bem como todos os subdiretórios com uma determinada extensão
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório</param>
        /// <param name="tipoArquivo">Tipos exemplo (jpeg, jpg, png, pdf, ppt, png, gif, svg, xml, sql, txt, exe, zip, rar, html)</param>
        public virtual List<string> ListarArquivosDoDiretorioSubDiretório(string caminhoDiretorio, string tipoArquivo)
        {
            try
            {
                List<string> arquivos = new List<string>();

                if (Directory.Exists(caminhoDiretorio))
                {
                    string[] fileArray = Directory.GetFiles(caminhoDiretorio, $"*.{tipoArquivo}", SearchOption.AllDirectories);
                    arquivos.AddRange(fileArray);
                }

                return arquivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exclui o diretório se ele existir.
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório</param>
        public virtual bool ExcluirDiretorio(string caminhoDiretorio)
        {
            try
            {
                if (Directory.Exists(caminhoDiretorio))
                {
                    Directory.Delete(caminhoDiretorio);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Verifica se o diretório existe.
        /// </summary>
        /// <param name="caminhoDiretorio">Caminho do diretório.</param>
        public virtual bool ExisteDiretorio(string caminhoDiretorio)
        {
            try
            {
                return Directory.Exists(caminhoDiretorio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se o arquivo existe. 
        /// </summary>
        /// <param name="caminhoArquivo">Nome do arquivo.</param>
        public virtual bool ExisteArquivo(string caminhoArquivo)
        {
            try
            {
                return File.Exists(caminhoArquivo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Copia o arquivo para outro diretório. Caso o diretório não exista ele cria.
        /// </summary>
        /// <param name="caminhoArquivoOrigem">Caminho de origem do arquivo.</param>
        /// <param name="caminhoArquivoDestino">Caminho de destino do arquivo.</param>
        /// <returns>Retorna caso a copia tenha sido realizada com sucesso.(true ou false)</returns>
        public virtual bool Copiar(string caminhoArquivoOrigem, string caminhoArquivoDestino)
        {
            try
            {
                VerificaSeEArquivo(caminhoArquivoOrigem);
                VerificaSeEArquivo(caminhoArquivoDestino);

                File.Copy(caminhoArquivoOrigem, caminhoArquivoDestino);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui o arquivo com o caminho informado.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo.</param>
        /// <returns>Retorna se foi excluido o arquivo.(true ou false)</returns>
        public virtual bool ExcluirArquivo(string caminhoArquivo)
        {

            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    File.Delete(caminhoArquivo);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca o arquivo no caminho expecificado
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo.</param>
        /// <returns>Retorna o que está escrito no arquivo.</returns>
        public virtual string Buscar(string caminhoArquivo)
        {

            try
            {
                if (ExisteArquivo(caminhoArquivo))
                {
                    string arquivo = "";
                    StreamReader reader = new StreamReader(caminhoArquivo);
                    do
                    {
                        arquivo = arquivo + reader.ReadLine();
                    }
                    while (reader.Peek() != -1);

                    return arquivo;
                }
                return "Arquivo não existe";
            }
            catch
            {
                return "Arquivo está vazio";
            }
        }

        /// <summary>
        /// Gravar criar ou editar o arquivo no caminho especificado.
        /// </summary>
        /// <param name="caminhoArquivoOrigem">Caminho de origem do arquivo.</param>
        /// <param name="conteudoArquivo">Conteudo do arquivo.</param>
        /// <returns>Retorna o caminho do arquivo.</returns>
        public virtual string Gravar(string caminhoArquivoOrigem, string conteudoArquivo)
        {
            try
            {
                VerificaSeEArquivo(caminhoArquivoOrigem);

                StreamWriter wt = new StreamWriter(caminhoArquivoOrigem);
                wt.WriteLine(conteudoArquivo);
                wt.Close();

                return caminhoArquivoOrigem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se no caminho do arquivo especificado tem informação de um arquivo. Caso tenha diretório no caminho ele ira criar.
        /// Tipos de arquivos sendo verificados (jpeg, jpg, png, pdf, ppt, png, gif, svg, xml, sql, txt, exe, zip, rar, html)
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo</param>
        public virtual void VerificaSeEArquivo(string caminhoArquivo)
        {
            try
            {
                //Verifica se é um arquivo
                string[] tipoImagens = { "jpeg", "jpg", "png", "pdf", "ppt", "png", "gif", "svg" };
                string[] tipoDeArquivos = { "xml", "sql", "txt", "exe", "zip", "rar", "html" };

                var todosTipos = tipoImagens.Concat(tipoDeArquivos).ToList();

                bool contemArquivoNaString = false;
                foreach (var tipo in todosTipos)
                {
                    if (caminhoArquivo.Contains("." + tipo))
                    {
                        contemArquivoNaString = true;
                        break;
                    }
                }

                var novoDiretorio = "";
                if (contemArquivoNaString)
                {
                    var t = caminhoArquivo.Split('\\');
                    var arr = t.Take(t.Count() - 1).ToList();
                    for (int i = 0; i < arr.Count(); ++i)
                    {
                        novoDiretorio += arr[i].ToString();
                        if (i + 1 < arr.Count())
                            novoDiretorio += "\\";
                    }
                    CriarDiretorio(novoDiretorio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void Dispose()
        {
        }
    }
}
