using PuppeteerSharp;

namespace TesteRelatorioPuppeter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var pdfGenerator = new PdfGenerator();
            await pdfGenerator.GeneratePdfAsync();
        }
    }

    internal class PdfGenerator
    {
        public async Task GeneratePdfAsync()
        {
            try
            {
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true, ExecutablePath = @"\Program Files\Google\Chrome\Application\chrome.exe" });
                var page = await browser.NewPageAsync();

                // Use um caminho relativo para o arquivo HTML
                var htmlFilePath = @"file:///C:/Users/davi.lemos/Desktop/Projetos_C%23/TesteRelatorioPuppeter/bin/Debug/net6.0/SiscomPDFReportTemplateExample.html";
                await page.GoToAsync(htmlFilePath);

                // Gere o PDF
                var pdfFilePath = Path.Combine(@"C:\Users\davi.lemos\Desktop\Projetos_C#\TesteRelatorioPuppeter\bin\Debug\net6.0", "PDFGerado.pdf");
                await page.PdfAsync(pdfFilePath);

                await browser.CloseAsync();
                Console.WriteLine($"PDF gerado em: {pdfFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar o PDF: {ex.Message}");
            }
        }
    }
}