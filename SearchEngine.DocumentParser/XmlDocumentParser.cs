using System.Xml;

namespace SearchEngine.DocumentParser
{
    public class XmlDocumentParser : DocumentParser
    {
        public override void Parse(Stream documentStream)
        {
            Console.WriteLine("Parsing XML document...");

            if (documentStream != null)
            {
                try
                {
                    using (var reader = XmlReader.Create(documentStream))
                    {
                        while (reader.Read())
                        {
                            // Process XML content
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                Console.WriteLine("Element: " + reader.Name);
                            }
                            else if (reader.NodeType == XmlNodeType.Text)
                            {
                                Console.WriteLine("Text: " + reader.Value);
                            }
                        }
                    }
                }
                catch (XmlException ex)
                {
                    Console.WriteLine("An error occurred while parsing the XML document: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred while reading the XML document: " + ex.Message);
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





}