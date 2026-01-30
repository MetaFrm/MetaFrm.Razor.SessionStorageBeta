using System;
using System.Collections.Generic;

namespace Blazored.SessionStorage;

/// <summary>
/// 
/// </summary>
[Obsolete("사용되지 않습니다.")]
public interface ISyncSessionStorageService
{
    /// <summary>
    /// Clears all data from session storage.
    /// </summary>
    [Obsolete("사용되지 않습니다.")]
    void Clear();

    /// <summary>
    /// Retrieve the specified data from session storage as a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="key">A <see cref="string"/> value specifying the name of the session storage slot to use</param>
    /// <returns>The data from the specified <paramref name="key"/> as a <typeparamref name="T"/></returns>
    [Obsolete("사용되지 않습니다.")]
    T GetItem<T>(string key);

    /// <summary>
    /// Retrieve the specified data from session storage as a <see cref="string"/>.
    /// </summary>
    /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
    /// <returns>The data associated with the specified <paramref name="key"/> as a <see cref="string"/></returns>
    [Obsolete("사용되지 않습니다.")]
    string GetItemAsString(string key);

    /// <summary>
    /// Return the name of the key at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The name of the key at the specified <paramref name="index"/></returns>
    [Obsolete("사용되지 않습니다.")]
    string Key(int index);

    /// <summary>
    /// Get the keys of all items stored in session storage.
    /// </summary>
    /// <returns>The keys of all items stored in session storage</returns>
    [Obsolete("사용되지 않습니다.")]
    IEnumerable<string> Keys();

    /// <summary>
    /// Checks if the <paramref name="key"/> exists in session storage, but does not check its value.
    /// </summary>
    /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
    /// <returns>Boolean indicating if the specified <paramref name="key"/> exists</returns>
    [Obsolete("사용되지 않습니다.")]
    bool ContainKey(string key);

    /// <summary>
    /// The number of items stored in session storage.
    /// </summary>
    /// <returns>The number of items stored in session storage</returns>
    [Obsolete("사용되지 않습니다.")]
    int Length();

    /// <summary>
    /// Remove the data with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
    [Obsolete("사용되지 않습니다.")]
    void RemoveItem(string key);

    /// <summary>
    /// Removes a collection of <paramref name="keys"/>.
    /// </summary>
    /// <param name="keys">A IEnumerable collection of strings specifying the name of the storage slot to remove</param>
    [Obsolete("사용되지 않습니다.")]
    void RemoveItems(IEnumerable<string> keys);

    /// <summary>
    /// Sets or updates the <paramref name="data"/> in session storage with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
    /// <param name="data">The data to be saved</param>
    [Obsolete("사용되지 않습니다.")]
    void SetItem<T>(string key, T data);

    /// <summary>
    /// Sets or updates the <paramref name="data"/> in session storage with the specified <paramref name="key"/>. Does not serialize the value before storing.
    /// </summary>
    /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
    /// <param name="data">The string to be saved</param>
    /// <returns></returns>
    [Obsolete("사용되지 않습니다.")]
    void SetItemAsString(string key, string data);

    /// <summary>
    /// 
    /// </summary>
    [Obsolete("사용되지 않습니다.")]
    event EventHandler<ChangingEventArgs> Changing;
    /// <summary>
    /// 
    /// </summary>
    [Obsolete("사용되지 않습니다.")]
    event EventHandler<ChangedEventArgs> Changed;
}
