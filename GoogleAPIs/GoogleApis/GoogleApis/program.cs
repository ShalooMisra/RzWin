using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace GoogleApis
{
    /// <summary>
    /// Sample which demonstrates how to use the Books API.
    /// https://developers.google.com/books/docs/v1/getting_started
    /// <summary>
    internal class program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ShowMainChoiceMenu();
        }

        static int userResponse = 0;

        private static void ShowMainChoiceMenu()
        {
            //Hello
            //Press 1 for photos access
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to the Google Apis");
            Console.WriteLine("For Google Photos Api, enter [1]:");
            Console.WriteLine("For Gmail Api, enter [2]:");
            Console.WriteLine("For Weather, enter [3]:");
            Console.WriteLine("For Google Authorization Api, enter [4]:");
            Console.WriteLine("To exit, enter [Q]:");
            GetUserResponse();


            HandleResponse("main");
            Console.WriteLine("Please make a choice ...");
            Console.ReadKey();
        }

        private static void ReturnToMainMenu(string returnReason = null)
        {
            if (returnReason == null)
                returnReason = "********************" + Environment.NewLine + Environment.NewLine + userResponse + " is not a valid response... returning to main menu" + Environment.NewLine + Environment.NewLine + "********************";
            Console.WriteLine(returnReason);
            ShowMainChoiceMenu();
        }

        private static void GetUserResponse()
        {
            string strResponse = Console.ReadLine();
            if (strResponse.ToLower() == "q")
                Environment.Exit(0);
            if (!inputIsInteger(strResponse))
                ReturnToMainMenu(strResponse + " is not an Integer (1,2,3,123456)");
            userResponse = Convert.ToInt32(strResponse);
        }


        private static void HandleResponse(string api)
        {
            try
            {
                switch (api.ToLower())
                {
                    case "main":
                        HandleMainMenuResponse();
                        break;
                    case "gmail":
                        HandleGmailApiResponse();
                        break;
                    case "photos":
                        HandlePhotosApiResponse();
                        break;
                    case "weather":
                        HandleWeatherApiResponse();
                        break;
                    case "authorization":
                        HandleAuthApiResponse();
                        break;
                    default:
                        ReturnToMainMenu();
                        break;
                }

                Console.WriteLine();
                Console.WriteLine();
                ReturnToMainMenu("Request completed.  Returning to main menu ...");
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                ReturnToMainMenu(ex.Message + Environment.NewLine + ex.InnerException);
            }



        }


        private static void HandlePhotosApiResponse()
        {

            switch (userResponse)
            {
                case 1:
                    GetGooglePhotosAlbumCount();
                    break;
                default:
                    ReturnToMainMenu();
                    break;
            }

        }


        private static void HandleWeatherApiResponse()
        {
            IRestResponse response = null;

            switch (userResponse)
            {
                case 1:
                    response = GetCurrentLocalWeather();
                    break;
                default:
                    ReturnToMainMenu();
                    break;
            }
            if (response == null)
            {
                Console.WriteLine("Weather Response was null.  Returning ...");
                ReturnToMainMenu();
            }

            string s = HandleWeatherRequestFromUser(response);
            Console.WriteLine("The response is " + s);

        }

        private static void HandleAuthApiResponse()
        {

            authentication.GetToken();


            //Per RFC 6749 https://tools.ietf.org/html/rfc6749
            //A The CLIENT REQUETS AUTHORIZATION FROM RESOURCE OWNER
            //B THIS GRANT IS PRESENTED TO THE AUTOORIZATION SERVER
            //C AUTHORIZzarion processes gran t(SCOPE etc) RETURNS A TOKEN REPRESENTION SCOPE ETC
            //D tokeN presented to the resource server, resources server uses token to dictate access


            IRestResponse response = null;




            switch (userResponse)
            {
                case 1:
                    {
                        string token = GetAccessToken();
                        
                    break;
                    }
                    
                default:
                    ReturnToMainMenu();
                    break;
            }
            if (response == null)
            {
                Console.WriteLine("Weather Response was null.  Returning ...");
                ReturnToMainMenu();
            }

            string s = HandleWeatherRequestFromUser(response);
            Console.WriteLine("The response is " + s);
        }



        private static string HandleWeatherRequestFromUser(IRestResponse response)
        {
            string ret = "";
            Console.WriteLine("What would you like to know about the weather?");
            Console.WriteLine("To get the current temperature, press [1]:");
            Console.WriteLine("To get the current City, press [2]:");
            Console.WriteLine("To get the current Time, press [3]:");
            Console.WriteLine("To get the current Geo Location, press [4]:");
            string strResponse = "";
            strResponse = Console.ReadLine();

            if (!inputIsInteger(strResponse))
                ReturnToMainMenu(strResponse + " is not an Integer (1,2,3,123456)");
            userResponse = Convert.ToInt32(strResponse);

            switch (userResponse)
            {
                case 1:
                    {
                        ret = "";//response.;
                        break;
                    }
                case 2:
                    {
                        ret = "";
                        break;
                    }
                case 3:
                    {
                        ret = "";
                        break;
                    }
                case 4:
                    {
                        ret = "";
                        break;
                    }

            }

            return ret;
        }

        private static void HandleMainMenuResponse()
        {
            switch (userResponse)
            {
                case 1://Photos
                    {
                        Console.WriteLine("What would you like to do with Google Photos?");
                        Console.WriteLine("To get a count of photo albums, press [1]:");
                        GetUserResponse();
                        HandleResponse("photos");
                        break;
                    }
                case 2://Gmail
                    {
                        Console.WriteLine("What would you like to do with Gmail?");
                        //Press 1 for Draft Email                      
                        Console.WriteLine("To send a test draft, press [1]:");
                        GetUserResponse();
                        HandleResponse("gmail");
                        break;
                    }
                case 3:
                    {

                        Console.WriteLine("What would you like to do with Weather?");
                        //Press 1 for Draft Email                      
                        Console.WriteLine("To get current weather, press [1]:");
                        GetUserResponse();
                        HandleResponse("weather");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Getting Authorization token ...");
                        HandleAuthApiResponse();
                        break;
                    }
                default:
                    ReturnToMainMenu();
                    break;


            }


        }

        private static void HandleGmailApiResponse()
        {
            switch (userResponse)
            {
                case 1:
                    gmailapi.CreateGmailTest("test subject", "test body", "ktill@sensiblemicro.com");
                    break;
                default:
                    ReturnToMainMenu();
                    break;

            }


        }

        private static int GetGooglePhotosAlbumCount()
        {
            Console.WriteLine("Getting Google Photos Album Count...");

            string clientId =
                @"804614284955-sjui1jos69381id99v7kboqirmfbcbgl.apps.googleusercontent.com";
            string clientSecret = @"qRRjryc1b30JJIjjrbKPMmYU";




            var client = new RestClient("http://localhost:53733/auth/google/callback");
            RestRequest request = new RestRequest() { Method = Method.POST };

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("grant_type", "client_credentials");
            client.Authenticator = new HttpBasicAuthenticator(clientId, clientSecret);


            var response = client.Execute(request);

            int count = 0;



            return count;

        }



        private static IRestResponse GetCurrentLocalWeather()
        {

            Console.WriteLine("Getting Current Local Weather...");
            return GetCurrentLocalWeatherResponse();

        }

        private static IRestResponse GetCurrentLocalWeatherResponse()
        {
            var client = new RestClient("http://www.google.com/ig/api");
            var request = new RestRequest(Method.GET);
            request.AddParameter("weather", "Brisbane");

            //KT 2-18-2019 - removed this as was having errors with GmailApi, and this overcomplicated finding a solution
            //var response = client.Execute<xml_api_reply>(request);
            // return response;
            return null;
        }


        private static string GetAccessToken()
        {
            //throw new NotImplementedException();
            //From Successful Postman
            //Token Name Google OAuth getpostman
            //Grant Type Authorization Code
            //Callback URL http://shmootill.com/auth/callback
            //Auth URL https://accounts.google.com/o/oauth2/auth
            //Access Token URL https://accounts.google.com/o/oauth2/token
            //Client ID 804614284955-cu6vnh91mueihhj289jo62gknkae2vrt.apps.googleusercontent.com
            //Client Secret fkAFnx0jopfVr-lgud2n5kWK
            //Scope https://www.googleapis.com/auth/photos
            //State State
            //Client Authentication "Send as Basic Auth Header"


            string url = "https://photoslibrary.googleapis.com/v1/albums";
            string client_id = "804614284955-cu6vnh91mueihhj289jo62gknkae2vrt.apps.googleusercontent.com";
            string client_secret = "fkAFnx0jopfVr-lgud2n5kWK";
            //request token
            var restclient = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST) { Method = Method.POST };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "client_credentials");
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            //return an AccessToken
            return token.Length > 0 ? token : null;

            
            

        }


        public static string GetAccessToken2()
        {
            var url = "https://photoslibrary.googleapis.com/v1/albums";
            string apiKey = "804614284955-cu6vnh91mueihhj289jo62gknkae2vrt.apps.googleusercontent.com";
            string apiPassword = "fkAFnx0jopfVr-lgud2n5kWK";
          

            //create RestSharp client and POST request object
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            //add GetToken() API method parameters
            request.Parameters.Clear();
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", apiKey);
            request.AddParameter("password", apiPassword);

            //make the API request and get the response
            IRestResponse response = client.Execute(request);

            //return an AccessToken
            //return JsonConvert.DeserializeObject<AccessToken>(response.Content);
            return response.ToString() ?? "No Resopnse";
        }




        //validation

        private static bool inputIsInteger(string s)
        {

            int value;
            if (int.TryParse(s, out value))
                return true;
            return false;

        }
    }
}
