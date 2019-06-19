using System.Collections.Generic;
using System.Linq;

namespace CarBuyer.Core.Models
{
    public class ProductCatalog
    {
        public IReadOnlyList<CarModel> Models { get; set; }

        public IReadOnlyList<decimal> LoanDownpaymentPercents { get; set; }

        public IReadOnlyList<LoanOffer> LoanOffers { get; set; }
    }

    public class CarModel
    {
        public string Name { get; set; }

        public string NameMarkup { get; set; }

        public decimal BasePrice { get; set; }

        public IReadOnlyList<EngineChoice> EngineChoices { get; set; }

        public IReadOnlyList<CustomizationGroup> CustomizationGroups { get; set; }

        public string EstimatedDelivery { get; set; }
    }

    public class EngineChoice
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }

    public class PaintColor : ICustomizationChoice
    {
        public string Name { get; set; }

        public string RgbPreview { get; set; }

        public decimal Price { get; set; }
    }

    public class CustomizationGroup
    {
        public string Name { get; set; }

        public IReadOnlyList<CustomizationBase> Customizations { get; set; }
    }

    public abstract class CustomizationBase
    {
        public abstract ICustomizationChoice DefaultValue { get; }
    }

    public class ColorCustomization : CustomizationBase
    {
        public string Name { get; set; }

        public IReadOnlyList<PaintColor> Choices { get; set; } = StandardChoices;

        public override ICustomizationChoice DefaultValue => Choices.First();

        private static IReadOnlyList<PaintColor> StandardChoices = new List<PaintColor>
        {
            new PaintColor { Name = "Arctic White", RgbPreview = "#fff", Price = 0 },
            new PaintColor { Name = "Onyx Black", RgbPreview = "#000", Price = 0 },
            new PaintColor { Name = "Spirit Red", RgbPreview = "#cc0039", Price = 450 },
            new PaintColor { Name = "Dusk Sea Blue", RgbPreview = "#236898", Price = 450 },
            new PaintColor { Name = "Steel Grey", RgbPreview = "#5f676d", Price = 780 },
            new PaintColor { Name = "Crystal Green", RgbPreview = "#27581d", Price = 780 },
            new PaintColor { Name = "Sport Orange", RgbPreview = "#c78737", Price = 1020 },
        };
    }

    public class MultiChoiceCustomization : CustomizationBase
    {
        public string Name { get; set; }

        public IReadOnlyList<MultiChoiceOption> Choices { get; set; }

        public override ICustomizationChoice DefaultValue => Choices.First();
    }

    public class MultiChoiceOption : ICustomizationChoice
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> Notes { get; set; }
    }

    public class BooleanCustomization : CustomizationBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public override ICustomizationChoice DefaultValue => BooleanCustomizationChoice.NotChosen;
    }

    public class BooleanCustomizationChoice : ICustomizationChoice
    {
        public decimal Price { get; set; }

        public readonly static BooleanCustomizationChoice NotChosen = new BooleanCustomizationChoice
        {
            Price = 0,
        };
    }

    public interface ICustomizationChoice
    {
        decimal Price { get; }
    }

    public class LoanOffer
    {
        public int DurationMonths { get; set; }

        public decimal APR { get; set; }
    }
}
