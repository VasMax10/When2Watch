using System.Threading.Tasks;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Repositories;

namespace When2Watch.DAL.Database.Tools
{
    public class EFUnitOfWork : ApplicationContext, IUnitOfWork
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IEpisodeStatusRepository _episodeStatusRepository;
        private readonly IFriendRepository _friendRepository;
        private readonly IFriendshipRequestRepository _friendshipRequestRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWatchlistRepository _watchlistRepository;

        public EFUnitOfWork()
        {
            _commentRepository = new CommentRepository(this);
            _episodeRepository = new EpisodeRepository(this);
            _episodeStatusRepository = new EpisodeStatusRepository(this);
            _friendRepository = new FriendRepository(this);
            _friendshipRequestRepository = new FriendshipRequestRepository(this);
            _messageRepository = new MessageRepository(this);
            _seasonRepository = new SeasonRepository(this);
            _seriesRepository = new SeriesRepository(this);
            _userRepository = new UserRepository(this);
            _watchlistRepository = new WatchlistRepository(this);
        }

        public ICommentRepository CommentRepository => _commentRepository;
        public IEpisodeRepository EpisodeRepository => _episodeRepository;
        public IEpisodeStatusRepository EpisodeStatusRepository => _episodeStatusRepository;
        public IFriendRepository FriendRepository => _friendRepository;
        public IFriendshipRequestRepository FriendshipRequestRepository => _friendshipRequestRepository;
        public IMessageRepository MessageRepository => _messageRepository;
        public ISeasonRepository SeasonRepository => _seasonRepository;
        public ISeriesRepository SeriesRepository => _seriesRepository;
        public IUserRepository UserRepository => _userRepository;
        public IWatchlistRepository WatchlistRepository => _watchlistRepository;

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
