using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Christoc.DNNTemplates.SetupWizard
{
    public class SetupWizard : IWizard
    {
        private DTE _dte;

        public void BeforeOpeningFile(ProjectItem projectItem) { }
        public void ProjectFinishedGenerating(Project project) { }
        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
        public void RunFinished() { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _dte = (DTE)automationObject;


            WizardView inputForm = null;

            while (inputForm == null || inputForm.PassesValidation() == false)
            {
                // If this is our first time in the loop, init with default parameters.
                if (inputForm == null)
                {
                    inputForm = new WizardView();
                }
                // Otherwise, init with the parameters the user entered last time.
                else
                {
                    inputForm = new WizardView(inputForm.RootNameSpace, inputForm.OwnerName, inputForm.OwnerEmail, inputForm.OwnerWebsite, inputForm.DevEnvironmentUrl);
                }

                // ShowDialog will return false when the user cancels the dialog.
                if (inputForm.ShowDialog() == false)
                {
                    throw new WizardCancelledException("Action was cancelled by the user.");
                }
            }

            
            /* remove them first so there isn't any conflict, they get added by the project templates themselves originally */
            replacementsDictionary.Remove("$rootnamespace$");
            replacementsDictionary.Remove("$ownername$");
            replacementsDictionary.Remove("$owneremail$");
            replacementsDictionary.Remove("$ownerwebsite$");
            replacementsDictionary.Remove("$devenvironmenturl$");

            replacementsDictionary.Add("$rootnamespace$", inputForm.RootNameSpace);
            replacementsDictionary.Add("$ownername$", inputForm.OwnerName);
            replacementsDictionary.Add("$owneremail$", inputForm.OwnerEmail);
            replacementsDictionary.Add("$ownerwebsite$", inputForm.OwnerWebsite);
            replacementsDictionary.Add("$devenvironmenturl$", inputForm.DevEnvironmentUrl);
            
        }

        public bool ShouldAddProjectItem(string filePath) { return true; }
    }
}