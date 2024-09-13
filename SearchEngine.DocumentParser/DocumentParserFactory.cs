namespace SearchEngine.DocumentParser
{
    // Factory class to create the appropriate parser based on document type
    public static class DocumentParserFactory
    {
        public static DocumentParser CreateParser(string documentType)
        {
            switch (documentType.ToLower())
            {
                case "pdf":
                    return new PdfDocumentParser();
                case "docx":
                    return new DocxDocumentParser();
                case "txt":
                    return new TxtDocumentParser();
                default:
                    throw new NotSupportedException($"Document type '{documentType}' is not supported.");
            }
        }
    }




}