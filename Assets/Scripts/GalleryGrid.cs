using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryGrid : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private RectTransform viewPort;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private int imagesCount;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private string baseUrl;

    private List<ImageLoader> rowsList;
    private float cellWidth = 0;
    private int rowsLoaded = 0;
    private float horizontalSpacing;
    private float verticalSpacing;
    private float lastPosition = 0;
    private RectTransform contentParentRect;

    void Start()
    {
        Canvas.ForceUpdateCanvases(); //forcing update to get calculated values from autolayout
        var verticalLayout = GetComponent<VerticalLayoutGroup>();
        verticalSpacing = verticalLayout.spacing;
        var temp = Instantiate(rowPrefab);
        var horizontalLayout = temp.GetComponent<HorizontalLayoutGroup>();
        horizontalSpacing = horizontalLayout.spacing;

        rowsList = new List<ImageLoader>();
        cellWidth = (viewPort.rect.width - 2*horizontalSpacing) / 2;
        int rowsToLoad = Mathf.CeilToInt(viewPort.rect.height / (cellWidth + verticalSpacing));

        for (int i = 0; i < imagesCount/2; i++) {
            var row = Instantiate(rowPrefab, contentParent);
            rowsList.Add(row.GetComponent<ImageLoader>());
            if (i <= rowsToLoad) {
                UpdateRow(i);         
            }
        }

        scrollRect.onValueChanged.AddListener(ScrollCheck);
        contentParentRect = contentParent.GetComponent<RectTransform>();
    }

    private void ScrollCheck(Vector2 value) {
        if ((contentParentRect.anchoredPosition.y - lastPosition) < cellWidth) return;
        if (rowsLoaded >= imagesCount / 2) return;
        UpdateRow(rowsLoaded); //counting from 0;
        lastPosition = contentParentRect.anchoredPosition.y;
    }

    private void UpdateRow(int rowNumber) {
            string url1 = baseUrl + $"{2*rowNumber + 1}" + ".jpg";
            string url2 = baseUrl + $"{2*rowNumber + 2}" + ".jpg";
            rowsList[rowNumber].FetchImages(url1, url2);
            rowsLoaded++;          
    }
}
