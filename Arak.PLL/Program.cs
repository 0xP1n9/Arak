
using Arak.BLL.Service.Abstraction;
using Arak.BLL.Service.Implementation;
using Arak.DAL.Database;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using Arak.DAL.Repository.Implementation;
using Arak.PLL.Extensions;
using Microsoft.AspNetCore.Authorization;
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

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Default", policy =>
                    policy.RequireAuthenticatedUser());

                options.InvokeHandlersAfterFailure = false;
            });

            builder.Services.AddSingleton<IAuthorizationHandler, AdminOverrideHandler>();

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
            builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();

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
			builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEvaluationService, EvaluationService>();

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

				string[] roles = { "Admin", "Teacher", "Parent", "Super Admin", "Academic Admin", "Fees Admin", "Users Admin" };

				foreach (var role in roles)
				{
					if (!await roleManager.RoleExistsAsync(role))
					{
						await roleManager.CreateAsync(new IdentityRole(role));
					}
				}
			}

			//Super Admin
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string adminEmail = "super_admin@gmail.com";
                string password = "SuperAdmin@123";

                if (!await roleManager.RoleExistsAsync("Super Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Super Admin"));

                var admin = await userManager.FindByEmailAsync(adminEmail);

                if (admin == null)
                {
                    admin = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail
                    };

                    await userManager.CreateAsync(admin, password);
                    await userManager.AddToRoleAsync(admin, "Super Admin");
                }
            }
			//======================================================================

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
