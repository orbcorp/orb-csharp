using System.Threading.Tasks;
using Orb.Models.Items;

namespace Orb.Services.Items;

public interface IItemService
{
    /// <summary>
    /// This endpoint is used to create an [Item](/core-concepts#item).
    /// </summary>
    Task<Item> Create(ItemCreateParams @params);

    /// <summary>
    /// This endpoint can be used to update properties on the Item.
    /// </summary>
    Task<Item> Update(ItemUpdateParams @params);

    /// <summary>
    /// This endpoint returns a list of all Items, ordered in descending order by creation time.
    /// </summary>
    Task<ItemListPageResponse> List(ItemListParams @params);

    /// <summary>
    /// Archive item
    /// </summary>
    Task<Item> Archive(ItemArchiveParams @params);

    /// <summary>
    /// This endpoint returns an item identified by its item_id.
    /// </summary>
    Task<Item> Fetch(ItemFetchParams @params);
}
