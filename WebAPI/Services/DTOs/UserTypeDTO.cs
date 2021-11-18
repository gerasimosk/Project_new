using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.DTOs
{
    /// <summary>
    /// DTO for UserType table
    /// </summary>
    public class UserTypeDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public char Code { get; set; }
    }
}
