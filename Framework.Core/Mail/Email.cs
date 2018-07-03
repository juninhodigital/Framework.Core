using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Provides methods to send and receive e-mail messages using a STMP server
    /// </summary>
    public class Email
    {
        #region| Methods |

        /// <summary>
        /// Sends the specified message to an SMTP server for deliver
        /// </summary>
        /// <param name="From">The from address for this e-mail message</param>
        /// <param name="To">Recipients of this e-mail message</param>
        /// <param name="Subject">The e-mail message subject</param>
        /// <param name="Body">The value that contains the body text</param>
        /// <param name="Server">The name or IP address of the host used for SMTP transactions.</param>
        /// <param name="Port">The port to be used on host</param>
        /// <param name="Priority">The priority of this e-mail message</param>
        /// <param name="Attachments">List of Attachments</param>
        /// <param name="UserName">The user name associated with the credential</param>
        /// <param name="Password">The password for the user name associated with the credentials</param>
        /// <param name="RequireSSL">Specify whether the System.Net.Mail.SmtpClient uses Secure Sockets Layer (SSL) to encrypt the connection.</param>
        public void SendMail(MailAddress From, MailAddress To, string Subject, string Body, string Server, int Port, MailPriority Priority = MailPriority.Normal, List<Attachment> Attachments = null, string UserName = "", string Password = "", bool RequireSSL = false)
        {
            var oRecipients = new List<MailAddress>();

            oRecipients.Add(To);

            this.SendMail(From, oRecipients, Subject, Body, Server, Port, Priority, Attachments, UserName, Password, RequireSSL);
        }

        /// <summary>
        /// Sends the specified message to an SMTP server for deliver
        /// </summary>
        /// <param name="From">The from address for this e-mail message</param>
        /// <param name="To">Recipients of this e-mail message</param>
        /// <param name="Subject">The e-mail message subject</param>
        /// <param name="Body">The value that contains the body text</param>
        /// <param name="Server">The name or IP address of the host used for SMTP transactions.</param>
        /// <param name="Port">The port to be used on host</param>
        /// <returns>true if the e-mail was sent, otherwise, false</returns>
        public bool SendMail(MailAddress From, MailAddress To, string Subject, string Body, string Server, int Port)
        {
            return this.SendMail(From, To, Subject, Body, Server, Port);
        }

        /// <summary>
        /// Sends the specified message to an SMTP server for deliver
        /// </summary>
        /// <param name="From">The from address for this e-mail message</param>
        /// <param name="To">Address collection that contains the recipients of this e-mail message</param>
        /// <param name="Subject">The e-mail message subject</param>
        /// <param name="Body">The value that contains the body text</param>
        /// <param name="Server">The name or IP address of the host used for SMTP transactions.</param>
        /// <param name="Port">The port to be used on host</param>
        /// <returns>true if the e-mail was sent, otherwise, false</returns>
        public bool SendMail(MailAddress From, List<MailAddress> To, string Subject, string Body, string Server, int Port)
        {
            return this.SendMail(From, To, Subject, Body, Server, Port);
        }

        /// <summary>
        /// Sends the specified message to an SMTP server for deliver
        /// </summary>
        /// <param name="From">The from address for this e-mail message</param>
        /// <param name="ToCollection">Address collection that contains the recipients of this e-mail message</param>
        /// <param name="Subject">The e-mail message subject</param>
        /// <param name="Body">The value that contains the body text</param>
        /// <param name="Server">The name or IP address of the host used for SMTP transactions.</param>
        /// <param name="Port">The port to be used on host</param>
        /// <param name="Priority">The priority of this e-mail message</param>
        /// <param name="Attachments">List of Attachments</param>
        /// <param name="UserName">The user name associated with the credential</param>
        /// <param name="Password">The password for the user name associated with the credentials</param>
        /// <param name="RequireSSL">Specify whether the System.Net.Mail.SmtpClient uses Secure Sockets Layer (SSL) to encrypt the connection.</param>
        public void SendMail(MailAddress From, List<MailAddress> ToCollection, string Subject, string Body, string Server, int Port, MailPriority Priority = MailPriority.Normal, List<Attachment> Attachments = null, string UserName = "", string Password = "", bool RequireSSL = false)
        {
            var oMailMessage = new MailMessage();

            for (int i = 0; i < ToCollection.Count; i++)
            {
                MailAddress Item = ToCollection[i];

                oMailMessage.To.Add(Item);
            }

            oMailMessage.Subject                     = Subject;
            oMailMessage.From                        = From;
            oMailMessage.Body                        = Body;
            oMailMessage.Priority                    = Priority;
            oMailMessage.SubjectEncoding             = Encoding.GetEncoding("ISO-8859-1");
            oMailMessage.BodyEncoding                = Encoding.GetEncoding("ISO-8859-1");
            oMailMessage.IsBodyHtml                  = true;
            oMailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            if (Attachments.IsNotNull())
            {
                for (int i = 0; i < Attachments.Count; i++)
                {
                    Attachment Item = Attachments[i];

                    oMailMessage.Attachments.Add(Item);
                }
            }

            var oSMTP = new SmtpClient(Server, Port);

            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                oSMTP.Credentials = new NetworkCredential(UserName, Password);
            }

            #region| AlternateView 

            // AlternateView
            // AlternateView HTML = AlternateView.CreateAlternateViewFromString(Body, null, MediaTypeNames.Text.Html);

            // LinkedResource
            // LinkedResource IMG = new LinkedResource(Server.MapPath("Images/imagem.jpg"), MediaTypeNames.Image.Jpeg);

            // IMG.ContentId = "Pic1";
            // HTML.LinkedResources.Add(IMG);

            // Message.AlternateViews.Add(HTML);

            #endregion

            oSMTP.EnableSsl = RequireSSL;
            oSMTP.Send(oMailMessage);

            oMailMessage.Dispose();
            oSMTP = null;
        }
 
        #endregion
    }
}
