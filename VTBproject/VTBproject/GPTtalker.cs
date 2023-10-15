using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace VTBproject
{
    public class GPTTalker
    {
        private readonly string apiKey = "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";
        private OpenAI_API.OpenAIAPI api;
        public GPTTalker()
        {
            api = new OpenAI_API.OpenAIAPI(apiKey);
        }

        public void SetSettings()
        {
            string prompt = "Source";
            if (chat == null) { RefreshConversation(); }
            chat.AppendSystemMessage(prompt);
        }
        public async Task<string> CompletPrompt(string prompt)
        {
            string answer = string.Empty;
            await foreach (var token in api.Completions.StreamCompletionEnumerableAsync(new CompletionRequest(prompt, Model.DavinciText, 200, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1)))
            {
                answer += token;
            }
            return answer;
        }

        OpenAI_API.Chat.Conversation chat;

        public void RefreshConversation()
        {
            chat = api.Chat.CreateConversation();
        }
        public async Task<string> Talk(string prompt)
        {
            if (chat == null) { RefreshConversation(); }
            chat.AppendUserInput(prompt);
            string answer = string.Empty;
            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                answer += res;  
            }
            return answer;
        }
    }
}
