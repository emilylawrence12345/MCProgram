using System.Threading.Tasks;
using HeathCareMemberCoreProj;
using Microsoft.AspNetCore.Mvc;

namespace AddMember.Controllers

{
    [Route("api/[controller]")]

    [ApiController]

    public class AddMemberController : ControllerBase

    {

        private readonly IMemberService _memberService;



        public AddMemberController(IMemberService memberService)

        {

            _memberService = memberService;

        }

        [HttpPost]

        public async Task<int> AddMember(Member member) => await _memberService.SaveMember(member);


    }

}