using System.Collections.Generic;
using System.Linq;
using UmbracoVault.Extensions;

namespace UmbracoVault.Collections
{
    /// <summary>
    /// Will Eager-load a collection; This should be used with care; For lazy-loading, use IEnumerable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VaultItemCollection<T> : List<T>
    {
        public VaultItemCollection(string commaDelimitedIds)
        {
            if (!commaDelimitedIds.IsSet()) return;

            var ids = commaDelimitedIds.Split(',');

            if (Vault.Context.IsMediaRequest<T>())
                ids.Select(id => Vault.Context.GetMediaById<T>(id)).Where(item => item != null).ToList().ForEach(x => Add(x));
            else
                ids.Select(id => Vault.Context.GetContentById<T>(id)).Where(item => item != null).ToList().ForEach(x => Add(x));
        }
    }
}
