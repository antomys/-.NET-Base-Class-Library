using BookClub.Ui.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .ConfigureStuff();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseStaticFiles();
//app.UseCookiePolicy();

app.UseRouting();
app.UseEndpoints(endpoints =>
    endpoints.MapRazorPages());

app.Run();