namespace SearchEngine.DocumentParser
{
    // Concrete implementation for TXT documents
    public class TxtDocumentParser : DocumentParser
    {
        public override void Parse(Stream documentStream)
        {
            Console.WriteLine("Parsing Text document...");
            if (documentStream != null)
            {
                try
                {
                    using (var reader = new StreamReader(documentStream))
                    {
                        // Optionally, check if the stream length is greater than zero
                        if (documentStream.Length > 0)
                        {
                            string content = reader.ReadToEnd();
                            Console.WriteLine("Content:");
                            Console.WriteLine(content);
                        }
                        else
                        {
                            Console.WriteLine("The document stream is empty.");
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("An error occurred while reading the document: " + ex.Message);
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