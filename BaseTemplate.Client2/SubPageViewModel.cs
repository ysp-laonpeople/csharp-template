using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseTemplate.Client2
{
    public class SubPageViewModel:ReactiveObject
    {
        public event EventHandler OnClickHandler;

        public SubPageViewModel(string title)
        {
            this.Title = title;
            OnClick  = ReactiveCommand.Create<RoutedEventArgs>(e => {
                this.OnClickHandler(this, new TextChangedEventArgs(this.Text));
            });
        }
        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref this.title, value);
            }
        }
        private string output;
        public string Output
        {
            get
            {
                return this.output;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref this.output, value);
            }
        }
        private string text;
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref this.text, value);
            }
        }
        public ReactiveCommand<RoutedEventArgs, Unit> OnClick { get; set; }
    }
    public class TextChangedEventArgs : EventArgs
    {
        
        public string Value { get; private set; }
        public TextChangedEventArgs(string value)
        {            
            this.Value = value;         
        }
    }
}
