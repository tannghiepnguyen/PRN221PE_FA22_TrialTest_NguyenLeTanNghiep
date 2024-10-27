using Candidate_Repository;
using Candidate_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();
builder.Services.AddScoped<IHrAccountService, HrAccountService>();
builder.Services.AddScoped<IJobPostingService, JobPostingService>();

builder.Services.AddSession();

builder.Services.AddScoped<IHrAccountRepo, HrAccountRepo>();
builder.Services.AddScoped<IJobPostingRepo, JobPostingRepo>();
builder.Services.AddScoped<ICandidateProfileRepo, CandidateProfileRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
