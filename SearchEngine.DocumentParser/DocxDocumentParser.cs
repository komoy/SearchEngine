using SearchEngine.DocumentParser;
using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

public class DocxDocumentParser : DocumentParser
{
    public override void Parse(Stream documentStream)
    {
        Console.WriteLine("Parsing DOCX document...");

        if (documentStream != null)
        {
            try
            {
                using (var zipArchive = new ZipArchive(documentStream))
                {
                    var documentPart = zipArchive.GetEntry("word/document.xml");
                    if (documentPart != null)
                    {
                        using (var entryStream = documentPart.Open())
                        using (var xmlReader = XmlReader.Create(entryStream))
                        {
                            while (xmlReader.Read())
                            {
                                if (xmlReader.NodeType == XmlNodeType.Element)
                                {
                                    Console.WriteLine("Element: " + xmlReader.Name);
                                }
                                else if (xmlReader.NodeType == XmlNodeType.Text)
                                {
                                    Console.WriteLine("Text: " + xmlReader.Value);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The DOCX file does not contain a document.xml part.");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading the DOCX document: " + ex.Message);
            }
            catch (XmlException ex)
            {
                Console.WriteLine("An error occurred while parsing the DOCX XML: " + ex.Message);
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
