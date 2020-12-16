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

            public FlowParam(
                FlowLayoutPanel flow,
                Button butMove,
                TextBox tbName,
                ComboBox cbDataType,
                TextBox tbDefaultValue,
                ComboBox cbDefaultValue,
                ComboBox cbUIControl,
                Button butLink,
                Button butDelete
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
            }
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
            Uti.Methods.SetupInputDataType(tbNewParamDefaultValue, GetDataType(), (isOkay)=> { if(GetDataType()!=ChatWeaverSystem.System.DataTypesParam.Enum) if(!isOkay)DisallowToMakeNewParam(); });
            Uti.Methods.SetupInputDataType(cbNewParamDefaultValue, ChatWeaverSystem.System.DataTypesParam.Enum, (isOkay) => { if (GetDataType() == ChatWeaverSystem.System.DataTypesParam.Enum) if (!isOkay) DisallowToMakeNewParam(); }, newEnumTypes );//Uti.Methods.ConvertToListString(cbNewParamDefaultValue.Items)

            ChatWeaverSystem.System.DataTypesParam GetDataType()
            {
                ChatWeaverSystem.System.DataTypesParam dataTypeParam;
                Enum.TryParse(cbNewParamDataType.Text, out dataTypeParam);
                return dataTypeParam;
            }

            #endregion

            //TODO: Load parameter datas, then update scroll bar
            Uti.Methods.UpdateMaxScroll(flowParamsContainer, panelScrollbarContainer, labScrollbar);
        }
        private void FormManageSayUnit_SizeChanged(object sender, EventArgs e)
        {
            flowMain.Size = new Size(flowMain.Width, Height);
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
                labelTest.Text = "";
                for (int i = 0; i < Master.GetParamAllNames().Count; i++)
                {
                    labelTest.Text += i+". "+ Master.GetParamAllNames()[i] + "\n";
                }
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
            List<string> newEnumTypes = null
            )
        {
            List<string> newEnumTypesCopy = new List<string>();
            if (newEnumTypes != null)
            {
                for (int i = 0; i < newEnumTypes.Count; i++)
                {
                    newEnumTypesCopy.Add(newEnumTypes[i]);
                }
            }

            #region Flow Panel Parent
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.BackColor = Uti.ColorTheme.lightFocus;
            flow.Size = new Size(900, flowParamHeight);
            flow.Margin = new Padding(0, 0, 0, 10);
            #endregion

            #region Move Icon
            Button butMove = Uti.MakeComponents.MakeButtonIcon("☵", flow.BackColor, Uti.ColorTheme.lightFocusDim, Uti.ColorTheme.lightButtonHover);
            butMove.MouseDown += flowParam_MouseDown;
            butMove.MouseUp += flowPram_MouseUp;

            flow.Controls.Add(butMove);
            #endregion

            int flowWidthReal = flow.Width - butMove.Width*2   ; // there are two buttons: but move and but delete

            #region Flow Param Main

            FlowLayoutPanel flowParamMain = new FlowLayoutPanel();
            flowParamMain.BackColor = Color.Transparent;
            flowParamMain.Size = new Size(flowWidthReal, flow.Height);
            flowParamMain.Margin = new Padding(0);

            flow.Controls.Add(flowParamMain);

            #endregion

            #region Name
            Panel panName = new Panel();
            panName.Size = new Size((int)(flowWidthReal / 5), flowParamMain.Height);
            panName.BackColor = Color.Transparent;
            panName.Margin = new Padding(0, 0, 0, 0);

            TextBox tbName = Uti.MakeComponents.MakeTextBoxRegular(name, new Size(panName.Width * 4 / 5, panName.Height), flow.BackColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightDimTextBox, Uti.ColorTheme.fontDark);
            panName.Controls.Add(tbName);

            flowParamMain.Controls.Add(panName);

            #endregion

            #region Data Type
            Panel panDataType = new Panel();
            panDataType.Size = new Size((int)(flowWidthReal / 5), flowParamMain.Height);
            panDataType.BackColor = Color.Transparent;
            panDataType.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbDatatype = Uti.MakeComponents.MakeComboBoxRegular(ChatWeaverSystem.System.DataTypes, flow.BackColor, dataType);
            panDataType.Controls.Add(cbDatatype);
            flowParamMain.Controls.Add(panDataType);

            #endregion

            #region Default Value
            Panel panDefaultValue = new Panel();
            panDefaultValue.Size = new Size((int)(flowWidthReal / 5), flowParamMain.Height);
            panDefaultValue.BackColor = Color.Transparent;
            panDefaultValue.Margin = new Padding(0, 0, 0, 0);

            TextBox tbDefaultValue = Uti.MakeComponents.MakeTextBoxRegular(defaultValue, new Size(panDefaultValue.Width * 4 / 5, panDefaultValue.Height), flow.BackColor, Uti.ColorTheme.fontDark, Uti.ColorTheme.lightDimTextBox, Uti.ColorTheme.fontDark);
            panDefaultValue.Controls.Add(tbDefaultValue);

            ComboBox cbDefaultValue = Uti.MakeComponents.MakeComboBoxRegular(new List<string>(), flow.BackColor, defaultValue);
            panDefaultValue.Controls.Add(cbDefaultValue);
            flowParamMain.Controls.Add(panDefaultValue);

            if (dataType == "Enum")
            {
                tbDefaultValue.Width = 0;
            }
            else
            {
                cbDefaultValue.Width = 0;
            }


            #endregion

            #region UI Control Type
            Panel panUIControl = new Panel();
            panUIControl.Size = new Size((int)(flowWidthReal / 5), flowParamMain.Height);
            panUIControl.BackColor = Color.Transparent;
            panUIControl.Margin = new Padding(0, 0, 0, 0);

            ComboBox cbUIControl = Uti.MakeComponents.MakeComboBoxRegular(ChatWeaverSystem.System.UIControls, flow.BackColor, uiControl);
            panUIControl.Controls.Add(cbUIControl);

            flowParamMain.Controls.Add(panUIControl);

            #endregion

            #region Button Link With Pub
            Panel panLink = new Panel();
            panLink.Size = new Size((int)(flowWidthReal / 5), flowParamMain.Height);
            panLink.BackColor = Color.Transparent;
            panLink.Margin = new Padding(0, 0, 0, 0);

            Button butLink = Uti.MakeComponents.MakeButtonRegular("Link With Pub"); //TODO: add action delegate for link
            panLink.Controls.Add(butLink);

            flowParamMain.Controls.Add(panLink);

            #endregion

            #region Enum Data Types [Small Flows]

            if(dataType == "Enum")
            {
                for (int i = 0; i < newEnumTypesCopy.Count; i++)
                {
                    FlowLayoutPanel newFlow = MakeEnumTypeControlLocal(newEnumTypesCopy[i]);
                    flowParamMain.Controls.Add(newFlow);
                }

                Button butAdd = Uti.MakeComponents.MakeButtonIcon("✚", Uti.ColorTheme.lightDimButton, Uti.ColorTheme.lightButtonHover, Uti.ColorTheme.lightButtonDown, new Size(22, 22), true);
                butAdd.ForeColor = Uti.ColorTheme.fontDarkDim;
                butAdd.Margin = new Padding(0, 0, 10, 0);
                butAdd.MouseClick += (sender, e) =>
                {
                    string nameHolder = Uti.Temp.namePlaceHolder;
                    int paramIndex = Master.projectData.parameters.IndexOf(parameterData);

                    int indexHolder = 0;
                    while (true)
                    {
                        indexHolder++;
                        if(!Master.projectData.parameters[paramIndex].enumDataTypes.Contains(nameHolder+ indexHolder.ToString()))
                        {
                            nameHolder += indexHolder.ToString();
                            break;
                        }
                    }
                    FlowLayoutPanel newFlow = MakeEnumTypeControlLocal(nameHolder);
                    flowParamMain.Controls.Add(newFlow);
                    flowParamMain.Controls.SetChildIndex(butAdd, flowParamMain.Controls.Count - 1);
                };
                flowParamMain.Controls.Add(butAdd);
            }

            FlowLayoutPanel MakeEnumTypeControlLocal(string nameNew)
            {
                int index = Master.projectData.parameters.IndexOf(parameterData);
                List<string> masterEnumData = Master.projectData.parameters[index].enumDataTypes;
                masterEnumData.Add(nameNew);

                cbDefaultValue.Items.Add(nameNew);

                FlowLayoutPanel newFlow = new FlowLayoutPanel();
                newFlow = MakeEnumTypeControl(
                                    nameNew,
                                    (thisEnum) =>
                                    {
                                        if (masterEnumData.Count <= 1) return;
                                        masterEnumData.Remove(thisEnum);
                                        cbDefaultValue.Items.Remove(thisEnum);
                                        newFlow.Dispose();
                                    },
                                    (oldName, newName, tb) =>
                                    {
                                        if (!masterEnumData.Contains(newName))
                                        {
                                            int thisIndex = masterEnumData.IndexOf(oldName);

                                            masterEnumData.Remove(oldName);
                                            masterEnumData.Insert(thisIndex, newName);

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
                flow.Height = flowParamHeight + newHeight;
                flowParamMain.Height = flowParamHeight + newHeight;

                UpdateFlowParamsHeight();

                return newFlow;
            }

            #endregion

            #region Delete Icon
            Button butDelete = Uti.MakeComponents.MakeButtonIcon("🔥", flow.BackColor, Uti.ColorTheme.red, Uti.ColorTheme.redDark);
            flow.Controls.Add(butDelete);
            #endregion

            #region Instantiate The Major Flow
            FlowParam newFlowParam = new FlowParam(
                flow: flow,
                butMove: butMove,
                tbName: tbName,
                cbDataType: cbDatatype,
                tbDefaultValue: tbDefaultValue,
                cbDefaultValue: null, //TODO: update
                cbUIControl: cbUIControl,
                butLink: butLink,
                butDelete: butDelete
                );
            flowParams.Add(newFlowParam);
            #endregion

            return flow;
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

        FlowLayoutPanel flowCurrent;
        private void flowParam_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocWhenDown = new Point(e.X, e.Y);
            foreach (FlowParam flow in flowParams)
            {
                if (flow.butMove == sender)
                {
                    flowCurrent = flow.flow;
                    flowCurrent.BackColor = Uti.ColorTheme.lightButtonHover;
                }
            }

            isMouseMoving = true;
        }
        private void flowPram_MouseUp(object sender, MouseEventArgs e)
        {
            Point newLocation = new Point(0, e.Y - mouseLocWhenDown.Y);
            int index = flowParamsContainer.Controls.GetChildIndex(flowCurrent) + (newLocation.Y > 0 ? ((int)Math.Floor((float)newLocation.Y / (flowParamHeight + 10))) : ((int)Math.Ceiling((float)newLocation.Y / (flowParamHeight + 10))));
            flowParamsContainer.Controls.SetChildIndex(flowCurrent, index>0?index:0);
            flowCurrent.BackColor = Uti.ColorTheme.lightFocus;

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
