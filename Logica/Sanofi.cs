using System;
using Datos;
using Utilitarios;


namespace Logica
{
    public class Sanofi : Vacuna
    {
        public bool registrarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 4;
            new DAOVacuna().registrarVacuna(vacuna);
            return true;

        }
        public bool actualizarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 4;
            new DAOVacuna().updateVacuna(vacuna);
            return true;
        }
    }
}
