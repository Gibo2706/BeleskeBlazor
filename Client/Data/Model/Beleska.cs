using System.ComponentModel.DataAnnotations;

namespace BeleskeBlazor.Client.Data.Model
{
    [Serializable]
    public class Beleska
    {
        [Key]
        private int idBeleska;
        [Required]
        private int redniBroj { get; set; }
        [Required]
        private string naslov { get; set; }
        [Required]
        private byte[] dokument { get; set; }
        [Required]
        private int idStudent { get; set; }
        [Required]
        private int idCas { get; set; }

        public Beleska(int idBeleska, int redniBroj, string naslov, byte[] dokument, int idStudent, int idCas)
        {
            this.idBeleska = idBeleska;
            this.redniBroj = redniBroj;
            this.naslov = naslov;
            this.dokument = dokument;
            this.idStudent = idStudent;
            this.idCas = idCas;
        }

        public Beleska()
        {
        }

        public int IdBeleska
        {
            get { return idBeleska; }
            set { idBeleska = value; }
        }


        public override string ToString()
        {
            return "Beleska{" + "idBeleska=" + idBeleska + ", redniBroj=" + redniBroj + ", naslov='" + naslov + '\'' + ", dokument=" + dokument + ", idStudent=" + idStudent + ", idCas=" + idCas + '}';
        }
    }
}
