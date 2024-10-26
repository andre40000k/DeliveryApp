using DeliveriApp.Domein.Entities;

namespace DeliveriApp.Application.UpsertModels.Commands
{
    public class UpsertCityCommand
    {
        public string CityName { get; set; }

        public City UpsertCity()
        {
            return new City
            {
                CityName = CityName,
            };
        }
    }
}
