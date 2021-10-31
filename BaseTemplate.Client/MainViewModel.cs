using BaseTemplate.Client.View;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseTemplate.Client
{
    public class MainViewModel : BaseViewModel, IBaseViewModel
    {
        public MainViewModel(string contractId)
            : base(contractId)
        {

            Events();
            Subscribe();
            Messages();
        }

        public void Events()
        {
            
        }


        public void Messages()
        {
            this.Disposer.Add(this.MessageContract.Listen<string>().Subscribe(msg => {
                Console.WriteLine($"string msg:{msg}");
            }));
            this.Disposer.Add(this.MessageContract.Listen<BaseViewModel>().Subscribe(msg => {
                Console.WriteLine($"BaseViewModel msg:{msg.ContractID}");
            }));
        }

        public void Subscribe()
        {
            
        }

        public void Commands()
        {
            this.OnClick = ReactiveCommand.Create(() => {
                
            });
            this.OnStopCommand = ReactiveCommand.Create<EventArgs>(e => {
                Console.WriteLine($"OnStopCommand");
            });
            this.OnLoaded = ReactiveCommand.Create<RoutedEventArgs>(e => {
                Console.WriteLine($"OnLoaded");
            });
        }

        public ReactiveCommand<Unit, Unit> OnClick { get; set; }
        public ReactiveCommand<EventArgs, Unit> OnStopCommand { get; set; }
        public ReactiveCommand<RoutedEventArgs, Unit> OnLoaded { get; set; }
        
    }
}
