using DeliveriApp.Domein;
using DeliveriApp.Domein.Interfaces;

namespace DeliveriApp.Application.UpsertModels.Common
{
    public class WorkWithId : BaseProperties
    {
        public TEntity GetByIdCommand<TEntity>() where TEntity : class, IBaseProperties, new()
        {
            return new TEntity
            {
                Id = Id
            };
        }
    }
}
