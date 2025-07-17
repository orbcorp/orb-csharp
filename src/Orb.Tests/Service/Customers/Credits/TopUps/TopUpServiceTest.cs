using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TopUpCreateByExternalIDParamsProperties = Orb.Models.Customers.Credits.TopUps.TopUpCreateByExternalIDParamsProperties;
using TopUpCreateParamsProperties = Orb.Models.Customers.Credits.TopUps.TopUpCreateParamsProperties;
using TopUps = Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Service.Customers.Credits.TopUps;

public class TopUpServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var topUp = await this.client.Customers.Credits.TopUps.Create(
            new TopUps::TopUpCreateParams()
            {
                CustomerID = "customer_id",
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new TopUpCreateParamsProperties::InvoiceSettings()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
                ActiveFrom = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAfter = 0,
                ExpiresAfterUnit = TopUpCreateParamsProperties::ExpiresAfterUnit.Day,
            }
        );
        topUp.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Customers.Credits.TopUps.List(
            new TopUps::TopUpListParams()
            {
                CustomerID = "customer_id",
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Delete_Works()
    {
        await this.client.Customers.Credits.TopUps.Delete(
            new TopUps::TopUpDeleteParams() { CustomerID = "customer_id", TopUpID = "top_up_id" }
        );
    }

    [Fact]
    public async Tasks::Task CreateByExternalID_Works()
    {
        var response = await this.client.Customers.Credits.TopUps.CreateByExternalID(
            new TopUps::TopUpCreateByExternalIDParams()
            {
                ExternalCustomerID = "external_customer_id",
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new TopUpCreateByExternalIDParamsProperties::InvoiceSettings()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
                ActiveFrom = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAfter = 0,
                ExpiresAfterUnit = TopUpCreateByExternalIDParamsProperties::ExpiresAfterUnit.Day,
            }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task DeleteByExternalID_Works()
    {
        await this.client.Customers.Credits.TopUps.DeleteByExternalID(
            new TopUps::TopUpDeleteByExternalIDParams()
            {
                ExternalCustomerID = "external_customer_id",
                TopUpID = "top_up_id",
            }
        );
    }

    [Fact]
    public async Tasks::Task ListByExternalID_Works()
    {
        var page = await this.client.Customers.Credits.TopUps.ListByExternalID(
            new TopUps::TopUpListByExternalIDParams()
            {
                ExternalCustomerID = "external_customer_id",
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }
}
