using System;

namespace CarInsClaims.App.Models
{
    public class ErrorViewModel
    {
        public string ErrorDescription { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}