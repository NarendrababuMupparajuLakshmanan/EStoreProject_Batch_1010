using EStoreAdminServices;
using EstoreModel.Services;

var builder = WebApplication.CreateBuilder(args);

//it will create object for all controllers in a project
//and hold in Service Collection classes
builder.Services.AddControllersWithViews();


//it will create object for BrandServices and hold in a ServiceCollection Class
//This Concept we will call it as a Inversion of Control (IOC)
builder.Services.Add(new ServiceDescriptor(
    typeof(IBrandService),
    typeof(BrandService),
    ServiceLifetime.Transient));

var app = builder.Build();


//Enable Static File Middleware
app.UseStaticFiles();

//it is used to collect the Incoming URL and Redirect to Corresponding Action Method.
app.UseRouting();

//After recceiving a URL, Corresponding Action Method Need to be Detected
app.MapControllers();

app.Run();
