using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application;
public static class Mapper
{
    public static void MapToDto<T, TDto>(T entity, TDto dto) where TDto : class
    {
        var dtoProperties = typeof(TDto).GetProperties();
        var entityProperties = typeof(T).GetProperties();

        foreach (var property in entityProperties)
        {
            var dtoProperty = dtoProperties.FirstOrDefault(p => p.Name == property.Name);
            if (dtoProperty != null && dtoProperty.CanWrite)
            {
                var value =dtoProperty.GetValue(dto);
                dtoProperty.SetValue(dto, value);
            }
        }
    }

    public static void MapToEntity<TDto, T>(TDto dto, T entity) where T : class
    {
        var dtoProperties = typeof(TDto).GetProperties();
        var entityProperties = typeof(T).GetProperties();

        foreach (var property in dtoProperties)
        {
            var entityProperty = entityProperties.FirstOrDefault(p => p.Name == property.Name);
            if (entityProperty != null && entityProperty.CanWrite)
            {
                var value = entityProperty.GetValue(entity);
                entityProperty.SetValue(entity, value);
            }
        }
    }
}
