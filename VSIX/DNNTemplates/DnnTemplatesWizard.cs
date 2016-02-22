using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Christoc.DNNTemplates
{
    public class DnnTemplatesWizard : IWizard
    {
        private DTE _dte;

        public void BeforeOpeningFile(ProjectItem projectItem) { }
        public void ProjectFinishedGenerating(Project project) { }
        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
        public void RunFinished() { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _dte = (DTE)automationObject;

            
            // add an entry to the dictionary to specify the string used for the $rootnamespace$ token 
            replacementsDictionary.Add("$rootnamespace2$", "Christoc.Dnn.Modules");
            replacementsDictionary.Add("$ownername2$", "Christoc.com");
            replacementsDictionary.Add("$owneremail2$", "modules@christoc.com");
            replacementsDictionary.Add("$ownerwebsite2$", "http://www.christoc.com");
            replacementsDictionary.Add("$devenvironmenturl2$", "dnndev.me");
        }

        public bool ShouldAddProjectItem(string filePath) { return true; }
    }
}