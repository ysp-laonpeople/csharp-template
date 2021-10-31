using BaseTemplate.Client3.Message;
using MvvmDialogs;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BaseTemplate.Client3.View
{
    public class StartPageViewModel:ReactiveObject
    {
        IMessageBus messageContract;
        IDialogService dialogContract;
        ILogger logger = Serilog.Log.Logger;

        public StartPageViewModel(string contractID,IMessageBus messageContract, IDialogService dialogContract)
        {
            this.Title = contractID;
            this.messageContract = messageContract;
            this.dialogContract = dialogContract;

            this.Workspaces = new ObservableCollection<SubPageViewModel>();
            for (int i = 0; i < 50; i++)
            {
                var subPage = new SubPageViewModel(i.ToString(),messageContract,dialogContract);                
                this.Workspaces.Add(subPage);
            }

            Commands();
            Events();
            Subscriptions();
            Messages();
            logger.Information($"Loaded StartPage {contractID}");
        }
        private void Messages()
        {
            
        }
        private void Commands()
        {
            
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
            get => this.title;
            set => this.RaiseAndSetIfChanged(ref this.title, value);
        }
        public ObservableCollection<SubPageViewModel> Workspaces { get; set; }

        
    }
}
