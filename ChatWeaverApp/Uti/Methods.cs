using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChatWeaverApp.Uti
{
    public static class Methods
    {
        #region REG: Scrollbar
        public static void UpdateMaxScroll(FlowLayoutPanel flow, Panel panScrollbarContainer, Label labScrollBar)
        {
            if (flow.Height > panScrollbarContainer.Height)
            {
                labScrollBar.Visible = true;
                panScrollbarContainer.Visible = true;

                //Calculate surplus
                double surplus = (double)panScrollbarContainer.Height / flow.Height;
                surplus = Math.Ceiling(surplus * panScrollbarContainer.Height);
                //Modify scrollbar
                labScrollBar.Height = Convert.ToInt32(surplus);
            }
            else
            {
                labScrollBar.Height = panScrollbarContainer.Height;
                labScrollBar.Visible = false;
                panScrollbarContainer.Visible = false;
            }

        }

        public static void ScrollMouseMove(MouseEventArgs e, Point mouseLocWhenDown, FlowLayoutPanel flow, Panel panScrollbarContainer, Label labScrollBar)
        {
            Point newLocation = labScrollBar.Location;
            newLocation.X = labScrollBar.Location.X;
            newLocation.Y += e.Y - mouseLocWhenDown.Y;

            ScrollMove(newLocation, flow, panScrollbarContainer, labScrollBar);
        }

        public static void ScrollMouseMove(Point offset, FlowLayoutPanel flow, Panel panScrollbarContainer, Label labScrollBar)
        {
            Point newLocation = labScrollBar.Location;
            newLocation.X += offset.X;
            newLocation.Y += offset.Y;

            ScrollMove(newLocation, flow, panScrollbarContainer, labScrollBar);

        }

        public static void ScrollMove(Point newLocation, FlowLayoutPanel flow, Panel panScrollbarContainer, Label labScrollBar)
        {
            //mouse.X is too low, bring the cursor to edge only
            if (newLocation.Y < 0)
            {
                newLocation.Y = 0;
            }
            //mouse.X is too high, bring the cursor to edge only
            else if (newLocation.Y > panScrollbarContainer.Height - labScrollBar.Height)
            {
                newLocation.Y = panScrollbarContainer.Height - labScrollBar.Height;
            }

            double speed = (double)flow.Height / panScrollbarContainer.Height;
            flow.Location = new Point(flow.Location.X, (int)Math.Ceiling(-newLocation.Y * speed));

            labScrollBar.Location = newLocation;
        }
        #endregion

        #region REG: Setups

        public static void SetupForm(Form form)
        {
            SetupTextBox(form);
        }

        public static void SetupTextBox(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    control.Enter += (sender, e) => { Highlight(sender, ColorTheme.lightFocus, ColorTheme.fontDark); };
                    control.MouseClick += (sender, e) => { Highlight(sender, ColorTheme.lightFocus, ColorTheme.fontDark); };
                    control.Leave += (sender, e) => { Dehighlight(sender, ColorTheme.lightDimTextBox, ColorTheme.fontDarkDim); };

                    if (control.HasChildren) SetupTextBox(control);
                }
                else
                {
                    if (control.HasChildren) SetupTextBox(control);
                }
            }
        }

        public static void Highlight(object sender, Color backColor, Color fontColor)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = backColor;
            if (tb.Parent is Panel) { (tb.Parent as Panel).BackColor = backColor; }
            else if (tb.Parent is FlowLayoutPanel) {(tb.Parent as FlowLayoutPanel).BackColor = backColor;}
            tb.ForeColor = fontColor;
            tb.Focus();
            tb.SelectAll();
        }

        public static void Dehighlight(object sender, Color backColor, Color fontColor)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = backColor;
            if (tb.Parent is Panel) { (tb.Parent as Panel).BackColor = backColor; }
            else if (tb.Parent is FlowLayoutPanel) { (tb.Parent as FlowLayoutPanel).BackColor = backColor; }
            tb.ForeColor = fontColor;
        }

        public static void SetupInputDataType(Control controlInput, ChatWeaverSystem.System.DataTypesParam dataType, Action<bool> CallbackIsOkay, List<string> refList = null)
        {
            controlInput.Validated += (sender, e) => { FalseDataTypeHandler(DataTypeValidation(controlInput, dataType, refList), controlInput, CallbackIsOkay); };
        }

        public static void SetupInputDataType(Control controlInput, ChatWeaverSystem.System.DataTypesParam dataType, Action<bool> CallbackIsOkay, Func<List<string>> GetRefList )
        {
            controlInput.Validated += (sender, e) => { FalseDataTypeHandler(DataTypeValidation(controlInput, dataType, GetRefList?.Invoke()), controlInput, CallbackIsOkay); };
        }

        private static void FalseDataTypeHandler(bool isAlright, Control controlInput, Action<bool> CallbackIsOkay)
        {
            bool isOkay = false;
            if (!isAlright)
            {
                controlInput.BackColor = ColorTheme.red;
                if (controlInput is TextBox) controlInput.Parent.BackColor = ColorTheme.red;
            }
            else
            {
                isOkay = true;
            }
            CallbackIsOkay?.Invoke(isOkay);
        }

        #endregion

        #region REG: Input

        /// <summary></summary>
        /// <param name="refList">optional reference list to check enum and string type. <br></br>
        /// Enum: Odd input will force the program to change inputto the first input of the list<br></br>
        /// String: Check if this string is unique against the list</param>
        public static bool DataTypeValidation(Control controlInput, ChatWeaverSystem.System.DataTypesParam dataType, List<string> refList = null)
        {
            bool isOkay = false;

            if (controlInput.Text == "" || controlInput.Text == " " || controlInput.Text == Temp.namePlaceHolder || controlInput.Text == null)
            {
                if (refList != null)PlaceHoldInControl(refList, controlInput);
            }

            switch (dataType)
            {
                case ChatWeaverSystem.System.DataTypesParam.Integer:
                    int resultInt;
                    if (Int32.TryParse(controlInput.Text, out resultInt)) isOkay = true;
                    else controlInput.Text = "0";
                    break;
                case ChatWeaverSystem.System.DataTypesParam.Float:
                    float resultFloat;
                    if (float.TryParse(controlInput.Text, out resultFloat)) isOkay = true;
                    else controlInput.Text = "0.0";
                    break;
                case ChatWeaverSystem.System.DataTypesParam.String:
                    if (refList != null)
                        if (Master.GetParamAllNames().Contains(controlInput.Text))
                        {
                            PlaceHoldInControl(refList, controlInput);
                        }
                        else
                        {
                            isOkay = true;
                        }
                    break;
                case ChatWeaverSystem.System.DataTypesParam.Enum:
                    if (refList != null)
                        if (refList.Count <= 0) break;
                        if (refList.Contains(controlInput.Text)) isOkay = true;
                        else controlInput.Text = refList[0];
                    break;
            }

            return isOkay;

            // Replace problematic string input with namePlaceHolder
            void PlaceHoldInControl(List<string> _refList, Control _controlInput)
            {
                int indexPlaceHolder = 1;

                while (true)
                {
                    if (!_refList.Contains(Temp.namePlaceHolder + indexPlaceHolder.ToString()))
                    {
                        _controlInput.Text = Temp.namePlaceHolder + indexPlaceHolder.ToString();
                        break;
                    }
                    else
                    {
                        indexPlaceHolder++;
                    } 
                }
            }
        }

        #endregion

        #region REG: Disposing

        public static void DisposeAllChildren(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Dispose();
                if (control.HasChildren) DisposeAllChildren(control);
            }

            while (parent.Controls.Count > 0)
            {
                foreach (Control controll in parent.Controls)
                {
                    controll.Dispose();
                }
            }
        }

        #endregion

        #region Misc:


        #endregion

        #region REG: CONVERTER

        public static List<string> ConvertToListString(ComboBox.ObjectCollection items)
        {
            List<string> result = new List<string>();

            foreach (var item in items)
            {
                result.Add(item.ToString());
            }
            return result;
        }

        #endregion
    }
}
