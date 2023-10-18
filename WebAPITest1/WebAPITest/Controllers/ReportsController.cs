using FastReport;
using FastReport.Export.Html;
using FastReport.Export.Image;
using System.Threading.Tasks;
using FastReport.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Data;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

using WebAPITest.Model;
using FastReport.Export.PdfSimple;
using System.IO;

namespace FastReportWebApiDemo.Controllers
{


	[Route("api/[controller]")]
	[ApiController]

	public class ReportsControoller : Controller
	{
		private readonly string filePath;
		public ReportsControoller(string filePath)
		{
			this.filePath = filePath;
		}
		[HttpGet]
		public FileResult Get()
		{
			

			return File(System.IO.File.ReadAllBytes(filePath), "application/frx", "People.frx");


		}

	}

	}
