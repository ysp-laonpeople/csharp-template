using MvvmDialogs;
using ReactiveUI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Client5.Common
{
    public class BaseViewModel: ReactiveObject,IDisposable
    {
        public IMessageBus MessageContract { get; set; }
        public IDialogService DialogContract { get; set; }
        public IList<IDisposable> Disposer { get; set; }
        public ILogger Logger { get; set; }
        public string ContractID { get; set; }
        

        private bool? dialogResult;

        public BaseViewModel()
        {
            this.Logger = Serilog.Log.Logger;
            this.Disposer = new List<IDisposable>();
        }
        public bool? DialogResult
        {
            get { return this.dialogResult; }
            set { this.RaiseAndSetIfChanged(ref this.dialogResult, value); }
        }

        public virtual void Dispose()
        {
            if (this.Disposer.Any())
            {
                foreach (var disposable in Disposer)
                    disposable.Dispose();
            }

            this.Disposer.Clear();
            this.Disposer = null;

            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
