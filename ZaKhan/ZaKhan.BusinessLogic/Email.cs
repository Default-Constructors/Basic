using SendGrid;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace ZaKhan.BusinessLogic
{
    public class Email
    {
        public void SendEmail(string email, string message)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("thammy202@gmail.com");

            // Add multiple addresses to the To field.
            List<String> recipients = new List<String>
                {
                    @"<"+email+">",
                };

            myMessage.AddTo(recipients);

            myMessage.Subject = "Booking For Consultation.";

            // Create network credentials to access your SendGrid account
            var username = "mzwangwane@gmail.com";
            var pswd = "Mzwa53560";

            var credentials = new NetworkCredential(username, pswd);

            //// Create the email object first, then add the properties.
            myMessage = new SendGridMessage();
            myMessage.AddTo(email);
            myMessage.From = new MailAddress("ZaKhan@gmail.com", "");
            myMessage.Subject = "Booking For Consultation.";


            myMessage.Text = message;

            // Create credentials, specifying your user name and password.
            credentials = new NetworkCredential("mzwangwane@gmail.com", "Mzwa53560");

            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            // You can also use the **DeliverAsync** method, which returns an awaitable task.
            transportWeb.DeliverAsync(myMessage);
        }
    }
}
