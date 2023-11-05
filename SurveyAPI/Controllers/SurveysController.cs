using Microsoft.AspNetCore.Mvc;
using SurveyAPI.Models;
using SurveyAPI.Services;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            this.surveyService=surveyService;
        }

        // GET: api/<SurveysController>
        [HttpGet]
        public ActionResult<List<Survey>> Get()
        {
            return surveyService.Get();
        }

        // POST api/<SurveysController>
        [HttpPost]
        public ActionResult<Survey> Post([FromBody] Survey survey)
        {
            surveyService.Create(survey);
            return survey;
        }

        // PUT api/<SurveysController>/5
        [HttpPut]
        public void Put([FromBody] Survey survey)
        {
            surveyService.Update(survey);
        }

        // DELETE api/<SurveysController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //GET api/<SurveysController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
