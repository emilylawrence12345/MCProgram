using System.Threading.Tasks;
using HeathCareMemberCoreProj;
using Microsoft.AspNetCore.Mvc;



namespace GetMemberPhysician.Controllers

{

    [Route("api/[controller]")]

        [ApiController]

        public class GetMemberPhysicianController : ControllerBase

        {

            private readonly IMemberService _memberService;

            public GetMemberPhysicianController(IMemberService memberService)

            {

                _memberService = memberService;

            }

            [HttpGet]

            public async Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID) => await _memberService.GetMemberPhysicianByMemberID(memberID);

        }

    }