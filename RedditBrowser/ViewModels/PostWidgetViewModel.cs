

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

        // ���ܵ��Ǵ���һ��Widget���������Ա仯����Ϣ, 
        // ֮��������������Ϣ������Ϊ�˱�������.

        // The handlers for the declared messages will be added automatically
        // by the ObservableRecipient class
        // when the IsActive property is set to true. 

        /// <summary>
        /// ��SubredditWidgetViewModel��SelectedPost���Է����˱仯,
        /// �����Widget����ʾ��Ӧ������ָʾ������.
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