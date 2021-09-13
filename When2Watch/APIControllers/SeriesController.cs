using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace When2Watch.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: api/<SeriesController>
        [HttpGet("get-all")]
        public async Task<ActionResult<List<SeriesDTO>>> GetAllSeriesAsync()
        {
            var result = await _seriesService.GetAllAsync();
            return Ok(result);
        }

        // GET: api/<SeriesController>
        [HttpGet("find/{keyword}")]
        public async Task<ActionResult<List<SeriesDTO>>> FindSeriesAsync(string keyword)
        {
            var result = await _seriesService.FindSeriesAsync(keyword);
            return Ok(result);
        }

        // GET api/<SeriesController>/5
        [HttpGet("get-id/{id}")]
        public async Task<ActionResult<SeriesDTO>> GetSeriesByIdAsync(int id)
        {
            var result = await _seriesService.GetSeriesAsync(id);
            return Ok(result);
        }

        // POST api/<SeriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeriesAsync(int id)
        {
            await _seriesService.DeleteSeriesAsync(id);
            return Ok();
        }
    }
}
