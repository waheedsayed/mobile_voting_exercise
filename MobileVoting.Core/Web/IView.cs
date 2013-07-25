namespace MobileVoting.Core.Web
{
    public interface IView<TModel>
        where TModel : class,new()
    {
        TModel Model { get; set; }
    }
}