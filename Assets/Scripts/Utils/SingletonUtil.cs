using UnityEngine;

namespace Utils
{
    public class SingletonUtil<T> where T :  new()
    {
        public static T single { get; private set; } = new T();
        
        
    }
}