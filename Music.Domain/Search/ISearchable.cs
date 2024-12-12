using System.Text.RegularExpressions;

namespace Music.Domain.Search;

public interface ISearchable
{
    public bool Preproccess(Request request);
    public string GetTarget();

    public bool Search(Request request)
    {
        if(!Preproccess(request)) return false;
        if(request.SearchText == null) return false;
        var separator = new Regex(@"[\s-]");
        var searchLines = separator.Split(request.SearchText);
        var titleLines = separator.Split(GetTarget());
        return searchLines.Intersect(titleLines).Any();
    }
}