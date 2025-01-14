using Autofac;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Application.Services;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Infrastructure.Data.Repositories;
using PersonnelInfo.Infrastructure.Services;

namespace PersonnelInfo.Infrastructure.Configuration;
public class ProjectModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
        builder.RegisterType<BankNameRepository>().As<IBankNameRepository>().InstancePerLifetimeScope();
        builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope();
        builder.RegisterType<JobTitleRepository>().As<IJobTitleRepository>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeServices>().As<IEmployeeServices>().InstancePerLifetimeScope();
    }
}
