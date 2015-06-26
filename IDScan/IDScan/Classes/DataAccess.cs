using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDScan.Data.DAL;

namespace IDScan.Classes
{
    class DataAccess
    {

        MembershipEntities db = new MembershipEntities();

        public void insertMembership()
        {

            membership newMember = new membership();
            //pk
            //newMember.membershipid = SessionData.membershipid;
            newMember.clubid = 1; // SessionData.clubid;
            newMember.scanid = SessionData.scanid;
            newMember.palmscanid = SessionData.palmscanid;
            newMember.first = SessionData.first;
            newMember.middle = SessionData.middle;
            newMember.last = SessionData.last;
            newMember.dob = SessionData.dob;
            newMember.gender = SessionData.gender;
            newMember.countrycode = SessionData.countrycode;
            newMember.address1 = SessionData.address1;
            newMember.address2 = SessionData.address2;
            newMember.city = SessionData.city;
            newMember.stateprov = SessionData.stateprov;
            newMember.zip = SessionData.zip;
            newMember.imagepath = SessionData.imagepath;
            newMember.applicationdate = SessionData.applicationdate;
            newMember.approvaldate = SessionData.approvaldate;
            newMember.statusid = SessionData.statusid;
            newMember.expirationdate = SessionData.expirationdate;
            newMember.issuedate = SessionData.issuedate;
            newMember.email = SessionData.email;
            newMember.documentid = SessionData.documentid;
            newMember.documenttype = SessionData.documenttype;
            newMember.bio_palm_id = SessionData.bio_palm_id;
            newMember.createddate = System.DateTime.Now;

            // Number of years should be configurable
            newMember.renewdate = System.DateTime.Now.AddYears(2);

            try
            {

                db.memberships.Add(newMember);

                db.SaveChanges();

            }
            catch(Exception err)
            {
                throw err;
            }

        }


        public void updateMembership()
        {
            membership updateMember = new membership();
            
            //updateMember.membershipid = SessionData.membershipid;
            updateMember.clubid = SessionData.clubid;
            updateMember.scanid = SessionData.scanid;
            updateMember.palmscanid = SessionData.palmscanid;
            updateMember.first = SessionData.first;
            updateMember.middle = SessionData.middle;
            updateMember.last = SessionData.last;
            updateMember.dob = SessionData.dob;
            updateMember.gender = SessionData.gender;
            updateMember.countrycode = SessionData.countrycode;
            updateMember.address1 = SessionData.address1;
            updateMember.address2 = SessionData.address2;
            updateMember.city = SessionData.city;
            updateMember.stateprov = SessionData.stateprov;
            updateMember.zip = SessionData.zip;
            updateMember.imagepath = SessionData.imagepath;
            updateMember.applicationdate = SessionData.applicationdate;
            updateMember.approvaldate = SessionData.approvaldate;
            updateMember.statusid = SessionData.statusid;
            updateMember.expirationdate = SessionData.expirationdate;
            updateMember.issuedate = SessionData.issuedate;
            updateMember.email = SessionData.email;
            updateMember.documentid = SessionData.documentid;
            updateMember.documenttype = SessionData.documenttype;
            updateMember.bio_palm_id = SessionData.bio_palm_id;


            try
            {
                var member  = db.memberships
                    .Where(m => m.membershipid == updateMember.membershipid)
                    .SingleOrDefault();

                if (updateMember != null &&  member != null)
                {
                    member = updateMember;

                    db.SaveChanges();
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }







    }
}


