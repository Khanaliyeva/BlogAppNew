using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public record CategoryDetailDto
    {
        public int Id { get; set; }
        public string Name;

    }
  
}
