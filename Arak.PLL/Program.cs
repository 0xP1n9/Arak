
using Arak.BLL.Service.Abstraction;
using Arak.BLL.Service.Implementation;
using Arak.DAL.Database;
using Arak.DAL.Repository.Abstraction;
using Arak.DAL.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Arak.PLL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<AppDbContext>(op =>
			op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			//Repositories
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.Services.AddScoped<IStudentRepository, StudentRepository>();
			builder.Services.AddScoped<ITimetableRepository,TimetableRepository>();
			builder.Services.AddScoped<IClassRepository, ClassRepository>();
			builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();

			//Services
			builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddScoped<ITimetableService, TimetableService>();
			builder.Services.AddScoped<IClassService, ClassService>();
			builder.Services.AddScoped<IAssignmentService, AssignmentService>();

			//add Swagger UI Service
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
