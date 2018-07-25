using System.Data.Entity;
using Gadi.Data;

namespace Gadi.Data
{
    public partial class GadiDatabase : DbContext
    {
        public GadiDatabase(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Initialise();
        }

        private void Initialise()
        {
            //Disable initializer
            Database.SetInitializer<GadiDatabase>(null);
            Database.CommandTimeout = 300;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
