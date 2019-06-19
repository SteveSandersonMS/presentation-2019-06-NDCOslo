using System.Collections.Generic;
using System.Threading.Tasks;
using CarBuyer.Core.Models;

namespace CarBuyer.Core.Services
{
    public class SampleCatalogService : ICatalogService
    {
        public Task<ProductCatalog> FetchCatalogAsync()
        {
            var result = new ProductCatalog
            {
                Models = new List<CarModel>
                {
                    new CarModel
                    {
                        Name = "6 System",
                        NameMarkup = "<span class='code'>6</span> System",
                        BasePrice = 26500,
                        EstimatedDelivery = "3 - 5 weeks",
                        EngineChoices = new List<EngineChoice>
                        {
                            new EngineChoice { Name = "240 kW", Description = "85mph", Price = 0 },
                            new EngineChoice { Name = "380 kW", Description = "120mph", Price = 550 },
                        },
                        CustomizationGroups = new List<CustomizationGroup>
                        {
                            new CustomizationGroup
                            {
                                Name = "Exterior",
                                Customizations = new List<CustomizationBase>
                                {
                                    new ColorCustomization { Name = "Color" },
                                    new MultiChoiceCustomization
                                    {
                                        Name = "Wheels",
                                        Choices = new List<MultiChoiceOption>
                                        {
                                            new MultiChoiceOption { Name = "16\" alloys", Price = 0 },
                                            new MultiChoiceOption { Name = "17\" alloys", Price = 250, Notes = new[] { "Kevlar reinforced", "Additional grip" } },
                                        }
                                    },
                                    new BooleanCustomization
                                    {
                                        Name = "Panoramic sunroof",
                                        Description = "Tinted glass with UV protection",
                                        Price = 750,
                                    }
                                }
                            },
                            new CustomizationGroup
                            {
                                Name = "Interior",
                                Customizations = new List<CustomizationBase>
                                {
                                    new MultiChoiceCustomization
                                    {
                                        Name = "Trim",
                                        Choices = new List<MultiChoiceOption>
                                        {
                                            new MultiChoiceOption { Name = "Standard", Price = 0, Notes = new[] { "Cloth seats", "Manual seat adjustment" } },
                                            new MultiChoiceOption { Name = "Premium", Price = 1750, Notes = new[] { "Leather seats", "Electric seat adjustment", "Digital dashboard", "Keyless entry" } },
                                        }
                                    },
                                    new MultiChoiceCustomization
                                    {
                                        Name = "Infotainment",
                                        Choices = new List<MultiChoiceOption>
                                        {
                                            new MultiChoiceOption { Name = "SE", Price = 0, Notes = new[] { "9\" screen", "4-speaker system" } },
                                            new MultiChoiceOption { Name = "SE Plus", Price = 595, Notes = new[] { "12\" touchscreen", "8-speaker system with subwoofer", "DAB radio" } },
                                        }
                                    },
                                }
                            },
                            new CustomizationGroup
                            {
                                Name = "Safety & Convenience",
                                Customizations = new List<CustomizationBase>
                                {
                                    new BooleanCustomization
                                    {
                                        Name = "Emergency brake assist",
                                        Price = 325,
                                    },
                                    new BooleanCustomization
                                    {
                                        Name = "Self parking",
                                        Description = "Autonomous maneuvering into parking spaces",
                                        Price = 995,
                                    },
                                }
                            },
                        }
                    },
                    new CarModel
                    {
                        Name = "8 System",
                        NameMarkup = "<span class='code'>8</span> System",
                        BasePrice = 41900,
                        EstimatedDelivery = "6 - 8 weeks",
                        EngineChoices = new List<EngineChoice>
                        {
                            new EngineChoice { Name = "320 kW", Description = "110mph", Price = 0 },
                            new EngineChoice { Name = "455 kW", Description = "130mph", Price = 850 },
                            new EngineChoice { Name = "660 kW", Description = "165mph", Price = 2300 },
                        },
                        CustomizationGroups = new List<CustomizationGroup>
                        {
                            new CustomizationGroup
                            {
                                Name = "Exterior",
                                Customizations = new List<CustomizationBase>
                                {
                                    new ColorCustomization { Name = "Color" },
                                    new MultiChoiceCustomization
                                    {
                                        Name = "Wheels",
                                        Choices = new List<MultiChoiceOption>
                                        {
                                            new MultiChoiceOption { Name = "16\" alloys", Price = 0 },
                                            new MultiChoiceOption { Name = "19\" alloys", Price = 1500, Notes = new[] { "Kevlar reinforced", "Additional grip" } },
                                        }
                                    },
                                    new BooleanCustomization
                                    {
                                        Name = "Panoramic sunroof",
                                        Description = "Tinted glass with UV protection",
                                        Price = 750,
                                    }
                                }
                            },
                            new CustomizationGroup
                            {
                                Name = "Interior",
                                Customizations = new List<CustomizationBase>
                                {
                                    new MultiChoiceCustomization
                                    {
                                        Name = "Trim",
                                        Choices = new List<MultiChoiceOption>
                                        {
                                            new MultiChoiceOption { Name = "Standard", Price = 0, Notes = new[] { "Cloth seats", "Manual seat adjustment" } },
                                            new MultiChoiceOption { Name = "Premium", Price = 1750, Notes = new[] { "Leather seats", "Electric seat adjustment", "Digital dashboard", "Keyless entry" } },
                                            new MultiChoiceOption { Name = "Executive", Price = 3500, Notes = new[] { "Fine Nappa leather", "Electric seat adjustment with memory", "Windscreen-projected dashboard", "Keyless entry", "Ambient lighting" } },
                                        }
                                    },
                                    new MultiChoiceCustomization
                                    {
                                        Name = "Infotainment",
                                        Choices = new List<MultiChoiceOption>
                                        {
                                            new MultiChoiceOption { Name = "SE", Price = 0, Notes = new[] { "9\" screen", "4-speaker system" } },
                                            new MultiChoiceOption { Name = "SE Plus", Price = 595, Notes = new[] { "12\" touchscreen", "8-speaker system with subwoofer", "DAB radio" } },
                                            new MultiChoiceOption { Name = "Signature", Price = 995, Notes = new[] { "24\" touchscreen", "Bang & Olufsen 16-speaker system", "Seat-back subwoofers", "DAB + internet radio", "Wifi" } },
                                        }
                                    },
                                }
                            },
                            new CustomizationGroup
                            {
                                Name = "Safety & Convenience",
                                Customizations = new List<CustomizationBase>
                                {
                                    new BooleanCustomization
                                    {
                                        Name = "Intelligent cruise control pack",
                                        Description = "Automatic lane keeping and speed control",
                                        Price = 1500,
                                    },
                                    new BooleanCustomization
                                    {
                                        Name = "Emergency brake assist",
                                        Price = 325,
                                    },
                                    new BooleanCustomization
                                    {
                                        Name = "Self parking",
                                        Description = "Autonomous maneuvering into parking spaces",
                                        Price = 995,
                                    },
                                }
                            },
                        }
                    }
                },
                LoanDownpaymentPercents = new List<decimal> { 5, 10, 25 },
                LoanOffers = new List<LoanOffer>
                {
                    new LoanOffer { DurationMonths = 12, APR = 6.2m },
                    new LoanOffer { DurationMonths = 24, APR = 5.8m },
                    new LoanOffer { DurationMonths = 36, APR = 5.4m },
                    new LoanOffer { DurationMonths = 48, APR = 4.8m },
                },
            };

            return Task.FromResult(result);
        }
    }
}
