using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeathCareMemberCoreProj

{

    public class ClaimsService : IClaimsService
    {
        private readonly IClaimsRepository _claimsRepository;
        public ClaimsService(IClaimsRepository claimsRepository)
                
        {

            _claimsRepository = claimsRepository;

        }
        public async Task<int> SaveClaims(ClaimDetails claimDetail)

        {

            return await _claimsRepository.SaveClaims(claimDetail);

        }
       

        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID)

        {

            return await _claimsRepository.GetClaimsDetailsByMemberID(memberID);

        }

    }

}