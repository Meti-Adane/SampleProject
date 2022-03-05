
using System.ComponentModel.DataAnnotations;

namespace sitesampleproject.Models{

    public class Role{
        // Table with 2 columns roles id and and id for privilaged access 
        public Guid Id {get; init;}

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string RoleName {set; get;}
        [Required]
        public Guid Accesses {set; get;}


    }
}