using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPatternTests.FourthVersion;
using System.Threading;

public class ThreadLocalSingleton<T> where T : new()
{
    private static ThreadLocal<T> instance = new ThreadLocal<T>(() => new T());

    public static T Instance => instance.Value;
}
