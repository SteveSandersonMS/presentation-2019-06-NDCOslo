using System;
using System.Collections.Generic;
using System.Linq;

namespace CarBuyer.Core.Models
{
    public class CustomerOrder
    {
        private CarModel _model;

        public CustomerOrder(ProductCatalog productCatalog)
        {
            // Set defaults
            Model = productCatalog.Models.First();
            FinanceType = FinanceType.Cash;
            LoanOffer = productCatalog.LoanOffers.First();
            LoanDownpaymentPercent = productCatalog.LoanDownpaymentPercents.First();
        }

        public CarModel Model
        {
            get => _model;
            set
            {
                _model = value ?? throw new ArgumentNullException(nameof(value));
                SetDefaultsForModel();
            }
        }

        public EngineChoice Engine { get; set; }

        public IDictionary<CustomizationBase, ICustomizationChoice> Customizations { get; set; }

        public FinanceType FinanceType { get; set; } = FinanceType.Cash;

        public decimal LoanDownpaymentPercent { get; set; }

        public LoanOffer LoanOffer { get; set; }

        public DeliveryDetails Delivery { get; set; } = new DeliveryDetails();

        public decimal Quote
            => _model.BasePrice
            + Engine.Price
            + Customizations.Sum(c => c.Value.Price);

        private void SetDefaultsForModel()
        {
            Engine = _model.EngineChoices.First();

            Customizations = new Dictionary<CustomizationBase, ICustomizationChoice>();

            foreach (var customizationGroup in _model.CustomizationGroups)
            {
                foreach (var customization in customizationGroup.Customizations)
                {
                    Customizations[customization] = customization.DefaultValue;
                }
            }
        }
    }

    public enum FinanceType
    {
        Cash, Loan
    }
}
