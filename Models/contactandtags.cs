using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class contactandtags
    {
        public List<userCTag> t,uclunassign;
        public List<Contact> c;
        public MyModel m1;
 
        public tag t1;
        public List<ftag> ft;
        public List<contact1> contactnewdb;
        public contact1 contacta;
        public contact1 c1;
        public List<GmailContacts> gmailcontact;
        public List<fTagDetail1> ftdetail;
        public Contact c11;
        public List<ftagdetail> ftd;
        public List<char> alpha;
        public List<userFTag> tagsplits;
        public List<userFTag> unassigned;

        public contactandtags(List<userCTag> a, List<userFTag> f, List<Contact> b)
        {
            t = a;
            c = b;
            ft1new = f;


        }
       
      
        public List<userFTag> ft1new;
        public contactandtags(List<userCTag> a, List<userFTag> f, List<contact1> b, List<char> alph)
        {
            t = a;
            this.contactnewdb = b;
            ft1new = f;
            alpha = alph;


        }


        public contactandtags(List<userCTag> a, List<userFTag> f, List<Contact> b, List<fTagDetail1> ftd)
        {
            t = a;
            c = b;
            ft1new = f;
            ftdetail = ftd;


        }

        public contactandtags(List<userCTag> a, List<userFTag> f, List<Contact> b, contact1 c2)
        {
            t = a;
            c = b;
            c1 = c2;
            ft1new = f;
        }

        public contactandtags(List<userCTag> a, List<userFTag> f, contact1 b)
        {
            t = a;
            c1 = b;
            ft1new = f;

        }
        public contactandtags(List<userCTag> a, List<userFTag> f, contact1 b,List<mobileNo> mns)
        {
            t = a;
            c1 = b;
            ft1new = f;
            mobilenumlist = mns;

        }

        public contactandtags(List<userCTag> a, List<userFTag> f, List<GmailContacts> b)
        {
            t = a;
            gmailcontact = b;
            ft1new = f;

        }

       
        public contactandtags(contact1 c11, List<fTagDetail1> ftd)
        {
  
            contacta = c11;
            c1 = c11;
            ftdetail = ftd;
           
        }
        public contactandtags(contact1 c11, List<fTagDetail1> ftd, List<userCTag> lc, List<userCTag> unassigned)
        {

            contacta = c11;
            c1 = c11;
            ftdetail = ftd;
            t = lc;
            uclunassign = unassigned;

        }
        public List<mobileNo> mobilenumlist;
        public contactandtags(contact1 c11, List<fTagDetail1> ftd, List<userCTag> lc, List<userCTag> unassigned,List<mobileNo> mns)
        {

            mobilenumlist = mns;
            contacta = c11;
            c1 = c11;
            ftdetail = ftd;
            t = lc;
            uclunassign = unassigned;


        }
        public contactandtags(List<userFTag> tagsplits, List<userFTag> unassigned)
        {
            // TODO: Complete member initialization
            this.tagsplits = tagsplits;
            this.unassigned = unassigned;
        }

        public contactandtags()
        {
            // TODO: Complete member initialization
        }
       

        
    }
}