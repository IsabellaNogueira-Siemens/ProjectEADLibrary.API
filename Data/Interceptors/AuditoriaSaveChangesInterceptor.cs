using EADFirstProjectApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace EADFirstProjectApi.Data.Interceptors
{
    public class AuditoriaSaveChangesInterceptor : SaveChangesInterceptor
    {
        // Este método é chamado ANTES do SaveChanges síncrono
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            AtualizarEntidades(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        // Este método é chamado ANTES do SaveChanges assíncrono (o que usamos mais)
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            AtualizarEntidades(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void AtualizarEntidades(DbContext? context)
        {
            if (context == null) return;

            // Itera sobre todas as entidades que estão sendo rastreadas pelo EF Core
            foreach (var entry in context.ChangeTracker.Entries<EntidadeAuditavel>())
            {
                // Se a entidade está sendo ADICIONADA
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DataCriacao = DateTime.UtcNow;
                }

                // Se a entidade está sendo ADICIONADA ou MODIFICADA
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.DataModificacao = DateTime.UtcNow;
                }
            }
        }
    }
}
