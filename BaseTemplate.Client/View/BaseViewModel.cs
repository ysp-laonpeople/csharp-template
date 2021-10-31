using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Client.View
{
    public class BaseViewModel: ReactiveObject, IDisposable
    {
        public string ContractID { get;  }
        protected IList<IDisposable> Disposer { get; private set; }
        protected IMessageBus MessageContract { get; }

        public BaseViewModel(string contractId)
        {
            this.ContractID = contractId;
            this.Disposer = new List<IDisposable>();
            this.MessageContract = new MessageBus();
        }

        public BaseViewModel(string contractId, IMessageBus messageBus)
        {
            this.ContractID = contractId;
            this.Disposer = new List<IDisposable>();
            this.MessageContract = messageBus;
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
