using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using HeathCareMemberCoreProj;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;



namespace SubmitClaim.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class SubmitClaimController : ControllerBase

    {

        private readonly IClaimsService _claimsService;

        public SubmitClaimController(IClaimsService claimsService)

        {

            _claimsService = claimsService;

        }

        [HttpPost]

        public async Task<int> SubmitClaim(ClaimDetails claimDetails) => await _claimsService.SaveClaims(claimDetails);

    }

}