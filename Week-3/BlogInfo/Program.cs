using Newtonsoft.Json.Linq;

namespace BlogInfo
{
    class Program
    {
        private const string TumblrApiPath = "/api/read/json";
        private const string PhotoTypeQuery = "type=photo";
        private const string PostsKey = "posts";
        private const string PhotosKey = "photos";
        private const string HighestResolutionKey = "photo-url-1280";

        static async Task Main(string[] args)
        {
            try
            {
                string blogName = ReadBlogName();
                (int startPost, int endPost) = ReadPostRange();

                string apiUrl = BuildApiUrl(blogName, startPost, endPost);
                JObject json = await FetchTumblrData(apiUrl);

                PrintBlogInfo(json);
                PrintImages(json, startPost);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred:");
                Console.WriteLine(ex.Message);
            }
        }

        static string ReadBlogName()
        {
            Console.WriteLine("Enter the Tumblr blog name:");
            return Console.ReadLine()?.Trim();
        }

        static (int startPost, int endPost) ReadPostRange()
        {
            Console.WriteLine("Enter the range (start-end):");
            string rangeInput = Console.ReadLine();

            var rangeParts = rangeInput.Split('-');
            int startPost = int.Parse(rangeParts[0]);
            int endPost = int.Parse(rangeParts[1]);

            return (startPost, endPost);
        }

        static string BuildApiUrl(string blogName, int startPost, int endPost)
        {
            int startIndex = startPost - 1;
            int postCount = endPost - startPost + 1;

            return $"https://{blogName}.tumblr.com{TumblrApiPath}?{PhotoTypeQuery}&start={startIndex}&num={postCount}";
        }

        static async Task<JObject> FetchTumblrData(string apiUrl)
        {
            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(apiUrl);

            /*
             * Tumblr API v1 does not return pure JSON.
             * It returns JavaScript with extra characters.
             * Extracting the JSON block is necessary before parsing.
             */
            int jsonStart = response.IndexOf('{');
            int jsonEnd = response.LastIndexOf('}');

            string cleanJson = response.Substring(
                jsonStart,
                jsonEnd - jsonStart + 1
            );

            return JObject.Parse(cleanJson);
        }

        static void PrintBlogInfo(JObject json)
        {
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("Blog Info:");
            Console.WriteLine($"Title       : {json["tumblelog"]?["title"]}");
            Console.WriteLine($"Name        : {json["tumblelog"]?["name"]}");
            Console.WriteLine($"Description : {json["tumblelog"]?["description"]}");
            Console.WriteLine($"No of Posts : {json["posts-total"]}");
            Console.WriteLine("---------------------------------------\n");
        }

        static void PrintImages(JObject json, int startPostNumber)
        {
            var posts = json[PostsKey] as JArray;
            int postNumber = startPostNumber;

            foreach (var post in posts)
            {
                Console.WriteLine($"{postNumber}.");

                var photos = post[PhotosKey] as JArray;

                if (photos != null)
                {
                    foreach (var photo in photos)
                    {
                        string imageUrl = photo[HighestResolutionKey]?.ToString();

                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            Console.WriteLine(imageUrl);
                        }
                    }
                }

                postNumber++;
            }
        }
    }
}
