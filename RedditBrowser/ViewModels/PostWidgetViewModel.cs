

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using RedditBrowser.Models;

namespace RedditBrowser.ViewModels
{
    partial class PostWidgetViewModel : ObservableRecipient, 
        IRecipient<PropertyChangedMessage<Post>>
    {
        [ObservableProperty]
        private Post post;

        public PostWidgetViewModel()
        {
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        // 接受的是从另一个Widget传来的属性变化的消息, 
        // 之所以利用这种消息机制是为了避免依赖.

        // The handlers for the declared messages will be added automatically
        // by the ObservableRecipient class
        // when the IsActive property is set to true. 

        /// <summary>
        /// 当SubredditWidgetViewModel的SelectedPost属性发生了变化,
        /// 在这个Widget中显示相应标题所指示的内容.
        /// </summary>
        /// <param name="message"></param>
        public void Receive(PropertyChangedMessage<Post> message)
        {
            if (message.Sender.GetType() == typeof(SubredditWidgetViewModel) &&
                message.PropertyName == nameof(SubredditWidgetViewModel.SelectedPost))
            {
                Post = message.NewValue;
            }
        }
    }
}