namespace ApiFilm.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } // Текст сообщения
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; } // ID пользователя
        public virtual User User { get; set; } // Связь с пользователем
        public int? MovieId { get; set; } // ID фильма (может быть null)
        public virtual Movie Movie { get; set; } // Связь с фильмом
        public ICollection<MessagePhoto> Photos { get; set; } // Фотографии в сообщении
    }

    // Models/MessagePhoto.cs
    public class MessagePhoto
    {
        public int Id { get; set; }
        public string FilePath { get; set; } // Путь к файлу
        public int MessageId { get; set; } // ID сообщения
        public virtual Message Message { get; set; } // Связь с сообщением
    }
}
