using Utilitarios;
namespace Logica
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    interface Vacuna
    {
        bool registrarVacuna(EVacuna vacuna);
        bool actualizarVacuna(EVacuna vacuna);
    }
}
