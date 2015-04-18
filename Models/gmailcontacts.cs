using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Contacts;
using Google.GData.Client;
using Google.GData.Contacts;
using Google.GData.Extensions;
namespace MvcApplication2.Models
{

    public class GmailContacts
    {
        private string _EmailID;
        private string _Title;

        public string EmailID
        {
            get
            {
                return _EmailID;
            }

            set
            {
                _EmailID = value;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
            }
        }
    }
    public class gmailcontacts
    {

        public List<GmailContacts> getall( string email,string pass)
        {
            RequestSettings reqSettings = new RequestSettings("My Application", email, pass);
            reqSettings.AutoPaging = true;

            ContactsRequest contReq = new ContactsRequest(reqSettings);
            var Contacts = contReq.GetContacts();
            List<GmailContacts> objContacts = new List<GmailContacts>();
            foreach (var objContact in Contacts.Entries)
            {
                GmailContacts objGmailContacts = new GmailContacts();
                objGmailContacts.Title = objContact.Title.ToString();



                 foreach (EMail emailId in objContact.Emails)
                {
                    objGmailContacts.EmailID = emailId.Address.ToString() + ",";
                }
                if (objGmailContacts.EmailID != null)
                {
                    objGmailContacts.EmailID = objGmailContacts.EmailID.Substring(0, objGmailContacts.EmailID.Length - 1);
                }
                objContacts.Add(objGmailContacts);
            }
            return objContacts;
            }
        }
    }
