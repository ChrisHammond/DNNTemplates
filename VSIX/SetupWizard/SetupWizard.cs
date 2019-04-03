using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Christoc.DNNTemplates.SetupWizard
{
    public class SetupWizard : IWizard
    {
        private DTE _dte;

        // Default parameters for the Project Setup Wizard.
        protected internal string RootNameSpace { get; set; } = "Christoc.Modules.";
        protected internal string OwnerName { get; set; } = "Christoc.com";
        protected internal string OwnerEmail { get; set; } = "modules@christoc.com";
        protected internal string OwnerWebsite { get; set; } = "https://www.christoc.com/";
        protected internal string DevEnvironmentUrl { get; set; } = "dnndev.me";

        public void BeforeOpeningFile(ProjectItem projectItem) { }
        public void ProjectFinishedGenerating(Project project) { }
        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
        public void RunFinished() { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _dte = (DTE)automationObject;

            // Ask the user for the necessary parameters.
            WizardView inputForm = null;
            while (inputForm == null || inputForm.PassesValidation() == false)
            {
                // If this is our first time in the loop, init with default parameters.
                if (inputForm == null)
                {
                    inputForm = new WizardView(RootNameSpace, OwnerName, OwnerEmail, OwnerWebsite, DevEnvironmentUrl);
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

            // Update our parameters with the user input.
            RootNameSpace = inputForm.RootNameSpace;
            OwnerName = inputForm.OwnerName;
            OwnerEmail = inputForm.OwnerEmail;
            OwnerWebsite = inputForm.OwnerWebsite;
            DevEnvironmentUrl = inputForm.DevEnvironmentUrl;

            // Remove them first so there isn't any conflict, they get added by the project templates themselves originally
            replacementsDictionary.Remove("$rootnamespace$");
            replacementsDictionary.Remove("$ownername$");
            replacementsDictionary.Remove("$owneremail$");
            replacementsDictionary.Remove("$ownerwebsite$");
            replacementsDictionary.Remove("$devenvironmenturl$");

            replacementsDictionary.Add("$rootnamespace$", RootNameSpace);
            replacementsDictionary.Add("$ownername$", OwnerName);
            replacementsDictionary.Add("$owneremail$", OwnerEmail);
            replacementsDictionary.Add("$ownerwebsite$", OwnerWebsite);
            replacementsDictionary.Add("$devenvironmenturl$", DevEnvironmentUrl);
            
        }

        public bool ShouldAddProjectItem(string filePath) { return true; }
    }
}