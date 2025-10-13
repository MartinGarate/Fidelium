using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils.Helpers
{
    public static class Validations
    {
        // Clase para validaciones de texto
        public static class Strings
        {
            // Verifica si una cadena tiene contenido válido
            public static bool HasValue(string? value) =>
                !string.IsNullOrWhiteSpace(value);

            // Valida formato básico de email (debe contener @ y .)
            public static bool IsValidEmail(string? email) =>
                HasValue(email) && email!.Contains("@") && email.Contains(".");

            // Verifica si la longitud de un texto está entre min y max
            public static bool IsValidLength(string? value, int min, int max) =>
                HasValue(value) && value!.Length >= min && value.Length <= max;
        }

        // Clase para validaciones numéricas
        public static class Numbers
        {
            // Valida que el DNI tenga un formato válido
            public static bool IsValidDNI(string? dni)
            {
                if (!HasValue(dni))
                    return false;

                // Elimina espacios y puntos para la validación
                var cleanDni = dni!.Replace(" ", "").Replace(".", "");

                // Verifica longitud mínima y máxima
                if (cleanDni.Length < 5 || cleanDni.Length > 100)
                    return false;

                // Permite números, letras y guiones
                return cleanDni.All(c => char.IsLetterOrDigit(c) || c == '-');
            }

            // Valida que el teléfono solo contenga dígitos y caracteres permitidos
            public static bool IsValidPhone(string? phone)
            {
                if (!HasValue(phone))
                    return false;

                // Elimina espacios, guiones y paréntesis para la validación
                var cleanPhone = phone!
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("+", "");

                return cleanPhone.All(char.IsDigit);
            }
        }

        // Clase para validaciones de usuarios
        public static class Users
        {
            // Valida unicidad del DNI contra una colección de usuarios existentes
            // T: Tipo genérico que representa la entidad usuario
            // Retorna: Tupla con el estado de validación y mensaje de error opcional
            public static async Task<(bool IsValid, string? ErrorMessage)> ValidarDNIUnico<T>(
                string? dni,                    // DNI a validar
                IEnumerable<T> existingUsers,   // Colección de usuarios existentes
                Func<T, string> getDNI,         // Delegado para extraer DNI de la entidad T
                int? currentUserId = null,      // ID del usuario actual (para edición)
                Func<T, int>? getUserId = null) // Delegado para extraer ID de la entidad T
            {
                // Validación de formato DNI
                if (!Numbers.IsValidDNI(dni))
                    return (false, "El DNI ingresado no es válido.");

                bool isDuplicate;

                // Modo edición: Excluye el usuario actual de la validación de duplicados
                if (currentUserId.HasValue && getUserId != null)
                {
                    isDuplicate = existingUsers.Any(u => 
                        string.Equals(getDNI(u), dni, StringComparison.OrdinalIgnoreCase) && 
                        getUserId(u) != currentUserId.Value);
                }
                // Modo creación: Verifica duplicados en toda la colección
                else
                {
                    isDuplicate = existingUsers.Any(u => 
                        string.Equals(getDNI(u), dni, StringComparison.OrdinalIgnoreCase));
                }

                return isDuplicate 
                    ? (false, "El DNI ingresado ya existe en el sistema.")
                    : (true, null);
            }
        }
        
        // Método base para validar que un texto no sea nulo o espacios en blanco
        private static bool HasValue(string? value) =>
            !string.IsNullOrWhiteSpace(value); 
    }
}
