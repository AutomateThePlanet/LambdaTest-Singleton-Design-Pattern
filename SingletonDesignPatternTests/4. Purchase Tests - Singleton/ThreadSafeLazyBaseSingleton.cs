﻿namespace SingletonDesignPatternTests.FourthVersion;
public abstract class ThreadSafeLazyBaseSingleton<T>
    where T : new()
{
    private static readonly Lazy<T> lazy = new Lazy<T>(() => new T());
    public static T Instance
    {
        get
        {
            return lazy.Value;
        }
    }
}
