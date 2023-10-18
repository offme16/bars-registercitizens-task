using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebAPITest.Model
   
{
	public class People
	{

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public string LastName { get; set; }
		public DateOnly BirthDate { get; set; }

        public string FullName { get => string.Join(" ", Name, SurName, LastName).ToLower().Replace(" ", ""); set => FullName.ToString(); }

    }
}
