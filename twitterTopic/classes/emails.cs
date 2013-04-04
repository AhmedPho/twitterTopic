using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Web.Security;
using System.Web.SessionState;

namespace twitterTopic.classes
{
    public class emails
    {
        void SendEmail()
        {
            string EmailSender = WebConfigurationManager.AppSettings["EmailSender"].ToString();
            string PassWordEmailSender = WebConfigurationManager.AppSettings["PassWordEmailSender"].ToString();
            string NameEmailSender = WebConfigurationManager.AppSettings["NameEmailSender"].ToString();
            string EmailForSendToAll = WebConfigurationManager.AppSettings["EmailForSendToAll"].ToString();
           
            var fromAddress = new MailAddress("a@a.a", "A");
            var toAddress = new MailAddress("a@a.a", "A");
            const string fromPassword = "***";
            //string subject = ;
            //string body = ;

            var smtp = new SmtpClient
            {
                Host = "smtp.awal.com.sa",
                Port = 25,
                //EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                //Subject = subject,
                //Body = body,
                IsBodyHtml = true
            })
            {
                //if (FileUpload1.PostedFile.ContentLength > 0)
                /*if (FileUpload1.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload1.FileContent, System.IO.Path.GetFileName(FileUpload1.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload2.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload2.FileContent, System.IO.Path.GetFileName(FileUpload2.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload3.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload3.FileContent, System.IO.Path.GetFileName(FileUpload3.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload4.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload4.FileContent, System.IO.Path.GetFileName(FileUpload4.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload5.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload5.FileContent, System.IO.Path.GetFileName(FileUpload5.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload6.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload6.FileContent, System.IO.Path.GetFileName(FileUpload6.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload7.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload7.FileContent, System.IO.Path.GetFileName(FileUpload7.FileName));
                    message.Attachments.Add(attachment);
                }
                if (FileUpload8.HasFile)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FileUpload8.FileContent, System.IO.Path.GetFileName(FileUpload8.FileName));
                    message.Attachments.Add(attachment);
                }
                */
                smtp.Send(message);
            }



        } 
       

    }
}