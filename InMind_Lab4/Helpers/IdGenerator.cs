using InMind_Lab4.Context;
using Microsoft.EntityFrameworkCore;

namespace InMind_Lab4.Helpers;

public static class IdGenerator
{
    public static int GenerateNewIdAsync<TEntity>(UniversityDbContext context) where TEntity : class
    {
        var entityType=context.Model.FindEntityType(typeof(TEntity));
        var primaryKey=entityType.FindPrimaryKey();
        if (primaryKey == null || primaryKey.Properties.Count != 1)
            throw new InvalidOperationException("The entity does not have a single primary key.");
        
        var idName = primaryKey.Properties[0].Name;
        var idValue = context.Set<TEntity>().Max(e=>EF.Property<int>(e,idName)) + 1;
        return idValue;
    }
}