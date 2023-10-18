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


























		////Класс параметров в запросе
		//public class ReportQuery
		//{
		//	// Format of resulting report: png, pdf, html
		//	public string Format { get; set; }
		//	// Value of "Parameter" variable in report
		//	public string Parameter { get; set; }
		//	// Enable Inline preview in browser (generates "inline" or "attachment")
		//	public bool Inline { get; set; }
		//}

		//public class ReportsController : ApiController
		//{ // Список отчетов
		//	Reports[] reportItems = new Reports[]
		//	{
		//		new Reports { Id = 1, ReportName = "People.frx" },
		//						new Reports { Id = 2, ReportName = "Barcode.frx" }
		//	};

		//	// Получить список отчетов
		//	public IEnumerable<Reports> GetAllReports()
		//	{
		//		return reportItems;
		//	}

		//	// Получить отчет по ID из запроса
		//	public HttpResponseMessage GetReportById(int id, [FromQuery] ReportQuery query)
		//	{
		//		// Найти отчет
		//		Reports reportItem = reportItems.FirstOrDefault((p) => p.Id == id);
		//		if (reportItem != null)
		//		{
		//			string reportPath = Path.Combine("~/People" + reportItem.ReportName);
		//			string dataPath = Path.Combine("~/App_Data/PostgreSQL");
		//			MemoryStream stream = new MemoryStream();
		//			try
		//			{
		//				using (DataSet dataSet = new DataSet())
		//				{
		//					//Заполняем источник данными
		//					dataSet.ReadXml(dataPath);
		//					//Включаем веб режим FastReport
		//					Config.WebMode = true;
		//					using (Report report = new Report())
		//					{
		//						report.Load(reportPath); //Загружаем отчет
		//						report.RegisterData(dataSet, "People"); //Регистрируем данные в отчете
		//						if (query.Parameter != null)
		//						{
		//							report.SetParameterValue("Parameter", query.Parameter); //Устанавливаем значение параметра в отчете. Само значение мы берем из URL
		//						}

		//						// Две фазы подготовки для исключения отображения каких-либо диалогов
		//						report.PreparePhase1();
		//						report.PreparePhase2();

		//						if (query.Format == "pdf")
		//						{
		//							//Экспорт отчета в PDF
		//							PDFExport pdf = new PDFExport();
		//							//Используем поток для хранения отчета, чтобы не плодить файлы
		//							report.Export(pdf, stream);

		//						}
		//						else if (query.Format == "html")
		//						{
		//							//Экспорт отчета в HTML
		//							HTMLExport html = new HTMLExport();
		//							html.SinglePage = true;
		//							html.Navigator = false;
		//							html.EmbedPictures = true;
		//							report.Export(html, stream);
		//						}
		//						else
		//						{
		//							//Экспорт в формат изображения
		//							ImageExport img = new ImageExport();
		//							img.ImageFormat = ImageExportFormat.Png;
		//							img.SeparateFiles = false;
		//							img.ResolutionX = 96;
		//							img.ResolutionY = 96;
		//							report.Export(img, stream);
		//							query.Format = "png";
		//						}
		//					}
		//				}
		//				//создаем результирующую переменную
		//				HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
		//				{
		//					Content = new ByteArrayContent(stream.ToArray())
		//				};

		//				stream.Dispose();

		//				result.Content.Headers.ContentDisposition =
		//				new System.Net.Http.Headers.ContentDispositionHeaderValue(query.Inline ? "inline" : "attachment")
		//				{
		//					//Задаем расширение файла в зависимости от типа экспорта
		//					FileName = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", query.Format)
		//				};
		//				//Определяем тип контента для браузера 
		//				result.Content.Headers.ContentType =
		//				 new MediaTypeHeaderValue("application/" + query.Format);
		//				return result;
		//			}
		//			//Обрабатываем исключения
		//			catch
		//			{
		//				return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		//			}
		//		}
		//		else
		//			return new HttpResponseMessage(HttpStatusCode.NotFound);
		//	}
		//}

	}
