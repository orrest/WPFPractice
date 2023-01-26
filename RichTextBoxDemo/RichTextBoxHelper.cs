using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace RichTextBoxDemo
{
    public class RichTextBoxHelper
    {
        public static string GetDocumentXaml(DependencyObject obj) 
        { 
            return (string)obj.GetValue(DocumentXamlProperty); 
        }

        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }

        public static readonly DependencyProperty DocumentXamlProperty = DependencyProperty.RegisterAttached
        (
            "DocumentXaml",
            typeof(string),
            typeof(RichTextBoxHelper),
            new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = (obj, e) =>
                {
                    var richTextBox = (RichTextBox)obj;
                    var xaml = GetDocumentXaml(richTextBox);
                    Stream sm = new MemoryStream(Encoding.UTF8.GetBytes(xaml));
                    richTextBox.Document = (FlowDocument)XamlReader.Load(sm);
                    sm.Close();
                }
            }
        );
    }
}
