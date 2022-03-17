using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication3.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow(string OldRegex) : this()
        {
            this.FindControl<TextBox>("RegexInput").Text = OldRegex;
        }

        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("RegexOk").Click += delegate
            {
                var regexStr = this.FindControl<TextBox>("RegexInput").Text;
                if (regexStr != null)
                    Close(regexStr);
                else
                    Close("");
            };

            this.FindControl<Button>("RegexCancel").Click += delegate
            {
                Close("");
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
