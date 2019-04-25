using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web
{
    public interface IBrowserActions
    {

        string GetCurrentUrl();
        void NavigateBack();
        void NavigateForward();
        void Refresh();
        string GetTitle();


        string GetWindowHandle();

        void CloseWindow();
        IReadOnlyCollection<string> GetWindowHandles();
        void SwitchToFrame(IGingerWebElement WebElement) ;
        void SwitchToParentFrame();

        void Maximize();
        void Minimize();
        void FullScreen();

        void ExecuteScript();

    }
}
