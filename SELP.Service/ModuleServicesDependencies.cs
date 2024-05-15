using Microsoft.Extensions.DependencyInjection;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Repository;
using SELP.Service.Abstract;
using SELP.Service.Implementation;

namespace SELP.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentSevice, StudentService>();
            services.AddTransient<IInstructorServices,InstructorServices >();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IQuizService,QuizService>();




          

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            
            
            services.AddTransient<IFileService, FileService>();


            return services;
        }

    }
}