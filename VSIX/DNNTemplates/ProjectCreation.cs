using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Christoc.DNNTemplates
{
    public partial class ProjectCreation : Form
    {

        public ProjectProperty ProjectInterface
        {
            get;
            set;
        }

        public ProjectCreation()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //int.TryParse(txtSLA.Text, out this.projectProperty.SLA);
            //int.TryParse(txtTimeout.Text, out this.projectProperty.TimeOut);
            //this.projectProperty.ExactTargetURL = txtTargetURL.Text;
            //this.projectProperty.Method = txtMethod.Text;
            this.Close();
        }

    }
}
