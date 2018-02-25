using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christoc.DNNTemplates.SetupWizard
{
    public class SkinSetupWizard : SetupWizard
    {

        public SkinSetupWizard() : base()
        {
            // Change the default root Namespace.
            base.RootNameSpace = "Christoc.Skins.";
        }

    }
}
