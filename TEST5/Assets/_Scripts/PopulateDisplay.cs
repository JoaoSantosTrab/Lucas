using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDisplay : MonoBehaviour
{
    public GameObject prefab;
    private CatalogObject obj;

    public RectTransform ScrollViewTransform;

    public Text Title;
    public Text Description;

    private GridLayoutGroup grid;

    // Start is called before the first frame update
    void Start()
    {
        obj = CatalogManager.Instance.GetCurrentObject();
        grid = GetComponent<GridLayoutGroup>();

        Rect rect = new Rect();
        rect = ScrollViewTransform.rect;
        rect.width = ScrollViewTransform.rect.width;
        rect.height = obj.Images[0].rect.height;
        ScrollViewTransform.rect.Set(rect.x,rect.y,rect.width, rect.height);

        Vector2 cellSize = new Vector2();
        cellSize.x = ScrollViewTransform.rect.height;
        cellSize.y = cellSize.x;
        grid.cellSize = cellSize;

        Populate();

        //SET TITLE
        Title.text = obj.Name;
        Description.text = obj.Description;
    }

    public void Populate()
    {
        GameObject newObject;

        for (int i = 0; i < obj.Images.Count; i++)
        {
            newObject = (GameObject)Instantiate(prefab, transform);
            newObject.GetComponent<Image>().sprite = obj.Images[i];
        }
    }
}
