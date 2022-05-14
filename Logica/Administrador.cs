using System.Collections.Generic;
using Utilitarios;
using Datos;


namespace Logica
{
    public class Administrador : Persona
    {
        
        public List<EFarmaceutica> listarFarmaceuticas()
        {
            return new DAOVacuna().listarFarmaceuticas();
        }
        public void agregarVacunas(EVacuna vacuna, string fabricante)
        {
            VacunaFactory factory = new ConcreteVacunaFactory();
            Vacuna vacc = factory.GetVacuna(fabricante);
            vacc.registrarVacuna(vacuna);
        }
        
        public Respuesta actualizarVacuna(EVacuna vacuna, string fabricante)
        {
            Respuesta resp = new Respuesta();
            VacunaFactory factory = new ConcreteVacunaFactory();
            Vacuna vacc = factory.GetVacuna(fabricante);
            if (vacc.actualizarVacuna(vacuna))
            {
                resp.Mensaje = "Vacuna Actualizada Correctamente";
                resp.Url = "../Views/RegistroVacunas.aspx";
            }
            else
            {
                resp.Mensaje = "Error, no se pudo actualizar!!!";

            }
            return resp;

        }
        public List<EVacuna> getVacunasXIdFarm(int id)
        {
            return new DAOVacuna().registros(id);
        }

        public List<ESolicitud> verRegistros()
        {
            return new DAOSolicitud().registros();
        }

        public ESolicitud verSolicitud(int id)
        {
            return new DAOSolicitud().getSolicitudXId(id);
        }

        public Respuesta cambiarRol(EPersona user, string correo, string body, string asunto)
        {
            Respuesta resp = new Respuesta();
            new DAOSolicitudAdmin().updateRol(user);
            new DAOSolicitudAdmin().deleteUserRol(user.Id);
            resp.User = null;
            resp.Mensaje = new Persona().SendMail(correo,body,asunto);
            resp.Url = "../Views/SolicitudesAdministrador.aspx";
            return resp;

        }

        public List<ESolicitudAdministrador> verRegistrosAdmin()
        {
            return new DAOSolicitudAdmin().registros(); ;
        }
        public Respuesta rechazarSolicitud(int id, string correo, string body, string asunto)
        {
            Respuesta resp = new Respuesta();
            new DAOSolicitudAdmin().deleteUserRol(id);
            resp.User = null;
            resp.Mensaje = new Persona().SendMail(correo, body, asunto);
            resp.Url = "../Views/SolicitudesAdministrador.aspx";
            return resp;
        }

        public ESolicitudAdministrador verSolicitudAdmin(int id)
        {
            return new DAOSolicitudAdmin().getSolicitudXId(id);
        }

        public Respuesta respuestaSolicitud(ESolicitud eSolicitud, string correo, string body, string asunto)
        {
            Respuesta resp = new Respuesta();
            
            new DAOSolicitud().updateSolicitud(eSolicitud);
            
            resp.User = null;
            resp.Mensaje = new Persona().SendMail(correo, body, asunto);
            resp.Url = "../Views/RecepcionPQRS.aspx";
            return resp;

        }

        public List<EVacuna> verVacunas()
        {
            return new DAOVacuna().registrosVacunas();
        }

        public EVacuna verVacunaXId(int id)
        {
            return new DAOVacuna().verVacunaXId(id);
        }

    }
}
