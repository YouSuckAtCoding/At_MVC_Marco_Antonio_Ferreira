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
    public class GuitarraHttpService : IGuitarraHttpService
    {
        private readonly HttpClient httpClient;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            IgnoreNullValues = true

        };

        public GuitarraHttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44386");

        }
        public async Task<GuitarraPresentationModel> Create(GuitarraPresentationModel Guitarras)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync("api/v1/GuitarraApi", Guitarras);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var created = await JsonSerializer.DeserializeAsync<GuitarraPresentationModel>(contentStream, jsonSerializerOptions);
            return created;
        }

        public async Task Delete(int id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync($"api/v1/GuitarraApi/{id}");
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<GuitarraPresentationModel> Edit(GuitarraPresentationModel Guitarras)
        {
            var httpResponseMessage = await httpClient.PutAsJsonAsync($"api/v1/GuitarraApi/{Guitarras.Id}", Guitarras);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var edited = await JsonSerializer.DeserializeAsync<GuitarraPresentationModel>(contentStream, jsonSerializerOptions);
            return edited;
        }

        public async Task<IEnumerable<GuitarraPresentationModel>> GetAll(string orderAscendant, string search = null)
        {
            var GuitarraModels = await httpClient.GetFromJsonAsync<IEnumerable<GuitarraPresentationModel>>($"api/v1/GuitarraApi");
            return GuitarraModels;

        }

        public async Task<GuitarraPresentationModel> GetById(int id)
        {
            var GuitarraModels = await httpClient.GetFromJsonAsync<GuitarraPresentationModel>($"api/v1/GuitarraApi/{id}");
            return GuitarraModels;
        }

       
    }
}
