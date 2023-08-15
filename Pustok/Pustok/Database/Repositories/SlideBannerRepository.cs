using Pustok.Database.Models;

namespace Pustok.Database.Repositories;

public class SlideBannerRepository
{
    private static readonly List<SlideBanner> _slideBanners = new List<SlideBanner>();

    static SlideBannerRepository()
    {
        _slideBanners.Add(new SlideBanner("24 % off 07.08.2023", "NEW PLANT", "This is description", "Social media master", 4));
        _slideBanners.Add(new SlideBanner("25% off for whole", "NEW PLANT", "This is description", "Ilham", 2));
        _slideBanners.Add(new SlideBanner("NEW PLANT", "This is Detective", "Detective author", 3));
        _slideBanners.Add(new SlideBanner("The adventure of heyder?", "This is description", "Heyder", 1));
    }

    public List<SlideBanner> GetAll()
    {
        return _slideBanners;
    }

    public void Insert(SlideBanner slideBanner)
    {
        _slideBanners.Add(slideBanner);
    }

    public SlideBanner GetById(int id)
    {
        return _slideBanners.FirstOrDefault(b => b.Id == id);
    }

    public void RemoveById(int id)
    {
        _slideBanners.RemoveAll(b => b.Id == id);
    }
}
