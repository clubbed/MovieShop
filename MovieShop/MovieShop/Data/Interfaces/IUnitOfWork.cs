namespace MovieShop.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository Movie { get; set; }
        IGenreRepository Genre { get; set; }
        IRentRepository Rent { get; set; }
        IUserRepository User { get; set; }

        void CommitChanges();
    }
}
