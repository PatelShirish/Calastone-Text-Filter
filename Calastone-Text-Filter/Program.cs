using Calastone_Text_Filter;
using Calastone_Text_Filter.Filters;
public class Program
{
    public static void Main(string[] args)
    {
        string inputFile = "InputFile.txt";
        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Input file '{inputFile}' not found.");
            return;
        }

        // Add required filters
        List<ITextFilter> filters = new List<ITextFilter>
            {
                new VowelInMiddleFilter(),
                new MinimumLengthFilter(),
                new ContainsTFilter()
            };
        TextProcessor processor = new TextProcessor(filters);

        // Process File
        IEnumerable<string> filteredWords = processor.ProcessText(inputFile);

        string result = string.Join(" ", filteredWords);

        Console.WriteLine("Filtered Text:");
        Console.WriteLine(result);
    }
}