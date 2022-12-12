namespace CyaEnglish.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(string name
                          , string email
                          , string password
                          , string secretKey)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            StAtivo = false;
            Password = password;
            ConfirmEmail = false;
            SecretKey = secretKey;
            Tentativas = 3;
        }

        public Guid Id { get; set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public bool StAtivo { get; private set; } = false;
        public string? Password { get; private set; }
        public bool ConfirmEmail { get; private set; } = false;
        public string? SecretKey { get; private set; }
        public int Tentativas { get; private set; } = 3;

    }
}
