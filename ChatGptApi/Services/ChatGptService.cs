using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;

namespace ChatGptApi.Services
{
    public static class ChatGptService
    {
        public static string SendMsg(string systemText, string sQuestion, string threadId = null)
        {
            var OPENAI_API_KEY = ConfigurationManager.AppSettings["chatGptApiKey"].ToString();
            System.Net.ServicePointManager.SecurityProtocol =
                System.Net.SecurityProtocolType.Ssl3 |
                System.Net.SecurityProtocolType.Tls12 |
                System.Net.SecurityProtocolType.Tls11 |
                System.Net.SecurityProtocolType.Tls;

            string sModel = "gpt-3.5-turbo";//cbModel.Text; // text-davinci-002, text-davinci-003
            string sUrl = "https://api.openai.com/v1/completions";

            if (sModel.IndexOf("gpt-3.5-turbo") != -1)
            {
                //Chat GTP 4 https://openai.com/research/gpt-4
                sUrl = "https://api.openai.com/v1/chat/completions";
            }

            var request = WebRequest.Create(sUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + OPENAI_API_KEY);

            string data = "";
            if (sModel.IndexOf("gpt-3.5-turbo") != -1)
            {
                data = "{";
                data += " \"model\":\"" + sModel + "\",";
                data += " \"messages\": [{\"role\": \"system\", \"content\": \"" + PadQuotes(systemText) + "\"}, {\"role\": \"user\", \"content\": \"" + PadQuotes(sQuestion) + "\"}]";
                data += "}";
            }

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var response = request.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            string sJson = streamReader.ReadToEnd();
            return sJson;
        }

        private static string PadQuotes(string s)
        {
            if (s.IndexOf("\\") != -1)
                s = s.Replace("\\", @"\\");

            if (s.IndexOf("\n\r") != -1)
                s = s.Replace("\n\r", @"\n");

            if (s.IndexOf("\r") != -1)
                s = s.Replace("\r", @"\r");

            if (s.IndexOf("\n") != -1)
                s = s.Replace("\n", @"\n");

            if (s.IndexOf("\t") != -1)
                s = s.Replace("\t", @"\t");

            if (s.IndexOf("\"") != -1)
                return s.Replace("\"", @"""");
            else
                return s;
        }
    }
}