using BaseTemplate.Client5.Common;
using BaseTemplate.Client5.Helper;
using BaseTemplate.Client5.View;
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

namespace BaseTemplate.Client5
{
    public class MainViewModel: BaseViewModel, IBaseViewModel
    { 

        public MainViewModel():base()
        {
            PathHelper.Init(System.Environment.CurrentDirectory,true);
            
            MessageContract = new MessageBus();
            DialogContract = new DialogService();
                        
            InitLogger();
            Commands();
            Events();
            Subscriptions();
            Messages();
            this.Logger.Information($"Loaded Main");
        }

        private void InitLogger()
        {
            this.Logger = new LoggerConfiguration()
                .WriteTo.File(PathHelper.LogFilePath, rollingInterval: RollingInterval.Day)
                //.WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();
        }

        public void Messages()
        {
            this.MessageContract.Listen<string>().Subscribe(msg =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Console.WriteLine($"rcv:{msg}");
                }));
            });
        }
        public void Commands()
        {
            this.OnClickCommand = ReactiveCommand.Create(() =>{
                this.DialogContract.ShowMessageBox(this, $"Name is {this.Name}", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                this.DialogContract.Show(this, new StartPageViewModel(this.Name,this.MessageContract, this.DialogContract));
            });
        }
        public void Events()
        {
            
        }
        public void Subscriptions()
        {
            this.WhenAnyValue(g => g.Name).WhereNotNull().Subscribe(x => {
                this.ToolTipName = $"length:{x.Length}";
            });
        }
                

        private string name;
        public string Name
        {
            get=> this.name;
            set=> this.RaiseAndSetIfChanged(ref this.name, value);
        }
        private string toolTipName;
        public string ToolTipName
        {
            get => this.toolTipName;
            set => this.RaiseAndSetIfChanged(ref this.toolTipName, value);
        }
        public ReactiveCommand<Unit, Unit> OnClickCommand { get; set; }
    }
}
