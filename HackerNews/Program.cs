using Fclp;
using System;
using HackerNewsLibrary.Validation;
using HackerNewsLibrary.Data;

using HackerNewsLibrary.BusinessLogic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace HackerNews
{
    class Program
    {
        static int Posts;
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var p = new FluentCommandLineParser();

            p.Setup<int>('p', "posts")
             .Callback(val => Posts = val) //Provide a delegate to call after the option has been parsed
             .Required();


            var result = p.Parse(args);

            // need to do it this way because of docker issues in interactive mode
            // normal console will take input, however in docker mode we need to give it alittle help
            Task.Factory.StartNew(() =>
            {
                if (result.HasErrors == false) // no errors reported after parsing
                {
                    Parse();
                }
                else
                {
                    Console.WriteLine("Missing --posts flag");
                }
                _closing.Set();
            });

            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            _closing.WaitOne();

        }

        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exiting...");
            _closing.Set();
        }

        /// <summary>
        /// Get input from users for all post entries
        /// </summary>
        static void Parse()
        {
            string error = string.Empty;
            string Title;
            string uri;
            string Author;
            int Points;
            int Comments;
            int Rank;

            PostLogic postLogic = new PostLogic();

            Console.WriteLine("Number of posts {0}", Program.Posts);

            for (int i = 1; i <= Program.Posts; i++)
            {
                while (true)
                {
                    Console.WriteLine("Please enter the title for Post No {0}", i);
                    Title = Console.ReadLine();
                    if (!ValidatePostInput.ValidateTitle(Title, out error))
                        Console.WriteLine(error);
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Please enter the uri for Post No {0}", i);
                    uri = Console.ReadLine();
                    if (!ValidatePostInput.ValidateUri(uri, out error))
                        Console.WriteLine(error);
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Please enter the Author for Post No {0}", i);
                    Author = Console.ReadLine();
                    if(!ValidatePostInput.ValidateAuthor(Author, out error))
                         Console.WriteLine(error);
                    else
                        break;
                }

                while (true)
                {
                    Console.WriteLine("Please enter the Points for Post No {0}", i);

                    if (!ValidatePostInput.ValidatePoints(Console.ReadLine(), out Points, out error))
                        Console.WriteLine(error);
                    else
                        break;
                }


                while (true)
                {
                    Console.WriteLine("Please enter the Comments for Post No {0}", i);

                    if (!ValidatePostInput.ValidateComments(Console.ReadLine(), out Comments, out error))
                        Console.WriteLine(error);
                    else
                        break;

                }

                while (true)
                {
                    Console.WriteLine("Please enter the Rank for Post No {0}", i);

                    if(!ValidatePostInput.ValidateRank(Console.ReadLine(), out Rank, out error))
                        Console.WriteLine(error);
                    else
                        break;
                }

                Posts post = new Posts()
                {
                    title = Title,
                    uri = uri,
                    author = Author,
                    points = Points,
                    comments = Comments,
                    rank = Rank
                };

                postLogic.CreateList(post);

            }
            Console.WriteLine("JSON post is as follows...");
            Console.WriteLine(postLogic.CreateJSON());
        }
    }
}
