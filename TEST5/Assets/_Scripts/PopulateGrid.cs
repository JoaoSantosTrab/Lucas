using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public RectTransform ScrollViewTransform;
    public RectTransform ScrollBarTransform;
    public int NumberOfColumns;

    private GridLayoutGroup grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();

        Vector2 cellSize = new Vector2();
        cellSize.x = (ScrollViewTransform.rect.width - ScrollBarTransform.rect.width) / NumberOfColumns;
        cellSize.y = cellSize.x;
        grid.cellSize = cellSize;

        FakePopulate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FakePopulate()
    {
        GameObject newObject;
        List<CatalogObject> c = CatalogManager.Instance.GetCatalogList();

        for (int i = 0; i < 25; i++)
        {
            newObject = (GameObject)Instantiate(prefab, transform);
            newObject.GetComponent<InfoHolder>().Info = c[0];
            newObject.GetComponent<Image>().sprite = c[0].Images[0];
        }
    }
    public void Populate()
    {
        GameObject newObject;
        List<CatalogObject> c = CatalogManager.Instance.GetCatalogList();

        for (int i = 0; i < c.Count; i++)
        {
            newObject = (GameObject)Instantiate(prefab, transform);
            newObject.GetComponent<InfoHolder>().Info = c[i];
            newObject.GetComponent<Image>().sprite = c[i].Images[0];
        }
    }
}
