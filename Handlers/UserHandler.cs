using System.Text.Json;
using jsonDesafio.Models;
using jsonDesafio.Response;

namespace jsonDesafio.Handlers
{
    public class UserHandler
    {
        public async Task<BaseResponse<string>> UsersJsonToClass(IFormFile json)
        {
            try
            {
                using var r = new StreamReader(json.OpenReadStream());
                var fileContent = await r.ReadToEndAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var users = JsonSerializer.Deserialize<List<User>>(fileContent, options);

                if (users == null)
                    return new BaseResponse<string>("Erro no deserialize", 500, "erro no deserialize");

                foreach (var user in users)
                    DatabaseFake.Adicionar(user);

                return new BaseResponse<string>("Usuarios salvos com sucesso!", 200, "Usuarios salvos com sucesso!");
            }
            catch (Exception e)
            {
                return new BaseResponse<string>(e.Message, 500, e.Message);

            }
        }

        public async Task<BaseResponse<List<User>>> GetAllUsers()
        {
            try
            {
                var users = DatabaseFake.GetUsers();

                return new BaseResponse<List<User>>(users, 200, "Usuarios salvos com sucesso!");
            }
            catch (Exception e)
            {
                return new BaseResponse<List<User>>(null, 500, e.Message);
            }
        }
    }
}