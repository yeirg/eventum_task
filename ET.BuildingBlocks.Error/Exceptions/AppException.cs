using System.Text;

namespace ET.BuildingBlocks.Error.Exceptions;

public class AppException : Exception, IEquatable<AppException>
    {
        /// <summary>
        /// Уникальный код для этого типа исключения.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Возвращает сообщение по текущей ошибке, включая таги.
        /// </summary>
        public override string Message
        {
            get
            {
                var messageBuilder = new StringBuilder(base.Message);

                foreach (var tag in Tags)
                {
                    messageBuilder.AppendLine($"\n{tag.Key}-{tag.Value}");
                }

                return messageBuilder.ToString();
            }
        }

        /// <summary>
        /// Дополнительные признаки исключения.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AppException"/> с указанным кодом и сообщением об ошибке.
        /// </summary>
        public AppException(string code, string message) : base(message)
        {
            Code = code;
        }

        /// <summary>
        /// Сравнивает текущий экземпляр с другим экземпляром <see cref="AppException"/> на равенство.
        /// </summary>
        public bool Equals(AppException other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code;
        }

        /// <summary>
        /// Добавляет тег к текущему исключению.
        /// </summary>
        public AppException SetTag(string key, string value)
        {
            Tags.TryAdd(key, value);

            return this;
        }

        /// <summary>
        /// Определяет, равен ли текущий объект другому объекту.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (GetType() == obj.GetType() ||
                GetType().IsSubclassOf(obj.GetType()) ||
                obj.GetType().IsSubclassOf(GetType()))
            {
                return Equals((AppException)obj);
            }

            return false;
        }

        /// <summary>
        /// Возвращает хеш-код для этого экземпляра.
        /// </summary>
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }