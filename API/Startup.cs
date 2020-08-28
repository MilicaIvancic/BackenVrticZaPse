using System;
using System.Text;
using API.Email;
using Aplication.Comands.City;
using Aplication.Comands.Dog;
using Aplication.Comands.Employe;
using Aplication.Comands.Izvestaju;
using Aplication.Comands.Medicine;
using Aplication.Comands.Race;
using Aplication.Comands.Roles;
using Aplication.Comands.Service;
using Aplication.Comands.Users;
using Aplication.Comands.Vaccine;
using Aplication.Interfaces;
using EfComands.EFCityCommands;
using EfComands.EFDogCommands;
using EfComands.EfEmployeCommands;
using EfComands.EfIzvestaji;
using EfComands.EfMedicineCommand;
using EfComands.EfRaceCommands;
using EfComands.EFRoleCommands;
using EfComands.EfServiceCommands;
using EfComands.EFUserCommands;
using EfComands.Vakcine;
using EfDataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<VrticZaPseContext>();
            services.AddCors();

            #region RoleRegion

            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IReturnRole, EfReturnRole>();

            #endregion

            #region UserRegion

            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<ILoginCommand, EfLoginCommand>();
            services.AddTransient<ILoginuserCommand, EfUserLoginCommand>();
            services.AddTransient<IChangePasswordCommand, EfChangePasswordCommand>();
            #endregion

            #region CityRegion

            services.AddTransient<IGetCitiesCommand, EfIGetCitiesCommand>();
            services.AddTransient<IGetCityCommand, EfGetCityCommand>();
            services.AddTransient<IAddCityCommand, EfAddCityCommand>();
            services.AddTransient<IUpdateCityCommand, EfUpdateCityCommand>();
            services.AddTransient<IDeleteCityCommand, EfDeleteCityCommand>();
            #endregion

            #region DogRegion

            services.AddTransient<IAddDogCommand, EfAddDogCommand>();
            services.AddTransient<IGetDogsCommand, EfGetDogsCommand>();
            services.AddTransient<IGetDogCommand, EfGetDOgCommand>();
            services.AddTransient<IUpisPsaMesecnoCommand, EfUpisPsaMesecnoCommand>();
            services.AddTransient<IGetUserDogCommand, EfGetUserDogCommand>();
            services.AddTransient<IChangeEducatorCommand, EfChangeEducatorId>();
            #endregion

            #region EmailRegion

            var section = Configuration.GetSection("Email");

            var sender =
                new EmailSenderSmpt(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);

            #endregion


            #region ServiceRegion
            services.AddTransient<IAddServiceCommand, EfAddService>();
            services.AddTransient<IGetServiceCommand, EfGetServiceCommand>();
            services.AddTransient<IGetServicesCommand, EfGetServicesCommand>();


            #endregion

            #region JWT token

            var key = Encoding.UTF8.GetBytes("1234567890123456");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        

        #endregion

            #region RaceRegion

            services.AddTransient<IGetRacesCommand, EfGetRacesCommand>();
            services.AddTransient<IGetRaceCommand, EfGetRaceCommand>();
            services.AddTransient<IAddRaceCommand, EfAddRaceCommand>();
            services.AddTransient<IUpdateRaceCommand, EfUpdateRaceCommand>();
            services.AddTransient<IDeleteRaceCommand, EfDeleteRaceCommand>();
            #endregion

            #region EmployeRegion

            services.AddTransient<IGetEmpoyesCommand, EfGetEmployesCommand>();
            services.AddTransient<AddEmployeCommand, EfAddEmployeCommand>();

            #endregion

            #region VaccineRegion
            services.AddTransient<IGetVaccineCommand, EfGetVaccineCommand>();
            services.AddTransient<IAddVaccineCommand, EfAddVaccineCommand>();
            services.AddTransient<IAddDogVaccineCommand, EfAddDogVaccineCommand>();
            #endregion

            #region MedicineRegion

            services.AddTransient<IGetMedicineCommand, EfGetMedicineCommand>();
            services.AddTransient<IAddMedicineCommand, EfAddMedicineCommand>();

            #endregion

            #region ReportMedicalRegion

            services.AddTransient<IGetMedicalReportCommand, IGetDogMedicalReportCommand>();
            services.AddTransient<IAddMedicalReportCommand, EfAddMedicalReportCommand>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
              
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());

            app.UseCors();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
