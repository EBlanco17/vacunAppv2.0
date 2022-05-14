using System;
using Datos;
using Utilitarios;

namespace Logica
{
    public class Bayer : Vacuna
    {
        public bool registrarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 8;
            new DAOVacuna().registrarVacuna(vacuna);
            return true;

        }
        public bool actualizarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 8;
            new DAOVacuna().updateVacuna(vacuna);
            return true;
        }
    }
}
