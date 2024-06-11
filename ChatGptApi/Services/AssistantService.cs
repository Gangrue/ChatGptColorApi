using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatGptApi.Services
{
    public class AssistantService
    {
        public AssistantService()
        {

        }

        public string AskQuestion(string question, string threadId)
        {
            var systemText = "";
            var response = ChatGptService.SendMsg(systemText, question, threadId);
            return response;
        }
    }
}