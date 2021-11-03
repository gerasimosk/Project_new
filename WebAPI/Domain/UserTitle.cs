using System.Collections.Generic;

namespace WebAPI.Domain
{
    /// <summary>
    ///   <para>DTO for UserTitle table</para>
    /// </summary>
    public class UserTitle
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<User> User { get; set; }
    }
}
