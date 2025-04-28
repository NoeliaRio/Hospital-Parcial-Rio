namespace Hospital_Parcial_Rio.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }


        public int Obra_SocialId { get; set; }
        public Obra_Social? obra_social { get; set; }

        public int SintomaId { get; set; }
        public Sintoma? sintoma { get; set; }
    }
}

