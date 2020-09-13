
using HeathCareMemberCoreProj.DBContext;
using HeathCareMemberCoreProj.Implementation.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeathCareMemberCoreProj

{

    public class MemberRepository : IMemberRepository

    {

        private readonly HM360DBContext _dBContext;

        public MemberRepository(HM360DBContext dBContext)

        {

            _dBContext = dBContext;

        }

        
        public async Task<Member> GetMemberByID(int memberID)

        {

            try

            {
                
                return await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == memberID).FirstOrDefaultAsync();

            }

            catch (Exception ex)

            {

                throw ex;
                //NLogger.Error(ex.Message);

            }

        }



        public async Task<int> SaveMember(Member member)

        {

            try

            {

                var result = await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == member.MemberID).FirstOrDefaultAsync();

                if (result == null)

                {

                    var minresult = await _dBContext.Physician.AsNoTracking().MinAsync(x => x.PhysicianId);

                    var maxresult = await _dBContext.Physician.AsNoTracking().MaxAsync(x => x.PhysicianId);



                    Random random = new Random();

                    int randomPhysicianId = random.Next(maxresult);

                    member.PhysicianId = randomPhysicianId;



                    _dBContext.Member.Add(member);
                    string success = "added successfully";
                    //NLogger.loginfo("member added successfully");
                    var message = string.Format("response:{0}", success);
                    NLogger.Error(message);

                    await _dBContext.SaveChangesAsync();

                }

                else

                {

                    _dBContext.Member.UpdateRange(member);

                    await _dBContext.SaveChangesAsync();

                }

                

            }

            catch (Exception ex)

            {

                //throw ex;
                NLogger.Error(ex.Message);
            }
            return member.MemberID;
        }



        public async Task<int> UpdateMember(Member member)

        {

            try

            {

                var UpdateResult = await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == member.MemberID).FirstOrDefaultAsync();

                if (UpdateResult == null)

                {

                    var minresult = await _dBContext.Physician.AsNoTracking().MinAsync(x => x.PhysicianId);

                    var maxresult = await _dBContext.Physician.AsNoTracking().MaxAsync(x => x.PhysicianId);



                    Random random = new Random();

                    int randomPhysicianId = random.Next(maxresult);

                    member.PhysicianId = randomPhysicianId;



                    _dBContext.Member.Add(member);

                    await _dBContext.SaveChangesAsync();

                }

                else

                {

                    _dBContext.Member.UpdateRange(member);

                    await _dBContext.SaveChangesAsync();

                }

                return member.MemberID;

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        
                                     

        public async Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID)

        {

            try

            {

                MemberPhysician memberPhysician = await (from member in _dBContext.Member.AsNoTracking()

                                                         join physician in _dBContext.Physician on member.PhysicianId equals physician.PhysicianId

                                                         where member.MemberID == memberID

                                                         select new MemberPhysician

                                                         {

                                                             MemberId = member.MemberID,

                                                             FirstName = member.FirstName,

                                                             LastName = member.LastName,

                                                             PhysicianName = physician.PhysicianName

                                                         }).FirstOrDefaultAsync();
                //var result = memberPhysician;
                return memberPhysician;




            }

            catch (Exception ex)

            {
                //NLogger.Error(ex.Message);
                throw ex;

            }

        }

    }

}