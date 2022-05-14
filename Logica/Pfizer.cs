using System;
using Utilitarios;
using Datos;

namespace Logica
{
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Pfizer : Vacuna
    {
        public bool registrarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 3;
            new DAOVacuna().registrarVacuna(vacuna);
            return true;

        }
        public bool actualizarVacuna(EVacuna vacuna)
        {
            vacuna.Farmaceutica_id = 3;
            new DAOVacuna().updateVacuna(vacuna);
            return true;
        }

        
        
    }
}
