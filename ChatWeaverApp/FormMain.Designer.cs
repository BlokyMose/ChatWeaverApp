namespace ChatWeaverApp
{
    partial class FormMain
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
            this.flowControlBar = new System.Windows.Forms.FlowLayoutPanel();
            this.butExit = new System.Windows.Forms.Button();
            this.butMinimize = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.labDebug = new System.Windows.Forms.Label();
            this.butHome = new System.Windows.Forms.Button();
            this.flowTabBar = new System.Windows.Forms.FlowLayoutPanel();
            this.flowControlBar.SuspendLayout();
            this.flowTabBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowControlBar
            // 
            this.flowControlBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowControlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flowControlBar.Controls.Add(this.butExit);
            this.flowControlBar.Controls.Add(this.butMinimize);
            this.flowControlBar.Controls.Add(this.butSave);
            this.flowControlBar.Controls.Add(this.labDebug);
            this.flowControlBar.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowControlBar.Location = new System.Drawing.Point(547, 0);
            this.flowControlBar.Margin = new System.Windows.Forms.Padding(0);
            this.flowControlBar.Name = "flowControlBar";
            this.flowControlBar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.flowControlBar.Size = new System.Drawing.Size(383, 50);
            this.flowControlBar.TabIndex = 1;
            this.flowControlBar.Paint += new System.Windows.Forms.PaintEventHandler(this.flowControlBar_Paint);
            // 
            // butExit
            // 
            this.butExit.BackColor = System.Drawing.Color.Gainsboro;
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.FlatAppearance.BorderSize = 0;
            this.butExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.butExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butExit.Location = new System.Drawing.Point(323, 10);
            this.butExit.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(40, 40);
            this.butExit.TabIndex = 0;
            this.butExit.Text = "⛌";
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butMinimize
            // 
            this.butMinimize.BackColor = System.Drawing.Color.Gainsboro;
            this.butMinimize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butMinimize.FlatAppearance.BorderSize = 0;
            this.butMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.butMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.butMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butMinimize.Location = new System.Drawing.Point(273, 10);
            this.butMinimize.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.butMinimize.Name = "butMinimize";
            this.butMinimize.Size = new System.Drawing.Size(40, 40);
            this.butMinimize.TabIndex = 1;
            this.butMinimize.Text = "◿";
            this.butMinimize.UseVisualStyleBackColor = false;
            this.butMinimize.Click += new System.EventHandler(this.butMinimize_Click);
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.Gainsboro;
            this.butSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butSave.FlatAppearance.BorderSize = 0;
            this.butSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.butSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butSave.Location = new System.Drawing.Point(223, 10);
            this.butSave.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(40, 40);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "💾";
            this.butSave.UseVisualStyleBackColor = false;
            // 
            // labDebug
            // 
            this.labDebug.Location = new System.Drawing.Point(152, 10);
            this.labDebug.Name = "labDebug";
            this.labDebug.Size = new System.Drawing.Size(58, 23);
            this.labDebug.TabIndex = 2;
            // 
            // butHome
            // 
            this.butHome.BackColor = System.Drawing.Color.Transparent;
            this.butHome.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butHome.FlatAppearance.BorderSize = 0;
            this.butHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.butHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.butHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.butHome.Location = new System.Drawing.Point(20, 10);
            this.butHome.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.butHome.Name = "butHome";
            this.butHome.Size = new System.Drawing.Size(90, 50);
            this.butHome.TabIndex = 3;
            this.butHome.Text = "🏠 Home";
            this.butHome.UseVisualStyleBackColor = false;
            this.butHome.Click += new System.EventHandler(this.butHome_Click);
            // 
            // flowTabBar
            // 
            this.flowTabBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flowTabBar.Controls.Add(this.butHome);
            this.flowTabBar.Location = new System.Drawing.Point(0, 0);
            this.flowTabBar.Margin = new System.Windows.Forms.Padding(0);
            this.flowTabBar.Name = "flowTabBar";
            this.flowTabBar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.flowTabBar.Size = new System.Drawing.Size(383, 60);
            this.flowTabBar.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(926, 678);
            this.ControlBox = false;
            this.Controls.Add(this.flowControlBar);
            this.Controls.Add(this.flowTabBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowControlBar.ResumeLayout(false);
            this.flowTabBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowControlBar;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butMinimize;
        private System.Windows.Forms.Button butHome;
        private System.Windows.Forms.FlowLayoutPanel flowTabBar;
        private System.Windows.Forms.Label labDebug;
        private System.Windows.Forms.Button butSave;
    }
}