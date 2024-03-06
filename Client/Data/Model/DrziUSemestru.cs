namespace BeleskeBlazor.Client.Data.Model
{
	public class DrziUSemestru
	{
		private int idDrzi;
		private int idProfesor;
		private int idPredmet;
		private int idSemestar;

		public DrziUSemestru(int idDrzi, int idProfesor, int idPredmet, int idSemestar)
		{
			this.idDrzi = idDrzi;
			this.idProfesor = idProfesor;
			this.idPredmet = idPredmet;
			this.idSemestar = idSemestar;
		}

		public int IdDrzi { get => idDrzi; set => idDrzi = value; }

		public int IdProfesor { get => idProfesor; set => idProfesor = value; }

		public int IdPredmet { get => idPredmet; set => idPredmet = value; }

		public int IdSemestar { get => idSemestar; set => idSemestar = value; }

		public override string ToString()
		{
			return "DrziUSemestru{" +
				"idDrzi=" + idDrzi +
				", idProfesor=" + idProfesor +
				", idPredmet=" + idPredmet +
				", idSemestar=" + idSemestar +
				'}';
		}

		public override bool Equals(object o)
		{
			if (this == o) return true;
			if (o == null || GetType() != o.GetType()) return false;

			DrziUSemestru that = (DrziUSemestru)o;

			if (idDrzi != that.idDrzi) return false;
			if (idProfesor != that.idProfesor) return false;
			if (idPredmet != that.idPredmet) return false;
			return idSemestar == that.idSemestar;
		}
	}
}
