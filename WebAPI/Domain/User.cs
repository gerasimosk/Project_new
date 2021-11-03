using System;

namespace WebAPI.Domain
{
    /// <summary>
    /// DTO for User table</para>
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int UserTypeId { get; set; }
        public int UserTitleId { get; set; }
        public string EmailAddress { get; set; }
        public bool? IsActive { get; set; }

        public UserTitle UserTitle { get; set; }
        public UserType UserType { get; set; }
    }
}
