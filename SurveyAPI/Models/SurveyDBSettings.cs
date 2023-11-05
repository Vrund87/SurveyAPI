namespace SurveyAPI.Models
{
    public class SurveyDBSettings:ISurveyDBSettings
    {
        public string SurveyCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
