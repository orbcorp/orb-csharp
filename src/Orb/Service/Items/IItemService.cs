using Items = Orb.Models.Items;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Items;

public interface IItemService
{
    /// <summary>
    /// This endpoint is used to create an [Item](/core-concepts#item).
    /// </summary>
    Tasks::Task<Items::Item> Create(Items::ItemCreateParams @params);

    /// <summary>
    /// This endpoint can be used to update properties on the Item.
    /// </summary>
    Tasks::Task<Items::Item> Update(Items::ItemUpdateParams @params);

    /// <summary>
    /// This endpoint returns a list of all Items, ordered in descending order by creation time.
    /// </summary>
    Tasks::Task<Items::ItemListPageResponse> List(Items::ItemListParams @params);

    /// <summary>
    /// Archive item
    /// </summary>
    Tasks::Task<Items::Item> Archive(Items::ItemArchiveParams @params);

    /// <summary>
    /// This endpoint returns an item identified by its item_id.
    /// </summary>
    Tasks::Task<Items::Item> Fetch(Items::ItemFetchParams @params);
}
