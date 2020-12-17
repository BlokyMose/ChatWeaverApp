namespace ChatWeaverApp.DialogForms
{
    partial class ContextSimple
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
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowMainContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.labInsight = new System.Windows.Forms.Label();
            this.flowMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowMain
            // 
            this.flowMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowMain.Location = new System.Drawing.Point(0, 0);
            this.flowMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowMain.Name = "flowMain";
            this.flowMain.Size = new System.Drawing.Size(150, 0);
            this.flowMain.TabIndex = 0;
            // 
            // flowMainContainer
            // 
            this.flowMainContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowMainContainer.Controls.Add(this.flowMain);
            this.flowMainContainer.Controls.Add(this.labInsight);
            this.flowMainContainer.Location = new System.Drawing.Point(0, 0);
            this.flowMainContainer.Margin = new System.Windows.Forms.Padding(0);
            this.flowMainContainer.Name = "flowMainContainer";
            this.flowMainContainer.Size = new System.Drawing.Size(150, 17);
            this.flowMainContainer.TabIndex = 3;
            // 
            // labInsight
            // 
            this.labInsight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labInsight.Location = new System.Drawing.Point(0, 0);
            this.labInsight.Margin = new System.Windows.Forms.Padding(0);
            this.labInsight.Name = "labInsight";
            this.labInsight.Size = new System.Drawing.Size(150, 17);
            this.labInsight.TabIndex = 2;
            this.labInsight.Text = "💡 Insight";
            this.labInsight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContextSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(153, 20);
            this.Controls.Add(this.flowMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ContextSimple";
            this.Text = "ContextSimple";
            this.flowMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.FlowLayoutPanel flowMainContainer;
        private System.Windows.Forms.Label labInsight;
    }
}