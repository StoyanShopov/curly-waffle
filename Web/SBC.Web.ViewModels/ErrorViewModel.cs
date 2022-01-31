namespace SBC.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
