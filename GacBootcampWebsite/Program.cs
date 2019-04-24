using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace GacBootcampWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddAzureKeyVault(
                    "https://globalazurebootcamp.vault.azure.net", 
                    "d1ea2c4c-855c-4b5e-a88e-b2c5fc90828e", 
                    "tKyd+xZDmIEqbqR8axikU/9Y3/xkLHUvh3CgLqFqNTg=", 
                    new DefaultKeyVaultSecretManager());
            }).UseStartup<Startup>();
    }
}
