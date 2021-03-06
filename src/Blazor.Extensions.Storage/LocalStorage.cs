using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.Storage
{
    public class LocalStorage : IStorage
    {
        public Task<int> Length() => JSRuntime.Current.InvokeAsync<int>(MethodNames.LENGTH_METHOD, StorageTypeNames.LOCAL_STORAGE);
        public Task Clear() => JSRuntime.Current.InvokeAsync<object>(MethodNames.CLEAR_METHOD, StorageTypeNames.LOCAL_STORAGE);

        public Task<TItem> GetItem<TItem>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return JSRuntime.Current.InvokeAsync<TItem>(MethodNames.GET_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key);
        }

        public Task<string> Key(int index) => JSRuntime.Current.InvokeAsync<string>(MethodNames.KEY_METHOD, StorageTypeNames.LOCAL_STORAGE, index);

        public Task RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return JSRuntime.Current.InvokeAsync<object>(MethodNames.REMOVE_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key);
        }

        public Task SetItem<TItem>(string key, TItem item)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return JSRuntime.Current.InvokeAsync<object>(MethodNames.SET_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key, Json.Serialize(item));
        }
    }
}
