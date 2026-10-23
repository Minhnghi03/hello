var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// =========================================================================
// MỤC ②: CONVENTIONAL ROUTING (Định tuyến theo quy ước)
// Mẫu mặc định: {controller}/{action}/{id?}
// Ví dụ: /Hello/WelcomeConventional/3?name=KTPM&Num=5
// - Controller: Hello
// - Action: WelcomeConventional
// - id: 3 (tham số route)
// - Query String: ?name=KTPM&Num=5
// =========================================================================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
