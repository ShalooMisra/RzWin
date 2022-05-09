using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Newtonsoft.Json;

namespace GoogleApis
{
    /// <summary>
    /// Sample which demonstrates how to use the Books API.
    /// https://developers.google.com/books/docs/v1/getting_started
    /// <summary>
    internal class authentication
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json        
        static string ApplicationName = "Gmail API .NET Quickstart";
        static UserCredential Credential = null;


        [STAThread]
        public static UserCredential getAuthenticationCredential(string[] Scopes)
        {           
            doBasicAuthentication(Scopes);
            return Credential;
        }

        private static void doBasicAuthentication(string[] Scopes)
        {
            Console.WriteLine("Basic Google Authentication");
            Console.WriteLine("================================");
            try
            {
                new authentication().Run(Scopes).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
        }

        private async Task Run(string[] Scopes)
        {
            UserCredential credential;
            Stream client_secret_json_stream = GenerateClientSecretStream();
           
            using (client_secret_json_stream)
            {
                
                //I prefer MyDocuments for protection of client secret.               
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                //Temp Folder
                //string credPath = Path.GetTempPath();
                credPath = Path.Combine(credPath, ".credentials/sm-gmail-api.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(client_secret_json_stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
                Credential = credential;
            }

           

        }

        

        //private async Task Run_bak()
        //{
        //    UserCredential credential;
        //    using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
        //    {
        //        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            new[] { BooksService.Scope.Books },
        //            "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary"));
        //    }

        //    // Create the service.
        //    var service = new BooksService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "Books API Sample",
        //    });

        //    var bookshelves = await service.Mylibrary.Bookshelves.List().ExecuteAsync();
        //    Console.WriteLine("Item Count: " + bookshelves.Items.Count);

        //}


        private static Stream GenerateClientSecretStream()
        {
            //Note, make sure you set Oauth 2.0 "type" to "Other" at https://console.developers.google.com/apis/credentials?project=sensiblemicro.com:api-project-820943666715
            string s = "<redacted>";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }













        private void authenticateBooksExample(string[] Scopes)
        {
            Console.WriteLine("Books API Sample: List MyLibrary");
            Console.WriteLine("================================");
            try
            {
                new authentication().Run(Scopes).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        public class Bearer
        {
            public string scope { get; set; }
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string refresh_token { get; set; }
            public string access_token { get; set; }
        }

        
            public static void GetToken()
            {
            //CLIENT ID
            //804614284955-gpalesf7kt5d4h2aqm5v3otppbtoolms.apps.googleusercontent.com

            //CLIENT Secred
            //7wCGAWzTdFINo9HmkGGBwo0V

            //Photos AUTHORIZATION endpoint URI:
            //https://www.googleapis.com/auth/photos





            string consumerKey = "804614284955-gpalesf7kt5d4h2aqm5v3otppbtoolms.apps.googleusercontent.com";
                string consumerSecret = "7wCGAWzTdFINo9HmkGGBwo0V";
                string accessToken;

                byte[] byte1 = Encoding.ASCII.GetBytes("grant_type=client_credentials");

                HttpWebRequest bearerReq = WebRequest.Create("https://www.googleapis.com/auth/photos") as HttpWebRequest;
                bearerReq.Accept = "application/json";
                bearerReq.Method = "POST";
                bearerReq.ContentType = "application/x-www-form-urlencoded";
                bearerReq.ContentLength = byte1.Length;
                bearerReq.KeepAlive = false;
                bearerReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(consumerKey + ":" + consumerSecret)));
                Stream newStream = bearerReq.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);

                WebResponse bearerResp = bearerReq.GetResponse();

                using (var reader = new StreamReader(bearerResp.GetResponseStream(), Encoding.UTF8))
                {
                    var response = reader.ReadToEnd();
                    Bearer bearer = JsonConvert.DeserializeObject<Bearer>(response);
                    accessToken = bearer.access_token;
                }

                Console.WriteLine(accessToken);
                Console.Read();
            }
      




    }
}