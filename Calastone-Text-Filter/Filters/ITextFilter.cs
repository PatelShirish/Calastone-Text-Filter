namespace Calastone_Text_Filter.Filters
{
    public interface ITextFilter
    {
        bool ShouldFilter(string word);
    }
}
