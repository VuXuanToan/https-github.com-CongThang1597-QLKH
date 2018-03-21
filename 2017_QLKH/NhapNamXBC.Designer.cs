namespace _2017_QLKH
{
    partial class NhapNamXBC
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Nam = new System.Windows.Forms.TextBox();
            this.bt_XacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm";
            // 
            // tbx_Nam
            // 
            this.tbx_Nam.Location = new System.Drawing.Point(107, 23);
            this.tbx_Nam.Name = "tbx_Nam";
            this.tbx_Nam.Size = new System.Drawing.Size(100, 20);
            this.tbx_Nam.TabIndex = 1;
            // 
            // bt_XacNhan
            // 
            this.bt_XacNhan.Location = new System.Drawing.Point(76, 57);
            this.bt_XacNhan.Name = "bt_XacNhan";
            this.bt_XacNhan.Size = new System.Drawing.Size(75, 23);
            this.bt_XacNhan.TabIndex = 2;
            this.bt_XacNhan.Text = "Xác Nhận";
            this.bt_XacNhan.UseVisualStyleBackColor = true;
            this.bt_XacNhan.Click += new System.EventHandler(this.bt_XacNhan_Click);
            // 
            // NhapNamXBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 92);
            this.Controls.Add(this.bt_XacNhan);
            this.Controls.Add(this.tbx_Nam);
            this.Controls.Add(this.label1);
            this.Name = "NhapNamXBC";
            this.Text = "NhapNamXBC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Nam;
        private System.Windows.Forms.Button bt_XacNhan;
    }
}