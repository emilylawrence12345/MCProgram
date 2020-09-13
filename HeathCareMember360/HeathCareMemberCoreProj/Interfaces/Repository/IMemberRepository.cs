
using System.Collections.Generic;

using System.Threading.Tasks;

 

namespace HeathCareMemberCoreProj.Implementation.Repository

{

    public interface IMemberRepository

    {
       
       Task<Member> GetMemberByID(int memberID);

        Task<int> SaveMember(Member member);

        Task<int> UpdateMember(Member member);
      

        Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID);

    }

}
