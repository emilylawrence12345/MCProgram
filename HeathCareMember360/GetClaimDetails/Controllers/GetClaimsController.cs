using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;


using HeathCareMemberCoreProj;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;



namespace GetClaimDetails.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class GetClaimsController : ControllerBase

    {

        private readonly IClaimsService _claimsService;

        public GetClaimsController(IClaimsService claimsService)

        {

            _claimsService = claimsService;

        }

        [HttpGet]

        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID) => await _claimsService.GetClaimsDetailsByMemberID(memberID);
        

    }

}