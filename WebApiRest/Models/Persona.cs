namespace WebApiRest.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;


    }
}
