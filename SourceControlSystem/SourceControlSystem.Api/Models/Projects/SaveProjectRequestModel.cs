using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlSystem.Api.Models.Projects
{
    public class SaveProjectRequestModel
    {
        [Required]
        public  string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }
    }
}