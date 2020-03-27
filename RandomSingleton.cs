using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomSingleton
{
    private static Random _random;

    public static Random Instance { get { return GetInstance(); } }

    private static Random GetInstance()
    {
        if (_random == null)
        {
            _random = new Random();
        }

        return _random;
    }
}