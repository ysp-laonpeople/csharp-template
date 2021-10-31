using BaseTemplate.Client5.Common;
using BaseTemplate.Client5.Message;
using MahApps.Metro.Controls;
using MvvmDialogs;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BaseTemplate.Client5.View
{
    public class StartPageViewModel:BaseViewModel, IBaseViewModel
    {
        public ObservableCollection<BaseViewModel> Workspaces { get; set; }


        public StartPageViewModel(string contractID,IMessageBus messageContract, IDialogService dialogContract):base()
        {
            this.Title = contractID;
            this.MessageContract = messageContract;
            this.DialogContract = dialogContract;

            this.Workspaces = new ObservableCollection<BaseViewModel>();            
            this.Workspaces.Add(new SubPageViewModel(nameof(SubPageViewModel), messageContract, dialogContract));            
            this.Workspaces.Add(new Sub2PageViewModel(nameof(Sub2PageViewModel), messageContract, dialogContract));

            this.CurrentViewModel = this.Workspaces[0];
            Commands();
            Events();
            Subscriptions();
            Messages();
            Logger.Information($"Loaded StartPage {contractID}");
        }
        public void Messages()
        {
            
        }
        public void Commands()
        {
            
        }
        public void Events()
        {

        }
        public void Subscriptions()
        {
       
            this.WhenAnyValue(g => g.SelectedItem).WhereNotNull().Subscribe(x => {
                //int index = 0;
                //if(int.TryParse(x.Tag.ToString(), out index))
                //    this.CurrentViewModel = this.Workspaces[index];
                this.CurrentViewModel = this.Workspaces.Where(g => g.GetType().Name == x.Tag.ToString()).FirstOrDefault();
            });
        }
        private string title;
        public string Title
        {
            get => this.title;
            set => this.RaiseAndSetIfChanged(ref this.title, value);
        }

        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => this.currentViewModel;
            set => this.RaiseAndSetIfChanged(ref this.currentViewModel, value);
        }

        private HamburgerMenuItem selectedItem;
        public HamburgerMenuItem SelectedItem
        {
            get => this.selectedItem;
            set => this.RaiseAndSetIfChanged(ref this.selectedItem, value);
        }


    }
}
