using ChatGptApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatGptApi.Controllers
{
    public class AssistantController : ApiController
    {
        public AssistantService AssistantService { get; set; }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]string question)
        {
            if (AssistantService == null)
            {
                AssistantService = new AssistantService();
            }

            var response = AssistantService.AskQuestion(question, "test");
            return response;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}