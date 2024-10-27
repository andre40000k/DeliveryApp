using DeliveriApp.Domein.Interfaces;

namespace DeliveriApp.Domein
{
    public abstract class BaseProperties : IBaseProperties
    {
       public Guid Id { get; set; }
    }
}
