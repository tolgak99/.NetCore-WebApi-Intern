using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramControllerReel.Models
{
    public class Programs
    {
        public int  Id { get; set; }

        public string ProgramName { get; set; }

        public string ProjectOwner { get; set; }

        public string ProjectManager { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string ProjectDetails { get; set; }
    }
}
