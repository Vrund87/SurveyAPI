using MongoDB.Driver;
using SurveyAPI.Models;

namespace SurveyAPI.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IMongoCollection<Survey> _surveys;

        public SurveyService(ISurveyDBSettings settings,IMongoClient mongoClient)
        {
            var DBName = mongoClient.GetDatabase(settings.DatabaseName);
            _surveys = DBName.GetCollection<Survey>(settings.SurveyCollectionName);
        }

        public Survey Create(Survey survey)
        {
            _surveys.InsertOne(survey);
            return survey;
        }

        public List<Survey> Get()
        {
            return _surveys.Find(survey => true).ToList();
        }

        public void Update(Survey survey)
        {

            var filter = Builders<Survey>.Filter.Eq(s => s.id, survey.id);
            var update = Builders<Survey>.Update
                // ... Include other properties that you want to update ...
                .Set(s => s.sq1, survey.sq1)
                .Set(s => s.sq2, survey.sq2)
                .Set(s => s.sq3, survey.sq3)
                .Set(s => s.sq4a, survey.sq4a)
                .Set(s => s.sq4b, survey.sq4b)
                .Set(s => s.sq4c, survey.sq4c)
                .Set(s => s.sq4d, survey.sq4d)
                .Set(s => s.sq4Other, survey.sq4Other)
                .Set(s => s.sq5, survey.sq5)
                .Set(s => s.sq6, survey.sq6)
                .Set(s => s.sq7, survey.sq7)
                .Set(s => s.sq8, survey.sq8)
                .Set(s => s.sq9, survey.sq9);

            _surveys.UpdateOne(filter, update);
            //_surveys.ReplaceOne(survey=>survey.Id==survey.Id,survey);
        }
    }
}
