namespace BeleskeBlazor.Client.Data.Model
{
	public class Profesor
	{
		private int idProfesor;
		private String ime;
		private String prezime;

		public Profesor()
		{
		}

		public Profesor(int idProfesor, String ime, String prezime)
		{
			this.idProfesor = idProfesor;
			this.ime = ime;
			this.prezime = prezime;
		}
		public int getIdProfesor()
		{
			return idProfesor;
		}
		public void setIdProfesor(int idProfesor)
		{
			this.idProfesor = idProfesor;
		}
		public String getIme()
		{
			return ime;
		}

		public void setIme(String ime)
		{
			this.ime = ime;
		}

		public String getPrezime()
		{
			return prezime;
		}

		public void setPrezime(String prezime)
		{
			this.prezime = prezime;
		}

		public override String ToString()
		{
			return "Profesor{" + "idProfesor=" + idProfesor + ", ime=" + ime + ", prezime=" + prezime + '}';
		}
	}
}
