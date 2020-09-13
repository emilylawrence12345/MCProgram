
using System.ComponentModel.DataAnnotations;

 

namespace HeathCareMemberCoreProj

{

    public class Physician

    {

        [Key]

        public int PhysicianId { get; set; }

        public string PhysicianName { get; set; }

        public string PhysicianState { get; set; }

    }

}