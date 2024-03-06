namespace BeleskeBlazor.Client.Data.Model
{

	public class Student
	{
		public int idStudent;
		public string ime;
		public string prezime;

		public Student(int idStudent, string ime, string prezime)
		{
			this.idStudent = idStudent;
			this.ime = ime;
			this.prezime = prezime;
		}

		public Student()
		{
		}

		public int IdStudent
		{
			get { return idStudent; }
			set { idStudent = value; }
		}

		public string Ime
		{
			get { return ime; }
			set { ime = value; }
		}

		public string Prezime
		{
			get { return prezime; }
			set { prezime = value; }
		}

		public override string ToString()
		{
			return "Student{" + "idStudent=" + idStudent + ", ime='" + ime + '\'' + ", prezime='" + prezime + '\'' + '}';
		}
	}
}
