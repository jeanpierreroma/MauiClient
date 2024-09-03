using Client.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Client.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<PersonModel>> UploadFile(Stream streamFile, string fileName)
        {
            var httpContent = new MultipartFormDataContent
            {
                { new StreamContent(streamFile), "file", fileName }
            };

            using HttpClient client = _httpClientFactory.CreateClient("MauiClient");

            try
            {
                HttpResponseMessage response = await client.PostAsync($"api/Data/upload-file", httpContent);

                response.EnsureSuccessStatusCode();

                List<PersonModel>? people = await response.Content.ReadFromJsonAsync<List<PersonModel>>(
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return people ?? [];
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex.Message}");
            }
        }

        public async Task<string> SavePeople(List<PersonModel> people)
        {
            using HttpClient client = _httpClientFactory.CreateClient("MauiClient");

            try
            {
                var json = JsonSerializer.Serialize(people);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PatchAsync("http://localhost:5168/api/Data/save-data", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return await Task.FromResult("Something gone wrong while saving data");
            }
        }

        public async Task<PersonModel> UpdatePerson(PersonModel person)
        {
            using HttpClient client = _httpClientFactory.CreateClient("MauiClient");

            try
            {
                var json = JsonSerializer.Serialize(person);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/Data/update-data", content);
                return await response.Content.ReadFromJsonAsync<PersonModel>(
                        new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
            catch (JsonException ex)
            {
                throw new JsonException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
