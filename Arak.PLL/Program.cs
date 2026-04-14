
using Arak.BLL.Service.Abstraction;
using Arak.BLL.Service.Implementation;
using Arak.DAL.Database;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using Arak.DAL.Repository.Implementation;
using Arak.PLL.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arak.PLL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<AppDbContext>(op =>
			op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

			//Repositories
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.Services.AddScoped<IStudentRepository, StudentRepository>();
			builder.Services.AddScoped<ITimetableRepository,TimetableRepository>();
			builder.Services.AddScoped<IClassRepository, ClassRepository>();
			builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
			builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
			builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
			builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
			builder.Services.AddScoped<IParentRepository, ParentRepository>();
			builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

			//Services
			builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddScoped<ITimetableService, TimetableService>();
			builder.Services.AddScoped<IClassService, ClassService>();
			builder.Services.AddScoped<IAssignmentService, AssignmentService>();
			builder.Services.AddScoped<ISubjectService, SubjectService>();
			builder.Services.AddScoped<ISemesterService, SemesterService>();
			builder.Services.AddScoped<IAttendanceService, AttendanceService>();
			builder.Services.AddScoped<IParentService, ParentService>();
			builder.Services.AddScoped<ITeacherService, TeacherService>();

			//add Swagger UI Service
			builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGenJwtAuth();

            builder.Services.AddCustomJwtAuth(builder.Configuration);

            

            var app = builder.Build();

			//Roles 
			using (var scope = app.Services.CreateScope())
			{
				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				string[] roles = { "Admin", "Teacher", "Parent" };

				foreach (var role in roles)
				{
					if (!await roleManager.RoleExistsAsync(role))
					{
						await roleManager.CreateAsync(new IdentityRole(role));
					}
				}
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
