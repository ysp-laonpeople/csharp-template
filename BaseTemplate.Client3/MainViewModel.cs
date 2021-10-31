using BaseTemplate.Client3.Helper;
using BaseTemplate.Client3.View;
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

namespace BaseTemplate.Client3
{
    public class MainViewModel:ReactiveObject
    {
        IMessageBus messageContract;
        IDialogService dialogContract;
        ILogger logger;        

        public MainViewModel()
        {
            PathHelper.Init(System.Environment.CurrentDirectory,true);

            messageContract = new MessageBus();
            dialogContract = new DialogService();
                        
            InitLogger();
            Commands();
            Events();
            Subscriptions();
            Messages();
            this.logger.Information($"Loaded Main");
        }

        private void InitLogger()
        {
            this.logger = new LoggerConfiguration()
                .WriteTo.File(PathHelper.LogFilePath, rollingInterval: RollingInterval.Day)
                //.WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();
            Serilog.Log.Logger = this.logger;
        }

        private void Messages()
        {
            this.messageContract.Listen<string>().Subscribe(msg =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Console.WriteLine($"rcv:{msg}");
                }));
            });
        }
        private void Commands()
        {
            this.OnClickCommand = ReactiveCommand.Create(() =>{
                this.dialogContract.ShowMessageBox(this, $"Name is {this.Name}", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                this.dialogContract.Show(this, new StartPageViewModel(this.Name,this.messageContract, this.dialogContract));
            });
        }
        private void Events()
        {
            
        }
        private void Subscriptions()
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
