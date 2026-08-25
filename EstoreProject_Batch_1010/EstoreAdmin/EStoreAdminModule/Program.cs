var builder = WebApplication.CreateBuilder(args);

//it will create object for all controllers in a project
//and hold in Service Collection classes
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Enable Static File Middleware
app.UseStaticFiles();

//it is used to collect the Incoming URL and Redirect to Corresponding Action Method.
app.UseRouting();

//After recceiving a URL, Corresponding Action Method Need to be Detected
app.MapControllers();

app.Run();
