using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.DTOs
{
    /// <summary>
    ///   <para>DTO for UserType table</para>
    /// </summary>
    public class UserTypeDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public char Code { get; set; }
    }
}
