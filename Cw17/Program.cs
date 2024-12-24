using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();


 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login"; 
        options.LogoutPath = "/User/Logout"; 
    });


builder.Services.AddControllersWithViews();
builder.Services.AddSession();  

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  
app.UseRouting();


app.UseAuthentication();  
app.UseAuthorization();   
app.UseSession();         

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();