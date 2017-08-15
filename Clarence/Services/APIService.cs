﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Actiance.Services
{
    public class APIService
    {
        public APIService()
        {
        }

        public static async Task<TResult> PostTo<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData)
        {
            //post to https://login.microsoftonline.com/db35d98a-b61b-4362-90e6-22237a243507/oauth2/v2.0/token

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    return await response.Content.ReadAsAsync<TResult>();
                }
            }
        }
    }
}