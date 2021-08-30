using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAPI.Models.Response
{
    public class FormResponse<TViewModel> where TViewModel : class
    {
        public TViewModel Form { get; set; }
    }
}
