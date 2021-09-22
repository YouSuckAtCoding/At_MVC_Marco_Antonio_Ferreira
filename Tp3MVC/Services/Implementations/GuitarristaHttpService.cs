using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Tp3MVC.Models;

namespace Tp3MVC.Services.Implementations
{
    public class GuitarristaHttpService : IGuitarristaHttpService
    {
        private readonly HttpClient httpClient;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            IgnoreNullValues = true
         
        };
              
              

        public GuitarristaHttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44386");

        }
        public async Task<GuitarristaPresentationModel> Create(GuitarristaPresentationModel Guitarristas)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync("api/v1/GuitarristaApi", Guitarristas);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var created = await JsonSerializer.DeserializeAsync<GuitarristaPresentationModel>(contentStream, jsonSerializerOptions);
            return created;
        }

        public async Task Delete(int id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync($"api/v1/GuitarristaApi/{id}" );
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<GuitarristaPresentationModel> Edit(GuitarristaPresentationModel Guitarristas)
        {
            var httpResponseMessage = await httpClient.PutAsJsonAsync($"api/v1/GuitarristaApi/{Guitarristas.Id}", Guitarristas);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var edited = await JsonSerializer.DeserializeAsync<GuitarristaPresentationModel>(contentStream, jsonSerializerOptions);
            return edited;
        }

        public async Task<IEnumerable<GuitarristaPresentationModel>> GetAll(string orderAscendant, string search = null)
        {
            var GuitarristaModels = await httpClient.GetFromJsonAsync<IEnumerable<GuitarristaPresentationModel>>($"api/v1/GuitarristaApi");
            return GuitarristaModels;

        }

        public async Task<GuitarristaPresentationModel> GetById(int id)
        {
            var GuitarristaModels = await httpClient.GetFromJsonAsync<GuitarristaPresentationModel>($"api/v1/GuitarristaApi/{id}");
            return GuitarristaModels;
        }

        public async Task<bool> IsNameValid(string nome)
        {

            var GuitarristaModels = await httpClient.GetFromJsonAsync<bool>($"api/v1/GuitarristaApi/IsNameValid/{nome}");
            return GuitarristaModels;
        }


    }
    
}
