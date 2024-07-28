using InMind_Lab4.Context;
using InMind_Lab4.Model;
using InMind_Lab4.Profile;
using InMind_Lab4.Service;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<UniversityDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Book>();//to access properties
modelBuilder.EntitySet<Book>("Books");//to access controller
modelBuilder.EntityType<Author>();
modelBuilder.EntitySet<Author>("Authors");
modelBuilder.EntityType<Borrower>();
modelBuilder.EntitySet<Borrower>("Borrowers");
modelBuilder.EntityType<Loan>();
modelBuilder.EntitySet<Loan>("Loans");
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",modelBuilder.GetEdmModel()));
builder.Services.AddAutoMapper(typeof(UniversityMappingProfile));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();