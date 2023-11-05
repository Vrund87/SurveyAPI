using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SurveyAPI.Models
{
    public class Survey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = String.Empty;

        public string name { get; set; } = String.Empty;

        public string yearsOfExperience { get; set; } = string.Empty;

        public string email { get; set; } = String.Empty;

        public string phone { get; set; } = String.Empty;

        public string linkedIn { get; set; } = String.Empty;

        public bool canContact { get; set; } = false;

        public string currentRole { get; set; } = string.Empty;

        public string otherRole { get; set; } = String.Empty;

        //Survey Questions

        public string sq1 { get; set; } = String.Empty;

       
        public string sq2 { get; set; } = String.Empty;

        
        public string sq3 { get; set; } = String.Empty;

        public bool sq4a { get; set; } = false;

        public bool sq4b { get; set; } = false;

        public bool sq4c { get; set; } = false;

        public bool sq4d { get; set; } = false;

        public string sq4Other { get; set; } = String.Empty;

        
        public string sq5 { get; set; } = String.Empty;

        
        public string sq6 { get; set; } = String.Empty;

        
        public string sq7 { get; set; } = String.Empty;

        public string sq8 { get; set; } = String.Empty;

        public string sq9 { get; set; } = String.Empty;
    }
}
