using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Services.DTOs
{
    /// <summary>
    /// DTO for User table details</para>
    /// </summary>
    public class UserDetailsDTO
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public string Name { get; set; }

        /// <summary>Gets or sets the surname.</summary>
        /// <value>The surname.</value>
        [StringLength(20, ErrorMessage = "Surname can't be longer than 20 characters")]
        public string Surname { get; set; }

        /// <summary>Gets or sets the birth date.</summary>
        /// <value>The birth date.</value>
        public DateTime? BirthDate { get; set; }

        /// <summary>Gets or sets the user type identifier.</summary>
        /// <value>The user type identifier.</value>
        [Required(ErrorMessage = "User Type Id is required")]
        public int UserTypeId { get; set; }

        /// <summary>Gets or sets the type of the user.</summary>
        /// <value>The type of the user.</value>
        public string UserType { get; set; }

        /// <summary>Gets or sets the user title identifier.</summary>
        /// <value>The user title identifier.</value>
        [Required(ErrorMessage = "User Title Id is required")]
        public int UserTitleId { get; set; }

        /// <summary>Gets or sets the user title.</summary>
        /// <value>The user title.</value>
        public string UserTitle { get; set; }

        /// <summary>Gets or sets the email address.</summary>
        /// <value>The email address.</value>
        [StringLength(50, ErrorMessage = "Email address can't be longer than 50 characters")]
        public string EmailAddress { get; set; }

        /// <summary>Gets or sets a value indicating whether a user is active.</summary>
        /// <value>
        ///   <c>true</c> if the user is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
