namespace BeleskeBlazor.Client.Data.Model
{
	public class Cas
	{
		private int idCas;
		private int redniBroj;
		private DateOnly date;
		private DateTime vremePocetka;
		private DateTime vremeKraja;
		private int idDrzi;

		public Cas(int idCas, int redniBroj, DateOnly date, DateTime vremePocetka, DateTime vremeKraja, int idDrzi)
		{
			this.idCas = idCas;
			this.redniBroj = redniBroj;
			this.date = date;
			this.vremePocetka = vremePocetka;
			this.vremeKraja = vremeKraja;
			this.idDrzi = idDrzi;
		}

		public Cas()
		{
		}

		public int IdCas
		{
			get { return idCas; }
			set { idCas = value; }
		}

		public int RedniBroj
		{
			get { return redniBroj; }
			set { redniBroj = value; }
		}

		public DateOnly Date
		{
			get { return date; }
			set { date = value; }
		}

		public DateTime VremePocetka
		{
			get { return vremePocetka; }
			set { vremePocetka = value; }
		}

		public DateTime VremeKraja
		{
			get { return vremeKraja; }
			set { vremeKraja = value; }
		}

		public int IdDrzi
		{
			get { return idDrzi; }
			set { idDrzi = value; }
		}

		public override string ToString()
		{
			return "Cas{" + "idCas=" + idCas + ", redniBroj=" + redniBroj + ", date=" + date + ", vremePocetka=" + vremePocetka + ", vremeKraja=" + vremeKraja + ", idDrzi=" + idDrzi + '}';
		}
	}
}
