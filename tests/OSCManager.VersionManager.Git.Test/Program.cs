using System;

using LibGit2Sharp;

namespace OSCManager.VersionManager.Git.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            var result = Repository.Clone("https://github.com.cnpmjs.org/libgit2/libgit2sharp", "E:\\WorkSpace\\Temp2",
                new CloneOptions()
                {
                    OnProgress = opString =>
                    {
                        Console.WriteLine(opString);
                        return true;
                    },
                    OnCheckoutProgress = (path, completedSteps, totalSteps) => Console.WriteLine(path),
                    OnUpdateTips = (referenceName, oldId, newId) => { Console.WriteLine(referenceName); return true; },
                    RepositoryOperationStarting = _ => true,
                    RepositoryOperationCompleted = _ => Console.WriteLine("Finish")

                    //CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = "huansky", Password = "Password" }
                });

            Console.WriteLine(result);
        }
    }
}
