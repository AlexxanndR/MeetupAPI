using MeetupAPI.Data;
using MeetupAPI.Interfaces;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupsController : ControllerBase
    {
        private readonly IEfRepository<Meetup> meetupRepository;

        public MeetupsController(IEfRepository<Meetup> meetupRepository)
        {
            this.meetupRepository = meetupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetups()
        {
            return Ok(await meetupRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetMeetupById([FromRoute] long id)
        {
            var meetup = await meetupRepository.GetByIdAsync(id);

            return meetup != null ? Ok(meetup) : NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> AddMeetup([FromBody] Meetup meetup)
        {
            var id = await meetupRepository.AddAsync(meetup);

            return Ok();
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateMeetup([FromRoute] long id, [FromBody] Meetup meetup)
        {
            var result = await meetupRepository.UpdateAsync(id, meetup);

            return result != false ? Ok() : NotFound();
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateMeetup([FromRoute] long id)
        {
            var result = await meetupRepository.DeleteAsync(id);

            return result != false ? Ok() : NotFound();
        }
    }
}
