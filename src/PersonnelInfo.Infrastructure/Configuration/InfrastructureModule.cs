using Autofac;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Services;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Data.Repositories;
using PersonnelInfo.Infrastructure.Services;

namespace PersonnelInfo.Infrastructure.Configuration;
public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<CityRepository<Employee>>().As<IEmployeeRepository<Employee>>().InstancePerLifetimeScope();
    }
}
