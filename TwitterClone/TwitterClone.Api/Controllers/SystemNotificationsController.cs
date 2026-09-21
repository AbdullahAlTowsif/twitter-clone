using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemNotificationsController : ControllerBase
    {
        // temporary in-memory storage
        private static readonly List<SystemNotification> _systemNotifications = new();

        // GET api/systemnotifications
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_systemNotifications);
        }

        // GET api/systemnotifications/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var systemNotification = _systemNotifications.FirstOrDefault(x => x.Id == id);
            if (systemNotification == null)
            {
                return NotFound();
            }

            return Ok(systemNotification);
        }

        // POST api/systemnotifications
        [HttpPost]
        public IActionResult Create(SystemNotification systemNotification)
        {
            _systemNotifications.Add(systemNotification);
            return CreatedAtAction(nameof(GetById), new { id = systemNotification.Id }, systemNotification);
        }

        // PUT api/systemnotifications/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, SystemNotification updated)
        {
            var systemNotification = _systemNotifications.FirstOrDefault(x => x.Id == id);
            if (systemNotification == null)
            {
                return NotFound();
            }

            systemNotification.UserId = updated.UserId;
            systemNotification.IsRead = updated.IsRead;
            return Ok(systemNotification);
        }

        // DELETE api/systemnotifications/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var systemNotification = _systemNotifications.FirstOrDefault(x => x.Id == id);
            if (systemNotification == null)
            {
                return NotFound();
            }

            _systemNotifications.Remove(systemNotification);
            return NoContent();
        }
    }
}
