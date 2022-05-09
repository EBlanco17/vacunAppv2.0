using System;
using Datos;
using Utilitarios;

namespace Logica
{
    public class Janssen : Vacuna
    {
        public bool registrarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 7;
            new DAOVacuna().registrarVacuna(vacuna);
            return true;

        }
        public bool actualizarVacuna(EVacuna vacuna)
        {
            new DAOVacuna().updateVacuna(vacuna);
            return true;
        }
    }
}
