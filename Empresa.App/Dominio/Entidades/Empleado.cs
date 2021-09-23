namespace Dominio
{
    public class Empleado : Persona
    {
        new public int Id { get; set; }
        public int SueldoBruto { get; set; }
        /// Relacion entre Empleado y la Empresa
        public Empresa Empleador { get; set; }

    }
}