namespace ChatWeaverApp
{
    partial class FormMainControl
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
            this.butOpenFormManageSayUnit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butOpenFormManageSayUnit
            // 
            this.butOpenFormManageSayUnit.Location = new System.Drawing.Point(407, 40);
            this.butOpenFormManageSayUnit.Name = "butOpenFormManageSayUnit";
            this.butOpenFormManageSayUnit.Size = new System.Drawing.Size(75, 23);
            this.butOpenFormManageSayUnit.TabIndex = 0;
            this.butOpenFormManageSayUnit.Text = "button1";
            this.butOpenFormManageSayUnit.UseVisualStyleBackColor = true;
            this.butOpenFormManageSayUnit.Click += new System.EventHandler(this.butOpenFormManageSayUnit_Click);
            // 
            // FormMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 103);
            this.ControlBox = false;
            this.Controls.Add(this.butOpenFormManageSayUnit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMainControl";
            this.Text = "FormMainControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butOpenFormManageSayUnit;
    }
}