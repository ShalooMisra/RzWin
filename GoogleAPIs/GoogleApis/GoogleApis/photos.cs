using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Diagnostics;
using MimeKit;
using System.Collections;

namespace GoogleApis
{
    public class photos
    {

        static string ApplicationName = "Gmail API .NET Google Photos";

        static void photosProgram(string[] scopes)
        {
            UserCredential credential = authentication.getAuthenticationCredential(scopes);



        }


    }
     
}

