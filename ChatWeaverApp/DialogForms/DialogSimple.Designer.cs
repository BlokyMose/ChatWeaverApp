namespace ChatWeaverApp.DialogForms
{
    partial class DialogSimple
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
            this.labDialogTitle = new System.Windows.Forms.Label();
            this.labDesc = new System.Windows.Forms.Label();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.labIcon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labDialogTitle
            // 
            this.labDialogTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDialogTitle.Location = new System.Drawing.Point(0, 0);
            this.labDialogTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labDialogTitle.Name = "labDialogTitle";
            this.labDialogTitle.Size = new System.Drawing.Size(800, 70);
            this.labDialogTitle.TabIndex = 0;
            this.labDialogTitle.Text = "Dialog Title";
            this.labDialogTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labDesc
            // 
            this.labDesc.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDesc.Location = new System.Drawing.Point(0, 140);
            this.labDesc.Name = "labDesc";
            this.labDesc.Padding = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.labDesc.Size = new System.Drawing.Size(800, 150);
            this.labDesc.TabIndex = 1;
            this.labDesc.Text = "Dialog long description";
            this.labDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowButtons
            // 
            this.flowButtons.Location = new System.Drawing.Point(0, 290);
            this.flowButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(800, 60);
            this.flowButtons.TabIndex = 2;
            // 
            // labIcon
            // 
            this.labIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIcon.Location = new System.Drawing.Point(0, 70);
            this.labIcon.Name = "labIcon";
            this.labIcon.Padding = new System.Windows.Forms.Padding(7);
            this.labIcon.Size = new System.Drawing.Size(800, 70);
            this.labIcon.TabIndex = 3;
            this.labIcon.Text = "- 🏄 -";
            this.labIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DialogSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.ControlBox = false;
            this.Controls.Add(this.labIcon);
            this.Controls.Add(this.flowButtons);
            this.Controls.Add(this.labDesc);
            this.Controls.Add(this.labDialogTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogYesNo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labDialogTitle;
        private System.Windows.Forms.Label labDesc;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Label labIcon;
    }
}