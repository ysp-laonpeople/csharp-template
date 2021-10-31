using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseTemplate.Client2
{
    public class StartPageViewModel:ReactiveObject
    {
        public ObservableCollection<SubPageViewModel> Workspaces { get; set; }

        public StartPageViewModel()
        {
            this.Workspaces = new ObservableCollection<SubPageViewModel>();
            for (int i = 0; i < 50; i++)
            {
                var subPage = new SubPageViewModel(i.ToString());
                subPage.OnClickHandler += SubPage_OnClickHandler;
                this.Workspaces.Add(subPage);
            }
        }

        private void SubPage_OnClickHandler(object sender, EventArgs e)
        {
            TextChangedEventArgs evt = e as TextChangedEventArgs;
            foreach (var item in Workspaces)
            {
                item.Output = evt.Value;
            }
        }
    }
}
