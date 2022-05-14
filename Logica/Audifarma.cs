using System;
using Datos;
using Utilitarios;

namespace Logica
{
    public class Audifarma : Vacuna
    {
        public bool registrarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 5;
            new DAOVacuna().registrarVacuna(vacuna);
            return true;

        }
        public bool actualizarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 5;
            new DAOVacuna().updateVacuna(vacuna);
            return true;
        }
    }
}
