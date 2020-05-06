using System;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace BluDenim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Pull();
        }

        static void Pull()
        {
            const string UserFullname = "H K";
            const string UserEmail = "anon@temp-mail.mcx";

            using var repo = new Repository(@"c:\git\BluDenim");

            // Credential information to fetch
            var options = new PullOptions
            {
                FetchOptions = new FetchOptions()
            };

            //options.FetchOptions.CredentialsProvider = new CredentialsHandler(
            //    (url, usernameFromUrl, types) =>
            //        new UsernamePasswordCredentials()
            //        {
            //            Username = USERNAME,
            //            Password = PASSWORD
            //        });

            // User information to create a merge commit
            var signature = new Signature(new Identity(UserFullname, UserEmail), DateTimeOffset.Now);

            // Pull
            try
            {
                var result = Commands.Pull(repo, signature, options);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not pull. Merge conflict");
            }
        }
    }
}
