using Autofac;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Services;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Infrastructure.Data.Repositories;

namespace PersonnelInfo.Infrastructure.Configuration;
public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepository<Employee>>().As<IRepository<Employee>>().InstancePerLifetimeScope();
    }
}
