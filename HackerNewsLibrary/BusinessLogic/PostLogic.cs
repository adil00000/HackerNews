using HackerNewsLibrary.Data;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HackerNewsLibrary.BusinessLogic
{
    public class PostLogic
    {
        List<Posts> listPost = new List<Posts>();

        /// <summary>
        /// Add a Post to the list
        /// </summary>
        /// <param name="post"></param>
        public void CreateList(Posts post)
        {
            listPost.Add(post);
        }

        /// <summary>
        /// Gets a list ot Posts added to the list
        /// </summary>
        /// <returns>return IEnumerable so that it cannot be modified</returns>
        public IEnumerable<Posts> GetPosts()
        {
            return listPost;
        }

        /// <summary>
        /// Create a JSON representation of the list
        /// </summary>
        /// <returns>actual JSON string</returns>
        public string CreateJSON()
        {
            string output = JsonConvert.SerializeObject(listPost, Formatting.Indented);
            return output;
        }

    }
}
