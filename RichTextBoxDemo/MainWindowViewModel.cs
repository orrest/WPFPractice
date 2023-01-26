using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Documents;

namespace RichTextBoxDemo
{
    public partial class MainWindowViewModel: ObservableObject
    {
        [ObservableProperty]
        public string autobiography = string.Empty;

        public MainWindowViewModel()
        {
            Autobiography = @"<FlowDocument xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""><Paragraph><Bold>Hello World!</Bold></Paragraph></FlowDocument>"; ;
        }
    }
}
