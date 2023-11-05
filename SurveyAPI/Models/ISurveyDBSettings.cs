namespace SurveyAPI.Models
{
    public interface ISurveyDBSettings
    {
        string SurveyCollectionName { get; set; }
        string ConnectionString {get;set; }
        string DatabaseName { get; set; }
    }
}
