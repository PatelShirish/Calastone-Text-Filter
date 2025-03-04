namespace Calastone_Text_Filter.Filters
{
    public class MinimumLengthFilter : ITextFilter
    {
        public bool ShouldFilter(string word)
        {
            return word.Length < 3;
        }
    }
}
