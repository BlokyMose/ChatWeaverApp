namespace ChatWeaverApp.TabHome
{
    partial class FormHomeMain
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
            this.labProjectTitle = new System.Windows.Forms.Label();
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.butProjectSettings = new System.Windows.Forms.Button();
            this.butData = new System.Windows.Forms.Button();
            this.flowLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panRight = new System.Windows.Forms.Panel();
            this.flowMenu.SuspendLayout();
            this.flowLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // labProjectTitle
            // 
            this.labProjectTitle.AutoSize = true;
            this.labProjectTitle.Font = new System.Drawing.Font("Futura Md BT", 54F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labProjectTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.labProjectTitle.Location = new System.Drawing.Point(20, 50);
            this.labProjectTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labProjectTitle.Name = "labProjectTitle";
            this.labProjectTitle.Padding = new System.Windows.Forms.Padding(15);
            this.labProjectTitle.Size = new System.Drawing.Size(447, 116);
            this.labProjectTitle.TabIndex = 0;
            this.labProjectTitle.Text = "Project Title";
            // 
            // flowMenu
            // 
            this.flowMenu.Controls.Add(this.butProjectSettings);
            this.flowMenu.Controls.Add(this.butData);
            this.flowMenu.Location = new System.Drawing.Point(40, 283);
            this.flowMenu.Margin = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(450, 400);
            this.flowMenu.TabIndex = 1;
            // 
            // butProjectSettings
            // 
            this.butProjectSettings.FlatAppearance.BorderSize = 0;
            this.butProjectSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.butProjectSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PapayaWhip;
            this.butProjectSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butProjectSettings.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butProjectSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butProjectSettings.Location = new System.Drawing.Point(10, 10);
            this.butProjectSettings.Margin = new System.Windows.Forms.Padding(10);
            this.butProjectSettings.Name = "butProjectSettings";
            this.butProjectSettings.Size = new System.Drawing.Size(100, 100);
            this.butProjectSettings.TabIndex = 0;
            this.butProjectSettings.Text = "🏄Project";
            this.butProjectSettings.UseVisualStyleBackColor = true;
            // 
            // butData
            // 
            this.butData.FlatAppearance.BorderSize = 0;
            this.butData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Khaki;
            this.butData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Beige;
            this.butData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butData.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butData.Location = new System.Drawing.Point(130, 10);
            this.butData.Margin = new System.Windows.Forms.Padding(10);
            this.butData.Name = "butData";
            this.butData.Size = new System.Drawing.Size(100, 100);
            this.butData.TabIndex = 1;
            this.butData.Text = "📑\r\nData";
            this.butData.UseVisualStyleBackColor = true;
            this.butData.Click += new System.EventHandler(this.butData_Click);
            // 
            // flowLeft
            // 
            this.flowLeft.Controls.Add(this.labProjectTitle);
            this.flowLeft.Controls.Add(this.label1);
            this.flowLeft.Controls.Add(this.flowMenu);
            this.flowLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLeft.Location = new System.Drawing.Point(0, 0);
            this.flowLeft.Margin = new System.Windows.Forms.Padding(0);
            this.flowLeft.Name = "flowLeft";
            this.flowLeft.Padding = new System.Windows.Forms.Padding(20, 50, 0, 0);
            this.flowLeft.Size = new System.Drawing.Size(600, 900);
            this.flowLeft.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(20, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(30, 15, 15, 15);
            this.label1.Size = new System.Drawing.Size(450, 87);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subtitle and Premise";
            // 
            // panRight
            // 
            this.panRight.BackgroundImage = global::ChatWeaverApp.Properties.Resources.bg_default;
            this.panRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panRight.Location = new System.Drawing.Point(600, 0);
            this.panRight.Margin = new System.Windows.Forms.Padding(0);
            this.panRight.Name = "panRight";
            this.panRight.Padding = new System.Windows.Forms.Padding(0, 50, 20, 0);
            this.panRight.Size = new System.Drawing.Size(500, 900);
            this.panRight.TabIndex = 3;
            // 
            // FormHomeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1100, 900);
            this.ControlBox = false;
            this.Controls.Add(this.panRight);
            this.Controls.Add(this.flowLeft);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormHomeMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormHomeMain";
            this.SizeChanged += new System.EventHandler(this.FormHomeMain_SizeChanged);
            this.flowMenu.ResumeLayout(false);
            this.flowLeft.ResumeLayout(false);
            this.flowLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labProjectTitle;
        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.Button butProjectSettings;
        private System.Windows.Forms.Button butData;
        private System.Windows.Forms.FlowLayoutPanel flowLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panRight;
    }
}