using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christoc.DNNTemplates.SetupWizard
{
    public class ModuleSetupWizard : SetupWizard
    {

        public ModuleSetupWizard() : base()
        {
            // Change the default root namespace.
            base.RootNameSpace = "Christoc.Modules.";
        }

    }
}
