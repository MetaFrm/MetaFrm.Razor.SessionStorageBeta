using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blazored.SessionStorage.Serialization;

namespace Blazored.SessionStorage;

[Obsolete("사용되지 않습니다.")]
internal class SessionStorageService : ISessionStorageService, ISyncSessionStorageService
{
    private readonly IStorageProvider _storageProvider;
    private readonly IJsonSerializer _serializer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storageProvider"></param>
    /// <param name="serializer"></param>
    public SessionStorageService(IStorageProvider storageProvider, IJsonSerializer serializer)
    {
        _storageProvider = storageProvider;
        _serializer = serializer;
    }

    [Obsolete("사용되지 않습니다.")]
    public ValueTask RemoveItemsAsync(IEnumerable<string> keys, CancellationToken cancellationToken = default)
        => _storageProvider.RemoveItemsAsync(keys, cancellationToken);

    [Obsolete("사용되지 않습니다.")]
    public async ValueTask SetItemAsync<T>(string key, T data, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var e = await RaiseOnChangingAsync(key, data).ConfigureAwait(false);

        if (e.Cancel)
            return;

        var serialisedData = _serializer.Serialize(data);
        await _storageProvider.SetItemAsync(key, serialisedData, cancellationToken).ConfigureAwait(false);

        RaiseOnChanged(key, e.OldValue, data);
    }

    [Obsolete("사용되지 않습니다.")]
    public async ValueTask SetItemAsStringAsync(string key, string data, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        if (data is null)
            throw new ArgumentNullException(nameof(data));

        var e = await RaiseOnChangingAsync(key, data).ConfigureAwait(false);

        if (e.Cancel)
            return;

        await _storageProvider.SetItemAsync(key, data, cancellationToken).ConfigureAwait(false);

        RaiseOnChanged(key, e.OldValue, data);
    }

    [Obsolete("사용되지 않습니다.")]
    public async ValueTask<T> GetItemAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var serialisedData = await _storageProvider.GetItemAsync(key, cancellationToken).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(serialisedData))
            return default;

        try
        {
            return _serializer.Deserialize<T>(serialisedData);
        }
        catch (JsonException e) when (e.Path == "$" && typeof(T) == typeof(string))
        {
            // For backward compatibility return the plain string.
            // On the next save a correct value will be stored and this Exception will not happen again, for this 'key'
            return (T)(object)serialisedData;
        }
    }

    [Obsolete("사용되지 않습니다.")]
    public ValueTask<string> GetItemAsStringAsync(string key, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        return _storageProvider.GetItemAsync(key, cancellationToken);
    }

    [Obsolete("사용되지 않습니다.")]
    public ValueTask RemoveItemAsync(string key, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        return _storageProvider.RemoveItemAsync(key, cancellationToken);
    }

    [Obsolete("사용되지 않습니다.")]
    public ValueTask ClearAsync(CancellationToken cancellationToken = default) 
        => _storageProvider.ClearAsync(cancellationToken);

    [Obsolete("사용되지 않습니다.")]
    public ValueTask<int> LengthAsync(CancellationToken cancellationToken = default) 
        => _storageProvider.LengthAsync(cancellationToken);

    [Obsolete("사용되지 않습니다.")]
    public ValueTask<string> KeyAsync(int index, CancellationToken cancellationToken = default) 
        => _storageProvider.KeyAsync(index, cancellationToken);

    [Obsolete("사용되지 않습니다.")]
    public ValueTask<IEnumerable<string>> KeysAsync(CancellationToken cancellationToken = default)
        => _storageProvider.KeysAsync(cancellationToken);

    [Obsolete("사용되지 않습니다.")]
    public ValueTask<bool> ContainKeyAsync(string key, CancellationToken cancellationToken = default) 
        => _storageProvider.ContainKeyAsync(key, cancellationToken);

    [Obsolete("사용되지 않습니다.")]
    public void SetItem<T>(string key, T data)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var e = RaiseOnChangingSync(key, data);

        if (e.Cancel)
            return;

        var serialisedData = _serializer.Serialize(data);
        _storageProvider.SetItem(key, serialisedData);

        RaiseOnChanged(key, e.OldValue, data);
    }

    [Obsolete("사용되지 않습니다.")]
    public void SetItemAsString(string key, string data)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        if (data is null)
            throw new ArgumentNullException(nameof(data));

        var e = RaiseOnChangingSync(key, data);

        if (e.Cancel)
            return;

        _storageProvider.SetItem(key, data);

        RaiseOnChanged(key, e.OldValue, data);
    }

    [Obsolete("사용되지 않습니다.")]
    public T GetItem<T>(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var serialisedData = _storageProvider.GetItem(key);

        if (string.IsNullOrWhiteSpace(serialisedData))
            return default;

        try
        {
            return _serializer.Deserialize<T>(serialisedData);
        }
        catch (JsonException e) when (e.Path == "$" && typeof(T) == typeof(string))
        {
            // For backward compatibility return the plain string.
            // On the next save a correct value will be stored and this Exception will not happen again, for this 'key'
            return (T)(object)serialisedData;
        }
    }

    [Obsolete("사용되지 않습니다.")]
    public string GetItemAsString(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        return _storageProvider.GetItem(key);
    }

    [Obsolete("사용되지 않습니다.")]
    public void RemoveItem(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        _storageProvider.RemoveItem(key);
    }

    [Obsolete("사용되지 않습니다.")]
    public void RemoveItems(IEnumerable<string> keys)
    {
        if (keys == null)
            throw new ArgumentNullException(nameof(keys));

        foreach (var key in keys)
        {
            _storageProvider.RemoveItem(key);
        }
    }

    [Obsolete("사용되지 않습니다.")]
    public void Clear()
        => _storageProvider.Clear();

    [Obsolete("사용되지 않습니다.")]
    public int Length()
        => _storageProvider.Length();

    [Obsolete("사용되지 않습니다.")]
    public string Key(int index)
        => _storageProvider.Key(index);

    [Obsolete("사용되지 않습니다.")]
    public IEnumerable<string> Keys() 
        => _storageProvider.Keys();

    [Obsolete("사용되지 않습니다.")]
    public bool ContainKey(string key)
        => _storageProvider.ContainKey(key);

    [Obsolete("사용되지 않습니다.")]
    public event EventHandler<ChangingEventArgs> Changing;
    private async Task<ChangingEventArgs> RaiseOnChangingAsync(string key, object data)
    {
        var e = new ChangingEventArgs
        {
            Key = key,
            OldValue = await GetItemInternalAsync<object>(key).ConfigureAwait(false),
            NewValue = data
        };

        Changing?.Invoke(this, e);

        return e;
    }

    private ChangingEventArgs RaiseOnChangingSync(string key, object data)
    {
        var e = new ChangingEventArgs
        {
            Key = key,
            OldValue = GetItemInternal(key),
            NewValue = data
        };

        Changing?.Invoke(this, e);

        return e;
    }

    private async Task<T> GetItemInternalAsync<T>(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        var serialisedData = await _storageProvider.GetItemAsync(key).ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(serialisedData))
            return default;
        try
        {
            return _serializer.Deserialize<T>(serialisedData);
        }
        catch (JsonException)
        {
            return (T)(object)serialisedData;
        }
    }

    private object GetItemInternal(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        var serialisedData = _storageProvider.GetItem(key);

        if (string.IsNullOrWhiteSpace(serialisedData))
            return default;

        try
        {
            return _serializer.Deserialize<object>(serialisedData);
        }
        catch (JsonException)
        {
            return serialisedData;
        }
    }

    [Obsolete("사용되지 않습니다.")]
    public event EventHandler<ChangedEventArgs> Changed;
    private void RaiseOnChanged(string key, object oldValue, object data)
    {
        var e = new ChangedEventArgs
        {
            Key = key,
            OldValue = oldValue,
            NewValue = data
        };

        Changed?.Invoke(this, e);
    }
}
