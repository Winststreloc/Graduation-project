using Microsoft.EntityFrameworkCore;

namespace PokemonAPI.Helpers;

public static class IdentityHelpers
{
    public static Task EnableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: true);
    public static Task DisableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: false);

    private static Task SetIdentityInsert<T>(DbContext context, bool enable)
    {
        var entityType = context.Model.FindEntityType(typeof(T));
        var value = enable ? "ON" : "OFF";

        return context.Database.ExecuteSqlRawAsync(
            $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
    }
    
    public static int SaveChangesWithIdentityInsert<T>(this DbContext context)
    {
        using var transaction = context.Database.BeginTransaction();
        context.EnableIdentityInsert<T>();
        var save = context.SaveChanges();
        context.DisableIdentityInsert<T>();
        transaction.Commit();
        return save;
    }
}