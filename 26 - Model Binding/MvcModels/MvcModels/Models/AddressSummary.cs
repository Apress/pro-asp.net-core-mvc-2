using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcModels.Models {

    public class AddressSummary {
        public string City { get; set; }

        //[BindNever]
        public string Country { get; set; }
    }
}