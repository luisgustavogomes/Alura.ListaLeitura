using Alura.ListaLeitura.App.Repositorio;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureProduction()
        {

        }

        public void LivrosParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            _repo.ParaLer.ToString();

        }
    }
}