using UnityEngine;

public interface IResourceLoader
{
    T Load<T>(string path) where T : Object;
    void Unload(Object obj);
}