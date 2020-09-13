 using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using HeathCareMemberCoreProj;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

 

namespace GetMemberDetails.Controllers

    {

        [Route("api/[controller]")]

        [ApiController]

        public class GetMemberDetails : ControllerBase
        {

            private readonly IMemberService _memberService;

            public GetMemberDetails(IMemberService memberService)

            {

                _memberService = memberService;

            }

            [HttpGet("{memberID}")]

            public async Task<Member> GetMemberByID(int memberID) => await _memberService.GetMemberByID(memberID);

        }

    }