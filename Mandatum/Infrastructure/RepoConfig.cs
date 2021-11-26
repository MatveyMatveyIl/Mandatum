using System;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public interface IRepoConfig
    {
        string filePath { get; }
    }

    public class RepoConfig : IRepoConfig
    {
        public string filePath { get; set; }
    }
    
    public class EnvRepoConfig : IRepoConfig
    {
        public string filePath => Environment.GetEnvironmentVariable("REPOFILEPATH");
    }
    
    public class NewRepoConfig : IRepoConfig
    {
        public string filePath { get; set; }

        public NewRepoConfig(IConfiguration  config)
        {
            filePath = config["REPOFILEPATH"];
        }
    }
}