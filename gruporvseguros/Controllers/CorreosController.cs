using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;

namespace gruporvseguros.Controllers
{
    public class CorreosController : Controller
    {
        private readonly IConfiguration _configuration;
        public CorreosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Enviar(string correo_destinatario, string destinatario, string asunto, string mensaje, string telefono,string accion_redireccionar)
        {
            var enviado = await enviar_correo(correo_destinatario, destinatario, asunto, mensaje);
            return RedirectToAction(accion_redireccionar,"Home");
        }

        private async Task<bool> enviar_correo(string correo_destinatario, string destinatario, string asunto, string cuerpo)
        {
            try
            {
                var estado = "";
                //-- variables para correos 
                var correo = _configuration.GetValue<string>("configuraciones:correo");
                var contrasena = _configuration.GetValue<string>("configuraciones:contra_correo");
                var smtpHost = _configuration.GetValue<string>("configuraciones:smpthost");
                var smtpPort = _configuration.GetValue<int>("configuraciones:smtpport");

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect(smtpHost, smtpPort, false);
                smtpClient.Authenticate(correo, contrasena);


                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("GRUPORV", correo));
                email.To.Add(new MailboxAddress(destinatario, correo_destinatario));
                email.Subject = asunto;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = cuerpo
                };
                using (smtpClient)
                {
                    estado = await smtpClient.SendAsync(email);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
