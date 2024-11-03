using DotNetEnv;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

Env.Load();

builder.Services.AddScoped<Supabase.Client>(_ =>
{
    var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
    var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_API_KEY");

    if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
    {
        throw new InvalidOperationException("Supabase URL and Key must be provided in configuration.");
    }

    return new Supabase.Client(
        supabaseUrl,
        supabaseKey,
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
