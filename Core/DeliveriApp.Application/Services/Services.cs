namespace DeliveriApp.Application.Services
{
    public interface IRsponsHendler<IRespons>
    {
        Task<IRespons> HendlerAsync(CancellationToken cancellationToken = default);
    }
    public interface IRequestHendler<in IRequest>
    {
        Task HendlerAsync(IRequest request, CancellationToken cancellationToken = default);
    }    

    public interface IRequestHendler<in IRequest, IRespons>
    {
        Task<IRespons> HendlerAsync(IRequest request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHendler<in IRequestFirst, in IRequestSecond, IRespons>
    {
        Task<IRespons> HendlerAsync(IRequestFirst requestFirst, IRequestSecond requestSecond, CancellationToken cancellationToken = default);
    }
}
