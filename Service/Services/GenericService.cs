using Service.Interfaces;
using Service.Utils;
using System.Net.Http.Json;
using System.Text.Json;

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _options;
        protected readonly string _endpoint;


        public GenericService()
        {
            _httpClient = new HttpClient();
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            //_endpoint = Properties.Resources.UrlApi + ApiEndpoints.GetEndpoint(typeof(T).Name);
            _endpoint = Properties.Resources.UrlApiLocal + ApiEndpoints.GetEndpoint(typeof(T).Name);

        }
        public Task<T?> AddAsync(T? entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar el dato: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;

        }

        public async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            var response = await _httpClient.GetAsync(_endpoint);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);

        }

        public async Task<List<T>?> GetAllDeletedsAsync(string? filtro = "")
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/Deleteds");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode} - {content}");
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
        }

        public async Task<bool> RestoreAsync(int id)
        {

            var response = await _httpClient.PutAsync($"{_endpoint}/restore/{id}", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hubo un problema al restaurar el dato");
            }
            else
            {
                return response.IsSuccessStatusCode;
            }

        }

        public async Task<bool> UpdateAsync(T? entity)
        {
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);
            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hubo un problema al actualizar");
            }
            else
            {
                return response.IsSuccessStatusCode;
            }

        }
    }
}
