using System;
using System.Net;
using System.Net.Mail;




namespace Silas.API.Services
{
    public class SendEmail
    {
        public string SendMail(string displayName, string subject, string emailTo, string Text)
        {
            string body = "Mensagem: " + Text;

            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.inteliprosistemas.com.br";
                //client.EnableSsl = false;
                client.Credentials = new NetworkCredential("atendimento@inteliprosistemas.com.br", "ss@dm1n102030");
                client.Port = Convert.ToInt32(587);

                //fazer for testando true e false
                //client.EnableSsl = false;
                //emailTo.Contains("gmail.com") ?
                MailMessage message = new MailMessage();
                message.Sender = new MailAddress("atendimento@inteliprosistemas.com.br", displayName);
                message.From = new MailAddress("atendimento@inteliprosistemas.com.br");

                message.To.Add(new MailAddress(emailTo));

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;



                client.Send(message);

                return "success";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}
