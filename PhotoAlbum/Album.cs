using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace PhotoAlbum
{
    public class Album
    {
        public Album()
        {
            //Intentionally left empty
        }

        public Dictionary<int, string> GetAlbumContents(string id)
        {
            string res;
            Dictionary<int, string> photos = new Dictionary<int, string>();

            string url = $"https://jsonplaceholder.typicode.com/photos?albumId={id}";

            using (WebClient wc = new WebClient())
            {
                res = wc.DownloadString(url);
            }

            var json = JArray.Parse(res);
            foreach (JObject photo in json)
            {
                photos.Add(photo.Value<int>("id"), photo.Value<string>("title"));
            }

            return photos;
        }
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Correct usage is PhotoAlbum.exe <albumId>");
                Environment.Exit(1);
            }
            Album al = new Album();
            Dictionary<int, string> photos = al.GetAlbumContents(args[0]);

            if (photos.Count > 0)
            {
                foreach (KeyValuePair<int, string> photo in photos)
                {
                    Console.WriteLine($"[{photo.Key}] {photo.Value}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Album ID");
            }
        }
    }
}
