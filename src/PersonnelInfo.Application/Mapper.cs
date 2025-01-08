namespace PersonnelInfo.Application;
public static class Mapper
{
    public static TDto MapToDto<T, TDto>(T entity, TDto dto) where TDto : class
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
        return dto;
    }
    public static TDto MapToDto<T,TDto>(T entity) where TDto : class,new()
    {
        var dto = new TDto();
        MapToDto(entity, dto);
        return dto;
    }

    public static T MapToEntity<TDto, T>(TDto dto, T entity) where T : class
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
        return entity;
    }
    public static T MapToEntity<TDto,T>(TDto dto) where T : class,new()
    {
        var entity = new T();
        MapToEntity(dto, entity);
        return entity;
    }
}
