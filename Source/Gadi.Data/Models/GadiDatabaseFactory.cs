using System;
using Gadi.Data.Interfaces;

namespace Gadi.Data.Models
{
    public class GadiDatabaseFactory : IDatabaseFactory<GadiDatabase>
    {
        public string NameOrConnectionString { get; }

        public GadiDatabaseFactory(string nameOrConnectionString)
        {
            NameOrConnectionString = nameOrConnectionString;
        }

        public GadiDatabase CreateContext()
        {
            ValidateConnectionString();
            var context = new GadiDatabase(NameOrConnectionString);
            // context.UseSerilog();

            return context;
        }

        private void ValidateConnectionString()
        {
            if (string.IsNullOrWhiteSpace(NameOrConnectionString))
                throw new NullReferenceException("OmbrosDatabaseFactory expects a valid NameOrConnectionString");
        }
    }
}
