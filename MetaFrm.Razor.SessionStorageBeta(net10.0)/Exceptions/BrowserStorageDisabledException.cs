using System;

namespace Blazored.SessionStorage.Exceptions;

/// <summary>
/// 
/// </summary>
public class BrowserStorageDisabledException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    public BrowserStorageDisabledException()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public BrowserStorageDisabledException(string message) : base(message)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    public BrowserStorageDisabledException(string message, Exception inner) : base(message, inner)
    {
    }
}
