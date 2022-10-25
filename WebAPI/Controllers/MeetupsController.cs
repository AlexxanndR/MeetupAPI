using MeetupAPI.Interfaces;
using MeetupAPI.Models;
using MeetupAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeetupAPI.Profiles;
using AutoMapper;

namespace MeetupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MeetupsController : ControllerBase
    {
        private readonly IEfRepository<Meetup> meetupRepository;
        private readonly IMapper mapper;

        public MeetupsController(IEfRepository<Meetup> meetupRepository, IMapper mapper)
        {
            this.meetupRepository = meetupRepository;
            this.mapper = mapper;
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
        public async Task<IActionResult> AddMeetup(MeetupModel meetupModel)
        {
            var meetup = mapper.Map<Meetup>(meetupModel);

            await meetupRepository.AddAsync(meetup);

            return Ok();
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateMeetup([FromRoute] long id, MeetupModel meetupModel)
        {
            var meetup = mapper.Map<Meetup>(meetupModel);

            var result = await meetupRepository.UpdateAsync(id, meetup);

            return result != false ? Ok() : NotFound();
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteMeetup([FromRoute] long id)
        {
            var result = await meetupRepository.DeleteAsync(id);

            return result != false ? Ok() : NotFound();
        }
    }
}
