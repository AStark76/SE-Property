namespace DocumentNumberCalculator.Serivce
{
    public class DocumentNumberComputer : IComputerDocumentNumbers
    {
        public string ComputeDocumentNumber(DocumentNumberOptions options)
        {
            if (options.values == null || options.values.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(options.separator, options.values);
        }
    }
}
