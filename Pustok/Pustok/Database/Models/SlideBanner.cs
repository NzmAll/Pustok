namespace Pustok.Database.Models;

public class SlideBanner
{
    private static int _idCounter = 1;

    public SlideBanner(string title, string description, string redirectionUrl, int order)
        : this(null, title, description, redirectionUrl, order) { }

    public SlideBanner(string offer, string title, string description, string redirectionUrl, int order)
    {
        Id = _idCounter++;
        Offer = offer;
        Title = title;
        Description = description;
        RedirectionUrl = redirectionUrl;
        Order = order;
    }

    public int Id { get; set; }
    public string Offer { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RedirectionUrl { get; set; }
    public int Order { get; set; }
}
