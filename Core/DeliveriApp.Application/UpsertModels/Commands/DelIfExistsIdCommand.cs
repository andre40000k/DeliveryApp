using DeliveriApp.Domein;
using DeliveriApp.Domein.Interfaces;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class DelIfExistsIdCommand : BaseProperties
    {
        public TEntity DelIfExistsCommand<TEntity>() where TEntity : class, IBaseProperties, new()
        {
            return new TEntity
            {
                Id = Id
            };
        }


    }
}
