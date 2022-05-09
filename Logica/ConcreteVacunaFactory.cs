using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteVacunaFactory : VacunaFactory
    {
        public override Vacuna GetVacuna(string vacuna)
        { 
            switch (vacuna)
            {
                case "Novartis De Colombia SA":
                    return new Novartis();
                case "Productos Roche SA":
                    return new Roche();
                case "Pfizer SAS":
                    return new Pfizer();
                case "Sanofi-Aventis De Colombia SA":
                    return new Sanofi();
                case "Audifarma SA":
                    return new Audifarma();
                case "Abbott Laboratories De Colombia SA":
                    return new Abbott();
                case "Janssen Cilag SA":
                    return new Janssen();
                case "Bayer SA":
                    return new Bayer();
                
                default:
                    throw new ApplicationException(string.Format("La vacuna '{0}' no puede ser creada", vacuna));

            }

        }
    }
}
