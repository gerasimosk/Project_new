using System.Collections.Generic;

namespace WebAPI.Domain
{
    /// <summary>
    /// Entity for UserTitle table
    /// </summary>
    public class UserTitle
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<User> User { get; set; }
    }
}
