using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application;
public static class Mapper
{
    public static T MapToEntity<TDto,T>(TDto dto,T entity) where T: class
    {
        var dtoProperties= typeof(TDto).GetProperties();
        var entityProperties=typeof(T).GetProperties();

        foreach(var property in dtoProperties)
        {
            var entityProperty = entityProperties.FirstOrDefault(p => p.Name == property.Name);
            if (entityProperty != null && entityProperty.CanWrite)
            {
                var value= entityProperty.GetValue(entity);
                entityProperty.SetValue(entity,value);
            }
        }
        return entity;
    }
}
