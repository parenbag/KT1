using UnityEngine;

public class ResourceManager
{
    private IResourceLoader loader;

    public ResourceManager(IResourceLoader loader)
    {
        this.loader = loader;
    }

    public T Load<T>(string path) where T : Object
    {
        return loader.Load<T>(path);
    }

    public void Unload(Object obj)
    {
        loader.Unload(obj);
    }
}