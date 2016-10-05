using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using AutoMapper;
using Sis.Interview.Api.Models.ScrumCeremony;
using Sis.Interview.Dal.Framework;
using Sis.Interview.Models.ScrumCeremony; 

namespace Sis.Interview.Api.Controllers
{
    public class RetrospectivesController : ApiController
    {
        private readonly BaseService<Retrospective> _retrospectiveService;

        public RetrospectivesController(BaseService<Retrospective> retrospectiveService)
        {
            _retrospectiveService = retrospectiveService;
        }
         
        public IHttpActionResult Get(string date = null)
        { 
            return string.IsNullOrWhiteSpace(date) ? Ok(_retrospectiveService.Get()) : Ok(_retrospectiveService.Get(r => r.Date.Date == DateTime.ParseExact(date, "dd-MM-yyyy", null).Date));
        }

        [HttpPost]
        public IHttpActionResult Post(RetrospectiveCreate model)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelStateError(ModelState));  
            var newRetrospective = _retrospectiveService.Create(Map<Retrospective>(model));

            return Created(Request.RequestUri, newRetrospective);
        }

        public IHttpActionResult Put(string name, FeedbackCreate model)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelStateError(ModelState));

            var retrospective = _retrospectiveService.Get(name);
            if (retrospective == null)
                return NotFound();

            retrospective.Feedbacks.Add(Map<Feedback>(model));
            retrospective = _retrospectiveService.Save(retrospective);

            return Ok(retrospective);
        }

        #region private
        private static TTarget Map<TTarget>(object source)
        {
            var config = new MapperConfiguration(c => c.CreateMap(source.GetType(), typeof(TTarget)));
            var mapper = config.CreateMapper();
            return mapper.Map<TTarget>(source);
        }

        private static string ModelStateError(ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values.Where(v => v.Errors.Any()).SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).Distinct());
        }
        #endregion
    }
}