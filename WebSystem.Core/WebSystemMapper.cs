using System.Collections.Concurrent;
using System.Reflection;
using WebSystem.Core.Exceptions;

namespace WebSystem.Core;

public static class WebSystemMapper
{
    private static readonly ConcurrentDictionary<string, PropertyInfo[]> PropertyCache = new();

    public static TDestiny Map<TSource, TDestiny>(TSource source) where TDestiny : new()
    {
        if (source is null) throw new WebSystemMapperException("source is null!");
        
        TDestiny destiny =  new TDestiny();
        
        var sourceProperties = PropertyCache.GetOrAdd(typeof(TSource).FullName!, _ => typeof(TSource).GetProperties());
        var targetProperties = PropertyCache.GetOrAdd(typeof(TDestiny).FullName!, _ => typeof(TDestiny).GetProperties());

        foreach (var sourceProp in sourceProperties)
        {
            if (sourceProp.CanRead)
            {
                var targetProp = Array.Find(targetProperties,p => p.Name == sourceProp.Name);

                if (targetProp is not null)
                {
                    if(targetProp.PropertyType == sourceProp.PropertyType)
                        destiny.GetType().GetProperty(sourceProp.Name)!.SetValue(destiny, sourceProp.GetValue(source) ?? null);
                    else
                        throw new WebSystemMapperException($"Property mismatch: {sourceProp.Name}");
                }
                else
                {
                    throw new WebSystemMapperException($"Property not found");
                }
            }
            else
            {
               throw new WebSystemMapperException($"Source property '{sourceProp.Name}' cannot be read.");
            }
        }
        
        return destiny;
    }
}