using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MentionNotificationsController : ControllerBase
    {
        // temporary in-memory storage
        private static readonly List<MentionNotification> _mentionNotifications = new();

        // GET api/mentionnotifications
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mentionNotifications);
        }

        // GET api/mentionnotifications/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var mentionNotification = _mentionNotifications.FirstOrDefault(x => x.Id == id);
            if (mentionNotification == null)
            {
                return NotFound();
            }

            return Ok(mentionNotification);
        }

        // POST api/mentionnotifications
        [HttpPost]
        public IActionResult Create(MentionNotification mentionNotification)
        {
            _mentionNotifications.Add(mentionNotification);
            return CreatedAtAction(nameof(GetById), new { id = mentionNotification.Id }, mentionNotification);
        }

        // PUT api/mentionnotifications/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, MentionNotification updated)
        {
            var mentionNotification = _mentionNotifications.FirstOrDefault(x => x.Id == id);
            if (mentionNotification == null)
            {
                return NotFound();
            }

            mentionNotification.UserId = updated.UserId;
            mentionNotification.IsRead = updated.IsRead;
            mentionNotification.MentionedByUserId = updated.MentionedByUserId;
            return Ok(mentionNotification);
        }

        // DELETE api/mentionnotifications/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var mentionNotification = _mentionNotifications.FirstOrDefault(x => x.Id == id);
            if (mentionNotification == null)
            {
                return NotFound();
            }

            _mentionNotifications.Remove(mentionNotification);
            return NoContent();
        }
    }
}
