namespace BeleskeBlazor.Client.Data.Model
{
	public class Beleska
	{
		private int idBeleska;
		private int redniBroj { get; set; }
		private string naslov { get; set; }
		private byte[] dokument { get; set; }
		private int idStudent { get; set; }
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
