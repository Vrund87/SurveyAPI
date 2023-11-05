using SurveyAPI.Models;

namespace SurveyAPI.Services
{
    public interface ISurveyService
    {
        List<Survey> Get();
        Survey Create(Survey survey);
        void Update(Survey survey);

    }
}
