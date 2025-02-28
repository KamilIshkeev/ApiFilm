using ApiFilm.DataBaseContext;
using ApiFilm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFilm.Controllers
{
    // Controllers/ChatController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public ChatController(MovieDbContext context)
        {
            _context = context;
        }

        // Получение всех сообщений для фильма
        [HttpGet("movie/{movieId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByMovie(int movieId)
        {
            var messages = await _context.Messages
                .Include(m => m.User)
                .Include(m => m.Movie)
                .Include(m => m.Photos)
                .Where(m => m.MovieId == movieId)
                .ToListAsync();
            return Ok(messages);
        }

        // Отправка нового сообщения
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage([FromBody] Message message)
        {
            if (message == null) return BadRequest();

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMessagesByMovie), new { id = message.Id }, message);
        }

        // Загрузка фотографий
        [HttpPost("upload-photo")]
        [ApiExplorerSettings(IgnoreApi = true)] // Исключаем из Swagger
        public async Task<ActionResult<MessagePhoto>> UploadPhoto([FromForm] IFormFile file, [FromForm] int messageId)
        {
            if (file == null || file.Length == 0) return BadRequest();

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new MessagePhoto
            {
                FilePath = $"uploads/{file.FileName}",
                MessageId = messageId
            };

            _context.MessagePhotos.Add(photo);
            await _context.SaveChangesAsync();

            return Ok(photo);
        }
    }
}
