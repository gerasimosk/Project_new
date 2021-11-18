using System.Collections.Generic;

namespace WebAPI.Domain
{
    /// <summary>
    /// Entity for UserType table
    /// </summary>
    public class UserType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public char Code { get; set; }

        public ICollection<User> User { get; set; }
    }
}
