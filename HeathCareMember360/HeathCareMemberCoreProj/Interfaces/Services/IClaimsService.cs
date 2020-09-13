using System.Collections.Generic;

using System.Threading.Tasks;



namespace HeathCareMemberCoreProj

{

    public interface IClaimsService

    {
        Task<int> SaveClaims(ClaimDetails claimDetail);       
        Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID);

    }

}