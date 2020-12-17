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
            public FlowParam(){}
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

            this.MouseWheel += (sender,e) => { labScrollbar.Focus(); controlScroll_MouseScroll(sender, e); };
            Uti.Methods.SetupForm(this);
            Uti.Methods.SetupInputDataType(tbNewParamName, ChatWeaverSystem.System.DataTypesParam.String, (isOkay)=> { if (!isOkay) DisallowToMakeNewParam(); }, ()=> { return Master.GetParamAllNames(); });
            Uti.Methods.SetupInputDataType(cbNewParamDataType, ChatWeaverSystem.System.DataTypesParam.Enum, (isOkay)=>{ if(!isOkay)DisallowToMakeNewParam();}, ChatWeaverSystem.System.DataTypes);
            Uti.Methods.SetupInputDataType(tbNewParamDefaultValue, Uti.Methods.ConvertToDataType(cbNewParamDataType.Text), (isOkay)=> { if(Uti.Methods.ConvertToDataType(cbNewParamDataType.Text) != ChatWeaverSystem.System.DataTypesParam.Enum) if(!isOkay)DisallowToMakeNewParam(); });
            Uti.Methods.SetupInputDataType(cbNewParamDefaultValue, ChatWeaverSystem.System.DataTypesParam.Enum, (isOkay) => { if (Uti.Methods.ConvertToDataType(cbNewParamDataType.Text) == ChatWeaverSystem.System.DataTypesParam.Enum) if (!isOkay) DisallowToMakeNewParam(); }, newEnumTypes );//Uti.Methods.ConvertToListString(cbNewParamDefaultValue.Items)

            #endregion

            //TODO: Load parameter datas, then update scroll bar
            Uti.Methods.UpdateMaxScroll(flowParamsContainer, panelScrollbarContainer, labScrollbar);

            // TODO: delete test methods
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += (sender,e)=> { DisplayDatas(); } ;
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
                labelTest.Text += i + ". " + Master.projectData.parameters[i].name+" "+ 
                    Master.projectData.parameters[i].dataType + " "+ 
                    Master.projectData.parameters[i].defaultValue +" "+ 
                    Master.projectData.parameters[i].uiControl +" " +
                    enums+
                    "\n";
            }
        }
        #endregion

        #region REG: Methods

        private void ResetNewParamControls()
        {
            isAllowedToMakeNewParam = true;

            tbNewParamName.Text = Uti.Temp.namePlaceHolder;
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

            if (cbNewParamDataType.Text != "Enum")
            {
                ParameterData newParamData = new ParameterData(
                    tbNewParamName.Text,
                    cbNewParamDataType.Text,
                    tbNewParamDefaultValue.Text,
                    "Text Box",
                    false
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
                ParameterData newParamData = new ParameterData(
                    tbNewParamName.Text,
                    cbNewParamDefaultValue.Text,
                    new List<string>() // new enum types will be added when the controls are made
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
            FlowParam thisFlowParam = new FlowParam();
            int indexOfThisFlow = flowParams.Count;
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
            Button butMove = Uti.MakeComponents.MakeButtonIcon("⚌", flowParamContainer.BackColor, Uti.ColorTheme.lightFocusDim, Uti.ColorTheme.lightButtonHover);
            butMove.MouseDown += flowParam_MouseDown;
            butMove.MouseUp += flowPram_MouseUp;

            flowParamContainer.Controls.Add(butMove);
            #endregion

            int flowWidthReal = flowParamContainer.Width - butMove.Width*3   ; // there are two buttons: but move and but delete
            int panelWidth = flowWidthReal / 5; // there are five panels to contain parameter's data

            #region Flow Param Main

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

            TextBox tbName = Uti.MakeComponents.MakeTextBoxRegular(name, new Size(panName.Width * 4 / 5, panName.Height), flowParamContainer.BackColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightDimTextBox, Uti.ColorTheme.fontDark);
            string oldParamName ="";
            tbName.Enter += (sender, e) => { oldParamName = tbName.Text; };
            tbName.MouseEnter += (sender, e) => { oldParamName = tbName.Text; };
            tbName.Validated += (sender, e) => 
            { 
                if (!Master.GetParamAllNames().Contains(tbName.Text))
                {
                    Master.projectData.parameters[GetMasterIndex()].name = tbName.Text;
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

            TextBox tbDefaultValue = Uti.MakeComponents.MakeTextBoxRegular(defaultValue, new Size(panDefaultValue.Width * 4 / 5, panDefaultValue.Height), flowParamContainer.BackColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightDimTextBox, Uti.ColorTheme.fontDark);
            Uti.Methods.SetupInputDataType(tbDefaultValue, () => { return Uti.Methods.ConvertToDataType(cbDatatype.Text); }, (isOkay)=> { Master.projectData.parameters[GetMasterIndex()].defaultValue = tbDefaultValue.Text; });
            panDefaultValue.Controls.Add(tbDefaultValue);

            ComboBox cbDefaultValue = Uti.MakeComponents.MakeComboBoxRegular(new List<string>(), flowParamContainer.BackColor, defaultValue);
            Uti.Methods.SetupInputDataType(cbDefaultValue, () => { return Uti.Methods.ConvertToDataType(cbDatatype.Text); }, (isOkay) => { Master.projectData.parameters[GetMasterIndex()].defaultValue = cbDefaultValue.Text; }, ()=> { return Uti.Methods.ConvertToListString(cbDefaultValue.Items); });
            panDefaultValue.Controls.Add(cbDefaultValue);
            flowParamMain.Controls.Add(panDefaultValue);
            #endregion

            #region >> CB Data Type : Moved to avoid error 
            // Avoid unassigned local variable
            string oldDataType = "";
            cbDatatype.Enter += (sender, e) => { oldDataType = cbDatatype.Text; };
            cbDatatype.MouseEnter += (sender, e) => { oldDataType = cbDatatype.Text; };
            cbDatatype.Validated += (sender, e) => { CheckDataType(); };
            cbDatatype.SelectedIndexChanged += (sender, e) =>{ CheckDataType(); };

            void CheckDataType()
            {
                if (cbDatatype.Items.Contains(cbDatatype.Text))
                {
                    if (oldDataType == cbDatatype.Text) return;

                    oldDataType = cbDatatype.Text; // to prevent double execution since this method is called in SelectedIndexChanged and Validated

                    // From enum to another type
                    if (oldDataType == "Enum" && cbDatatype.Text != "Enum")
                    {
                        tbDefaultValue.Width = 100;
                        cbDefaultValue.Width = 0;

                        #region Remove enum controls
                        int count = Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Count + flowParamMain.Controls.Count;// butAdd is included
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
                        Master.projectData.parameters[GetMasterIndex()].dataType = cbDatatype.Text;
                        Master.projectData.parameters[GetMasterIndex()].defaultValue = "0";

                        #endregion

                    }
                    // From another type to enum
                    else if (cbDatatype.Text == "Enum")
                    {
                        tbDefaultValue.Width = 0;
                        cbDefaultValue.Width = 100;

                        #region Setup enum initializations
                        string placeHolderName = Uti.Temp.namePlaceHolder + "1";
                        List<string> newEnumTypesTemp = new List<string>() { placeHolderName };
                        SetupEnumFlowLocal(newEnumTypesTemp, GetMasterIndex());
                        cbDefaultValue.Text = placeHolderName;
                        Master.projectData.parameters[GetMasterIndex()].defaultValue = placeHolderName;
                        #endregion
                    }
                    else
                    {
                        tbDefaultValue.Text = "0";
                        Master.projectData.parameters[GetMasterIndex()].dataType = cbDatatype.Text;
                        Master.projectData.parameters[GetMasterIndex()].defaultValue = "0";
                    }
                    Master.projectData.parameters[GetMasterIndex()].dataType = cbDatatype.Text;
                }
                else
                {
                    cbDatatype.Text = oldDataType;
                }
            }
            #endregion

            #region CB UI Control Type
            Panel panUIControl = new Panel();
            panUIControl.Size = new Size(panelWidth, flowParamMain.Height);
            panUIControl.BackColor = Color.Transparent;
            panUIControl.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbUIControl = Uti.MakeComponents.MakeComboBoxRegular(dataType=="Enum"? ChatWeaverSystem.System.UIControlsEnum: ChatWeaverSystem.System.UIControls, flowParamContainer.BackColor, uiControl);
            string oldUIControl = "";
            cbUIControl.Enter += (sender, e) => { oldUIControl = cbUIControl.Text; };
            cbUIControl.MouseEnter += (sender, e) => { oldUIControl = cbUIControl.Text; };
            cbUIControl.Validated += (sender, e) =>
            {
                if (cbUIControl.Items.Contains(cbUIControl.Text))
                {
                    Master.projectData.parameters[GetMasterIndex()].uiControl = cbUIControl.Text;
                }
                else
                {
                    cbUIControl.Text = oldUIControl;
                }
            };
            panUIControl.Controls.Add(cbUIControl);

            flowParamMain.Controls.Add(panUIControl);

            #endregion

            #region CB Icon

            Panel panDisplayIcon = new Panel();
            panDisplayIcon.Size = new Size(panelWidth, flowParamMain.Height);
            panDisplayIcon.BackColor = Color.Transparent;
            panDisplayIcon.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbDisplayIcon = Uti.MakeComponents.MakeComboBoxRegular(ChatWeaverSystem.System.DisplayIcons, flowParamContainer.BackColor, displayIcon); // Default: <noIcon>
            panDisplayIcon.Controls.Add(cbDisplayIcon);

            flowParamMain.Controls.Add(panDisplayIcon);

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
                        if (!Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Contains(nameHolder + indexHolder.ToString()))
                        {
                            nameHolder += indexHolder.ToString();
                            break;
                        }
                    }
                    FlowLayoutPanel newFlow = MakeEnumTypeControlLocal(nameHolder, GetMasterIndex());
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
                                    nameNew,
                                    (thisEnum) =>
                                    {
                                        if (Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Count <= 1) return;
                                        Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Remove(thisEnum);
                                        cbDefaultValue.Items.Remove(thisEnum);
                                        newFlow.Dispose();
                                    },
                                    (oldName, newName, tb) =>
                                    {
                                        if (!Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Contains(newName))
                                        {
                                            int thisIndex = Master.projectData.parameters[GetMasterIndex()].enumDataTypes.IndexOf(oldName);

                                            Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Remove(oldName);
                                            Master.projectData.parameters[GetMasterIndex()].enumDataTypes.Insert(thisIndex, newName);

                                            cbDefaultValue.Items.Remove(oldName);
                                            cbDefaultValue.Items.Insert(thisIndex, newName);
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
            Button butMore = Uti.MakeComponents.MakeButtonIcon("⚙️", flowParamContainer.BackColor, Uti.ColorTheme.more, Uti.ColorTheme.moreDark);
            butMore.MouseClick += (sender, e) =>
            {
                DialogForms.ContextSimple contextSimple = new DialogForms.ContextSimple(true,()=> { ShowInsight(); });
                contextSimple.MakeMenuClick("Delete", () => { DeleteParam(); }, true, "🔥", Uti.ColorTheme.red);
                contextSimple.MakeMenuClick("Delete", () => { DeleteParam(); }, true, "🔥", Uti.ColorTheme.red);
                contextSimple.MakeMenuClick("Delete", () => { DeleteParam(); }, true, "🔥", Uti.ColorTheme.red);
                contextSimple.MakeMenuClick("Delete", () => { DeleteParam(); }, true, "🔥", Uti.ColorTheme.red);

                contextSimple.Show();
                
                void DeleteParam()
                {

                }

                void ShowInsight()
                {

                }
            };
            flowParamContainer.Controls.Add(butMore);
            #endregion

            #region Instantiate The Major Flow
            thisFlowParam.SetData(
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
            flowParams.Add(thisFlowParam);
            #endregion

            return flowParamContainer;

            int GetMasterIndex()
            {
                return flowParams[flowParams.IndexOf(thisFlowParam)].index;
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
                    if (!newEnumTypes.Contains(namePlaceHolder+index.ToString()))
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
                    namePlaceHolder,
                    (name) => 
                    { 
                        if (newEnumTypes.Count <= 1) return;
                        newEnumTypes.Remove(name);
                        cbNewParamDefaultValue.Items.Remove(name);
                        newFlowEnum.Dispose();
                    },
                    (oldName, newName, tb) =>
                    {
                        if (!newEnumTypes.Contains(newName))
                        {
                            int thisIndex = newEnumTypes.IndexOf(oldName);

                            newEnumTypes.Remove(oldName);
                            newEnumTypes.Insert(thisIndex, newName);

                            cbNewParamDefaultValue.Items.Remove(oldName);
                            cbNewParamDefaultValue.Items.Insert(thisIndex, newName);

                            cbNewParamDefaultValue.SelectedIndex = 0;
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

            tbDataType.Focus();
            tbDataType.SelectAll();

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
            index = index > 0 ? index < flowParams.Count ? index : flowParams.Count-1 : 0;

            // Reorder UI controls
            flowParamsContainer.Controls.SetChildIndex(flowCurrent.flow, index);

            // Reorder master data
            ParameterData tempParamData = new ParameterData(flowCurrent.paramData);
            if(index == flowParams.Count-1) Master.projectData.parameters.Add(tempParamData);
            else Master.projectData.parameters.Insert(index, tempParamData);
            Master.projectData.parameters.Remove(flowCurrent.paramData);

            // Reorder the flowParam data handlers in flowParams
            if (index < indexOld)
            {
                labTitleAddNewParam.Text = "To Down: Ind: " + index.ToString() + ";  Old: " + indexOld.ToString();

                for (int i = indexOld - 1; i >= index; i--)
                {
                    flowParams[i].index++;
                }
            }
            else if (index > indexOld)
            {
                labTitleAddNewParam.Text = "To UP: Ind: " + index.ToString() + ";  Old: " + indexOld.ToString();
                for (int i = indexOld+1; i <= index; i++)
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
                    //labTitleAddNewParam.Text += flowParams[i].index.ToString(); //TODO: delete
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
        public void ScrollMouseDown(object sender,MouseEventArgs e)
        {
            isMouseMoving = true;
            mouseLocWhenDown = new Point(e.X, e.Y);
        }
        public void ScrollMouseMove(object sender,MouseEventArgs e)
        {
            if(isMouseMoving)
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
    }
}
