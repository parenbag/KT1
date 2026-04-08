using UnityEngine;

public class ResourcesLoader : IResourceLoader
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public void Unload(Object obj)
    {
        if (obj != null)
            Resources.UnloadAsset(obj);
    }
}