using DeliveriApp.Domein.Interfaces;

namespace DeliveriApp.Domein
{
    public abstract class BaseEntity : IBaseProperties
    {
       public Guid Id { get; set; }
    }
}
