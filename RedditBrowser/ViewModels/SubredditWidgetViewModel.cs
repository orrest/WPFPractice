using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using RedditBrowser.Models;
using RedditBrowser.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RedditBrowser.ViewModels
{
    // ObservableRecipient可以接收IMessage, 同时也是个ObservableObject
    // 如果用注解的话就要加 partial
    partial class SubredditWidgetViewModel : ObservableRecipient
    {

        // We can use the AsyncRelayCommand type
        // to wrap a private method that will
        // fetch the posts from Reddit.
        // 用AsyncRelayCommand来包裹耗时方法, 网络, 文件.

        // 如果一些属性不需要更新, 那么它没必要是Observable的.

        // ---

        private readonly IRedditService RedditService;

        public SubredditWidgetViewModel(IRedditService redditService)
        {
            this.RedditService = redditService;
            this.selectedSubreddit = Subreddits[0];
        }

        /// <summary>
        /// Gets the collection of loaded posts.
        /// </summary>
        public ObservableCollection<Post> Posts { get; } = new ObservableCollection<Post>();

        /// <summary>
        /// Gets the collection of available subreddits to pick from.
        /// </summary>
        public IReadOnlyList<string> Subreddits { get; } = new[]
        {
            "microsoft",
            "windows",
            "surface",
            "windowsphone",
            "dotnet",
            "csharp"
        };

        [ObservableProperty]
        private string selectedSubreddit;

        [ObservableProperty]
        private Post selectedPost;

        partial void OnSelectedPostChanged(global::RedditBrowser.Models.Post value)
        {
            WeakReferenceMessenger.Default.Send(
                new PropertyChangedMessage<Post>(this, "SelectedPost", null, value)
            );
        }


        /// <summary>
        /// Loads the posts from a specified subreddit.
        /// </summary>
        [RelayCommand]
        private async Task LoadPostsAsync()
        {
            try
            {
                var response = await RedditService.GetSubredditPostsAsync(SelectedSubreddit);

                Posts.Clear();

                foreach (var item in response.Data.Items)
                {
                    Posts.Add(item.Data);
                }
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
