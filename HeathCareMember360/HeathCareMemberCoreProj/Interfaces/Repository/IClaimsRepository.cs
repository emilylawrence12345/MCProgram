using System.Collections.Generic;
using System.Threading.Tasks;



namespace HeathCareMemberCoreProj

{

    public interface IClaimsRepository

    {
       
        Task<int> SaveClaims(ClaimDetails claimDetail);      
        Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID);

    }

}