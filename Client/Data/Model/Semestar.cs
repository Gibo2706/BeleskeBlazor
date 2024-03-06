namespace BeleskeBlazor.Client.Data.Model
{
	public class Semestar
	{
		private int idSemestar;
		private String broj;

		public Semestar()
		{
		}

		public Semestar(int idSemestar, String broj)
		{
			this.idSemestar = idSemestar;
			this.broj = broj;
		}

		public int IdSemestar
		{
			get { return idSemestar; }
			set { idSemestar = value; }
		}

		public String Broj
		{
			get { return broj; }
			set { broj = value; }
		}

		public override String ToString()
		{
			return "Semestar{" + "idSemestar=" + idSemestar + ", broj=" + broj + '}';
		}
	}
}
