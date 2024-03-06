namespace BeleskeBlazor.Client.Data.Model
{
	public class Predmet
	{
		private int idPredmet;
		private String naziv;

		public Predmet()
		{
		}

		public Predmet(int idPredmet, String naziv)
		{
			this.idPredmet = idPredmet;
			this.naziv = naziv;
		}

		public int IdPredmet
		{
			get { return idPredmet; }
			set { idPredmet = value; }
		}

		public String Naziv
		{
			get { return naziv; }
			set { naziv = value; }
		}

		public override String ToString()
		{
			return "Predmet{" + "idPredmet=" + idPredmet + ", naziv=" + naziv + '}';
		}

	}
}
