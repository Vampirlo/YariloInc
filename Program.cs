namespace YariloInc
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Получаем конфигурацию Kestrel из appsettings.json
			var configuration = builder.Configuration;
			var kestrelOptions = configuration.GetSection("Kestrel");

			// Получаем путь к сертификату и приватному ключу
			var certificatePath = kestrelOptions.GetValue<string>("Endpoints:Https:Certificate:Path");
			//var keyPath = kestrelOptions.GetValue<string>("Endpoints:Https:Certificate:KeyPath");

			var url = kestrelOptions.GetValue<string>("Endpoints:Https:Url");
			var endpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, int.Parse(url.Split(":")[2]));
			var pass = kestrelOptions.GetValue<string>("Endpoints:Https:Certificate:Password");
			// Настраиваем Kestrel
			builder.WebHost.ConfigureKestrel(options =>
			{
				options.Listen(endpoint, listenOptions =>
				{
					listenOptions.UseHttps(certificatePath, pass);
				});
			});

			/////////////////////

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
		}

	}
}