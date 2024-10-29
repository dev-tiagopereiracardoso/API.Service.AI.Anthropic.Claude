namespace API.Service.AI.Anthropic.Claude.Models.Settings
{
	public enum ModelType
	{
		OpenAIDalleImage,
		OpenAIGpt
	}

	public class ChatSettings
	{
		public string Id { get; set; }
		public string ConversationId { get; set; }
		public ModelType ModelType { get; set; }
		public string ModelSettingsJson { get; set; }
	}
}