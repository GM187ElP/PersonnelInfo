using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Data.Repositories;

namespace PersonnelInfo.Infrastructure.Data;

[Serializable]
public class NotFoundEntity : Exception
{
    private Type type;

    public NotFoundEntity()
    {
    }

    public NotFoundEntity(Type type)
    {
        this.type = type;
        Console.WriteLine("Nothing is found!");
    }

    public NotFoundEntity(string? message) : base(message)
    {
    }

    public NotFoundEntity(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}