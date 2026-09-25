using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeNotificationsController : ControllerBase
    {
        // temporary in-memory storage
        private static readonly List<LikeNotification> _likeNotifications = new();

        // GET api/likenotifications
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_likeNotifications);
        }

        // GET api/likenotifications/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var likeNotification = _likeNotifications.FirstOrDefault(x => x.Id == id);
            if (likeNotification == null)
            {
                return NotFound();
            }

            return Ok(likeNotification);
        }

        // POST api/likenotifications
        [HttpPost]
        public IActionResult Create(LikeNotification likeNotification)
        {
            _likeNotifications.Add(likeNotification);
            return CreatedAtAction(nameof(GetById), new { id = likeNotification.Id }, likeNotification);
        }

        // PUT api/likenotifications/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, LikeNotification updated)
        {
            var likeNotification = _likeNotifications.FirstOrDefault(x => x.Id == id);
            if (likeNotification == null)
            {
                return NotFound();
            }

            likeNotification.UserId = updated.UserId;
            likeNotification.IsRead = updated.IsRead;
            likeNotification.LikeByUserId = updated.LikeByUserId;
            return Ok(likeNotification);
        }

        // DELETE api/likenotifications/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var likeNotification = _likeNotifications.FirstOrDefault(x => x.Id == id);
            if (likeNotification == null)
            {
                return NotFound();
            }

            _likeNotifications.Remove(likeNotification);
            return NoContent();
        }
    }
}