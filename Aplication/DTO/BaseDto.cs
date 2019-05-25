using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO
{
    public abstract class BaseDto
    {
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
