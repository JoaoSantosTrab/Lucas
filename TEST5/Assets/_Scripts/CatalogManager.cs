using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AcceptedPlane { Vertical, Horizontal };

[Serializable]
public class CatalogObject
{
    public string Name;
    public AcceptedPlane Plane;
    public GameObject Prefab;
    public List<Sprite> Images;
    [TextArea(15,20)]
    public string Description;
}

public class CatalogManager : Singleton<CatalogManager>
{
    public List<CatalogObject> Catalog;
    public CatalogObject CurrentObject;

    public List<CatalogObject> GetCatalogList()
    {
        return Catalog;
    }

    public void SetCurrentObject(CatalogObject catalogObject)
    {
        CurrentObject = catalogObject;
    }
    public CatalogObject GetCurrentObject()
    {
        return CurrentObject;
    }
}
