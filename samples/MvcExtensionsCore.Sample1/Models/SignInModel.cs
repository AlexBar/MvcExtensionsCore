namespace MvcExtensionsCore.Sample1.Models
{
    public class SignInModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInModelMetadata : ModelMetadataConfiguration<SignInModel>
    {
        public SignInModelMetadata()
        {
            Configure(x => x.Login)
                .DisplayName("User ID 1")
                .Required()
                .Watermark("User ID WM")
                .MaximumLength(8)
                .Validate(s => !s.Equals("admin", System.StringComparison.InvariantCultureIgnoreCase), "Not allowed for {0} (server validation).");

            Configure(x => x.Email)
                .DisplayName("User email")
                .Required()
                .Watermark("user@email")
                .MinimumLength(6)
                .MaximumLength(50)
                .NotEqualTo(nameof(SignInModel.Login));

            Configure(x => x.Password)
                .DisplayName("Password")
                .Required()
                .AsPassword()
                .Watermark("Password");
        }
    }
}
