using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Routing;
using DotVVM.Framework.ViewModel;

namespace DotVVM.DevExtreme.Samples.ViewModels
{
    public interface ISamplesViewModelBase : IDotvvmViewModel
    {
        
    }

    public class SamplesViewModelBase : DotvvmViewModelBase, ISamplesViewModelBase
    {
        
    }

    public class DefaultViewModel : SamplesViewModelBase
    {
        public string Title { get; set; }
        public List<RouteBase> Routes { get; set; }


        public DefaultViewModel()
        {
            if (HttpContext.Current.GetOwinContext().GetDotvvmContext() == null)
            {
                throw new Exception("DotVVM context was not found!");
            }

        }

        public override Task Init()
        {
            Routes = new List<RouteBase>(Context.Configuration.RouteTable);
            return base.Init();
        }
    }
}
