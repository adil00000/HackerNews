using HackerNewsLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsLibrary.Validation
{
    public static class ValidatePostInput
    {
        private static object _locker = new object();
        public static int ValidatePosts(string posts, out string error)
        {
            error = "";
            lock (_locker)
            {
                int x = 0;

                if(!Int32.TryParse(posts, out x))
                {
                    error = "Unable to convert" + posts + " to integer.";
                }
                else
                {
                    if(x>100)
                    {
                        error = "Post must be less than 100.";
                    }
                }
                return x;
            }
        }

        /// <summary>
        /// Method to check the lenght of the title
        /// </summary>
        /// <param name="Title">Title of the post</param>
        /// <param name="error">Will error if lenght is greater than annotation</param>
        /// <returns>Returns false if there is an error</returns>
        public static bool ValidateTitle(string Title, out string error)
        {
            lock (_locker)
            {
                error = "";
                bool result = true;
                if(Title.Length > DataAnnotation.GetMaxLengthFromStringLengthAttribute(typeof(Posts), "title"))
                {
                    error = "Title is too long";
                    result = false;
                }
                return result;
            }
        }

        /// <summary>
        /// Checks if the uri is correctly formatted - http and https part of validation
        /// </summary>
        /// <param name="uriName">URL to validate</param>
        /// <param name="error">etxt explaing the error</param>
        /// <returns>returns false if there is an error</returns>
        public static bool ValidateUri(string uriName, out string error)
        {
            lock (_locker)
            {
                error = "";
                Uri uriResult;
                bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (!result)
                    error = "Incorrectly formed URL - " + uriName;


                return result;
            }
        }

        /// <summary>
        /// Checks the leght of the author
        /// </summary>
        /// <param name="Author">checks again the annotation in the Post class</param>
        /// <param name="error">returns false if its greater than annotation</param>
        /// <returns>returns false if its greater than annotation</returns>
        public static bool ValidateAuthor(string Author, out string error)
        {
            lock (_locker)
            {
                bool result = true;

                error = "";
                if (Author.Length > DataAnnotation.GetMaxLengthFromStringLengthAttribute(typeof(Posts), "author"))
                {
                    error = "Author is too long";
                }

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">input text by user</param>
        /// <param name="points">out - converted output</param>
        /// <param name="error">errors arising from convertions or if its less than zero</param>
        /// <returns></returns>
        public static bool ValidatePoints(string input, out int points, out string error)
        {
            lock (_locker)
            {
                points = 0;
                error = "";
                bool result = false;

                if (!Int32.TryParse(input, out points))
                {
                    error = "Unable to convert "+ input + " to integer.";
                }
                else
                {
                    if (points < 0)
                    {
                        error = "Points must be greater than 0.";
                    }
                    else
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">input text by user</param>
        /// <param name="comments">out - converted output</param>
        /// <param name="error">errors arising from convertions or if its less than zero</param>
        /// <returns></returns>
        public static bool ValidateComments(string input, out int comments, out string error)
        {
            lock (_locker)
            {
                error = "";
                comments = 0;
                bool result = false;


                if (!Int32.TryParse(input, out comments))
                {
                    error = "Unable to convert "+ input + " to integer.";
                }
                else
                {
                    if (comments <= 0)
                    {
                        error = "Comments must be greater than 0.";
                    }
                    else
                        result = true;
                }
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">input text by user</param>
        /// <param name="rank">out - converted output</param>
        /// <param name="error">errors arising from convertions or if its less than zero</param>
        /// <returns></returns>
        public static bool ValidateRank(string input, out int rank, out string error)
        {
            lock (_locker)
            {
                error = "";
                 rank = 0;
                bool result = false;

                if (!Int32.TryParse(input, out rank))
                {
                    error = "Unable to convert to integer.";
                }
                else
                {
                    if (rank < 0)
                    {
                        error = "Rank must be greater than 0.";
                    }
                    else
                        result = true;
                }
                return result;
            }
        }

    }
}
