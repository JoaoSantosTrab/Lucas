using GoogleARCore;
using GoogleARCore.Examples.Common;
using GoogleARCore.Examples.HelloAR;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Singleton<AppManager>
{
    public HelloARController Controller;
    public DetectedPlaneGenerator DetectedPlaneGenerator;
    public PlaneDiscoveryGuide PlaneDiscoveryGuide;

    public Action ApiUpdate;

    void Start()
    {
        SetCurrentModel(CatalogManager.Instance.Catalog[0]);
        DeactivateApi();
    }

    private void Update()
    {
        ApiUpdate?.Invoke();
    }

    public void SetCurrentModel(CatalogObject model) => Controller.SetCurrentModel(model);
    public void ConfirmPosition()
    {
        Controller.ConfirmPosition();
    }
    public void DeleteObject()
    {
        Controller.DeleteObject();
    }
    public void ActivatePlacingUI()
    {
        UIManager.Instance.Show_Catalogo_Placing();
    }

    public void ActivateApi()
    {
        ApiUpdate += Controller.UpdateObjectPlacer;
        ApiUpdate += DetectedPlaneGenerator.UpdatePlaneGenerator;
        ApiUpdate += PlaneDiscoveryGuide.UpdatePlaneDiscovery;
    }
    public void DeactivateApi()
    {
        ApiUpdate -= Controller.UpdateObjectPlacer;
        ApiUpdate -= DetectedPlaneGenerator.UpdatePlaneGenerator;
        ApiUpdate -= PlaneDiscoveryGuide.UpdatePlaneDiscovery;
    }

}
