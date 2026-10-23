namespace DocumentNumberCalculator.Serivce
{
    public record struct DocumentNumberOptions(char separator, params string[] values);
}