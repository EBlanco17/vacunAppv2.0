using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using Datos;
using Utilitarios;

namespace Logica
{
    public class Persona
    {
        public Respuesta crearPersona(EPersona persona)
        {
            int numCorreos = 0;
            int numDocumentos = 0;
            numCorreos = new DAOUsuario().comprobarBD(persona.Correo);
            numDocumentos = new DAOUsuario().comprobarDocumentos(persona.Documento);
            Respuesta resp = new Respuesta();

            if (numCorreos == 0 && numDocumentos == 0)
            {
                new DAOUsuario().createUser(persona);
                resp.User = null;
                resp.Mensaje = "Usuario Creado Correctamente";
                resp.Url = "../Views/Login.aspx";
            }
            else
            {
                if (numCorreos > 0)
                {
                    resp.User = null;
                    resp.Mensaje = "Error al crear usuario, correo ya registrado";
                    resp.Url = "../Views/Registro.aspx";
                }
                else
                {
                    resp.User = null;
                    string email = (new DAOUsuario().correoRegistrado(persona.Documento)).Correo;
                    resp.Mensaje = "Error al crear usuario, documento ya registrado con el correo: " + email;
                    resp.Url = "../Views/Registro.aspx";
                }
            }
            return resp;
        }
        public Respuesta actualizarPersona(EPersona user)
        {
            Respuesta resp = new Respuesta();
            new DAOUsuario().updateUser(user);
            resp.User = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/Login.aspx";
            return resp;
        }

        public Respuesta login(EPersona user)
        {
            user = new DAOUsuario().login(user);
            Respuesta resp = new Respuesta();

            if (user != null)
            {
                resp.User = user;
                resp.Mensaje = "Bienvenido: " + user.Nombres;
                resp.Url = "../Views/Perfil.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "Datos incorrectos";
                resp.Url = "../Views/Login.aspx";
            }
            return resp;
        }


        public Respuesta recuperarPassword(string correo, string body, string asunto, string token)
        {
            Respuesta resp = new Respuesta();
            EPersona user = new EPersona();

            user = new DAOUsuario().recuperarPassword(correo);

            if (user != null)
            {
                user.Clave = encriptarPassword(token);
                new DAOUsuario().updatePassword(user);
                resp.User = null;
                resp.Mensaje = SendMail(correo, body, asunto);
                resp.Url = "../Views/Login.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "El correo no se ha encontradoo";
                resp.Url = "../Views/RecuperarPassword.aspx";
            }

            return resp;
        }

        public Respuesta actualizarPassword(EPersona user)
        {
            Respuesta resp = new Respuesta();
            new DAOUsuario().updatePassword(user);
            resp.User = null;
            resp.Mensaje = "Datos Actualizados Correctamente";
            resp.Url = "../Views/Login.aspx";
            return resp;
        }

        public Respuesta buscarRegistro(int id)
        {
            Respuesta resp = new Respuesta();
            resp.User = new DAOUsuario().getUsuarioXId(id);
            return resp;
        }

        public string encriptarPassword(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public Boolean validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int CalcularEdad(DateTime fechaNac)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (fechaNac > fechaActual)
            {
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNac.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (fechaNac.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }

        public string SendMail(string To, string Body, string asunto)
        {
            string from = "vacunapp21@gmail.com";
            string displayName = "VacunApp 2021";
            string pass = "vacun2021_app";
            MailMessage mail = new MailMessage();
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            try
            {

                mail.From = new MailAddress(from, displayName);
                mail.To.Add(To);

                mail.Subject = asunto;


                mail.Body = Body;
                mail.IsBodyHtml = true;



                cliente.Credentials = new NetworkCredential(from, pass);
                cliente.EnableSsl = true;
                cliente.Send(mail);
                return "Se envio mensaje correctamente";
            }
            catch
            {
                try
                {
                    cliente.EnableSsl = true;
                    cliente.Send(mail);
                    return "Se envio mensaje correctamente";
                }
                catch
                {
                    return "No se pudo enviar el mensaje";
                }
            }


        }
    }

}