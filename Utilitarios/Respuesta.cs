namespace Utilitarios
{
    public class Respuesta
    {
        private EPersona persona;
        private string mensaje;
        private string url;

        public EPersona User { get => persona; set => persona = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Url { get => url; set => url = value; }

    }
}
