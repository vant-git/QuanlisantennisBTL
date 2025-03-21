using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
namespace QuanLySanBong.View
{
    public partial class TK_HoaDon : Form
    {
        public TK_HoaDon()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_TK_Click(object sender, EventArgs e)
        {
            ParameterValues inputday = new ParameterValues();
            ParameterValues outputday = new ParameterValues();
            ParameterDiscreteValue disinputday = new ParameterDiscreteValue();
            ParameterDiscreteValue disoutputday = new ParameterDiscreteValue();
            disinputday.Value = dtp_input.Value;
            disoutputday.Value = dtp_output.Value;
            inputday.Add(disinputday);
            outputday.Add(disoutputday);
            crystalReportViewer2.Refresh();

           
        }

        private void TK_HoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
