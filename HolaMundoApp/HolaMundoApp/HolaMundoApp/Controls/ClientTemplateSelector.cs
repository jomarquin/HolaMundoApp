using HolaMundoApp.Data.Models;
using Xamarin.Forms;

namespace HolaMundoApp.Controls
{
    public class ClientTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate CNBTemplate { get; set; }
        public DataTemplate OfficeTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object officeObject, BindableObject container)
        {
            if (!(officeObject is Office office))
            {
                return DefaultTemplate;
            }

            var officeType = office.OfficeType;

            if (officeType != null )
            {

                if (officeType == "CNB")
                {
                    return CNBTemplate;
                }

                if (officeType == "OFICINA")
                {
                    return OfficeTemplate;
                }
            }

            return DefaultTemplate;
        }
    }
}
