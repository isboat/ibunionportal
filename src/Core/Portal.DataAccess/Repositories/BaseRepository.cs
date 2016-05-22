using System.Configuration;

namespace Portal.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly string ConString;

        public BaseRepository()
        {
            this.ConString = ConfigurationManager.ConnectionStrings["portal"].ConnectionString;
        }
    }
}
