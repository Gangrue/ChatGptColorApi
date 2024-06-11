using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ChatGptApi.Services
{
    public static class ColorInterpreterService
    {
        public static List<string> GetPossibleColorNames()
        {
            var colorNames = new List<string>();
            colorNames.Add("Red");
            colorNames.Add("Blue");
            colorNames.Add("Green");
            colorNames.Add("Yellow");
            colorNames.Add("Black");
            colorNames.Add("White");
            return colorNames;
        }

        public static string InterpretColors(string[] colors)
        {
            var newColorString = string.Join(",", colors);
            var properColors = string.Join(",", GetPossibleColorNames());

            var systemString = "You are a helpful assistant that corrects and standardizes color names. Only respond with a list of the following colors: " + properColors;
            var requestMessage = "Please correct and standardize the following color names: " + newColorString;

            var returnedMessage = ChatGptService.SendMsg(systemString, requestMessage);
            // Parse the JSON string
            JObject jsonObject = JObject.Parse(returnedMessage);
            // Navigate to the specific field
            string content = jsonObject["choices"][0]["message"]["content"].ToString();
            return content;
        }
    }
}