using System.Transactions;
using Repositories.Interfaces;
using Streetcode.DAL.Persistence;
using Streetcode.DAL.Repositories.Interfaces.AdditionalContent;
using Streetcode.DAL.Repositories.Interfaces.Analytics;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.DAL.Repositories.Interfaces.Media.Images;
using Streetcode.DAL.Repositories.Interfaces.Newss;
using Streetcode.DAL.Repositories.Interfaces.Partners;
using Streetcode.DAL.Repositories.Interfaces.Source;
using Streetcode.DAL.Repositories.Interfaces.Streetcode;
using Streetcode.DAL.Repositories.Interfaces.Streetcode.TextContent;
using Streetcode.DAL.Repositories.Interfaces.Team;
using Streetcode.DAL.Repositories.Interfaces.Timeline;
using Streetcode.DAL.Repositories.Interfaces.Toponyms;
using Streetcode.DAL.Repositories.Interfaces.Transactions;
using Streetcode.DAL.Repositories.Interfaces.Users;
using Streetcode.DAL.Repositories.Realizations.AdditionalContent;
using Streetcode.DAL.Repositories.Realizations.Analytics;
using Streetcode.DAL.Repositories.Realizations.Media;
using Streetcode.DAL.Repositories.Realizations.Media.Images;
using Streetcode.DAL.Repositories.Realizations.Newss;
using Streetcode.DAL.Repositories.Realizations.Partners;
using Streetcode.DAL.Repositories.Realizations.Source;
using Streetcode.DAL.Repositories.Realizations.Streetcode;
using Streetcode.DAL.Repositories.Realizations.Streetcode.TextContent;
using Streetcode.DAL.Repositories.Realizations.Team;
using Streetcode.DAL.Repositories.Realizations.Timeline;
using Streetcode.DAL.Repositories.Realizations.Toponyms;
using Streetcode.DAL.Repositories.Realizations.Transactions;
using Streetcode.DAL.Repositories.Realizations.Users;

namespace Streetcode.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly StreetcodeDbContext _streetcodeDbContext;

    private IVideoRepository _videoRepository;

    private IAudioRepository _audioRepository;

    private IStreetcodeCoordinateRepository _streetcodeCoordinateRepository;

    private IImageRepository _imageRepository;

    private IImageDetailsRepository _imageDetailsRepository;

    private IArtRepository _artRepository;

    private IStreetcodeArtRepository _streetcodeArtRepository;

    private IFactRepository _factRepository;

    private IPartnersRepository _partnersRepository;

    private ISourceCategoryRepository _sourceCategoryRepository;

    private IStreetcodeCategoryContentRepository _streetcodeCategoryContentRepository;

    private IRelatedFigureRepository _relatedFigureRepository;

    private IRelatedTermRepository _relatedTermRepository;

    private IStreetcodeRepository _streetcodeRepository;

    private ISubtitleRepository _subtitleRepository;

    private IStatisticRecordRepository _statisticRecordRepository;

    private ITagRepository _tagRepository;

    private ITermRepository _termRepository;

    private ITeamRepository _teamRepository;

    private IPositionRepository _positionRepository;

    private ITextRepository _textRepository;

    private ITimelineRepository _timelineRepository;

    private IToponymRepository _toponymRepository;

    private ITransactLinksRepository _transactLinksRepository;

    private IHistoricalContextRepository _historyContextRepository;

    private IPartnerSourceLinkRepository _partnerSourceLinkRepository;

    private IUserRepository _userRepository;

    private IStreetcodeTagIndexRepository _streetcodeTagIndexRepository;

    private IPartnerStreetcodeRepository _partnerStreetcodeRepository;

    private INewsRepository _newsRepository;

    private ITeamLinkRepository _teamLinkRepository;

    private ITeamPositionRepository _teamPositionRepository;

    private IHistoricalContextTimelineRepository _historicalContextTimelineRepository;

    private IStreetcodeToponymRepository _streetcodeToponymRepository;

    private IStreetcodeImageRepository _streetcodeImageRepository;

    public RepositoryWrapper(StreetcodeDbContext streetcodeDbContext)
    {
        _streetcodeDbContext = streetcodeDbContext;
    }

    public INewsRepository NewsRepository =>
          GetRepository((NewsRepository)_newsRepository);

    public IFactRepository FactRepository =>
          GetRepository((FactRepository)_factRepository);

    public IImageRepository ImageRepository =>
          GetRepository((ImageRepository)_imageRepository);

    public ITeamRepository TeamRepository =>
          GetRepository((TeamRepository)_teamRepository);

    public ITeamPositionRepository TeamPositionRepository =>
          GetRepository((TeamPositionRepository)_teamPositionRepository);

    public IAudioRepository AudioRepository =>
          GetRepository((AudioRepository)_audioRepository);

    public IStreetcodeCoordinateRepository StreetcodeCoordinateRepository =>
          GetRepository((StreetcodeCoordinateRepository)_streetcodeCoordinateRepository);

    public IVideoRepository VideoRepository =>
          GetRepository((VideoRepository)_videoRepository);

    public IArtRepository ArtRepository =>
          GetRepository((ArtRepository)_artRepository);

    public IStreetcodeArtRepository StreetcodeArtRepository =>
          GetRepository((StreetcodeArtRepository)_streetcodeArtRepository);

    public IPartnersRepository PartnersRepository =>
          GetRepository((PartnersRepository)_partnersRepository);

    public ISourceCategoryRepository SourceCategoryRepository =>
          GetRepository((SourceCategoryRepository)_sourceCategoryRepository);

    public IStreetcodeCategoryContentRepository StreetcodeCategoryContentRepository =>
          GetRepository((StreetcodeCategoryContentRepository)_streetcodeCategoryContentRepository);

    public IRelatedFigureRepository RelatedFigureRepository =>
          GetRepository((RelatedFigureRepository)_relatedFigureRepository);

    public IStreetcodeRepository StreetcodeRepository =>
          GetRepository((StreetcodeRepository)_streetcodeRepository);

    public ISubtitleRepository SubtitleRepository =>
          GetRepository((SubtitleRepository)_subtitleRepository);

    public IStatisticRecordRepository StatisticRecordRepository =>
          GetRepository((StatisticRecordsRepository)_statisticRecordRepository);

    public ITagRepository TagRepository =>
          GetRepository((TagRepository)_tagRepository);

    public ITermRepository TermRepository =>
          GetRepository((TermRepository)_termRepository);

    public ITextRepository TextRepository =>
          GetRepository((TextRepository)_textRepository);

    public ITimelineRepository TimelineRepository =>
          GetRepository((TimelineRepository)_timelineRepository);

    public IToponymRepository ToponymRepository =>
          GetRepository((ToponymRepository)_toponymRepository);

    public ITransactLinksRepository TransactLinksRepository =>
          GetRepository((TransactLinksRepository)_transactLinksRepository);

    public IHistoricalContextRepository HistoricalContextRepository =>
          GetRepository((HistoricalContextRepository)_historyContextRepository);

    public IPartnerSourceLinkRepository PartnerSourceLinkRepository =>
          GetRepository((PartnersourceLinksRepository)_partnerSourceLinkRepository);

    public IRelatedTermRepository RelatedTermRepository =>
          GetRepository((RelatedTermRepository)_relatedTermRepository);

    public IUserRepository UserRepository =>
          GetRepository((UserRepository)_userRepository);

    public IStreetcodeTagIndexRepository StreetcodeTagIndexRepository =>
          GetRepository((StreetcodeTagIndexRepository)_streetcodeTagIndexRepository);

    public IPartnerStreetcodeRepository PartnerStreetcodeRepository =>
        GetRepository((PartnerStreetodeRepository)_partnerStreetcodeRepository);

    public IPositionRepository PositionRepository =>
        GetRepository((PositionRepository)_positionRepository);

    public ITeamLinkRepository TeamLinkRepository =>
          GetRepository((TeamLinkRepository)_teamLinkRepository);

    public IImageDetailsRepository ImageDetailsRepository =>
        GetRepository((ImageDetailsRepository)_imageDetailsRepository);

    public IHistoricalContextTimelineRepository HistoricalContextTimelineRepository =>
        GetRepository((HistoricalContextTimelineRepository)_historicalContextTimelineRepository);

    public IStreetcodeToponymRepository StreetcodeToponymRepository =>
        GetRepository((StreetcodeToponymRepository)_streetcodeToponymRepository);

    public IStreetcodeImageRepository StreetcodeImageRepository =>
        GetRepository((StreetcodeImageRepository)_streetcodeImageRepository);

    public T GetRepository<T>(T repo)
     where T : IDbConextForRepositoryBase, new()
    {
        if (repo is null)
        {
            repo = new T();
            repo.DbContext = _streetcodeDbContext;
        }

        return repo;
    }

    public int SaveChanges()
    {
        return _streetcodeDbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _streetcodeDbContext.SaveChangesAsync();
    }

    public TransactionScope BeginTransaction()
    {
        return new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    }
}
