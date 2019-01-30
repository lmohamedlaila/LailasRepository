using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BusinessLogic;

namespace SportsMatchesService.Controllers
{
    public class SportsMatchController : ApiController
    {
        MatchService _matchService;
        public SportsMatchController()
        {
            _matchService = new MatchService();
        }
        [HttpGet]
        public List<MatchModel> GetAll()
        {
            try
            {
                return _matchService.GetAll();
            }
            catch (Exception ex) //log the excptions in file later 
            {
                throw;
            }
        }
    }
}
