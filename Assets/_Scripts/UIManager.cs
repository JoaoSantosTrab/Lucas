using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public GameObject UIOpening;
    public GameObject UIMarcador;
    public GameObject UICatalogo;
    public GameObject UICatalogoPlacing;
    public GameObject UICatalogObjects;
    public GameObject UICatalogObjectDisplay;
    public GameObject UIComoUsar;


    public void Button_Catalogo()
    {
        UIOpening.SetActive(false);
        UICatalogo.SetActive(true);

        AppManager.Instance.ActivateApi();
    }
    public void Button_Marcador()
    {
        UIOpening.SetActive(false);
        UICatalogo.SetActive(true);

        //Load Scene
        SceneManager.LoadScene(1);
    }
    public void Button_ComoUsar()
    {
        UIComoUsar.SetActive(true);
        UIOpening.SetActive(false);
    }
    public void Button_ComoUsar_Back()
    {
        UIComoUsar.SetActive(false);
        UIOpening.SetActive(true);
    }

    public void Button_Catalogo_Plus()
    {
        UICatalogObjects.SetActive(true);
        UICatalogo.SetActive(false);
        AppManager.Instance.DeactivateApi();
    }
    public void Show_Catalogo_Placing()
    {
        UICatalogoPlacing.SetActive(true);
        UICatalogo.SetActive(false);
    }
    public void Hide_Catalogo_Placing()
    {
        UICatalogoPlacing.SetActive(false);
        UICatalogo.SetActive(true);
    }
    public void Button_Catalogo_Confirm()
    {
        AppManager.Instance.ConfirmPosition();
        Hide_Catalogo_Placing();
    }
    public void Button_Catalogo_Delete()
    {
        AppManager.Instance.DeleteObject();
        Hide_Catalogo_Placing();
    }

    public void Button_CatalogObjects_Back()
    {
        UICatalogObjects.SetActive(false);
        UICatalogo.SetActive(true);
        AppManager.Instance.ActivateApi();
    }
    public void Button_CatalogObjects_ObjectReceiver(InfoHolder info)
    {
        CatalogManager.Instance.SetCurrentObject(info.Info);
        UIManager.Instance.Button_CatalogObjects_Object();
    }
    public void Button_CatalogObjects_Object()
    {
        UICatalogObjectDisplay.SetActive(true);
        UICatalogObjects.SetActive(false);
    }

    public void Button_CatalogObjectDisplay_Back()
    {
        UICatalogObjects.SetActive(true);
        UICatalogObjectDisplay.SetActive(false);
    }
    public void Button_CatalogObjectDisplay_Confirm()
    {
        UICatalogObjectDisplay.SetActive(false);
        UICatalogo.SetActive(true);

        //Change choosen prefab
        AppManager.Instance.SetCurrentModel(CatalogManager.Instance.CurrentObject);
        AppManager.Instance.ActivateApi();
    }

}
