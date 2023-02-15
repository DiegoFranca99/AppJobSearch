﻿using JobSearch.App.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppJobSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private JobSearchContext _data;
        public JobsController(JobSearchContext data)
        {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<Job> GetJobs(string word, string cityState)
        {

            //ADD PAGINAÇÃO (INFINITYSCROLL)

            //LIMITAR PESQUISA POR PERIODO

            return _data.Jobs.Where(a =>
                a.CityStare.ToLower().Contains(cityState.ToLower()) &&
                (
                    a.JobTitle.ToLower().Contains(word.ToLower()) ||
                    a.TecnologyTools.ToLower().Contains(word.ToLower()) ||
                    a.Company.ToLower().Contains(word.ToLower())
                )
            ).ToList<Job>();
        }

        [HttpGet]
        public IActionResult GetJob(int id)
        {
            Job jobDb = _data.Jobs.Find(id);

            if(jobDb == null)
            {
                return NotFound();
            }
            return new JsonResult(jobDb);
        }


        //[HttpPost]
        public IActionResult AddJob(Job job)
        {

            //VALIDAÇÃO
            job.PublicationDate = DateTime.Now;
            _data.Jobs.Add(job);
            _data.SaveChanges();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }
    }
}