using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Christoc.DNNTemplates.SetupWizard
{
    ///http://www.kendar.org/?p=/tutorials/vsextensions/part03

    /// <summary>
    /// Interaction logic for SetupWizard.xaml
    /// </summary>
    public partial class WizardView : Window
    {

        public string RootNameSpace = "Christoc.Modules.";
        public string OwnerName = "Christoc.com";
        public string OwnerEmail = "modules@christoc.com";
        public string OwnerWebsite = "http://www.christoc.com/";
        public string DevEnvironmentUrl = "dnndev.me";

        public WizardView()
        {
            InitializeComponent();
        }


        private void InitializeForm()
        {
            txtRootnamespace.Text = RootNameSpace;
            txtOwnerName.Text = OwnerName;
            txtOwnerEmail.Text = OwnerEmail;
            txtOwnerWebsite.Text = OwnerWebsite;
            txtDevUrl.Text = DevEnvironmentUrl;
            
        }


        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            RootNameSpace = txtRootnamespace.Text;
            OwnerName = txtOwnerName.Text;
            OwnerEmail = txtOwnerEmail.Text;
            OwnerWebsite = txtOwnerWebsite.Text;
            DevEnvironmentUrl = txtDevUrl.Text;
            Close();
        }
    }
}
