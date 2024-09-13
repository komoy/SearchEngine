using SearchEngine.DocumentParser;
using System;
using System.IO;

public class PdfDocumentParser : DocumentParser
{
    public override void Parse(Stream documentStream)
    {
        Console.WriteLine("Parsing PDF document...");

        if (documentStream != null)
        {
            try
            {
                using (var reader = new StreamReader(documentStream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("Content:");
                    Console.WriteLine(content);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading the PDF document: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("The document stream is null.");
        }
    }
}
