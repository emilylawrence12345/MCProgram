using Microsoft.EntityFrameworkCore;

namespace HeathCareMemberCoreProj.DBContext
{
    public class HM360DBContext : DbContext

    {
        public HM360DBContext(DbContextOptions<HM360DBContext> options) : base(options)

        {

        }

        public virtual DbSet<Claims> Claims { get; set; }

        public virtual DbSet<Member> Member { get; set; }

        public virtual DbSet<Physician> Physician { get; set; }

        public virtual DbSet<ClaimTypes> ClaimTypes { get; set; }

    }

}
