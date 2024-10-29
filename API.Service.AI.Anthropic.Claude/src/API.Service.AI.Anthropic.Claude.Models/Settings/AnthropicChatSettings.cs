namespace API.Service.AI.Anthropic.Claude.Models.Settings
{
	public class AnthropicChatSettings : ChatSettings
	{
		public double Temperature { get; set; }

		public int MaxTokens { get; set; }

		public string TopP { get; set; }

		public double FrequencyPenalty { get; set; }

		public double PresencePenalty { get; set; }

		public string StopSequences { get; set; }

		public bool Stream { get; set; }

		public string System { get; set; }
	}
}