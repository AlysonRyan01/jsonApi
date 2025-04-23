using jsonDesafio.Models;

namespace jsonDesafio
{
    public static class DatabaseFake
    {
        private static readonly List<User> users = new();

        public static void Adicionar(User? user)
        {
            if (user == null)
                return;

            users.Add(user);
        }

        public static List<User> GetUsers()
        {
            return users;
        }
    }
}