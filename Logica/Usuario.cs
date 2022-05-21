using System.Collections.Generic;
using Utilitarios;
using Datos;

namespace Logica
{
    public class Usuario : Persona
    {
        public List<EFarmaceutica> listarFarmaceuticas()
        {
            return new DAOVacuna().listarFarmaceuticas();
        }

        public List<EVacuna> getVacunas(int idFarm)
        {
            return new DAOVacuna().registros(idFarm);
        }

        public Respuesta ingresarVacuna(EVacunasAplicadas vacunaA)
        {
            Respuesta resp = new Respuesta();
            EVacuna vacuna = new DAOVacuna().verVacunaXId(vacunaA.VacunaId);
            vacuna.Cantidad -= 1;
            new DAOVacuna().updateVacuna(vacuna);    
            new DAOVacuna().registrarVacunaAplicada(vacunaA);
            resp.User = null;
            resp.Mensaje = "Se añadio vacuna correctamente";
            resp.Url = "../Views/Perfil.aspx";
            return resp;
        }
        public int dosisTotales(int id)
        {
            return new DAOVacuna().getDosisTotales(id);
        }
        public List<EVacunasAplicadas> getVacunasAplicadas(int idUser)
        {
            return new DAOVacuna().verEsquema(idUser);
        }


        public Respuesta insertarSolicitud(ESolicitud solicitud)
        {

            Respuesta resp = new Respuesta();
            new DAOSolicitud().insertarSolicitud(solicitud);
            resp.User = null;
            resp.Mensaje = "Solicitud enviada correctamente";
            resp.Url = "../Views/Perfil.aspx";
            return resp;
        }


        public Respuesta comprobarSolicitudAdmin(int id)
        {
            Respuesta resp = new Respuesta();
            int numSolicitudes = 0;
            numSolicitudes = new DAOSolicitudAdmin().verificarSolAdmin(id);
            if (numSolicitudes == 0)
            {
                resp.User = null;
                resp.Mensaje = "Realice una petición...";
                resp.Url = "../Views/SolicitarAdministrador.aspx";
            }
            else
            {
                resp.User = null;
                resp.Mensaje = "Ya se realizo la solictud antes";
                resp.Url = null;
            }
            return resp;
        }

        public Respuesta solicitarAdmin(ESolicitudAdministrador solAdmin)
        {
            Respuesta resp = new Respuesta();

            new DAOSolicitudAdmin().solicitarAdmin(solAdmin);
            resp.User = null;
            resp.Mensaje = "Mensaje Enviado";
            resp.Url = "../Views/Login.aspx";

            return resp;
        }

        public List<ELocalidad> listarLocalidades()
        {
            return new DAOFormulario().listar();
        }

        public List<EBarrio> listarBarrios(int id)
        {
            return new DAOFormulario().listarBarrios(id);
        }

        public EFormulario comprobarFormulario(int id)
        {
                                  
            return new DAOFormulario().verificarFormXUsuario(id);

        }

        public EFormulario GetFormulario(int idUsuario)
        {
            return new DAOFormulario().GetFormulario(idUsuario);
        }

        public string getNombreLocalidad(int id)
        {
            return new DAOFormulario().getLocalidadXId(id);
        }
        public string getNombreBarrio(int id)
        {
            return new DAOFormulario().getBarrioXId(id);
        }
        public Respuesta guardarFormulario(EFormulario form)
        {
            Respuesta resp = new Respuesta();
            new DAOFormulario().guardar(form);
            resp.Mensaje = "Formulario guardado correctamente";
            resp.Url = "../Views/Perfil.aspx";
            return resp;
        }
    }
}
