using BaseTemplate.Client4.Message;
using MvvmDialogs;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseTemplate.Client4.View
{
    public class SubPageViewModel:ReactiveObject
    {        
        IMessageBus messageContract;
        IDialogService dialogContract;
        ILogger logger = Serilog.Log.Logger;

        public SubPageViewModel(string contractID, IMessageBus messageContract, IDialogService dialogContract)
        {
            
            this.Title = contractID;
            this.messageContract = messageContract;
            this.dialogContract = dialogContract;

            Commands();
            Events();
            Subscriptions();
            Messages();
            logger.Information($"Loaded SubPage {contractID}");
        }
    
        private void Messages()
        {
            this.messageContract.Listen<ChangedText>().Subscribe(msg => {
                this.Output = msg.Value;
            });
        }
        private void Commands()
        {
            OnClickCommand = ReactiveCommand.Create<RoutedEventArgs>(e => {
                Output = Text;
                Task.Run(() =>
                {
                    this.IsBusy = true;
                    this.Description = $"Loading.. {this.Title}";
                    System.Threading.Thread.Sleep(3000);
                    this.messageContract.SendMessage(new ChangedText(Text));
                    this.IsBusy = false;
                });                
            });
        }
        private void Events()
        {

        }
        private void Subscriptions()
        {

        }
        private string title;
        public string Title
        {
            get=>this.title;
            set => this.RaiseAndSetIfChanged(ref this.title, value);            
        }
        private string output;
        public string Output
        {
            get => this.output;
            set=>this.RaiseAndSetIfChanged(ref this.output, value);
        }
        private string text;
        public string Text
        {
            get => this.text;
            set=>this.RaiseAndSetIfChanged(ref this.text, value);            
        }
        private bool isBusy = false;
        public bool IsBusy
        {
            get => this.isBusy;
            set => this.RaiseAndSetIfChanged(ref this.isBusy, value);
        }
        private string description;
        public string Description
        {
            get => this.description;
            set => this.RaiseAndSetIfChanged(ref this.description, value);
        }
        public ReactiveCommand<RoutedEventArgs, Unit> OnClickCommand { get; set; }
    }
    
}
