using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatWeaverApp.TabHome
{
    public partial class FormManageSayUnit : Form
    {
        // Design
        private const int flowEnumHeight = 32;
        private const int flowParamHeight = 40;

        class FlowParam
        {
            public FlowLayoutPanel flow;
            public Button butMove;
            public TextBox tbName;
            public ComboBox cbDataType;
            public TextBox tbDefaultValue;
            public ComboBox cbDefaultValue;
            public ComboBox cbUIControl;
            public Button butLink;
            public Button butDelete;
            public ParameterData paramData;
            public int index;               
            // To avoid re-instantiation of FlowParam, each flow param has its own index property
            // When moved, only when "moved", the index value will be changed. 

            public FlowParam(
                FlowLayoutPanel flow,
                Button butMove,
                TextBox tbName,
                ComboBox cbDataType,
                TextBox tbDefaultValue,
                ComboBox cbDefaultValue,
                ComboBox cbUIControl,
                Button butLink,
                Button butDelete,
                ParameterData paramData,
                int index
                )
            {
                this.flow = flow;
                this.butMove = butMove;
                this.tbName = tbName;
                this.cbDataType = cbDataType;
                this.tbDefaultValue = tbDefaultValue;
                this.cbDefaultValue = cbDefaultValue;
                this.cbUIControl = cbUIControl;
                this.butLink = butLink;
                this.butDelete = butDelete;
                this.paramData = paramData;
                this.index = index;
            }

            public void SetData(
                FlowLayoutPanel flow,
                Button butMove,
                TextBox tbName,
                ComboBox cbDataType,
                TextBox tbDefaultValue,
                ComboBox cbDefaultValue,
                ComboBox cbUIControl,
                Button butLink,
                Button butDelete,
                ParameterData paramData,
                int index
                )
            {
                this.flow = flow;
                this.butMove = butMove;
                this.tbName = tbName;
                this.cbDataType = cbDataType;
                this.tbDefaultValue = tbDefaultValue;
                this.cbDefaultValue = cbDefaultValue;
                this.cbUIControl = cbUIControl;
                this.butLink = butLink;
                this.butDelete = butDelete;
                this.paramData = paramData;
                this.index = index;
            }

            /// <summary> Only for caching</summary>
            public FlowParam() { }
        }

        List<FlowParam> flowParams = new List<FlowParam>();

        #region REG: Init
        public FormManageSayUnit()
        {
            InitializeComponent();
            cbNewParamDataType.Items.AddRange(ChatWeaverSystem.System.DataTypes.Cast<object>().ToArray());
            ResetNewParamControls();

            panParamsContainer.Height = (flowParamsContainer.Height + 10) * 5;
            cbNewParamDefaultValue.Size = new Size(0, cbNewParamDefaultValue.Height);

            #region -> Delegations

            this.MouseWheel += (sender, e) => { labScrollbar.Focus(); controlScroll_MouseScroll(sender, e); };
            Uti.Methods.SetupForm(this);

            Uti.Methods.SetupInputDataType(
                tbNewParamName, 
                ChatWeaverSystem.System.DataTypesParam.String, 
                (isOkay) => { if (!isOkay) DisallowToMakeNewParam(); }, 
                () => { return Master.GetParamAllNames(); });

            Uti.Methods.SetupInputDataType(
                cbNewParamDataType, 
                ChatWeaverSystem.System.DataTypesParam.Enum, 
                (isOkay) => { 
                    if (!isOkay) DisallowToMakeNewParam(); 
                }, 
                ChatWeaverSystem.System.DataTypes);
            cbNewParamDataType.SelectedIndexChanged += (sender, e) => { cbNewParamDataType_SelectedIndexChanged(sender, e); };

            Uti.Methods.SetupInputDataType(
                tbNewParamDefaultValue, 
                Uti.Methods.ConvertToDataType(cbNewParamDataType.Text), 
                (isOkay) => { 
                    if (Uti.Methods.ConvertToDataType(cbNewParamDataType.Text) != ChatWeaverSystem.System.DataTypesParam.Enum) 
                        if (!isOkay) DisallowToMakeNewParam(); 
                });

            Uti.Methods.SetupInputDataType(
                cbNewParamDefaultValue, 
                ChatWeaverSystem.System.DataTypesParam.Enum, 
                (isOkay) => { 
                    if (Uti.Methods.ConvertToDataType(cbNewParamDataType.Text) == ChatWeaverSystem.System.DataTypesParam.Enum) 
                        if (!isOkay) 
                            DisallowToMakeNewParam(); }, 
                newEnumTypes); //Uti.Methods.ConvertToListString(cbNewParamDefaultValue.Items)

            #endregion

            //TODO: Load parameter datas, then update scroll bar
            Uti.Methods.UpdateMaxScroll(flowParamsContainer, panelScrollbarContainer, labScrollbar);

            #region -> Template

            butManageTempAddRight.MouseClick += (sender, e) =>
            {
                if (templateBottomCBs.Count + templateRightCBs.Count >= Master.GetParamAllNames().Count) return;
                if (Master.GetParamAllNames().Count > 0 )
                {
                    MakeTemplateCBManage(flowManageTempTop, RightOrBottom.Right);
                    flowManageTempTop.Controls.SetChildIndex(butManageTempAddRight, flowManageTempTop.Controls.Count - 1);
                }
            };
            butManageTempAddBottom.MouseClick += (sender, e) =>
            {
                if (templateBottomCBs.Count + templateRightCBs.Count >= Master.GetParamAllNames().Count) return;
                if (Master.GetParamAllNames().Count > 0)
                {
                    MakeTemplateCBManage(flowManageTempBottom, RightOrBottom.Bottom);
                    flowManageTempBottom.Controls.SetChildIndex(butManageTempAddBottom, flowManageTempBottom.Controls.Count - 1);
                }
            };

            #endregion

            // TODO: delete test methods
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += (sender, e) => { DisplayDatas(); };
        }

        private void FormManageSayUnit_SizeChanged(object sender, EventArgs e)
        {
            flowMain.Size = new Size(flowMain.Width, Height);
        }

        void DisplayDatas()
        {
            labelTest.Text = "";
            for (int i = 0; i < Master.projectData.parameters.Count; i++)
            {
                string enums = Master.projectData.parameters[i].enumDataTypes != null ? Master.projectData.parameters[i].enumDataTypes.Count > 0 ? Master.projectData.parameters[i].enumDataTypes[0] : "<no>" : "<no>";
                labelTest.Text += i + ". " + Master.projectData.parameters[i].name + " " +
                    Master.projectData.parameters[i].dataType + " " +
                    Master.projectData.parameters[i].defaultValue + " " +
                    Master.projectData.parameters[i].uiControl + " " +
                    Master.projectData.parameters[i].icon + " " +
                    enums +
                    "\n";
            }
        }

        #endregion

        #region REG: Methods

        private void ResetNewParamControls()
        {
            isAllowedToMakeNewParam = true;

            tbNewParamName.Text = Uti.Temp.namePlaceHolder+"0";
            cbNewParamDataType.SelectedIndex = 0;
            tbNewParamDefaultValue.Text = "0";
            cbNewParamDefaultValue.Text = "";
            cbNewParamDefaultValue.Items.Clear();

            tbNewParamName.BackColor = Uti.ColorTheme.lightDimTextBox;
            tbNewParamName.Parent.BackColor = Uti.ColorTheme.lightDimTextBox;
            cbNewParamDataType.BackColor = Uti.ColorTheme.lightDimTextBox;
            tbNewParamDefaultValue.BackColor = Uti.ColorTheme.lightDimTextBox;
            tbNewParamDefaultValue.Parent.BackColor = Uti.ColorTheme.lightDimTextBox;
            cbNewParamDefaultValue.BackColor = Uti.ColorTheme.lightDimTextBox;


            labEnumDataTypes.Visible = false;
            Uti.Methods.DisposeAllChildren(flowEnumDataTypes);


            flowEnumDataTypes.Height = flowEnumHeight;
            flowEnum.Height = flowEnumHeight;
            newEnumTypes = new List<string>();//TODO: change trasfer the data to master and flowParam first
        }

        #endregion

        #region REG: Add new Param

        private void butNewParamAdd_Click(object sender, EventArgs e)
        {
            if (!isAllowedToMakeNewParam)
            {
                isAllowedToMakeNewParam = true;
                return;
            }

            if (Master.GetParamAllNames().Contains(tbNewParamName.Text))
            {
                tbNewParamName.BackColor = Uti.ColorTheme.red;
                tbNewParamName.Parent.BackColor = Uti.ColorTheme.red;
                return;
            }

            ParameterData newParamData = new ParameterData();
            if (cbNewParamDataType.Text != "Enum")
            {
                newParamData = new ParameterData(
                    tbNewParamName.Text,
                    cbNewParamDataType.Text,
                    tbNewParamDefaultValue.Text,
                    "Text Box",
                    false,
                    "<noIcon>"
                    );

                Master.projectData.parameters.Add(newParamData);

                flowParamsContainer.Controls.Add(
                    MakePanelParam(
                        tbNewParamName.Text,
                        cbNewParamDataType.Text,
                        tbNewParamDefaultValue.Text,
                        "Text Box",
                        newParamData
                        )
                    );
            }
            else
            {
                newParamData = new ParameterData(
                    tbNewParamName.Text,
                    cbNewParamDefaultValue.Text,
                    new List<string>(), // new enum types will be added when the controls are made
                    "<noIcon>"
                    );

                Master.projectData.parameters.Add(newParamData);

                flowParamsContainer.Controls.Add(
                    MakePanelParam(
                        tbNewParamName.Text,
                        cbNewParamDataType.Text,
                        cbNewParamDefaultValue.Text,
                        "Combo Box",
                        newParamData,
                        newEnumTypes
                        )
                    );
            }

            AddItemTemplateCBManage(newParamData);
            UpdateFlowParamsHeight();
            ResetNewParamControls();
        }

        private void UpdateFlowParamsHeight()
        {
            int heightTotal = 0;
            foreach (FlowParam flow in flowParams)
            {
                heightTotal += flow.flow.Height + flow.flow.Margin.Vertical;
            }

            flowParamsContainer.Height = heightTotal;

            Uti.Methods.UpdateMaxScroll(flowParamsContainer, panelScrollbarContainer, labScrollbar);
        }

        private void cbNewParamDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNewParamDataType.SelectedItem.ToString() == "Enum")
            {
                cbNewParamDefaultValue.Items.Clear();
                SetEnumControls(true);
                isEnumMode = true;

                if (tbNewParamDefaultValue.Size.Width > 0)
                {
                    cbNewParamDefaultValue.Size = tbNewParamDefaultValue.Size;
                    tbNewParamDefaultValue.Size = new Size(0, tbNewParamDefaultValue.Height);
                    flowNewParamDefaultValue.Size = new Size(0, tbNewParamDefaultValue.Height);

                    flowEnum.Size = new Size(flowEnum.Width, flowEnumHeight);
                    flowEnumDataTypes.Size = new Size(flowEnumDataTypes.Width, flowEnumHeight);
                }
            }
            else
            {
                isEnumMode = false;
                SetEnumControls(false);
                newEnumTypes = new List<string>();

                if (cbNewParamDefaultValue.Size.Width > 0)
                {
                    tbNewParamDefaultValue.Size = cbNewParamDefaultValue.Size;
                    flowNewParamDefaultValue.Size = cbNewParamDefaultValue.Size;
                    cbNewParamDefaultValue.Size = new Size(0, cbNewParamDefaultValue.Height);

                    flowEnum.Size = new Size(flowEnum.Width, flowEnumHeight);
                    flowEnumDataTypes.Size = new Size(flowEnumDataTypes.Width, flowEnumHeight);

                }
            }
        }

        private FlowLayoutPanel MakePanelParam(
            string name,
            string dataType,
            string defaultValue,
            string uiControl,
            ParameterData parameterData,
            List<string> newEnumTypes = null,
            string displayIcon = "<noIcon>"
            )
        {
            FlowParam flowParam = new FlowParam();
            List<string> newEnumTypesCopy = new List<string>();
            if (newEnumTypes != null)
            {
                for (int i = 0; i < newEnumTypes.Count; i++)
                {
                    newEnumTypesCopy.Add(newEnumTypes[i]);
                }
            }

            #region Flow Panel Parent
            FlowLayoutPanel flowParamContainer = new FlowLayoutPanel();
            flowParamContainer.BackColor = Uti.ColorTheme.lightFocus;
            flowParamContainer.Size = new Size(900, flowParamHeight);
            flowParamContainer.Margin = new Padding(0, 0, 0, 10);
            #endregion

            #region Move Icon
            Button butMove = Uti.MakeComponents.MakeButtonIcon("⚌", flowParamContainer.BackColor, Uti.ColorTheme.lightFocusBrighter, Uti.ColorTheme.lightButtonHover);
            butMove.MouseDown += flowParam_MouseDown;
            butMove.MouseUp += flowPram_MouseUp;

            flowParamContainer.Controls.Add(butMove);
            #endregion

            int flowWidthReal = flowParamContainer.Width - butMove.Width * 3; // there are two buttons: but move and but delete
            int panelWidth = flowWidthReal / 5; // there are five panels to contain parameter's data

            #region Flow Param Main
            // Contains all the TBs and CBs

            FlowLayoutPanel flowParamMain = new FlowLayoutPanel();
            flowParamMain.BackColor = Color.Transparent;
            flowParamMain.Size = new Size(flowWidthReal, flowParamContainer.Height);
            flowParamMain.Margin = new Padding(0);

            flowParamContainer.Controls.Add(flowParamMain);

            #endregion

            #region TB Name
            Panel panName = new Panel();
            panName.Size = new Size(panelWidth, flowParamMain.Height);
            panName.BackColor = Color.Transparent;
            panName.Margin = new Padding(0, 0, 0, 0);

            TextBox tbName = Uti.MakeComponents.MakeTextBoxRegular(name, new Size(panName.Width * 4 / 5, panName.Height), flowParamContainer.BackColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightFocusBrighter, Uti.ColorTheme.fontDark);
            string oldParamName = "";
            tbName.Enter += (sender, e) => { oldParamName = tbName.Text; };
            tbName.MouseEnter += (sender, e) => { oldParamName = tbName.Text; };
            tbName.Validated += (sender, e) =>
            {
                if (!Master.GetParamAllNames().Contains(tbName.Text))
                {
                    GetThisParamData(true).name = tbName.Text;
                    UpdateTemplateCBManage(oldParamName, GetThisParamData(), tbName.Text);
                }
                else
                {
                    tbName.Text = oldParamName;
                }
            };
            panName.Controls.Add(tbName);

            flowParamMain.Controls.Add(panName);

            #endregion

            #region CB Data Type
            Panel panDataType = new Panel();
            panDataType.Size = new Size(panelWidth, flowParamMain.Height);
            panDataType.BackColor = Color.Transparent;
            panDataType.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbDatatype = Uti.MakeComponents.MakeComboBoxRegular(ChatWeaverSystem.System.DataTypes, flowParamContainer.BackColor, dataType);
            // Delegates are assigned after cbDefaultValue has been declared
            panDataType.Controls.Add(cbDatatype);
            flowParamMain.Controls.Add(panDataType);

            #endregion

            #region TB/CB Default Value
            Panel panDefaultValue = new Panel();
            panDefaultValue.Size = new Size(panelWidth, flowParamMain.Height);
            panDefaultValue.BackColor = Color.Transparent;
            panDefaultValue.Margin = new Padding(0, 0, 0, 0);

            TextBox tbDefaultValue = Uti.MakeComponents.MakeTextBoxRegular(defaultValue, new Size(panDefaultValue.Width * 4 / 5, panDefaultValue.Height), flowParamContainer.BackColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightFocusBrighter, Uti.ColorTheme.fontDark);
            Uti.Methods.SetupInputDataType(
                controlInput:   tbDefaultValue, 
                GetDataType:    () => { return Uti.Methods.ConvertToDataType(cbDatatype.Text); }, 
                CallbackIsOkay: (isOkay) => { if (isOkay) OnDefaultValueChanged(tbDefaultValue); });
            panDefaultValue.Controls.Add(tbDefaultValue);

            ComboBox cbDefaultValue = Uti.MakeComponents.MakeComboBoxRegular(new List<string>(), flowParamContainer.BackColor, defaultValue);
            Uti.Methods.SetupInputDataType(
                controlInput:   cbDefaultValue,
                GetDataType:    () => { return Uti.Methods.ConvertToDataType(cbDatatype.Text); },
                CallbackIsOkay: (isOkay) => { if (isOkay) OnDefaultValueChanged(cbDefaultValue); }, 
                GetRefList:     () => { return Uti.Methods.ConvertToListString(cbDefaultValue.Items); });
            panDefaultValue.Controls.Add(cbDefaultValue);
            flowParamMain.Controls.Add(panDefaultValue);

            void OnDefaultValueChanged(Control _con)
            {
                GetThisParamData().defaultValue = _con.Text;
                UpdateTemplateCBManage(tbName.Text, GetThisParamData()); // Recreate the template input
            }
            #endregion

            #region CB UI Control Type
            Panel panUIControl = new Panel();
            panUIControl.Size = new Size(panelWidth, flowParamMain.Height);
            panUIControl.BackColor = Color.Transparent;
            panUIControl.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbUIControl = Uti.MakeComponents.MakeComboBoxRegular(dataType == "Enum" ? ChatWeaverSystem.System.UIControlsEnum : ChatWeaverSystem.System.UIControls, flowParamContainer.BackColor, uiControl);
            string oldUIControl = "";
            cbUIControl.Enter += (sender, e) => { oldUIControl = cbUIControl.Text; };
            cbUIControl.MouseEnter += (sender, e) => { oldUIControl = cbUIControl.Text; };
            cbUIControl.Validated += (sender, e) =>
            {
                if (cbUIControl.Items.Contains(cbUIControl.Text))
                {
                    GetThisParamData().uiControl = cbUIControl.Text;
                    UpdateTemplateCBManage(tbName.Text, GetThisParamData()); // Recreate the template input
                }
                else
                {
                    cbUIControl.Text = oldUIControl;
                }
            };
            panUIControl.Controls.Add(cbUIControl);

            flowParamMain.Controls.Add(panUIControl);

            #endregion

            #region >> CB Data Type : Moved to avoid error 
            // Avoid unassigned local variable
            string oldDataType = "";
            cbDatatype.Enter += (sender, e) => { oldDataType = cbDatatype.Text; };
            cbDatatype.MouseEnter += (sender, e) => { oldDataType = cbDatatype.Text; };
            cbDatatype.SelectedIndexChanged += (sender, e) => { OnChangeDataType(); };

            void OnChangeDataType()
            {
                if (cbDatatype.Items.Contains(cbDatatype.Text))
                {
                    if (oldDataType == cbDatatype.Text) return;

                    // From enum to another type
                    if (oldDataType == "Enum" && cbDatatype.Text != "Enum")
                    {
                        tbDefaultValue.Width = panelWidth;
                        cbDefaultValue.Width = 0;

                        #region Remove enum controls
                        int count = GetThisParamData().enumDataTypes.Count + flowParamMain.Controls.Count;// butAdd is included
                        flowParamMain.Height = flowParamHeight;
                        flowParamContainer.Height = flowParamHeight;
                        UpdateFlowParamsHeight();
                        cbDefaultValue.Items.Clear();
                        for (int i = flowParamMain.Controls.Count - 1; i > 4; i--)
                        {
                            flowParamMain.Controls[i].Dispose();
                        }
                        #endregion

                        #region Setup other data type initialization

                        tbDefaultValue.Text = "0";
                        GetThisParamData().dataType = cbDatatype.Text;
                        GetThisParamData().defaultValue = "0";

                        cbUIControl.Items.Clear();
                        cbUIControl.Items.AddRange(ChatWeaverSystem.System.UIControls.ToArray());
                        cbUIControl.SelectedIndex = 0;
                        GetThisParamData().uiControl = ChatWeaverSystem.System.UIControls[0];

                        #endregion
                    }

                    // From another type to enum
                    else if (cbDatatype.Text == "Enum")
                    {
                        tbDefaultValue.Width = 0;
                        cbDefaultValue.Width = 120;

                        #region Setup enum initializations
                        string placeHolderName = Uti.Temp.namePlaceHolder + "1";
                        List<string> newEnumTypesTemp = new List<string>() { placeHolderName };
                        SetupEnumFlowLocal(newEnumTypesTemp, GetThisParamIndex());
                        cbDefaultValue.SelectedIndex = 0;// = placeHolderName;
                        GetThisParamData().defaultValue = placeHolderName;

                        // Reset UI control list
                        cbUIControl.Items.Clear();
                        cbUIControl.Items.AddRange(ChatWeaverSystem.System.UIControlsEnum.ToArray());
                        cbUIControl.SelectedIndex = 0;
                        GetThisParamData().uiControl = ChatWeaverSystem.System.UIControlsEnum[0];
                        #endregion
                    }
                    else
                    {
                        tbDefaultValue.Text = "0";
                        GetThisParamData().dataType = cbDatatype.Text;
                        GetThisParamData().defaultValue = "0";
                    }
                    GetThisParamData().dataType = cbDatatype.Text;

                    oldDataType = cbDatatype.Text; // to prevent double execution since this method is called in SelectedIndexChanged and Validated

                    UpdateTemplateCBManage(tbName.Text, GetThisParamData()); // Recreate the template input
                }
                else
                {
                    cbDatatype.Text = oldDataType;
                }
            }

            #endregion

            #region CB Icon

            Panel panDisplayIcon = new Panel();
            panDisplayIcon.Size = new Size(panelWidth, flowParamMain.Height);
            panDisplayIcon.BackColor = Color.Transparent;
            panDisplayIcon.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbDisplayIcon = Uti.MakeComponents.MakeComboBoxRegular(ChatWeaverSystem.System.DisplayIcons, flowParamContainer.BackColor, displayIcon); // Default: <noIcon>
            string oldIcon = displayIcon;
            cbDisplayIcon.SelectedIndexChanged += (sender, e) => { UpdateIcon(); };
            cbDisplayIcon.Validated += (sender, e) => { 
                if(oldIcon != cbDisplayIcon.Text){ UpdateIcon(); }
                else{return;}
            };
            panDisplayIcon.Controls.Add(cbDisplayIcon);
            flowParamMain.Controls.Add(panDisplayIcon);

            void UpdateIcon()
            {
                GetThisParamData().icon = cbDisplayIcon.Text;
                UpdateTemplateCBManage(tbName.Text, GetThisParamData());
                oldIcon = cbDisplayIcon.Text;
            }

            #endregion

            #region SmallFlows Enum Data Types

            if (dataType == "Enum")
            {
                tbDefaultValue.Width = 0;
                SetupEnumFlowLocal(newEnumTypesCopy, flowParams.Count);
            }
            else
            {
                cbDefaultValue.Width = 0;
            }

            void SetupEnumFlowLocal(List<string> _newEnumTypesCopy, int masterIndex)
            {
                Master.projectData.parameters[masterIndex].enumDataTypes = new List<string>();
                for (int i = 0; i < _newEnumTypesCopy.Count; i++)
                {
                    FlowLayoutPanel newFlow = MakeEnumTypeControlLocal(_newEnumTypesCopy[i], masterIndex);
                    flowParamMain.Controls.Add(newFlow);
                }

                Button butAdd = Uti.MakeComponents.MakeButtonIcon("✚", Uti.ColorTheme.lightDimButton, Uti.ColorTheme.lightButtonHover, Uti.ColorTheme.lightButtonDown, new Size(22, 22), true);
                butAdd.ForeColor = Uti.ColorTheme.fontDarkDim;
                butAdd.Margin = new Padding(0, 0, 10, 0);
                butAdd.MouseClick += (sender, e) =>
                {
                    string nameHolder = Uti.Temp.namePlaceHolder;

                    int indexHolder = 0;
                    while (true)
                    {
                        indexHolder++;
                        if (!GetThisParamData().enumDataTypes.Contains(nameHolder + indexHolder.ToString()))
                        {
                            nameHolder += indexHolder.ToString();
                            break;
                        }
                    }
                    FlowLayoutPanel newFlow = MakeEnumTypeControlLocal(nameHolder, GetThisParamIndex());
                    flowParamMain.Controls.Add(newFlow);
                    flowParamMain.Controls.SetChildIndex(butAdd, flowParamMain.Controls.Count - 1);
                };
                flowParamMain.Controls.Add(butAdd);
            }

            FlowLayoutPanel MakeEnumTypeControlLocal(string nameNew, int masterIndex)
            {
                List<string> masterEnumData = Master.projectData.parameters[masterIndex].enumDataTypes;
                masterEnumData.Add(nameNew);

                cbDefaultValue.Items.Add(nameNew);

                FlowLayoutPanel newFlow = new FlowLayoutPanel();
                newFlow = MakeEnumTypeControl(
                                    text: nameNew,
                                    CallbackDelete: (thisEnumName) =>
                                    {
                                        if (GetThisParamData().enumDataTypes.Count <= 1) return;
                                        // Select new default value
                                        if (cbDefaultValue.Text == thisEnumName)
                                        {
                                            cbDefaultValue.Text = cbDefaultValue.Items.IndexOf(thisEnumName) == 0 ? cbDefaultValue.Items[1].ToString() : cbDefaultValue.Items[0].ToString();
                                            GetThisParamData().defaultValue = cbDefaultValue.Text;
                                        }
                                        // Dispose data
                                        cbDefaultValue.Items.Remove(thisEnumName);
                                        GetThisParamData().enumDataTypes.Remove(thisEnumName);
                                        newFlow.Dispose();
                                    },
                                    CallbackValidated: (oldName, newName, tb) =>
                                    {
                                        if (!GetThisParamData().enumDataTypes.Contains(newName))
                                        {
                                            int thisIndex = GetThisParamData().enumDataTypes.IndexOf(oldName);

                                            GetThisParamData().enumDataTypes.Remove(oldName);
                                            GetThisParamData().enumDataTypes.Insert(thisIndex, newName);

                                            cbDefaultValue.Items.Remove(oldName);
                                            cbDefaultValue.Items.Insert(thisIndex, newName);

                                            if(cbDefaultValue.Text == "" || cbDefaultValue.Text == oldName) cbDefaultValue.Text = newName; // Check if the renamed enum is the default value
                                        }
                                        else
                                        {
                                            tb.Text = oldName;
                                        }
                                    }
                                    );

                int newHeight = (int)Math.Ceiling(masterEnumData.Count / 5.0f) * (newFlow.Height + newFlow.Margin.Vertical); // Line break every 5 flows
                flowParamContainer.Height = flowParamHeight + newHeight;
                flowParamMain.Height = flowParamHeight + newHeight;

                UpdateFlowParamsHeight();

                return newFlow;
            }

            #endregion

            #region Pub Icon
            Button butPub = Uti.MakeComponents.MakeButtonIcon("🍻", flowParamContainer.BackColor, Uti.ColorTheme.pub, Uti.ColorTheme.pubDark);
            flowParamContainer.Controls.Add(butPub);
            #endregion

            #region More Icon
            bool isContextOpen = false;
            Button butMore = Uti.MakeComponents.MakeButtonIcon("⚙️", flowParamContainer.BackColor, Uti.ColorTheme.more, Uti.ColorTheme.moreDark);
            butMore.MouseClick += (sender, e) =>
            {
                DialogForms.ContextSimple contextSimple = new DialogForms.ContextSimple();
                isContextOpen = !isContextOpen;
                if (isContextOpen)
                {
                    contextSimple = new DialogForms.ContextSimple(true, () => { ShowInsight(); });
                    contextSimple.MakeMenuClick("Delete", () => { DeleteParam(); }, true, "🔥", Uti.ColorTheme.red);
                    contextSimple.Deactivate += (_sender, _e) => { isContextOpen = false; contextSimple.Dispose(); };

                    Point loc = new Point(flowParamContainer.PointToScreen(butMore.Location).X + butMore.Width, flowParamContainer.PointToScreen(butMore.Location).Y);
                    contextSimple.Location = loc;
                    contextSimple.Show();
                }
                else
                {
                    contextSimple.Dispose();
                }


                void DeleteParam()
                {
                    ParameterData deleteParam = GetThisParamData();
                    RemoveItemTemplateCBManage(deleteParam);
                    //flowParams.Remove(flowParam); //QUICK: fix? Don't remove?
                    flowParamContainer.Dispose();
                    Master.projectData.parameters.Remove(deleteParam);
                }

                void ShowInsight()
                {

                }
            };
            flowParamContainer.Controls.Add(butMore);
            #endregion

            #region Instantiate The Major Flow
            flowParam.SetData(
                flow: flowParamContainer,
                butMove: butMove,
                tbName: tbName,
                cbDataType: cbDatatype,
                tbDefaultValue: tbDefaultValue,
                cbDefaultValue: null, //TODO: update
                cbUIControl: cbUIControl,
                butLink: butPub,
                butDelete: butMore,
                paramData: parameterData,
                index: flowParams.Count
                );
            flowParams.Add(flowParam);
            #endregion

            return flowParamContainer;

            int GetThisParamIndex()
            {
                return flowParams[flowParams.IndexOf(flowParam)].index;
            }

            ParameterData GetThisParamData(bool useOldName = false)
            {
                try
                {
                    //labTitleAddNewParam.Text = flowParam.index.ToString();
                    //return Master.projectData.parameters[flowParams[flowParams.IndexOf(flowParam)].index];
                    int index = Master.GetParamAllNames().IndexOf(useOldName ? oldParamName : tbName.Text) ;
                    return Master.projectData.parameters[index];
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    string b = Master.GetParamAllNames()[0];
                    int a = Master.GetParamAllNames().IndexOf(oldParamName);
                    throw null;
                }

            }

        }

        #endregion

        #region REG: New Enum Data Types

        bool isEnumMode = false;
        List<string> newEnumTypes = new List<string>();
        string oldEnumType = "";
        private void SetEnumControls(bool isActive)
        {
            if (isEnumMode) return;
            if (isActive)
            {
                labEnumDataTypes.Visible = true;
                flowEnumDataTypes.Controls.Add(MakeEnumTypeControlLocal());

                Button butAdd = Uti.MakeComponents.MakeButtonIcon("✚", Uti.ColorTheme.lightDimButton, Uti.ColorTheme.lightButtonHover, Uti.ColorTheme.lightButtonDown, new Size(22, 22), true);
                butAdd.ForeColor = Uti.ColorTheme.fontDarkDim;
                butAdd.Margin = new Padding(0, 0, 10, 0);
                butAdd.MouseClick += (sender, e) =>
                {
                    FlowLayoutPanel newFlow = MakeEnumTypeControlLocal();
                    flowEnumDataTypes.Controls.Add(newFlow);
                    flowEnumDataTypes.Controls.SetChildIndex(butAdd, flowEnumDataTypes.Controls.Count - 1);
                    flowEnumDataTypes.Height = (int)Math.Ceiling(newEnumTypes.Count / 5.0f) * (newFlow.Height + newFlow.Margin.Vertical);

                    flowEnum.Height = flowEnumDataTypes.Height;
                };
                flowEnumDataTypes.Controls.Add(butAdd);
            }
            else
            {
                labEnumDataTypes.Visible = false;
                Uti.Methods.DisposeAllChildren(flowEnumDataTypes);
            }

            FlowLayoutPanel MakeEnumTypeControlLocal()
            {
                string namePlaceHolder = Uti.Temp.namePlaceHolder;
                int index = 0;
                while (true)
                {
                    index++;
                    if (!newEnumTypes.Contains(namePlaceHolder + index.ToString()))
                    {
                        namePlaceHolder += index.ToString();
                        break;
                    }
                }

                newEnumTypes.Add(namePlaceHolder);
                cbNewParamDefaultValue.Items.Add(namePlaceHolder);
                cbNewParamDefaultValue.SelectedIndex = 0;

                FlowLayoutPanel newFlowEnum = new FlowLayoutPanel();
                newFlowEnum = MakeEnumTypeControl(
                    text: namePlaceHolder,
                    CallbackDelete: (name) =>
                    {
                        if (newEnumTypes.Count <= 1) return;
                        if(cbNewParamDefaultValue.Text == name)
                        {
                            cbNewParamDefaultValue.Text = cbNewParamDefaultValue.Items.IndexOf(name) == 0 ? cbNewParamDefaultValue.Items[1].ToString() : cbNewParamDefaultValue.Items[0].ToString();
                        }

                        newEnumTypes.Remove(name);
                        cbNewParamDefaultValue.Items.Remove(name);
                        newFlowEnum.Dispose();
                    },
                    CallbackValidated: (oldName, newName, tb) =>
                    {
                        if (!newEnumTypes.Contains(newName))
                        {
                            int thisIndex = newEnumTypes.IndexOf(oldName);

                            newEnumTypes.Remove(oldName);
                            newEnumTypes.Insert(thisIndex, newName);

                            cbNewParamDefaultValue.Items.Remove(oldName);
                            cbNewParamDefaultValue.Items.Insert(thisIndex, newName);
                            if (cbNewParamDefaultValue.Text == "" || cbNewParamDefaultValue.Text == oldName) cbNewParamDefaultValue.Text = newName; // Check if the renamed enum is the default value. OldName is used when "unnamed1" is manually printed on the cb
                        }
                        else
                        {
                            tb.Text = oldEnumType; //TODO: default parameter names cannot be used inany input
                        }
                    });

                return newFlowEnum;
            }
        }

        private FlowLayoutPanel MakeEnumTypeControl(string text, Action<string> CallbackDelete, Action<string, string, TextBox> CallbackValidated)
        {
            string tempName = text;
            FlowLayoutPanel flowDataTypeMember = new FlowLayoutPanel();
            flowDataTypeMember.Size = new Size(130, 22);
            flowDataTypeMember.BackColor = Uti.ColorTheme.lightDimTextBox;
            flowDataTypeMember.Margin = new Padding(0, 0, 10, 10);

            TextBox tbDataType = Uti.MakeComponents.MakeTextBoxRegular(tempName, new Size(100, flowDataTypeMember.Height), flowDataTypeMember.BackColor);
            tbDataType.Margin = new Padding(3, 0, 0, 0);
            tbDataType.Enter += (sender, e) => { oldEnumType = tbDataType.Text; tbDataType.Focus(); tbDataType.SelectAll(); };
            tbDataType.MouseClick += (sender, e) => { oldEnumType = tbDataType.Text; tbDataType.Focus(); tbDataType.SelectAll(); };
            tbDataType.Validated += (sender, e) => { CallbackValidated(oldEnumType, tbDataType.Text, tbDataType); };
            flowDataTypeMember.Controls.Add(tbDataType);

            Button butDelete = Uti.MakeComponents.MakeButtonIcon("🔥", flowDataTypeMember.BackColor, Uti.ColorTheme.red, Uti.ColorTheme.redDark, new Size(flowDataTypeMember.Height, flowDataTypeMember.Height), true);
            butDelete.ForeColor = Uti.ColorTheme.fontDarkDim;
            butDelete.Margin = new Padding(5, 0, 0, 0);
            butDelete.MouseClick += (sender, e) => { CallbackDelete(tbDataType.Text); };
            flowDataTypeMember.Controls.Add(butDelete);

            ActiveControl = null;

            tbDataType.SelectAll();
            tbDataType.Focus();


            return flowDataTypeMember;
        }

        #endregion

        #region REG: Moving Flow Param

        FlowParam flowCurrent = new FlowParam();
        private void flowParam_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocWhenDown = new Point(e.X, e.Y);
            foreach (FlowParam flow in flowParams)
            {
                if (flow.butMove == sender)
                {
                    flowCurrent = flow;
                    flowCurrent.flow.BackColor = Uti.ColorTheme.lightButtonHover;
                }
            }

            isMouseMoving = true;
        }

        private void flowPram_MouseUp(object sender, MouseEventArgs e)
        {
            Point newLocation = new Point(0, e.Y - mouseLocWhenDown.Y);
            //int indexOld = flowParams.IndexOf(flowCurrent);
            int indexOld = flowCurrent.index;

            int index = flowParamsContainer.Controls.GetChildIndex(flowCurrent.flow) + (
                newLocation.Y > 0
                ? ((int)Math.Floor((float)newLocation.Y / (flowParamHeight + 10)))
                : ((int)Math.Ceiling((float)newLocation.Y / (flowParamHeight + 10))));
            index = index > 0 ? index < flowParams.Count ? index : flowParams.Count - 1 : 0;

            // Reorder UI controls
            flowParamsContainer.Controls.SetChildIndex(flowCurrent.flow, index);

            // Reorder master data
            ParameterData tempParamData = new ParameterData(flowCurrent.paramData);
            if (index == flowParams.Count - 1) Master.projectData.parameters.Add(tempParamData);
            else Master.projectData.parameters.Insert(index, tempParamData);
            Master.projectData.parameters.Remove(flowCurrent.paramData);

            // Reorder the flowParam data handlers in flowParams
            if (index < indexOld)
            {
                for (int i = indexOld - 1; i >= index; i--)
                {
                    flowParams[i].index++;
                }
            }
            else if (index > indexOld)
            {
                for (int i = indexOld + 1; i <= index; i++)
                {
                    try
                    {
                        flowParams[i].index--;

                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        System.Diagnostics.Debug.WriteLine(i.ToString());

                        System.Diagnostics.Debug.WriteLine(i.ToString());
                        throw;
                    }
                }
            }

            // Assign new data in new location
            flowCurrent.index = index;
            flowCurrent.paramData = tempParamData;
            flowCurrent.flow.BackColor = Uti.ColorTheme.lightFocus;

            isMouseMoving = false;
        }

        #endregion

        #region REG: Scrollbar

        bool isMouseMoving = false;
        Point mouseLocWhenDown;
        public void ScrolllMouseUp(object sender, MouseEventArgs e)
        {
            isMouseMoving = false;
        }
        public void ScrollMouseDown(object sender, MouseEventArgs e)
        {
            isMouseMoving = true;
            mouseLocWhenDown = new Point(e.X, e.Y);
        }
        public void ScrollMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseMoving)
                Uti.Methods.ScrollMouseMove(e, mouseLocWhenDown, flowParamsContainer, panelScrollbarContainer, labScrollbar);
        }

        private void controlScroll_MouseScroll(object sender, MouseEventArgs e)
        {
            Uti.Methods.ScrollMouseMove(new Point(0, -e.Delta / 10), flowParamsContainer, panelScrollbarContainer, labScrollbar);
        }


        #endregion

        #region REG: Handlers

        bool isAllowedToMakeNewParam = true;
        private void DisallowToMakeNewParam()
        {
            isAllowedToMakeNewParam = false;
        }

        #endregion

        #region REG: Template

        List<ComboBox> templateBottomCBs = new List<ComboBox>();
        List<ComboBox> templateRightCBs = new List<ComboBox>();
        List<TemplateInput> templateInputsRight = new List<TemplateInput>();
        List<TemplateInput> templateInputsBottom = new List<TemplateInput>();

        class TemplateInput 
        {
            public string icon;
            public Control control;
            public ComboBox cbManage;
            public RightOrBottom rob;

            public TemplateInput(string icon, Control control, ComboBox cbManage, RightOrBottom rob)
            {
                this.icon = icon;
                this.control = control;
                this.cbManage = cbManage;
                this.rob = rob;
            }
        }

        private void AddItemTemplateCBManage(ParameterData param)
        {
            if (param.linkedToPub) cbManageTempLeft.Items.Add(param.name);

            foreach (ComboBox cb in templateBottomCBs)
            {
                    cb.Items.Add(param.name);
            }
            foreach (ComboBox cb in templateRightCBs)
            {
                    cb.Items.Add(param.name);
            }
        }

        private void RemoveItemTemplateCBManage(ParameterData param)
        {
            if (param.linkedToPub)
            {
                cbManageTempLeft.Items.Remove(param.name);

                // If this cb has the deleted param name
                if (cbManageTempLeft.Text == param.name)
                {
                    cbManageTempLeft.Text = "";
                    labManageTempLeft.Text = "";
                    picTemp.Image = null;
                }
            }
            foreach (ComboBox cb in templateBottomCBs)
            {
                cb.Items.Remove(param.name);

                // If this cb has the deleted param name
                if (cb.Text == param.name || cb.Text == "")
                {
                    int index = templateBottomCBs.IndexOf(cb);
                    templateInputsBottom[index].control.Dispose();
                    templateInputsBottom.RemoveAt(index);
                    templateBottomCBs.Remove(cb);
                    cb.Dispose();
                    break;
                }
            }
            foreach (ComboBox cb in templateRightCBs)
            {
                cb.Items.Remove(param.name);

                // If this cb has the deleted param name
                if (cb.Text == param.name || cb.Text == "")
                {
                    int index = templateRightCBs.IndexOf(cb);
                    templateInputsRight[index].control.Dispose();
                    templateInputsRight.RemoveAt(index);
                    templateRightCBs.Remove(cb);
                    cb.Dispose();
                    break;
                }
            }
        }

        private void UpdateTemplateCBManage(string name, ParameterData paramData, string newName = "")
        {
            newName = newName == "" ? name : newName; // Check whether there's a new name
            if (paramData.linkedToPub)
            {
                cbManageTempLeft.Items[cbManageTempLeft.Items.IndexOf(name)] = newName;
                if(cbManageTempLeft.Text == name)
                {
                    cbManageTempLeft.Text = newName;
                    labManageTempLeft.Text = paramData.defaultValue;
                }
            }
            foreach (ComboBox cb in templateBottomCBs)
            {
                if(cb.Text == name)
                {
                    cb.Items[cb.Items.IndexOf(name)] = newName;
                    cb.Text = newName;
                    int index = templateBottomCBs.IndexOf(cb);
                    int indexInFlow = flowTempBottom.Controls.IndexOf(templateInputsBottom[index].control);
                    templateInputsBottom[index].control.Dispose();
                    templateInputsBottom[index].icon = paramData.icon;
                    Control newControl = MakeTemplateInput(paramData.uiControl, RightOrBottom.Bottom, paramData, cb);
                    templateInputsBottom[index].control = newControl;
                    flowTempBottom.Controls.SetChildIndex(newControl, indexInFlow);
                }
                else
                {
                    cb.Items[cb.Items.IndexOf(name)] = newName;
                }
            }
            foreach (ComboBox cb in templateRightCBs)
            {
                if (cb.Text == name)
                {
                    cb.Items[cb.Items.IndexOf(name)] = newName;
                    cb.Text = newName;
                    int index = templateRightCBs.IndexOf(cb);
                    int indexInFlow = flowTempRight.Controls.IndexOf(templateInputsRight[index].control);
                    templateInputsRight[index].control.Dispose();
                    templateInputsRight[index].icon = paramData.icon;
                    Control newControl = MakeTemplateInput(paramData.uiControl, RightOrBottom.Right, paramData, cb);
                    templateInputsRight[index].control = newControl;
                    flowTempRight.Controls.SetChildIndex(newControl, indexInFlow);
                }
                else
                {
                    cb.Items[cb.Items.IndexOf(name)] = newName;
                }
            }
        }

        enum RightOrBottom { Right, Bottom };
        static class TemplateRight
        {
            //NOTE: more controls in template right will cause the scrollbar to emerge and decrease the height of the child flows
            public static Size parentSize = new Size(720, 160);
            public static Padding parentPadding = new Padding(10, 15, 10, 15);
            public static Color backColor = Uti.ColorTheme.lightFocus;
            public static Size childSize = new Size(700, 120);
            public static Font font = Uti.FontTheme.regular;
        }
        static class TemplateBottom
        {
            public static Size parentSize = new Size(900, 40);
            public static Color backColor = Uti.ColorTheme.lightDimAccent220;
            public static Padding childFlowPadding = new Padding(5, 0, 0, 0);
            public static Size childFlowSize = new Size(180, 40);
            public static Size childControlInputSize = new Size(110, 40);
            public static Size childIconSize = new Size(60, childFlowSize.Height);
            public static Font font = Uti.FontTheme.small;
        }

        private void MakeTemplateCBManage(FlowLayoutPanel parent, RightOrBottom rightOrBottom)
        {
            #region Select a name that hasn't been selected
            ParameterData unselectedParam = Master.projectData.parameters[0];
            List<ComboBox> combinedCBs = new List<ComboBox>();
            combinedCBs.AddRange(templateRightCBs);
            combinedCBs.AddRange(templateBottomCBs);
            List<string> allNames = Master.GetParamAllNames().ToList();
            for ( int i = allNames.Count-1; i>=0; i--)
            {
                foreach (ComboBox item in combinedCBs)
                {
                    if (item.Text == allNames[i])
                    {
                        allNames.RemoveAt(i);
                        break;
                    }
                }
            }

            // one of the first data that hasn't been selected
            unselectedParam = Master.projectData.parameters[Master.GetParamAllNames().IndexOf(allNames[0])]; 
            #endregion

            #region Instantiate

            ComboBox cb = Uti.MakeComponents.MakeComboBoxRegular(Master.GetParamAllNames(), Uti.ColorTheme.lightDimTextBox, unselectedParam.name);
            cb.Margin = new Padding(0, 3, 5, 2);
            cb.Items.Insert(0, "<delete>");
            Uti.Methods.SetupInputDataType(
                controlInput:   cb,
                dataType: ChatWeaverSystem.System.DataTypesParam.Enum,
                CallbackIsOkay: (isOkay) => { CheckSelectedIndex(isOkay, rightOrBottom, cb);},
                GetRefList:     () =>
                {
                    List<string> names = new List<string>();
                    names.Add("<delete>");
                    names.AddRange(Master.GetParamAllNames());
                    return names;
                });

            //cb.SelectedIndexChanged += (sender, e) => { CheckSelectedIndex(rightOrBottom, cb); };

            #endregion

            #region Locate in the template

            if (rightOrBottom == RightOrBottom.Right)
            {
                templateRightCBs.Add(cb);
                flowTempRight.Controls.Add(MakeTemplateInput(unselectedParam.uiControl, rightOrBottom, unselectedParam, cb));
            }
            else
            {
                templateBottomCBs.Add(cb);
                flowTempBottom.Controls.Add(MakeTemplateInput(unselectedParam.uiControl, rightOrBottom, unselectedParam, cb));
            }

            parent.Controls.Add(cb);

            #endregion

            #region Local Methods

            void CheckSelectedIndex(bool _isOkay, RightOrBottom _rightOrBottom, ComboBox _cb)
            {
                if (_cb.SelectedIndex == 0)
                {
                    if (_rightOrBottom == RightOrBottom.Right)
                    {
                        templateRightCBs.Remove(_cb);
                        foreach (TemplateInput item in templateInputsRight)
                        {
                            if(item.cbManage == _cb)
                            {
                                Uti.Methods.DisposeAllChildren(item.control, true);
                                item.cbManage.Dispose();
                                templateInputsRight.Remove(item);
                                break;
                            }
                        }
                    }
                    else
                    {
                        templateBottomCBs.Remove(_cb);
                        foreach (TemplateInput item in templateInputsBottom)
                        {
                            if (item.cbManage == _cb)
                            {
                                Uti.Methods.DisposeAllChildren(item.control, true);
                                item.cbManage.Dispose();
                                templateInputsBottom.Remove(item);
                                break;
                            }
                        }
                    }
                    DestroyThis(_cb, _rightOrBottom);
                }
                else
                {
                    // TODO: switch same control ui
                    List<ComboBox> allCBs = new List<ComboBox>();
                    allCBs.AddRange(templateRightCBs);
                    allCBs.AddRange(templateBottomCBs);

                    foreach (ComboBox comboBox in allCBs)
                    {
                        if(comboBox.SelectedIndex == _cb.SelectedIndex)
                        {
                            int temp = _cb.SelectedIndex;
                            _cb.SelectedIndex = comboBox.SelectedIndex;
                            comboBox.SelectedIndex = temp;

                            //TODO: switch the control

                            return;
                        }
                    }

                    // TODO: Instantiate the contorl based on index
                }

            }

            void DestroyThis(ComboBox _cb, RightOrBottom rob)
            {
                // TODO: remove the control ui based on index


                int index = rob == RightOrBottom.Right ? templateRightCBs.IndexOf(_cb) : templateBottomCBs.IndexOf(_cb);

                if (rob == RightOrBottom.Right) templateRightCBs.Remove(cb);
                else templateBottomCBs.Remove(cb);
                _cb.Dispose();
            }

            #endregion
        }

        Control MakeTemplateInput(string controlType, RightOrBottom rob, ParameterData paramData, ComboBox cb)
        {
            Control control = new Control();

            string icon = Master.projectData.parameters[Master.GetParamAllNames().IndexOf(cb.Text)].icon;
            int index = Master.GetParamAllNames().IndexOf(cb.Text);

            if (rob == RightOrBottom.Right)
            {
                // NOTE: The child in Right doesn't show icon and doesn't have container;
                if (controlType == "Text Box")
                {
                    control = Uti.MakeComponents.MakeTextBoxRegular(paramData.defaultValue, TemplateRight.childSize, TemplateRight.backColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightFocusBrighter);
                    (control as TextBox).Multiline = true;
                }
                else if (controlType == "Label")
                {
                    control = Uti.MakeComponents.MakeLabelRegular(paramData.defaultValue, TemplateRight.backColor);
                    (control as Label).AutoSize = false;
                    (control as Label).Size = TemplateRight.childSize;
                }
                else if (controlType == "Combo Box")
                {
                    control = Uti.MakeComponents.MakeComboBoxRegular(paramData.enumDataTypes, TemplateRight.backColor, paramData.defaultValue);
                    control.Size = TemplateRight.childSize;
                }

                control.Font = TemplateRight.font;
                TemplateInput ti = new TemplateInput(icon, control, cb, rob);
                templateInputsRight.Add(ti);
                flowTempRight.Controls.Add(control);
            }
            else
            {
                control = new FlowLayoutPanel();
                control.Size = TemplateBottom.childFlowSize;
                control.Padding = TemplateBottom.childFlowPadding;
                control.Margin = new Padding(0);
                control.BackColor = TemplateBottom.backColor;
                control.Font = TemplateBottom.font;

                Label _icon = Uti.MakeComponents.MakeLabelRegular(paramData.icon == "<noIcon>" ? paramData.name+":" : paramData.icon, TemplateBottom.backColor);
                _icon.AutoSize = false;
                _icon.Size = TemplateBottom.childIconSize;
                _icon.Font = TemplateBottom.font;
                _icon.TextAlign = ContentAlignment.MiddleRight;
                _icon.AutoEllipsis = true;
                _icon.Padding = new Padding(0, 0, 2, 0);
                control.Controls.Add(_icon);


                // NOTE: The child in Right doesn't show icon and doesn't have container;
                if (controlType == "Text Box")
                {
                    FlowLayoutPanel container = new FlowLayoutPanel();
                    container.Size = TemplateBottom.childControlInputSize;
                    container.Padding = new Padding(3, 12, 3, 3);
                    container.Margin = new Padding(0, 0, 0, 0);
                    control.Controls.Add(container);
                    Size tbSize = new Size(TemplateBottom.childControlInputSize.Width - container.Padding.Horizontal, TemplateBottom.childControlInputSize.Height - container.Padding.Vertical);
                    TextBox tb = Uti.MakeComponents.MakeTextBoxRegular(paramData.defaultValue, tbSize, TemplateBottom.backColor);
                    tb.Font = TemplateBottom.font;
                    container.Controls.Add(tb);
                }
                else if (controlType == "Label")
                {
                    Label lab = Uti.MakeComponents.MakeLabelRegular(paramData.defaultValue, TemplateBottom.backColor);
                    lab.AutoSize = false;
                    lab.Size = TemplateBottom.childControlInputSize;
                    lab.Font = TemplateBottom.font;
                    control.Controls.Add(lab);
                }
                else if (controlType == "Combo Box")
                {
                    ComboBox _cb = Uti.MakeComponents.MakeComboBoxRegular(paramData.enumDataTypes, TemplateBottom.backColor, paramData.defaultValue);
                    _cb.Size = new Size(TemplateBottom.childControlInputSize.Width - TemplateBottom.childFlowPadding.Horizontal, 25);
                    _cb.Margin = new Padding(0, 5, 0, 0);
                    control.Controls.Add(_cb);
                }

                TemplateInput ti = new TemplateInput(icon, control, cb, rob);
                templateInputsBottom.Add(ti);
                flowTempBottom.Controls.Add(control);
            }

            return control;
        }

        #endregion
    }
}
