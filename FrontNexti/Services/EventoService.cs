using FrontNexti.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FrontNexti.Services
{
    public class EventoService : IEvento
    {
        private static string _urlBase = string.Empty;
        private readonly HttpClient _httpClient;

        public EventoService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();


            _urlBase = builder.GetSection("ConexionAPI:urlBase").Value;
        }

        public async Task<List<EventoVM>> GetAllEventos()
        {
            List<EventoVM> lista = new List<EventoVM>();
            StringContent content = new(JsonConvert.SerializeObject(""), Encoding.UTF8, "Aplication/json");
            var response = await _httpClient.GetAsync(_urlBase + "GetAllEventos");
            if (response.IsSuccessStatusCode)
            {
                string respuesta = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<EventoVM>>(respuesta);
                return lista;
            }
           
            return lista;
        }
    }
}
