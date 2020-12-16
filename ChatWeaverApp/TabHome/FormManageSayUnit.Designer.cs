namespace ChatWeaverApp.TabHome
{
    partial class FormManageSayUnit
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
            this.butNewParamAdd = new System.Windows.Forms.Button();
            this.flowParamsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.labNewParamName = new System.Windows.Forms.Label();
            this.labAddNewParam = new System.Windows.Forms.Label();
            this.labNewParamDataType = new System.Windows.Forms.Label();
            this.cbNewParamDataType = new System.Windows.Forms.ComboBox();
            this.labNewParamDefaultValue = new System.Windows.Forms.Label();
            this.flowNewParam = new System.Windows.Forms.FlowLayoutPanel();
            this.flowNewParamName = new System.Windows.Forms.FlowLayoutPanel();
            this.tbNewParamName = new System.Windows.Forms.TextBox();
            this.flowNewParamDefaultValue = new System.Windows.Forms.FlowLayoutPanel();
            this.tbNewParamDefaultValue = new System.Windows.Forms.TextBox();
            this.cbNewParamDefaultValue = new System.Windows.Forms.ComboBox();
            this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.labManageSayUnit = new System.Windows.Forms.Label();
            this.flowEnum = new System.Windows.Forms.FlowLayoutPanel();
            this.labEnumDataTypes = new System.Windows.Forms.Label();
            this.flowEnumDataTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panParamsContainer = new System.Windows.Forms.Panel();
            this.panelScrollbarContainer = new System.Windows.Forms.Panel();
            this.labScrollbar = new System.Windows.Forms.Label();
            this.labelTest = new System.Windows.Forms.Label();
            this.flowTempMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTempLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.cbTempName = new System.Windows.Forms.ComboBox();
            this.flowTempRight = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTempContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panTempColor = new System.Windows.Forms.Panel();
            this.butTempMore = new System.Windows.Forms.Button();
            this.panTempTool = new System.Windows.Forms.Panel();
            this.labManageTemplate = new System.Windows.Forms.Label();
            this.labTempName = new System.Windows.Forms.Label();
            this.flowTempName = new System.Windows.Forms.FlowLayoutPanel();
            this.flowTempClass = new System.Windows.Forms.FlowLayoutPanel();
            this.cbTempClass = new System.Windows.Forms.ComboBox();
            this.labTempClass = new System.Windows.Forms.Label();
            this.labTempDisplayName = new System.Windows.Forms.Label();
            this.butTempCollapse = new System.Windows.Forms.Button();
            this.picTemp = new System.Windows.Forms.PictureBox();
            this.flowTempBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.flowNewParam.SuspendLayout();
            this.flowNewParamName.SuspendLayout();
            this.flowNewParamDefaultValue.SuspendLayout();
            this.flowMain.SuspendLayout();
            this.flowEnum.SuspendLayout();
            this.panParamsContainer.SuspendLayout();
            this.panelScrollbarContainer.SuspendLayout();
            this.flowTempMain.SuspendLayout();
            this.flowTempLeft.SuspendLayout();
            this.flowTempContainer.SuspendLayout();
            this.panTempTool.SuspendLayout();
            this.flowTempName.SuspendLayout();
            this.flowTempClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // butNewParamAdd
            // 
            this.butNewParamAdd.BackColor = System.Drawing.Color.Gainsboro;
            this.butNewParamAdd.FlatAppearance.BorderSize = 0;
            this.butNewParamAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNewParamAdd.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.butNewParamAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butNewParamAdd.Location = new System.Drawing.Point(795, 3);
            this.butNewParamAdd.Margin = new System.Windows.Forms.Padding(35, 3, 0, 0);
            this.butNewParamAdd.Name = "butNewParamAdd";
            this.butNewParamAdd.Size = new System.Drawing.Size(60, 25);
            this.butNewParamAdd.TabIndex = 0;
            this.butNewParamAdd.Text = "Add";
            this.butNewParamAdd.UseVisualStyleBackColor = false;
            this.butNewParamAdd.Click += new System.EventHandler(this.butNewParamAdd_Click);
            // 
            // flowParamsContainer
            // 
            this.flowParamsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flowParamsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowParamsContainer.Location = new System.Drawing.Point(0, 0);
            this.flowParamsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.flowParamsContainer.Name = "flowParamsContainer";
            this.flowParamsContainer.Size = new System.Drawing.Size(910, 40);
            this.flowParamsContainer.TabIndex = 2;
            // 
            // labNewParamName
            // 
            this.labNewParamName.AutoSize = true;
            this.labNewParamName.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNewParamName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.labNewParamName.Location = new System.Drawing.Point(0, 0);
            this.labNewParamName.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labNewParamName.Name = "labNewParamName";
            this.labNewParamName.Size = new System.Drawing.Size(55, 21);
            this.labNewParamName.TabIndex = 3;
            this.labNewParamName.Text = "Name:";
            this.labNewParamName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labAddNewParam
            // 
            this.labAddNewParam.AutoSize = true;
            this.labAddNewParam.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAddNewParam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labAddNewParam.Location = new System.Drawing.Point(0, 134);
            this.labAddNewParam.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.labAddNewParam.Name = "labAddNewParam";
            this.labAddNewParam.Size = new System.Drawing.Size(240, 24);
            this.labAddNewParam.TabIndex = 4;
            this.labAddNewParam.Text = "Add a new parameter";
            // 
            // labNewParamDataType
            // 
            this.labNewParamDataType.AutoSize = true;
            this.labNewParamDataType.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNewParamDataType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.labNewParamDataType.Location = new System.Drawing.Point(211, 0);
            this.labNewParamDataType.Margin = new System.Windows.Forms.Padding(35, 0, 10, 0);
            this.labNewParamDataType.Name = "labNewParamDataType";
            this.labNewParamDataType.Size = new System.Drawing.Size(79, 21);
            this.labNewParamDataType.TabIndex = 6;
            this.labNewParamDataType.Text = "Data type:";
            this.labNewParamDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbNewParamDataType
            // 
            this.cbNewParamDataType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.cbNewParamDataType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNewParamDataType.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.cbNewParamDataType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbNewParamDataType.FormattingEnabled = true;
            this.cbNewParamDataType.Location = new System.Drawing.Point(300, 0);
            this.cbNewParamDataType.Margin = new System.Windows.Forms.Padding(0);
            this.cbNewParamDataType.Name = "cbNewParamDataType";
            this.cbNewParamDataType.Size = new System.Drawing.Size(105, 25);
            this.cbNewParamDataType.TabIndex = 7;
            this.cbNewParamDataType.SelectedIndexChanged += new System.EventHandler(this.cbNewParamDataType_SelectedIndexChanged);
            // 
            // labNewParamDefaultValue
            // 
            this.labNewParamDefaultValue.AutoSize = true;
            this.labNewParamDefaultValue.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNewParamDefaultValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.labNewParamDefaultValue.Location = new System.Drawing.Point(440, 0);
            this.labNewParamDefaultValue.Margin = new System.Windows.Forms.Padding(35, 0, 10, 0);
            this.labNewParamDefaultValue.Name = "labNewParamDefaultValue";
            this.labNewParamDefaultValue.Size = new System.Drawing.Size(104, 21);
            this.labNewParamDefaultValue.TabIndex = 8;
            this.labNewParamDefaultValue.Text = "Default value:";
            this.labNewParamDefaultValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowNewParam
            // 
            this.flowNewParam.Controls.Add(this.labNewParamName);
            this.flowNewParam.Controls.Add(this.flowNewParamName);
            this.flowNewParam.Controls.Add(this.labNewParamDataType);
            this.flowNewParam.Controls.Add(this.cbNewParamDataType);
            this.flowNewParam.Controls.Add(this.labNewParamDefaultValue);
            this.flowNewParam.Controls.Add(this.flowNewParamDefaultValue);
            this.flowNewParam.Controls.Add(this.cbNewParamDefaultValue);
            this.flowNewParam.Controls.Add(this.butNewParamAdd);
            this.flowNewParam.Location = new System.Drawing.Point(0, 183);
            this.flowNewParam.Margin = new System.Windows.Forms.Padding(0);
            this.flowNewParam.Name = "flowNewParam";
            this.flowNewParam.Size = new System.Drawing.Size(950, 32);
            this.flowNewParam.TabIndex = 10;
            // 
            // flowNewParamName
            // 
            this.flowNewParamName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.flowNewParamName.Controls.Add(this.tbNewParamName);
            this.flowNewParamName.Location = new System.Drawing.Point(65, 0);
            this.flowNewParamName.Margin = new System.Windows.Forms.Padding(0);
            this.flowNewParamName.Name = "flowNewParamName";
            this.flowNewParamName.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowNewParamName.Size = new System.Drawing.Size(111, 24);
            this.flowNewParamName.TabIndex = 10;
            // 
            // tbNewParamName
            // 
            this.tbNewParamName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.tbNewParamName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNewParamName.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewParamName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.tbNewParamName.Location = new System.Drawing.Point(3, 0);
            this.tbNewParamName.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tbNewParamName.Name = "tbNewParamName";
            this.tbNewParamName.Size = new System.Drawing.Size(104, 22);
            this.tbNewParamName.TabIndex = 5;
            this.tbNewParamName.Text = "newParam";
            // 
            // flowNewParamDefaultValue
            // 
            this.flowNewParamDefaultValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.flowNewParamDefaultValue.Controls.Add(this.tbNewParamDefaultValue);
            this.flowNewParamDefaultValue.Location = new System.Drawing.Point(557, 0);
            this.flowNewParamDefaultValue.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowNewParamDefaultValue.Name = "flowNewParamDefaultValue";
            this.flowNewParamDefaultValue.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowNewParamDefaultValue.Size = new System.Drawing.Size(100, 22);
            this.flowNewParamDefaultValue.TabIndex = 11;
            // 
            // tbNewParamDefaultValue
            // 
            this.tbNewParamDefaultValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.tbNewParamDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNewParamDefaultValue.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewParamDefaultValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.tbNewParamDefaultValue.Location = new System.Drawing.Point(3, 0);
            this.tbNewParamDefaultValue.Margin = new System.Windows.Forms.Padding(0);
            this.tbNewParamDefaultValue.Name = "tbNewParamDefaultValue";
            this.tbNewParamDefaultValue.Size = new System.Drawing.Size(100, 22);
            this.tbNewParamDefaultValue.TabIndex = 9;
            this.tbNewParamDefaultValue.Text = "0";
            // 
            // cbNewParamDefaultValue
            // 
            this.cbNewParamDefaultValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.cbNewParamDefaultValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNewParamDefaultValue.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.cbNewParamDefaultValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbNewParamDefaultValue.FormattingEnabled = true;
            this.cbNewParamDefaultValue.Location = new System.Drawing.Point(660, 0);
            this.cbNewParamDefaultValue.Margin = new System.Windows.Forms.Padding(0);
            this.cbNewParamDefaultValue.Name = "cbNewParamDefaultValue";
            this.cbNewParamDefaultValue.Size = new System.Drawing.Size(100, 25);
            this.cbNewParamDefaultValue.TabIndex = 12;
            // 
            // flowMain
            // 
            this.flowMain.AutoScroll = true;
            this.flowMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flowMain.Controls.Add(this.labManageSayUnit);
            this.flowMain.Controls.Add(this.labAddNewParam);
            this.flowMain.Controls.Add(this.flowNewParam);
            this.flowMain.Controls.Add(this.flowEnum);
            this.flowMain.Controls.Add(this.label1);
            this.flowMain.Controls.Add(this.panParamsContainer);
            this.flowMain.Controls.Add(this.labManageTemplate);
            this.flowMain.Controls.Add(this.flowTempContainer);
            this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowMain.Location = new System.Drawing.Point(0, 0);
            this.flowMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowMain.Name = "flowMain";
            this.flowMain.Padding = new System.Windows.Forms.Padding(0, 50, 20, 0);
            this.flowMain.Size = new System.Drawing.Size(950, 974);
            this.flowMain.TabIndex = 11;
            // 
            // labManageSayUnit
            // 
            this.labManageSayUnit.AutoSize = true;
            this.labManageSayUnit.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labManageSayUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.labManageSayUnit.Location = new System.Drawing.Point(0, 50);
            this.labManageSayUnit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 45);
            this.labManageSayUnit.Name = "labManageSayUnit";
            this.labManageSayUnit.Size = new System.Drawing.Size(284, 39);
            this.labManageSayUnit.TabIndex = 11;
            this.labManageSayUnit.Text = "Manage Say Unit";
            // 
            // flowEnum
            // 
            this.flowEnum.Controls.Add(this.labEnumDataTypes);
            this.flowEnum.Controls.Add(this.flowEnumDataTypes);
            this.flowEnum.Location = new System.Drawing.Point(0, 215);
            this.flowEnum.Margin = new System.Windows.Forms.Padding(0);
            this.flowEnum.Name = "flowEnum";
            this.flowEnum.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowEnum.Size = new System.Drawing.Size(950, 40);
            this.flowEnum.TabIndex = 14;
            // 
            // labEnumDataTypes
            // 
            this.labEnumDataTypes.AutoSize = true;
            this.labEnumDataTypes.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEnumDataTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.labEnumDataTypes.Location = new System.Drawing.Point(0, 5);
            this.labEnumDataTypes.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labEnumDataTypes.Name = "labEnumDataTypes";
            this.labEnumDataTypes.Size = new System.Drawing.Size(133, 21);
            this.labEnumDataTypes.TabIndex = 4;
            this.labEnumDataTypes.Text = "Enum Data Types:";
            this.labEnumDataTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowEnumDataTypes
            // 
            this.flowEnumDataTypes.Location = new System.Drawing.Point(143, 5);
            this.flowEnumDataTypes.Margin = new System.Windows.Forms.Padding(0);
            this.flowEnumDataTypes.Name = "flowEnumDataTypes";
            this.flowEnumDataTypes.Size = new System.Drawing.Size(767, 27);
            this.flowEnumDataTypes.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(0, 280);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 25, 0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Say unit parameters";
            // 
            // panParamsContainer
            // 
            this.panParamsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panParamsContainer.Controls.Add(this.panelScrollbarContainer);
            this.panParamsContainer.Controls.Add(this.flowParamsContainer);
            this.panParamsContainer.Location = new System.Drawing.Point(0, 329);
            this.panParamsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panParamsContainer.Name = "panParamsContainer";
            this.panParamsContainer.Size = new System.Drawing.Size(950, 250);
            this.panParamsContainer.TabIndex = 13;
            // 
            // panelScrollbarContainer
            // 
            this.panelScrollbarContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScrollbarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panelScrollbarContainer.Controls.Add(this.labScrollbar);
            this.panelScrollbarContainer.Location = new System.Drawing.Point(925, 0);
            this.panelScrollbarContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelScrollbarContainer.Name = "panelScrollbarContainer";
            this.panelScrollbarContainer.Size = new System.Drawing.Size(25, 250);
            this.panelScrollbarContainer.TabIndex = 43;
            // 
            // labScrollbar
            // 
            this.labScrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labScrollbar.BackColor = System.Drawing.Color.Gainsboro;
            this.labScrollbar.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScrollbar.ForeColor = System.Drawing.Color.DimGray;
            this.labScrollbar.Location = new System.Drawing.Point(0, 0);
            this.labScrollbar.Margin = new System.Windows.Forms.Padding(0);
            this.labScrollbar.Name = "labScrollbar";
            this.labScrollbar.Size = new System.Drawing.Size(25, 100);
            this.labScrollbar.TabIndex = 1;
            this.labScrollbar.Text = "||";
            this.labScrollbar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labScrollbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScrollMouseDown);
            this.labScrollbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScrollMouseMove);
            this.labScrollbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScrolllMouseUp);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(953, 227);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(35, 13);
            this.labelTest.TabIndex = 12;
            this.labelTest.Text = "label2";
            // 
            // flowTempMain
            // 
            this.flowTempMain.BackColor = System.Drawing.Color.Transparent;
            this.flowTempMain.Controls.Add(this.flowTempLeft);
            this.flowTempMain.Controls.Add(this.flowTempRight);
            this.flowTempMain.Controls.Add(this.panTempTool);
            this.flowTempMain.Controls.Add(this.flowTempBottom);
            this.flowTempMain.Location = new System.Drawing.Point(10, 0);
            this.flowTempMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempMain.Name = "flowTempMain";
            this.flowTempMain.Size = new System.Drawing.Size(900, 200);
            this.flowTempMain.TabIndex = 15;
            // 
            // flowTempLeft
            // 
            this.flowTempLeft.Controls.Add(this.flowTempName);
            this.flowTempLeft.Controls.Add(this.flowTempClass);
            this.flowTempLeft.Controls.Add(this.picTemp);
            this.flowTempLeft.Controls.Add(this.labTempDisplayName);
            this.flowTempLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowTempLeft.Location = new System.Drawing.Point(0, 0);
            this.flowTempLeft.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempLeft.Name = "flowTempLeft";
            this.flowTempLeft.Padding = new System.Windows.Forms.Padding(5, 20, 5, 10);
            this.flowTempLeft.Size = new System.Drawing.Size(180, 160);
            this.flowTempLeft.TabIndex = 1;
            // 
            // cbTempName
            // 
            this.cbTempName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbTempName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTempName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTempName.FormattingEnabled = true;
            this.cbTempName.Location = new System.Drawing.Point(53, 0);
            this.cbTempName.Margin = new System.Windows.Forms.Padding(0);
            this.cbTempName.Name = "cbTempName";
            this.cbTempName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTempName.Size = new System.Drawing.Size(115, 24);
            this.cbTempName.TabIndex = 0;
            this.cbTempName.Text = "Marcus";
            // 
            // flowTempRight
            // 
            this.flowTempRight.Location = new System.Drawing.Point(180, 0);
            this.flowTempRight.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempRight.Name = "flowTempRight";
            this.flowTempRight.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
            this.flowTempRight.Size = new System.Drawing.Size(700, 160);
            this.flowTempRight.TabIndex = 2;
            // 
            // flowTempContainer
            // 
            this.flowTempContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowTempContainer.Controls.Add(this.panTempColor);
            this.flowTempContainer.Controls.Add(this.flowTempMain);
            this.flowTempContainer.Location = new System.Drawing.Point(0, 663);
            this.flowTempContainer.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempContainer.Name = "flowTempContainer";
            this.flowTempContainer.Size = new System.Drawing.Size(910, 200);
            this.flowTempContainer.TabIndex = 16;
            // 
            // panTempColor
            // 
            this.panTempColor.BackColor = System.Drawing.Color.Coral;
            this.panTempColor.Location = new System.Drawing.Point(0, 0);
            this.panTempColor.Margin = new System.Windows.Forms.Padding(0);
            this.panTempColor.Name = "panTempColor";
            this.panTempColor.Size = new System.Drawing.Size(10, 200);
            this.panTempColor.TabIndex = 0;
            // 
            // butTempMore
            // 
            this.butTempMore.BackColor = System.Drawing.Color.Transparent;
            this.butTempMore.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butTempMore.FlatAppearance.BorderSize = 0;
            this.butTempMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.butTempMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.butTempMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTempMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTempMore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butTempMore.Location = new System.Drawing.Point(0, 0);
            this.butTempMore.Margin = new System.Windows.Forms.Padding(0);
            this.butTempMore.Name = "butTempMore";
            this.butTempMore.Size = new System.Drawing.Size(20, 20);
            this.butTempMore.TabIndex = 4;
            this.butTempMore.Text = "⚙️";
            this.butTempMore.UseVisualStyleBackColor = false;
            // 
            // panTempTool
            // 
            this.panTempTool.BackColor = System.Drawing.Color.Transparent;
            this.panTempTool.Controls.Add(this.butTempCollapse);
            this.panTempTool.Controls.Add(this.butTempMore);
            this.panTempTool.Location = new System.Drawing.Point(880, 0);
            this.panTempTool.Margin = new System.Windows.Forms.Padding(0);
            this.panTempTool.Name = "panTempTool";
            this.panTempTool.Size = new System.Drawing.Size(20, 160);
            this.panTempTool.TabIndex = 5;
            // 
            // labManageTemplate
            // 
            this.labManageTemplate.AutoSize = true;
            this.labManageTemplate.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labManageTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labManageTemplate.Location = new System.Drawing.Point(0, 614);
            this.labManageTemplate.Margin = new System.Windows.Forms.Padding(0, 35, 0, 25);
            this.labManageTemplate.Name = "labManageTemplate";
            this.labManageTemplate.Size = new System.Drawing.Size(201, 24);
            this.labManageTemplate.TabIndex = 17;
            this.labManageTemplate.Text = "Manage Template";
            // 
            // labTempName
            // 
            this.labTempName.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTempName.Location = new System.Drawing.Point(3, 2);
            this.labTempName.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.labTempName.Name = "labTempName";
            this.labTempName.Size = new System.Drawing.Size(50, 23);
            this.labTempName.TabIndex = 1;
            this.labTempName.Text = "Name:";
            // 
            // flowTempName
            // 
            this.flowTempName.Controls.Add(this.labTempName);
            this.flowTempName.Controls.Add(this.cbTempName);
            this.flowTempName.Location = new System.Drawing.Point(5, 20);
            this.flowTempName.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempName.Name = "flowTempName";
            this.flowTempName.Size = new System.Drawing.Size(170, 0);
            this.flowTempName.TabIndex = 2;
            // 
            // flowTempClass
            // 
            this.flowTempClass.Controls.Add(this.labTempClass);
            this.flowTempClass.Controls.Add(this.cbTempClass);
            this.flowTempClass.Location = new System.Drawing.Point(5, 20);
            this.flowTempClass.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempClass.Name = "flowTempClass";
            this.flowTempClass.Size = new System.Drawing.Size(170, 0);
            this.flowTempClass.TabIndex = 3;
            // 
            // cbTempClass
            // 
            this.cbTempClass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbTempClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTempClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTempClass.FormattingEnabled = true;
            this.cbTempClass.Location = new System.Drawing.Point(53, 0);
            this.cbTempClass.Margin = new System.Windows.Forms.Padding(0);
            this.cbTempClass.Name = "cbTempClass";
            this.cbTempClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTempClass.Size = new System.Drawing.Size(115, 24);
            this.cbTempClass.TabIndex = 0;
            this.cbTempClass.Text = "Protagonist";
            // 
            // labTempClass
            // 
            this.labTempClass.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTempClass.Location = new System.Drawing.Point(3, 2);
            this.labTempClass.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.labTempClass.Name = "labTempClass";
            this.labTempClass.Size = new System.Drawing.Size(50, 23);
            this.labTempClass.TabIndex = 2;
            this.labTempClass.Text = "Class:";
            // 
            // labTempDisplayName
            // 
            this.labTempDisplayName.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTempDisplayName.Location = new System.Drawing.Point(5, 105);
            this.labTempDisplayName.Margin = new System.Windows.Forms.Padding(0);
            this.labTempDisplayName.Name = "labTempDisplayName";
            this.labTempDisplayName.Size = new System.Drawing.Size(170, 30);
            this.labTempDisplayName.TabIndex = 4;
            this.labTempDisplayName.Text = "Marcus Ember";
            this.labTempDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butTempCollapse
            // 
            this.butTempCollapse.BackColor = System.Drawing.Color.Transparent;
            this.butTempCollapse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butTempCollapse.FlatAppearance.BorderSize = 0;
            this.butTempCollapse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.butTempCollapse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.butTempCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTempCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTempCollapse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.butTempCollapse.Location = new System.Drawing.Point(0, 25);
            this.butTempCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.butTempCollapse.Name = "butTempCollapse";
            this.butTempCollapse.Size = new System.Drawing.Size(20, 20);
            this.butTempCollapse.TabIndex = 5;
            this.butTempCollapse.Text = "◿";
            this.butTempCollapse.UseVisualStyleBackColor = false;
            // 
            // picTemp
            // 
            this.picTemp.Image = global::ChatWeaverApp.Properties.Resources.raySmile_PNG;
            this.picTemp.Location = new System.Drawing.Point(45, 20);
            this.picTemp.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.picTemp.Name = "picTemp";
            this.picTemp.Size = new System.Drawing.Size(85, 85);
            this.picTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTemp.TabIndex = 0;
            this.picTemp.TabStop = false;
            // 
            // flowTempBottom
            // 
            this.flowTempBottom.BackColor = System.Drawing.Color.Gainsboro;
            this.flowTempBottom.Location = new System.Drawing.Point(0, 160);
            this.flowTempBottom.Margin = new System.Windows.Forms.Padding(0);
            this.flowTempBottom.Name = "flowTempBottom";
            this.flowTempBottom.Size = new System.Drawing.Size(900, 40);
            this.flowTempBottom.TabIndex = 3;
            // 
            // FormManageSayUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.flowMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormManageSayUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.FormManageSayUnit_SizeChanged);
            this.flowNewParam.ResumeLayout(false);
            this.flowNewParam.PerformLayout();
            this.flowNewParamName.ResumeLayout(false);
            this.flowNewParamName.PerformLayout();
            this.flowNewParamDefaultValue.ResumeLayout(false);
            this.flowNewParamDefaultValue.PerformLayout();
            this.flowMain.ResumeLayout(false);
            this.flowMain.PerformLayout();
            this.flowEnum.ResumeLayout(false);
            this.flowEnum.PerformLayout();
            this.panParamsContainer.ResumeLayout(false);
            this.panelScrollbarContainer.ResumeLayout(false);
            this.flowTempMain.ResumeLayout(false);
            this.flowTempLeft.ResumeLayout(false);
            this.flowTempContainer.ResumeLayout(false);
            this.panTempTool.ResumeLayout(false);
            this.flowTempName.ResumeLayout(false);
            this.flowTempClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butNewParamAdd;
        private System.Windows.Forms.FlowLayoutPanel flowParamsContainer;
        private System.Windows.Forms.Label labNewParamName;
        private System.Windows.Forms.Label labAddNewParam;
        private System.Windows.Forms.Label labNewParamDataType;
        private System.Windows.Forms.ComboBox cbNewParamDataType;
        private System.Windows.Forms.Label labNewParamDefaultValue;
        private System.Windows.Forms.FlowLayoutPanel flowNewParam;
        private System.Windows.Forms.FlowLayoutPanel flowMain;
        private System.Windows.Forms.Label labManageSayUnit;
        private System.Windows.Forms.FlowLayoutPanel flowNewParamName;
        private System.Windows.Forms.TextBox tbNewParamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panParamsContainer;
        private System.Windows.Forms.Panel panelScrollbarContainer;
        private System.Windows.Forms.Label labScrollbar;
        private System.Windows.Forms.FlowLayoutPanel flowEnum;
        private System.Windows.Forms.ComboBox cbNewParamDefaultValue;
        private System.Windows.Forms.FlowLayoutPanel flowNewParamDefaultValue;
        private System.Windows.Forms.TextBox tbNewParamDefaultValue;
        private System.Windows.Forms.Label labEnumDataTypes;
        private System.Windows.Forms.FlowLayoutPanel flowEnumDataTypes;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.FlowLayoutPanel flowTempContainer;
        private System.Windows.Forms.Panel panTempColor;
        private System.Windows.Forms.FlowLayoutPanel flowTempMain;
        private System.Windows.Forms.FlowLayoutPanel flowTempLeft;
        private System.Windows.Forms.ComboBox cbTempName;
        private System.Windows.Forms.FlowLayoutPanel flowTempRight;
        private System.Windows.Forms.Panel panTempTool;
        private System.Windows.Forms.Button butTempMore;
        private System.Windows.Forms.Label labManageTemplate;
        private System.Windows.Forms.Label labTempName;
        private System.Windows.Forms.FlowLayoutPanel flowTempName;
        private System.Windows.Forms.FlowLayoutPanel flowTempClass;
        private System.Windows.Forms.Label labTempClass;
        private System.Windows.Forms.ComboBox cbTempClass;
        private System.Windows.Forms.Label labTempDisplayName;
        private System.Windows.Forms.PictureBox picTemp;
        private System.Windows.Forms.Button butTempCollapse;
        private System.Windows.Forms.FlowLayoutPanel flowTempBottom;
    }
}

