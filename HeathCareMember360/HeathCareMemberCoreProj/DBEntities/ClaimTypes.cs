
using System.ComponentModel.DataAnnotations;


namespace HeathCareMemberCoreProj

{

    public class ClaimTypes

    {

        [Key]

        public int ClaimTypeID { get; set; }

        public string ClaimType { get; set; }

    }
}

