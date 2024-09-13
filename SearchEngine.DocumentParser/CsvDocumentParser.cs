using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.DocumentParser
{
    
public class CsvDocumentParser : DocumentParser
        {
            public override void Parse(Stream documentStream)
            {
                Console.WriteLine("Parsing CSV document...");

                if (documentStream != null)
                {
                    try
                    {
                        using (var reader = new StreamReader(documentStream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                // Process each line of the CSV file
                                Console.WriteLine("Line: " + line);
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("An error occurred while reading the CSV document: " + ex.Message);
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

