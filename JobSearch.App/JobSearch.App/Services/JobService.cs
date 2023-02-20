using JobSearch.App.Models;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppJobSearch.API.Services
{
    public class JobService : Service
    {
        public async Task<ResponseService<List<Job>>> GetJobs(string word, string cityState, int numberOfPage = 1)
        {
            HttpResponseMessage response = await _client.GetAsync($"{baseAPIUrl}/api/Jobs?word={word}&cityState={cityState}&numberOfPage={numberOfPage}");

            ResponseService<List<Job>> responseService = new ResponseService<List<Job>>();
            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;


            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<List<Job>>();
            }
            else
            {
                string problemResponse = await response.Content.ReadAsStringAsync();
                var erros = JsonConvert.DeserializeObject<ResponseService<List<Job>>>(problemResponse);
                responseService.Errors = erros.Errors;
            }
            return responseService;
        }

        public async Task<ResponseService<Job>> GetJob(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{baseAPIUrl}/api/Jobs/{id}");

            ResponseService<Job> responseService = new ResponseService<Job>();
            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;


            if (response.IsSuccessStatusCode)
            {

                responseService.Data = await response.Content.ReadAsAsync<Job>();
            }
            else
            {
                string problemResponse = await response.Content.ReadAsStringAsync();
                var erros = JsonConvert.DeserializeObject<ResponseService<Job>>(problemResponse);
                responseService.Errors = erros.Errors;
            }
            return responseService;


        }

        public async Task<ResponseService<Job>> AddJob(Job job)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"{baseAPIUrl}/api/Jobs", job);

            ResponseService<Job> responseService = new ResponseService<Job>();
            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;


            if (response.IsSuccessStatusCode)
            {

                responseService.Data = await response.Content.ReadAsAsync<Job>();
            }
            else
            {
                string problemResponse = await response.Content.ReadAsStringAsync();
                var erros = JsonConvert.DeserializeObject<ResponseService<Job>>(problemResponse);

                responseService.Errors = erros.Errors;
            }
            return responseService;

        }
    }
}
