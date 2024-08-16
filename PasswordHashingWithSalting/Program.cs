using PasswordHashingWithSalting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PasswordHasher>();

var app = builder.Build();

app.MapPost("/create-passwordhash", (PasswordHasher passwordHasher, PasswordRequest request) =>
{
    var passwordHash = passwordHasher.Hash(request.Password);

    return $"Password hash was created and stored in application memory.\n\n{passwordHash}";
});

app.MapPost("/verify-password", (PasswordHasher passwordHasher, PasswordRequest request) =>
{
    return passwordHasher.Verify(request.Password)
        ? "Password is valid."
        : "Password is invalid.";
});

app.Run();
