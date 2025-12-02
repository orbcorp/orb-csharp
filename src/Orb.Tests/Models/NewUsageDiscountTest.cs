using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewUsageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        ApiEnum<string, NewUsageDiscountAdjustmentType> expectedAdjustmentType =
            NewUsageDiscountAdjustmentType.UsageDiscount;
        double expectedUsageDiscount = 0;
        ApiEnum<bool, NewUsageDiscountAppliesToAll> expectedAppliesToAll =
            NewUsageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<Filter16> expectedFilters =
        [
            new()
            {
                Field = Filter16Field.PriceID,
                Operator = Filter16Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewUsageDiscountPriceType> expectedPriceType =
            NewUsageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
        Assert.Equal(expectedAppliesToAll, model.AppliesToAll);
        Assert.Equal(expectedAppliesToItemIDs.Count, model.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], model.AppliesToItemIDs[i]);
        }
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedPriceType, model.PriceType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewUsageDiscountAdjustmentType> expectedAdjustmentType =
            NewUsageDiscountAdjustmentType.UsageDiscount;
        double expectedUsageDiscount = 0;
        ApiEnum<bool, NewUsageDiscountAppliesToAll> expectedAppliesToAll =
            NewUsageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<Filter16> expectedFilters =
        [
            new()
            {
                Field = Filter16Field.PriceID,
                Operator = Filter16Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewUsageDiscountPriceType> expectedPriceType =
            NewUsageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
        Assert.Equal(expectedAppliesToAll, deserialized.AppliesToAll);
        Assert.Equal(expectedAppliesToItemIDs.Count, deserialized.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], deserialized.AppliesToItemIDs[i]);
        }
        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, deserialized.IsInvoiceLevel);
        Assert.Equal(expectedPriceType, deserialized.PriceType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Filter16Field.PriceID,
                    Operator = Filter16Operator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            IsInvoiceLevel = true,
        };

        Assert.Null(model.AppliesToAll);
        Assert.False(model.RawData.ContainsKey("applies_to_all"));
        Assert.Null(model.AppliesToItemIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_item_ids"));
        Assert.Null(model.AppliesToPriceIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.PriceType);
        Assert.False(model.RawData.ContainsKey("price_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            IsInvoiceLevel = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            IsInvoiceLevel = true,

            AppliesToAll = null,
            AppliesToItemIDs = null,
            AppliesToPriceIDs = null,
            Currency = null,
            Filters = null,
            PriceType = null,
        };

        Assert.Null(model.AppliesToAll);
        Assert.True(model.RawData.ContainsKey("applies_to_all"));
        Assert.Null(model.AppliesToItemIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_item_ids"));
        Assert.Null(model.AppliesToPriceIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.PriceType);
        Assert.True(model.RawData.ContainsKey("price_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            IsInvoiceLevel = true,

            AppliesToAll = null,
            AppliesToItemIDs = null,
            AppliesToPriceIDs = null,
            Currency = null,
            Filters = null,
            PriceType = null,
        };

        model.Validate();
    }
}

public class Filter16Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter16
        {
            Field = Filter16Field.PriceID,
            Operator = Filter16Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter16Field> expectedField = Filter16Field.PriceID;
        ApiEnum<string, Filter16Operator> expectedOperator = Filter16Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filter16
        {
            Field = Filter16Field.PriceID,
            Operator = Filter16Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter16>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter16
        {
            Field = Filter16Field.PriceID,
            Operator = Filter16Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter16>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter16Field> expectedField = Filter16Field.PriceID;
        ApiEnum<string, Filter16Operator> expectedOperator = Filter16Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Filter16
        {
            Field = Filter16Field.PriceID,
            Operator = Filter16Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
