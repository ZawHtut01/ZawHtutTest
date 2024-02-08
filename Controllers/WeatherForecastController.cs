
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ZawHtutTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GenerateFile")]
        public IActionResult GeneratePDF()
        {
            return Ok();
        }

        [HttpGet("CreateAndDownloadPDF")]
        public async Task<IActionResult> CreateAndDownloadPdf()
        {
            // Create memory stream to hold PDF data
            using (var memoryStream = new MemoryStream())
            {
                // Create a new document
                var document = new Document(PageSize.A4);

                // Set output stream
                var pdfWriter = PdfWriter.GetInstance(document, memoryStream);

                // Open the document
                document.Open();

                // Add content, e.g., paragraphs, images, tables
                // (Replace with your desired content generation logic)
                Paragraph para = new Paragraph("This is an auto-generated PDF report");
                document.Add(para);

                // Close the document
                document.Close();

                // Set response headers for PDF download
                Response.ContentType = "application/pdf";
                Response.Headers.Add("Content-Disposition", "attachment; filename=my-report.pdf");

                // Write PDF data to a temporary memory stream
                using (var tempMemoryStream = new MemoryStream(memoryStream.ToArray()))
                {
                    // Copy the data from the temporary memory stream to the response body
                    tempMemoryStream.Seek(0, SeekOrigin.Begin);
                    await tempMemoryStream.CopyToAsync(Response.Body);
                }

                // Flush and close response
                await Response.Body.FlushAsync();
            }

            return Ok();
        }


    }
}
