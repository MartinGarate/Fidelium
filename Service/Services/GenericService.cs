using Service.Interfaces;
using Service.Models;
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
            _endpoint = Properties.Resources.UrlApi + ApiEndpoints.GetEndpoint(typeof(T).Name);
            //_endpoint = Properties.Resources.UrlApiLocal + ApiEndpoints.GetEndpoint(typeof(T).Name);

        }
        public async Task<T?> AddAsync(T? entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al agregar el dato: {response.StatusCode} - {content}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
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
            // Mantén el filtro si tus controladores lo usan, pero asegura el retorno
            var response = await _httpClient.GetAsync($"{_endpoint}?filter={filtro}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener datos: {response.StatusCode}");
            }

            return JsonSerializer.Deserialize<List<T>>(content, _options) ?? new List<T>();
        }

        public async Task<List<T>?> GetAllDeletedsAsync(string? filtro = "")
        {
            // Quitamos el query string del filtro ya que el controlador /deleteds trae todo lo borrado
            var response = await _httpClient.GetAsync($"{_endpoint}/deleteds");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener eliminados: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
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
            var entidad = JsonSerializer.Deserialize<T>(content, _options);

            // Si T es Cliente, inicializa Usuario si está nulo
            if (typeof(T) == typeof(Cliente) && entidad is Cliente cliente && cliente.Usuario == null)
            {
                cliente.Usuario = new Usuario();
                return entidad;
            }

            return entidad;
        }

        public async Task<bool> RestoreAsync(int id)
        {
            var response = await _httpClient.PutAsync($"{_endpoint}/restore/{id}", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al restaurar el dato: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(T? entity)
        {
            if (entity == null) return false;

            // Obtenemos el valor de la propiedad "ID"
            var property = entity.GetType().GetProperty("ID");
            if (property == null) throw new Exception("La entidad no tiene una propiedad ID válida.");

            var idValue = property.GetValue(entity);

            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar: {response.StatusCode} - {errorContent}");
            }

            return response.IsSuccessStatusCode;
        }
    }
}

