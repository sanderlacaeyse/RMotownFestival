using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RMotownFestival.DAL;
using RMotownFestival.DAL.Entities;

namespace RMotownFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly TelemetryClient telemetryClient;
        private readonly MotownDbContext ctx;

        public FestivalController(TelemetryClient telemetryClient, MotownDbContext ctx)
        {
            // AppInsights
            this.telemetryClient = telemetryClient;
            this.ctx = ctx;
        }

        [HttpGet("LineUp")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Schedule))]
        public async Task<ActionResult> GetLineUp()
        {
            var schedule = await ctx.Schedules.Include(x => x.Festival)
                                              .Include(x => x.Items)
                                              .ThenInclude(x => x.Artist)
                                              .Include(x => x.Items)
                                              .ThenInclude(x => x.Stage)
                                              .FirstOrDefaultAsync();

            return Ok(schedule);
        }

        [HttpGet("Artists")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Artist>))]
        public async Task<ActionResult> GetArtists(bool? withRatings)
        {
            var artists = await ctx.Artists.ToListAsync();

            // AppInsights
            if (withRatings.HasValue && withRatings.Value)
                telemetryClient.TrackEvent($"List of artists with ratings");
            else
                telemetryClient.TrackEvent($"List of artists without ratings");
            return Ok(artists);
        }

        [HttpGet("Stages")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Stage>))]
        public async Task<ActionResult> GetStages()
        {
            var stages = await ctx.Stages.ToListAsync();
            return Ok(stages);
        }

        [HttpPost("Favorite")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ScheduleItem))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> SetAsFavorite(int id)
        {

            var schedule = await ctx.ScheduleItems.Where(x => x.Id == id).FirstOrDefaultAsync();


            if (schedule != null)
            {
                schedule.IsFavorite = !schedule.IsFavorite;
                return Ok(schedule);
            }
            return NotFound();
        }

    }
}