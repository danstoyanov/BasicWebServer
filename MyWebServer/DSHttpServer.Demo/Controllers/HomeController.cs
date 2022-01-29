﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

using DSHttpServer.Server.HTTP;
using DSHttpServer.Server.Controllers;
using DSHttpServer.Server.HTTP.Cookies;

namespace DSHttpServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
                 <input type='submit' value ='Download Sites Content' /> 
        </form>";

        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name ='Age'/>
            <input type='submit' value ='Save' />
        </form>";

        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index() => Text("Hello I am Dan and wellcome to my web server !");

        public Response Redirect() => Redirect("https://github.com/");

        public Response Html() => Html(HomeController.HtmlForm);

        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => Html(HomeController.DownloadForm);

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(HomeController.FileName,
                new string[] { "https://judge.softuni.org/", "https://softuni.org/" })
                .Wait();

            return File(HomeController.FileName);
        }

        public Response Cookies()
        {
            if (this.Request.Cookies.Any(c => c.Name != DSHttpServer.Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");
                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in this.Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");

                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();

            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookes set!</h1>", cookies);
        }

        public Response Session()
        {
            string currentDateKey = "CurrentDate";
            var sessionExists = this.Request.Session.ContainsKey(currentDateKey);

            if (sessionExists)
            {
                var currentDate = this.Request.Session[currentDateKey];

                return Text($"Stored date: {currentDate}!");
            }
            else
            {
                return Text("Current date stored!");
            }
        }

        private static async Task DownloadSitesAsTextFile(
            string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(
                Environment.NewLine + new String('-', 100),
                responses);

            await System.IO.File.WriteAllTextAsync(fileName, responsesString);
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }
    }
}

