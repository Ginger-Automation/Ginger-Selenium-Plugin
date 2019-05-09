using Amdocs.Ginger.CoreNET.RunLib;
using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Execution
{
    public class UIELementActionHandler
    {

        public enum eElementAction
        {
            #region Generic Action Types

            Unknown,

            Hover,

            Visible,

            Click,

            GetCustomAttribute,//keeping for backward support

            AsyncClick,
            // not here at all ?
            WinClick,

            MouseClick,

            ClickXY,

            SetText,

            GetText,

            SetValue,

            GetValue,

            GetXY,

            GetSize,

            OpenDropDown,

            SelectandValidate,
            CloseDropDown,
            GetAllValues,
            GetAttrValue,
            SetFocus,
            IsEnabled,
            Toggle,
            Select,
            IsVisible,
            IsMandatory,
            Exist,
            NotExist,
            Enabled,
            GetName,
            GetDialogText,
            AcceptDialog,
            DismissDialog,
            SetDate,
            ScrollUp,
            ScrollDown,
            ScrollLeft,
            ScrollRight,
            SelectByIndex,
            GetValueByIndex,
            GetItemCount,
            SendKeys,
            DragDrop,
            IsExist,
            GetContexts,
            SetContext,
            MouseRightClick,
            GetFont,
            GetWidth,
            GetHeight,
            GetStyle,
            MultiClicks,
            MultiSetValue,
            GetWindowTitle,
            IsDisabled,
            Switch,
            SendKeysXY,
            #endregion Generic Action Types

            #region TextBox Action Types
            ClearValue,
            GetTextLength,
            #endregion TextBox Action Types


            #region ComboBox related Types
            SetSelectedValueByIndex,
            SelectByText,
            GetValidValues,
            GetSelectedValue,
            IsValuePopulated,
            #endregion Usable Action Types

            Submit,
            RunJavaScript,


        }
        string mElementType = string.Empty;

        string ElementLocateBy = string.Empty;
        string LocateByValue = string.Empty;
        eElementAction ElementAction;
        ElementType ElementType;
        string Value;
        readonly IWebPlatform PlatformService;
        Dictionary<string, string> InputParams;
       internal List<NodeActionOutputValue> AOVs = new List<NodeActionOutputValue>();
        public UIELementActionHandler(IWebPlatform mplatformService, Dictionary<string, string> mInputParams)
        {
            PlatformService = mplatformService;

            InputParams = mInputParams;

            PopulateValues();   
        }

        private void PopulateValues()
        {

            InputParams.TryGetValue("ElementType", out mElementType);

            string mElementAction;

            InputParams.TryGetValue("ElementAction", out mElementAction);
            InputParams.TryGetValue("ElementLocateBy", out ElementLocateBy);
            InputParams.TryGetValue("Value", out Value);

            ElementAction = (eElementAction)Enum.Parse(typeof(eElementAction), mElementAction);
        }




#warning Pending all locator implementation

      internal  void ExecuteAction()
        {
            string Locatevalue=  InputParams["ElementLocateValue"];
            ElementType = (ElementType)Enum.Parse(typeof(ElementType), mElementType);
            IGingerWebElement Element = null;

            LocateByValue = Locatevalue;
            switch (ElementLocateBy)
            {
                case "ByID":

                    Element = PlatformService.LocatLWebElement.LocateElementByID(Elements.ElementType.TextBox, LocateByValue);
                    break;
                case "ByCSSSelector":
                case "ByCSS":

                    Element = PlatformService.LocatLWebElement.LocateElementByCss(Elements.ElementType.TextBox, LocateByValue);

                    break;
                case "ByLinkText":
                    Element = PlatformService.LocatLWebElement.LocateElementByLinkTest(Elements.ElementType.TextBox, LocateByValue);

                    break;

                case "ByXPath":
                    Element = PlatformService.LocatLWebElement.LocateElementByXPath(Elements.ElementType.TextBox, LocateByValue);

                    break;



            }
            bool ActionPerformed = PerformCommonActions(Element);


            if(!ActionPerformed)
            {

                   switch (ElementType)
                {
                    case ElementType.Button:
                        HandleButtonActions(Element);
                        break;
                    case ElementType.Canvas:

                        HandleCanvasAction(Element);
                        break;
                    case ElementType.CheckBox:
                        HandleCheckBoxActions(Element);
                        break;
                    case ElementType.ComboBox:
                        HandleComboBoxActions(Element);
                        break;
                    case ElementType.Div:
                        HandleDivActions(Element);
                        break;
                    case ElementType.Image:
                        HandleImageActions(Element);
                        break;
                    case ElementType.Label:
                        HandleLabelActions(Element);
                        break;
                    case ElementType.List:
                        HandleListActions(Element);
                        break;
                    case ElementType.RadioButton:
                        HandleRadioButtonActions(Element);
                        break;
                    case ElementType.Span:
                        HandleSpanActions(Element);
                        break;
                    case ElementType.Table:
                        HandleTableActions(Element);
                        break;
                    case ElementType.TextBox:
                        HandleTextBoxActions(Element);
                        break;
               
                }
            }
            }

        private void HandleTableActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

        private void HandleTextBoxActions(IGingerWebElement element)
        {

            ITextBox TextBox = (ITextBox)element;
            switch (ElementAction)
            {
                case eElementAction.SetValue:

                    TextBox.SetValue(Value);
                    break;
                case eElementAction.GetValue:
                    AOVs.Add(new NodeActionOutputValue() { Param = "Value", Value = TextBox.GetValue() });

                    break;





            }


        }

            private void HandleSpanActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

        private void HandleRadioButtonActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

        private void HandleListActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

        private void HandleLabelActions(IGingerWebElement element)
        {
            if (element is ILabel Label)
            {
                switch (ElementAction)
                {

                    case eElementAction.GetFont:
                       

                        AOVs.Add(new NodeActionOutputValue() { Param = "Font", Value = Label.GetFont()    });

                        break;
                    case eElementAction.GetText:

                        AOVs.Add(new NodeActionOutputValue() { Param = "Text", Value = Label.GetText() });
                
                        break;

                    case eElementAction.GetValue:
                        AOVs.Add(new NodeActionOutputValue() { Param = "Value", Value = Label.Getvalue() });
                        break;
                }
            }
        }

        private void HandleImageActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

        private void HandleDivActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

#warning Combobox Pending select implementation
        private void HandleComboBoxActions(IGingerWebElement element)
        {

            if (element is IComboBox Element)
            {

                switch (ElementAction)
                {
                    case eElementAction.ClearValue:
                        Element.ClearValue();
                        break;
                    case eElementAction.GetValidValues:
                        Element.GetValidValue();
                        break;
                    case eElementAction.IsValuePopulated:

                        AOVs.Add(new NodeActionOutputValue() { Param = "Font", Value = Element.IsValuePopulated() });
                        break;

                    case eElementAction.Select:
                        Element.Select("");
                        break;
                    case eElementAction.SelectByIndex:
                        Element.SelectByIndex(0);
                        break;
                    case eElementAction.SelectByText:
                        Element.SelectByText("");
                        break;

                }
            }
        }

        private void HandleCheckBoxActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }

        private void HandleCanvasAction(IGingerWebElement element)
        {
            if (element is ICanvas E)
            {
                E.DrawObject(); }
        }

        private void HandleButtonActions(IGingerWebElement element)
        {
            throw new NotImplementedException();
        }





        /// <summary>
        /// Perform Common action on GngerWebelement return true if iction is perfomed 
        /// </summary>
        /// <param name="Element"></param>
        /// <returns></returns>
        private bool PerformCommonActions(IGingerWebElement Element)
        {
            bool performed = true;
            
            switch (ElementAction)
            {
                case eElementAction.DragDrop:
                    Element.DragAndDrop();
                    break;

                case eElementAction.GetAttrValue:
                    Element.GetAttribute("");

                    break;

                case eElementAction.GetHeight:
                    AOVs.Add(new NodeActionOutputValue() { Param = "Height", Value = Element.GetHeight() });
                    break;

                case eElementAction.GetItemCount:
                   
                    AOVs.Add(new NodeActionOutputValue() { Param = "Value", Value = Element.GetItemCount()           });
                    break;
                case eElementAction.GetSize:
                   Size s= Element.GetSize();
                    AOVs.Add(new NodeActionOutputValue() { Param = "Height", Value = s.Height});
                    AOVs.Add(new NodeActionOutputValue() { Param = "Width", Value = s.Width });

                    break;
                case eElementAction.GetStyle:
              
                    AOVs.Add(new NodeActionOutputValue() { Param = "Style", Value = Element.GetStyle() });
                    break;
                case eElementAction.GetWidth:

                    AOVs.Add(new NodeActionOutputValue() { Param = "Width", Value = Element.GetWidth() });
                    break;
                case eElementAction.Hover:
                    Element.Hover();
                    break;
                case eElementAction.IsEnabled:
                    AOVs.Add(new NodeActionOutputValue() { Param = "Enabled", Value = Element.IsEnabled() });
                    break;
                case eElementAction.IsVisible:
                    AOVs.Add(new NodeActionOutputValue() { Param = "Visible", Value = Element.IsVisible() });

                    break;
                case eElementAction.MouseRightClick:
                    Element.RightClick();
                    break;
                case eElementAction.RunJavaScript:
                    Element.RunJavascript("");
                    break;
                case eElementAction.SetFocus:
                    Element.SetFocus();
                    break;

                default:
                    performed = false;
                    break;
            }

            return performed;
        }
    }
}
