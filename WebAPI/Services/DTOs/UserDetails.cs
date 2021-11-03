using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Services.DTOs
{
    /// <summary>
    /// DTO for User table details</para>
    /// </summary>
    public class UserDetails
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "Surname can't be longer than 20 characters")]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "User Type Id is required")]
        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        [Required(ErrorMessage = "User Title Id is required")]
        public int UserTitleId { get; set; }
        public string UserTitle { get; set; }

        [StringLength(50, ErrorMessage = "Email address can't be longer than 50 characters")]
        public string EmailAddress { get; set; }
        public bool isActive { get; set; }
    }
}
