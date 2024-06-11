using ChatGptApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatGptApi.Controllers
{
    public class ColorInterpreterController : ApiController
    {
        // GET api/ColorInterpreter
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/ColorInterpreter/offwhite
        public string Get(string colors)
        {
            var possibleColors = ColorInterpreterService.GetPossibleColorNames();
            //TODO: trim the colors string and place in new string that only has non-accurate color names. This is to avoid overuse of chatgpt.
            var cleanedColorString = colors.Split(',');
            var interpretedColorString = ColorInterpreterService.InterpretColors(cleanedColorString);
            return interpretedColorString;
        }

        // POST api/ColorInterpreter
        public void Post([FromBody]string value)
        {
        }

        // PUT api/ColorInterpreter/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ColorInterpreter/5
        public void Delete(int id)
        {
        }
    }
}
