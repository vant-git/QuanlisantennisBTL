namespace QuanLySanBong.View
{
    partial class TK_HoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtp_input = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_output = new System.Windows.Forms.DateTimePicker();
            this.btn_TK = new System.Windows.Forms.Button();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // dtp_input
            // 
            this.dtp_input.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_input.Location = new System.Drawing.Point(276, 36);
            this.dtp_input.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_input.Name = "dtp_input";
            this.dtp_input.Size = new System.Drawing.Size(265, 22);
            this.dtp_input.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thời gian từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtp_output
            // 
            this.dtp_output.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_output.Location = new System.Drawing.Point(748, 36);
            this.dtp_output.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_output.Name = "dtp_output";
            this.dtp_output.Size = new System.Drawing.Size(265, 22);
            this.dtp_output.TabIndex = 3;
            // 
            // btn_TK
            // 
            this.btn_TK.Location = new System.Drawing.Point(1079, 32);
            this.btn_TK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TK.Name = "btn_TK";
            this.btn_TK.Size = new System.Drawing.Size(176, 28);
            this.btn_TK.TabIndex = 5;
            this.btn_TK.Text = "Tìm kiếm";
            this.btn_TK.UseVisualStyleBackColor = true;
            this.btn_TK.Click += new System.EventHandler(this.btn_TK_Click);
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(28, 171);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(1427, 697);
            this.crystalReportViewer2.TabIndex = 6;
            // 
            // TK_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 880);
//            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.btn_TK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_input);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TK_HoaDon";
            this.Text = "TK_HoaDon";
            this.Load += new System.EventHandler(this.TK_HoaDon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtp_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_output;
        private System.Windows.Forms.Button btn_TK;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}