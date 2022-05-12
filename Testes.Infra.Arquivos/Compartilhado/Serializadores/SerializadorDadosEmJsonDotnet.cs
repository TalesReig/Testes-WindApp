using System.IO;
using System.Text.Json;
using System.Linq;
using Newtonsoft.Json;

namespace Testes.Infra.Arquivos.Compartilhado.Serializadores
{
    public class SerializadorDadosEmJsonDotnet : ISerializador
    {
        private const string arquivo = @"C:\Temp\dados.json";
        //se der errado é pq o t é T

        public DataContext CarregarDadosDoArquivo()
        {
            if (File.Exists(arquivo) == false)
                return new DataContext();

            string arquivoJson = File.ReadAllText(arquivo);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            return JsonConvert.DeserializeObject<DataContext>(arquivoJson, settings);
        }

        public void GravarDadosEmArquivo(DataContext dados)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.All;

            string arquivoJson = JsonConvert.SerializeObject(dados, settings);

            File.WriteAllText(arquivo, arquivoJson);
        }
    }
}
