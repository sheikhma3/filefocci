using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Web.Mail;

using System.IO;

using MvcApplication2.Models;


namespace MvcApplication2.Controllers
{

  


    


    public class UserController : BaseController
    {
        //
        @base c = new @base();
        List<userCTag> lt1;
        List<ftag> ft1;
        List<userFTag> ft1new;
       
        contactandtags ct;
        List<char> alpha =new List<char>();
        List<Contact> cl;
        List<contact1> cln;
        contact1 c1;
        List<contact1> cl1 = new List<contact1>();
        List<fTagDetail1> ftd;
        // GET: /User/
        Database1Entities2 dbnew = new Database1Entities2();
        Database1Entities1 cx = new Database1Entities1();
        public ActionResult cloud()
        {
            var userid = Int32.Parse(Session["userId"].ToString());

            lt1 = c.getallctag(userid);
            ft1new = c.getallftag(userid);
            c1 = new contact1();
            ct = new contactandtags(lt1,ft1new, c1);
            return View(ct);
        }


    
        public ActionResult Contacts(string a , string u)
        {
            if(Session["username"] != null)
         
            { 
            if (a == null && u==null)
            {
                
               
                String usertag = Session["username"].ToString();
                
                var userid = Int32.Parse(Session["userId"].ToString());
                  cl1 = dbnew.contacts1.Where(x => x.uid==userid).ToList();
               // cl1 = db.contacts1.ToList();


                cl1 = cl1.OrderBy(x => x.firstName).ToList();
                for (int i = 0; i < cl1.Count; i++)
                {
                    cl1[i].firstName = char.ToUpper(cl1[i].firstName[0]) + cl1[i].firstName.Substring(1);
                }
                alpha=   c.getalphabetsnewdb(cl1);








                ft1new = c.getallftag(userid);

                lt1 = c.getallctag(userid);



                contactandtags ct = new contactandtags(lt1, ft1new, cl1, alpha);
                return View(ct);

            }
            else if(a !=null && u==null)
            {






                var userid = Int32.Parse(Session["userId"].ToString());
                ft1new = c.getallftag(userid);

                lt1 = c.getallctag(userid);
                
               
                cl1 = dbnew.contacts1.Where(x => x.uid == userid).ToList();
                // cl1 = db.contacts1.ToList();


                cl1 = cl1.OrderBy(x => x.firstName).ToList();
                for (int i = 0; i < cl1.Count; i++)
                {
                    cl1[i].firstName = char.ToUpper(cl1[i].firstName[0]) + cl1[i].firstName.Substring(1);
                }
                alpha = c.getalphabetsnewdb(cl1);

                ct = new contactandtags(lt1, ft1new, cl1, alpha);
                return View(ct);
            }
            else if(a==null && u != null)
            {
              
                var userid = Int32.Parse(Session["userId"].ToString());
                ft1new = c.getallftag(userid);
                lt1 = c.getallctag(userid);
                String usertag = Session["username"].ToString();
                List<Contact> cl = new List<Contact>();

                cl1 = dbnew.contacts1.Where(x => x.uid == userid).ToList();
                // cl1 = db.contacts1.ToList();


                cl1 = cl1.OrderBy(x => x.firstName).ToList();
                for (int i = 0; i < cl1.Count; i++)
                {
                    cl1[i].firstName = char.ToUpper(cl1[i].firstName[0]) + cl1[i].firstName.Substring(1);
                }
                alpha = c.getalphabetsnewdb(cl1);

                contactandtags ct = new contactandtags(lt1, ft1new, cl1,alpha);
                return View(ct);
            }
            else
            {

               
                var userid = Int32.Parse(Session["userId"].ToString());
                ft1new = c.getallftag(userid);
                lt1 = c.getallctag(userid);
                String usertag = Session["username"].ToString();
                cl1 = dbnew.contacts1.Where(x => x.uid == userid).ToList();
                // cl1 = db.contacts1.ToList();


                cl1 = cl1.OrderBy(x => x.firstName).ToList();
                for (int i = 0; i < cl1.Count; i++)
                {
                    cl1[i].firstName = char.ToUpper(cl1[i].firstName[0]) + cl1[i].firstName.Substring(1);
                }
                alpha = c.getalphabetsnewdb(cl1);


                contactandtags ct = new contactandtags(lt1, ft1new, cl1,alpha);
                return View(ct);
            }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public JsonResult ContactsJSON(string a, string u)
        {
            String usertag = Session["username"].ToString();
            List<Contact> cl = new List<Contact>();

            cl = cx.Contacts.Where(x => x.Name.Contains(u) && x.username.Equals(usertag)).ToList();
            if(cl.Count>0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
        public ActionResult managetags()
        {
            if (Session["username"] != null)
            {
                cl = new List<Contact>();

                var userid = Int32.Parse(Session["userId"].ToString());
                ft1new = c.getallftag(userid);

                String user = Session["username"].ToString();
                lt1 = c.getallctag(userid);
                ct = new contactandtags(lt1, ft1new, cl);
                return View(ct);
            }

            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        

        public ActionResult FileUpload(string name,string s, HttpPostedFileBase file)
        {
            
           // if (action == "upload") { 
            if (name.Equals("upload")) { 
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Files"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for 
                

               

            }
            }
            if (name.Equals("mail"))
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Files"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB



                var fromAddress = new MailAddress("sheikhma3@yahoo.com", "Mateen");
                var toAddress = new MailAddress("bcsf11a038@gmail.com", "Mateen");
                const string fromPassword = "03134418108a";
                const string subject = "test file";
                const string body = "Hey now!!";

                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.yahoo.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("C:/Users/Sheikho0/Documents/Visual Studio 2013/Projects/MvcApplication2/MvcApplication2/Files/" + file.FileName);
                    message.Attachments.Add(attachment);

                    smtp.Send(message);
                }
            }

            // after successfully uploading redirect the user
            return (RedirectToAction("ShowContactdetail", new {a=s }));
           // return Content(null);
        }
        public ActionResult FileUpload1(HttpPostedFileBase file)
        {

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Files"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB



                var fromAddress = new MailAddress("sheikhma3@yahoo.com", "Mateen");
                var toAddress = new MailAddress("bcsf11a038@gmail.com", "Mateen");
                const string fromPassword = "03134418108a";
                const string subject = "test file";
                const string body = "Hey now!!";

                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.yahoo.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("C:/Users/Sheikho0/Documents/Visual Studio 2013/Projects/MvcApplication2/MvcApplication2/Files/" + file.FileName);
                    message.Attachments.Add(attachment);

                    smtp.Send(message);
                }


            }

            // after successfully uploading redirect the user
            return Redirect("Contacts");
        }
        public ActionResult manageftags()
        {
            if (Session["username"] != null)
            {

                cl = new List<Contact>();
                var userid = Int32.Parse(Session["userId"].ToString());
                ft1new = c.getallftag(userid);


                String user = Session["username"].ToString();
                lt1 = c.getallctag(userid); 
                ct = new contactandtags(lt1, ft1new, cl);
                return View(ct);
            }  
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        public JsonResult managetagsforlayout()
        {
            String user = Session["username"].ToString();
            List<tag> a = cx.tags.Where(x => x.username.Equals(user)).ToList();
            return this.Json(a, JsonRequestBehavior.AllowGet);
        }
        public ActionResult showcontact(string a)
        {
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);

            String usertag = Session["username"].ToString();
            cl = cx.Contacts.Where(x => x.tagname.Equals(a) && x.username.Equals(usertag)).ToList();
            ct = new contactandtags(lt1, ft1new, cl);
            return View(ct);
        }
        public ActionResult contactdetail(int id)
        {
           // String usertag = Session["username"].ToString();
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);

            c1 = dbnew.contacts1.Find(id);
            ct = new contactandtags(lt1, ft1new, c1);
            return View(ct);
        }
        public ActionResult ShowContactdetail(string a)
        {

            int id = Int32.Parse(a);
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);

            // String usertag = Session["username"].ToString();
            c1 = dbnew.contacts1.Find(id);

            ct = new contactandtags(lt1, ft1new, c1);

            return View(ct);
        }
        public JsonResult gettagsofselectedfile(string a)
        {
            int id = Int32.Parse(a);

            var file = dbnew.fTagDetails1.Find(id);
            var userid = Int32.Parse(Session["userId"].ToString());

            ftd = dbnew.fTagDetails1.Where(x => x.uid == userid && x.cid == file.cid && x.url.Equals(file.url) && x.orignalName.Equals(file.orignalName) ).ToList();
            //file.ftagname;
            //var tagsplits = tags.Split(',');
            ft1new = c.getallftag(userid);
            List<userFTag> assigned = new List<userFTag>();
            List<userFTag> unassigend= new List<userFTag>();
           
            for (int j = 0; j < ft1new.Count; j++)
                for(int k=0;k<ftd.Count;k++)
                 {

                if (ftd[k].fid==ft1new[j].Id)
                {
                    userFTag nn = new userFTag();
                    nn.Id = ft1new[j].Id;
                    nn.uid = ft1new[j].uid;
                    nn.fTagName = ft1new[j].fTagName;
                    
                    assigned.Add(nn);
                    
                }
               // else
                {
                    
                    
                }
            }

           

               /* for (int k = 0; k < assigned.Count; k++)
                {
                    if(ft1new[j].Id==assigned[k].Id)
                    {

                    }
                    else
                    {
                        userFTag nn = new userFTag();
                        nn.Id = ft1new[j].Id;
                        nn.uid = ft1new[j].uid;
                        nn.fTagName = ft1new[j].fTagName;
                        unassigend.Add(nn);
                    }

                }*/
            assigned = assigned.GroupBy(p=>p.fTagName).Select(g=>g.First()).ToList();
            var unassigend1 = ft1new.Where(p=>!assigned.Any(l=>p.fTagName.Equals(l.fTagName))).ToList();

            foreach (var v in unassigend1)
            {

                userFTag nn = new userFTag();
                nn.Id = v.Id;
                nn.uid = v.uid;
                nn.fTagName = v.fTagName;
                unassigend.Add(nn);
            }

            ct = new contactandtags(assigned, unassigend);
            return Json(ct, JsonRequestBehavior.AllowGet);
        }
        public JsonResult editftagContactdetailJSON(string f,string i)
        {
            int id = Int32.Parse(i);
            if(i != null)
            {
                fTagDetail1 file = dbnew.fTagDetails1.Find(id);
                                string filename = file.orignalName;
                                string vnam = file.virtualName;
                                string path = file.url;
                                var cid = file.cid;

                                ftd = dbnew.fTagDetails1.Where(x => x.cid == file.cid && x.uid == file.uid && x.orignalName.Equals(filename)).ToList();
                foreach(var fi in ftd)
                {
                    dbnew.fTagDetails1.Remove(fi);
                }
                dbnew.SaveChanges();
                var tagsplits = f.Split(',');
                List<int> ftagids = new List<int>();
                for (int i1 = 0; i1 < (tagsplits.Length - 1); i1++)
                {
                    ftagids.Add(Int32.Parse(tagsplits[i1]));
                }

               

                    //   Int32.Parse(
                    

                    foreach (var x in ftagids)
                    {

                        fTagDetail1 fdnew = new fTagDetail1();

                        fdnew.uid = Int32.Parse(Session["userId"].ToString());
                        fdnew.fid = x;
                        fdnew.cid = cid;
                        fdnew.orignalName = filename;
                        fdnew.virtualName = vnam;
                        fdnew.url = path;
                        dbnew.fTagDetails1.Add(fdnew);
                        dbnew.SaveChanges();
                    }
                 


            }
           
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult editContactTag(string a, string i)

        {

            if (i != null)
            {
                int id = Int32.Parse(i);

                List<contactCTag> lct= new List<contactCTag>();
                 lct= dbnew.contactCTags.Where(x => x.cid == id).ToList();
                foreach (var fi in lct)
                {
                    dbnew.contactCTags.Remove(fi);
                }
                dbnew.SaveChanges();
               
                var tagsplits = a.Split(',');

                List<int> ftagids = new List<int>();
                for (int i1 = 0; i1 < (tagsplits.Length - 1); i1++)
                {
                    ftagids.Add(Int32.Parse(tagsplits[i1]));
                }
                foreach (var x in ftagids)
                {

                    contactCTag cct = new contactCTag();
                    cct.cid = id;
                    cct.uctid = x;
                    dbnew.contactCTags.Add(cct);
                }
                dbnew.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
        public JsonResult addmobilelabels(string f,string i)
        {
            int id = Int32.Parse(i);
            var tagsplits = f.Split(',');
            int j=0;
            foreach(var x in tagsplits)
            {
                if (j < tagsplits.Length - 1)
                {
                    var eachlabel = x.Split(';');
                    string label123 = eachlabel[1];
                    var mbl = dbnew.mobileNoLabels.Where(y => y.label.Equals(label123)).First();
                    var userid = Int32.Parse(Session["userId"].ToString());
                    mobileNo mn = new mobileNo();
                    mn.uid = userid;
                    mn.cid = id;
                    mn.mid = mbl.Id;
                    mn.number = eachlabel[0];

                    dbnew.mobileNoes.Add(mn);
                    dbnew.SaveChanges();
                    j++;
                }

                
              


            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowContactdetailJSON(string a)
        {
            //var tagofafile=cx.ftagdetails
            /* int id = Int32.Parse(a);
             contact1 c1n=null;
             c1n = db.contacts1.Find(id);
            
                 // ftd = cx.ftagdetails.Where(x=>x.username.Equals(a)).ToList();

                 contactandtags cat = new contactandtags(c1n);

                 // String usertag = Session["username"].ToString();


                 return this.Json(cat, JsonRequestBehavior.AllowGet);*/
            //var tagofafile=cx.ftagdetails

            int id = Int32.Parse(a);
            c1 = dbnew.contacts1.Find(id);

            contact1 c1nn = null;
            c1nn = dbnew.contacts1.Find(id);
           
          //  ftd = cx.ftagdetails.Where(x => x.username.Equals(a)).ToList();
             var userid = Int32.Parse(Session["userId"].ToString());

             ftd = dbnew.fTagDetails1.Where(x => x.uid == userid && x.cid==id).ToList();
             List<contactCTag> cct = new List<contactCTag>();
              cct = dbnew.contactCTags.Where(x => x.cid == id).ToList();
            int i=0;
            lt1 = new List<userCTag>();
              foreach (var x in cct)
              {
                  var uc = dbnew.userCTags.Find(cct[i].uctid);
                  lt1.Add(uc);
                  i++;

              }
              List<userCTag> unassignedctag = new List<userCTag>();
              unassignedctag = c.getallctag(userid);
              var unass = unassignedctag.Where(p => !lt1.Any(l => p.Id.Equals(l.Id))).ToList();
          

           
            contact1 cat1 = new contact1();

            cat1.Id = c1nn.Id;
            cat1.uid = c1nn.uid;
            cat1.firstName = c1nn.firstName;
            cat1.middleName = c1nn.middleName;
            cat1.lastName = c1nn.lastName;
            cat1.dob = c1nn.dob;
            cat1.note = c1nn.note;
            cat1.phoneticFirstName = c1nn.phoneticFirstName;
            cat1.phoneticMiddleName = c1nn.phoneticMiddleName;
            cat1.phoneticLastName = c1nn.phoneticLastName;
            cat1.prefix = c1nn.prefix;
            cat1.suffix = c1nn.suffix;
            cat1.nickName = c1nn.nickName;
            cat1.jobTitle = c1nn.jobTitle;
            cat1.company = c1nn.company;
            cat1.department = c1nn.department;

            List<fTagDetail1> a123 = new List<fTagDetail1>();
            foreach(var x in ftd)
            {
                fTagDetail1 child = new fTagDetail1();
                child.Id = x.Id;
                child.uid = x.uid;
                child.cid = x.cid;
                child.orignalName = x.orignalName;
                child.virtualName = x.virtualName;
                child.url = x.url;
                a123.Add(child);
            }
            List<userCTag> ucl = new List<userCTag>();
            List<userCTag> uclunassign = new List<userCTag>();

            foreach(var p in lt1)
            {
                userCTag uc = new userCTag();
                uc.Id = p.Id;
                uc.cTagName = p.cTagName;
                uc.uid = p.uid;
                ucl.Add(uc);

            }
            foreach (var p in unass)
            {
                userCTag uc = new userCTag();
                uc.Id = p.Id;
                uc.cTagName = p.cTagName;
                uc.uid = p.uid;
                uclunassign.Add(uc);

            }
            List<mobileNo> mobnums = new List<mobileNo>();
            var mobnum = dbnew.mobileNoes.Where(x=>x.cid==id&&x.uid==userid);
            foreach(var q   in mobnum)
            {
                mobileNo mns = new mobileNo();
                mns.Id = q.Id;
                mns.cid = q.cid;
                mns.uid = q.uid;
                mns.mid = q.mid;
                mns.number = q.number;
                mobnums.Add(mns);
                
            }


            contactandtags cat = new contactandtags(cat1, a123, ucl, uclunassign, mobnums);

            // String usertag = Session["username"].ToString();


            return this.Json(cat, JsonRequestBehavior.AllowGet);


      
            
           
        }
        public JsonResult ShowftagedfilesJSON(string a)
        {
            
            
            //ftd = cx.ftagdetails.Where(x => x.ftagname.Contains(a)).ToList();



          

            return this.Json(ftd, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditContact(string a)
        {

            if (Session["username"] != null)
            {

            int id = Int32.Parse(a);
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);

            // String usertag = Session["username"].ToString();7
            
            c1 = dbnew.contacts1.Find(id);
            List<mobileNo> mobnums = new List<mobileNo>();
            var mobnum = dbnew.mobileNoes.Where(x => x.cid == id && x.uid == userid);
            foreach (var q in mobnum)
            {
                mobileNo mns = new mobileNo();
                mns.Id = q.Id;
                mns.cid = q.cid;
                mns.uid = q.uid;
                mns.mid = q.mid;
                mns.number = q.number;
                mobnums.Add(mns);

            }
            ct = new contactandtags(lt1, ft1new, c1,mobnums);
            return View(ct);
                 
            }  
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        public ActionResult updatecontact(contact1 c1nn)
        {


            contact1 cat1 = new contact1();

            cat1 = dbnew.contacts1.Find(c1nn.Id);
            
            cat1.firstName = c1nn.firstName;
            cat1.middleName = c1nn.middleName;
            cat1.lastName = c1nn.lastName;
            cat1.dob = c1nn.dob;
            cat1.note = c1nn.note;
            cat1.phoneticFirstName = c1nn.phoneticFirstName;
            cat1.phoneticMiddleName = c1nn.phoneticMiddleName;
            cat1.phoneticLastName = c1nn.phoneticLastName;
            cat1.prefix = c1nn.prefix;
            cat1.suffix = c1nn.suffix;
            cat1.nickName = c1nn.nickName;
            cat1.jobTitle = c1nn.jobTitle;
            cat1.company = c1nn.company;
            cat1.department = c1nn.department;

           
            
         
            dbnew.SaveChanges();
           

            return Redirect("Contacts");
        }
        public ActionResult addnewtag()
        {
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);

            ct = new contactandtags(lt1, ft1new, c1);

            return View(ct);
        }

        public ActionResult validitytag(tag t)
        {
            Database1Entities1 db = new Database1Entities1();
            var max = db.tags.Max(x => x.Id);
            t.Id = max+1;

            t.username = Session["username"].ToString();
            t.tagcolor = "white";
            db.tags.Add(t);
            db.SaveChanges();
            return Redirect("Contacts");
        }
        public JsonResult addtagJSON(string n)
        {
            Database1Entities1 db = new Database1Entities1();
            
            userCTag t = new userCTag();
            t.cTagName= n;


            t.uid = Int32.Parse(Session["userId"].ToString());
          
            dbnew.userCTags.Add(t);
            dbnew.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult addftagJSON(string n)
        {
            //Database1Entities1 db = new Database1Entities1();

            userFTag t = new userFTag();
            t.fTagName = n;


            t.uid = Int32.Parse(Session["userId"].ToString());
            
            dbnew.userFTags.Add(t);
            dbnew.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult newcontact()
        {
           
            c1 = new contact1();
            
            ft1 = c.getallftag();
            var userid = Int32.Parse(Session["userId"].ToString());
            lt1 = c.getallctag(userid);

            ft1new = c.getallftag(userid);
            ct = new contactandtags(lt1,ft1new, c1);
            return View(ct);

        }
        public ActionResult facebookimport()
        {
            String username1 = Session["username"].ToString();

            var tl = cx.Contacts.Where(x => x.username.Equals(username1)).ToList();
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);


            ct = new contactandtags(lt1, ft1new, tl);
            return View(ct);

        }
        public ActionResult facebookmeinfo()
        {
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);
            cl=new List<Contact>();
            ct = new contactandtags(lt1, ft1new, cl);
            return View(ct);

        }
        public ActionResult mailattachfile(HttpPostedFileBase file)
        {

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Files"), pic);
                // file is uploaded
                file.SaveAs(path);
            }

            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);
            cl = new List<Contact>();
            ct = new contactandtags(lt1, ft1new, cl);
            return Redirect("Contact");

        }
        public ActionResult gmailimport()
        {
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);
            var gc = new List<GmailContacts>();
            //gmailcontacts gmail=new gmailcontacts();
           // gc = gmail.getall();
            ct = new contactandtags(lt1, ft1new, gc);
            return View(ct);

        }
        public ActionResult gmailimportcontact()
        {
            string email = Request["email"];
            string pass = Request["pass"];
            var gc = new List<GmailContacts>();
            gmailcontacts gmail = new gmailcontacts();
            gc = gmail.getall(email,pass);
            var userid = Int32.Parse(Session["userId"].ToString());
            ft1new = c.getallftag(userid);
            lt1 = c.getallctag(userid);
            ct = new contactandtags(lt1, ft1new, gc);

            return View(ct);

        }
        public void putgmmailcontactindb( List<GmailContacts> g)
        {

            var gmailc = g;
            string ok;



            int a=0;
            while(a<10000)
            {
                a++;
            }
        }
        
        public ActionResult addnewcontact(contact1 c)
        {
            
           // var max = cx.Contacts.Max(x => x.Id);
            //c.Id = max + 1;


            
            c.uid = Int32.Parse(Session["userId"].ToString());

            dbnew.contacts1.Add(c);

            dbnew.SaveChanges();
           // var tl = cx.tags.ToList();
            return Redirect("Contacts");

        }



        [HttpPost]
        public JsonResult Upload(string f,string c,string v)
        {
            
            var tagsplits = f.Split(',');
            List<int> ftagids = new List<int>();
            for (int i = 0; i < (tagsplits.Length-1)  ;i++ )
            {
                ftagids.Add(Int32.Parse(tagsplits[i]));
            }
           
            for (int i = 0; i < Request.Files.Count; i++)
            {
                
                    //   Int32.Parse(
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    string pathoffile = "C:/Users/" + file.FileName;
                    string ftag = f;

                    ftag = ftag.Replace(" ", "");
                    string cid = c;
                    string name = file.FileName;
                    string vrname1 = v;
                    
                    foreach (var x in ftagids)
                    {
                      
                     fTagDetail1 fdnew = new fTagDetail1();

                    fdnew.uid = Int32.Parse(Session["userId"].ToString()); 
                    fdnew.fid = x;
                    fdnew.cid = Int32.Parse(c);
                    fdnew.orignalName = name;
                    fdnew.virtualName = vrname1;
                    fdnew.url = path;
                    dbnew.fTagDetails1.Add(fdnew);
                    dbnew.SaveChanges();
                }
                    file.SaveAs(path);
                

            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
        public void Uploadmail()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                file.SaveAs(path);


                var fromAddress = new MailAddress("sheikhma3@yahoo.com", "Mateen");
                var toAddress = new MailAddress("bcsf11a038@gmail.com", "Mateen");
                const string fromPassword = "03134418108a";
                const string subject = "test file";
                const string body = "Hey now!!";

                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.yahoo.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("C:/Users/Sheikho0/Documents/Visual Studio 2013/Projects/MvcApplication2/MvcApplication2/Files/" + file.FileName);
                    message.Attachments.Add(attachment);

                    smtp.Send(message);
                }
            }


        }



    }
}
