using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blazored.SessionStorage;

[Obsolete("사용되지 않습니다.")]
internal interface IStorageProvider
{
    [Obsolete("사용되지 않습니다.")]
    void Clear();
    [Obsolete("사용되지 않습니다.")]
    ValueTask ClearAsync(CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    bool ContainKey(string key);
    [Obsolete("사용되지 않습니다.")]
    ValueTask<bool> ContainKeyAsync(string key, CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    string GetItem(string key);
    [Obsolete("사용되지 않습니다.")]
    ValueTask<string> GetItemAsync(string key, CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    string Key(int index);
    [Obsolete("사용되지 않습니다.")]
    ValueTask<string> KeyAsync(int index, CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    IEnumerable<string> Keys();
    [Obsolete("사용되지 않습니다.")]
    ValueTask<IEnumerable<string>> KeysAsync(CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    int Length();
    [Obsolete("사용되지 않습니다.")]
    ValueTask<int> LengthAsync(CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    void RemoveItem(string key);
    [Obsolete("사용되지 않습니다.")]
    ValueTask RemoveItemAsync(string key, CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    ValueTask RemoveItemsAsync(IEnumerable<string> keys, CancellationToken cancellationToken = default);
    [Obsolete("사용되지 않습니다.")]
    void SetItem(string key, string data);
    [Obsolete("사용되지 않습니다.")]
    ValueTask SetItemAsync(string key, string data, CancellationToken cancellationToken = default);
}
