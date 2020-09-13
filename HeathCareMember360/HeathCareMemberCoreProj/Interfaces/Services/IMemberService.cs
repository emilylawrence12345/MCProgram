using System.Collections.Generic;

using System.Threading.Tasks;



namespace HeathCareMemberCoreProj

{

    public interface IMemberService

    {
        
        Task<Member> GetMemberByID(int memberID);

        Task<int> SaveMember(Member member);

        Task<int> UpdateMember(Member member);

        Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID);

    }

}