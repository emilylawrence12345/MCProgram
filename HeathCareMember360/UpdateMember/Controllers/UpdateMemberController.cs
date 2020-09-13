using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;
using HeathCareMemberCoreProj;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;



namespace UpdateMember.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class UpdateMemberController : ControllerBase

    {

        private readonly IMemberService _memberService;

        public UpdateMemberController(IMemberService memberService)

        {

            _memberService = memberService;

        }

        [HttpPut]

        public async Task<int> UpdateMember(Member member) => await _memberService.UpdateMember(member);

    }

}