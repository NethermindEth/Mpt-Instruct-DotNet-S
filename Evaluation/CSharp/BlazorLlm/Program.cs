using BlazorLlm.Services;
using MptLibrary;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddSingleton<HttpClient>();

var downloader = new ModelDownloader();
var path = await downloader.DownloadModel("q8"); //TODO configure from somewhere!
var mpt_settings = new mpt_params()
{
    model = path,
    n_threads = Environment.ProcessorCount,
    n_ctx = 1024,  //TODO configure from somewhere!
    n_predict = 512  //TODO configure from somewhere!
};

builder.Services.AddSingleton<CodeService>(_ => new CodeService(mpt_settings));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // This line is crucial
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();
