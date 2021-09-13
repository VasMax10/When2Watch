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
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        // GET: api/<EpisodeController>
        [HttpGet("get-by-series/{seriesId}")]
        public async Task<ActionResult<List<EpisodeDTO>>> GetEpisodesBySeasonAsync(int seasonId)
        {
            var result = await _episodeService.GetEpisodesBySeasonAsync(seasonId);
            return Ok(result);
        }

        // GET api/<EpisodeController>/5
        [HttpGet("get-id/{id}")]
        public async Task<ActionResult<EpisodeDTO>> GetEpisodeByIdAsync(int id)
        {
            var result = await _episodeService.GetEpisodeAsync(id);
            return Ok(result);
        }

        // POST api/<EpisodeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EpisodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EpisodeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEpisodeAsync(int id)
        {
            await _episodeService.DeleteEpisodeAsync(id);
            return Ok();
        }
    }
}
