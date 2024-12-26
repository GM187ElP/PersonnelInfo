using Autofac;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Infrastructure.Data;
using PersonnelInfo.Infrastructure.Data.Repositories;
using PersonnelInfo.Shared.Interfaces;

namespace PersonnelInfo.Infrastructure.Configuration;
public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PersonnelInfoDbContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
    }
}
