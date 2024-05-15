using Microsoft.Extensions.DependencyInjection;
using SELP.Infrastructur.Repository;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.InfrastructurBase;
using SELP.Infrustructure.Abstracts;
using SELP.Infrustructure.Repositories;

namespace SELP.Infrastructur
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructurDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository , StudentRepository>();
            services.AddTransient<ISubjectRepository , SubjectRepository>();
            services.AddTransient<IResultRepository ,ResultRepository >();
            services.AddTransient<IQuizRepository,QuizRepository>();
            services.AddTransient<IContentRepository,ContentRepository>();
            services.AddTransient<IInstructorRepository,InstructorRepository >();
            services.AddTransient<ISubjectRepository, SubjectRepository>();

            services.AddTransient<IStudentSubjectRepository, StudentSubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));




            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            return services;
        }

    }
}