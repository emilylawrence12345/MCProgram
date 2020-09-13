using HeathCareMemberCoreProj.DBContext;
using Microsoft.EntityFrameworkCore;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Security.Claims;

using System.Text;

using System.Threading.Tasks;



namespace HeathCareMemberCoreProj

{

    public class ClaimsRepository : IClaimsRepository

    {

        private readonly HM360DBContext _dBContext;
        private List<ClaimDetails> claimDetails;

        public ClaimsRepository(HM360DBContext dBContext)

        {

            _dBContext = dBContext;

        }
        
        public async Task<int> SaveClaims(ClaimDetails claimDetail)

        {

            try

            {

                ClaimTypes claimType = await _dBContext.ClaimTypes.AsNoTracking().Where(c => c.ClaimType == claimDetail.ClaimType).FirstOrDefaultAsync();

                Member member = await _dBContext.Member.AsNoTracking().Where(m => m.FirstName + " " + m.LastName == claimDetail.MemberName).FirstOrDefaultAsync();



                var claim = await _dBContext.Claims.AsNoTracking().Where(c => c.ClaimID == claimDetail.ClaimID).FirstOrDefaultAsync();

                if (claim == null)

                {

                    Claims claims = new Claims()

                    {

                        ClaimID = 0,

                        ClaimType = claimType.ClaimTypeID,

                        ClaimAmount = claimDetail.ClaimAmount,

                        ClaimDate = claimDetail.ClaimDate,

                        Remarks = claimDetail.Remarks,

                        MemberID = member.MemberID

                    };

                    _dBContext.Claims.Add(claims);

                    await _dBContext.SaveChangesAsync();

                }

                else

                {

                    claim = new Claims()

                    {

                        ClaimType = claimType.ClaimTypeID,

                        ClaimAmount = claimDetail.ClaimAmount,

                        ClaimDate = claimDetail.ClaimDate,

                        Remarks = claimDetail.Remarks,

                        MemberID = member.MemberID

                    };

                    _dBContext.Claims.UpdateRange(claim);

                    await _dBContext.SaveChangesAsync();

                }

                return claimDetail.ClaimID;

            }

            catch (Exception ex)

            {

                throw ex;   

            }

        }



       
        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID)

        {

            try

            {

                List<ClaimDetails> claimDetails = await (from claim in _dBContext.Claims.AsNoTracking()

                                                         join claimType in _dBContext.ClaimTypes.AsNoTracking() on claim.ClaimType equals claimType.ClaimTypeID

                                                         join member in _dBContext.Member.AsNoTracking() on claim.MemberID equals member.MemberID

                                                         where member.MemberID == memberID

                                                         select new ClaimDetails

                                                         {

                                                             ClaimID = claim.ClaimID,

                                                             ClaimAmount = claim.ClaimAmount,

                                                             ClaimDate = claim.ClaimDate,

                                                             ClaimType = claimType.ClaimType,

                                                             Remarks = claim.Remarks,

                                                             MemberName = member.FirstName + " " + member.LastName

                                                         }

                                            ).ToListAsync();                
                                
            }

            catch (Exception ex)

            {

                //throw ex;
                NLogger.Error(ex.Message);
            }
            return claimDetails;

        }

    }

}



