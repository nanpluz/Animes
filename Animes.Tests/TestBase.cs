using Application.Mappers;
using AutoMapper;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

public class TestBase : IDisposable
{
    protected readonly AnimesDbContext _dbContext;
    protected readonly IMapper _mapper;

    public TestBase()
    {
        var options = new DbContextOptionsBuilder<AnimesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // um db por teste
            .Options;

        _dbContext = new AnimesDbContext(options);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AnimeProfile>();
        });

        _mapper = config.CreateMapper();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}