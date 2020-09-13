using System;
using System.Collections.Generic;
using HeathCareMemberCoreProj.Implementation.Repository;
using System.Text;
using System.Threading.Tasks;

namespace HeathCareMemberCoreProj
{
    public class MemberService : IMemberService
    {

        private readonly IMemberRepository _memberRepository;



        public MemberService(IMemberRepository memberRepository)

        {

            _memberRepository = memberRepository;

        }

       



        public async Task<Member> GetMemberByID(int memberID)

        {

            return await _memberRepository.GetMemberByID(memberID);

        }



        public async Task<int> SaveMember(Member member)

        {

            return await _memberRepository.SaveMember(member);

        }



        public async Task<int> UpdateMember(Member member)

        {

            return await _memberRepository.UpdateMember(member);

        }
      

        public Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID)

        {

            return _memberRepository.GetMemberPhysicianByMemberID(memberID);

        }

    }

}