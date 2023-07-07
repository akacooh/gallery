using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private ImageView imageView;
    private ScreenOrientation previousOrientation = ScreenOrientation.Portrait;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation != previousOrientation) {
            ChangeAnchor();
            previousOrientation = Screen.orientation;
        }

        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKey(KeyCode.Escape)) {
                imageView.CloseView();
            }
        }
    }

    private void ChangeAnchor() {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
            rect.anchorMin = new Vector2(1, 0.5f);
            rect.anchorMax = new Vector2(1, 0.5f);
            rect.anchoredPosition = new Vector2(-120, 0);
        }
        if (Screen.orientation == ScreenOrientation.LandscapeRight) {
            rect.anchorMin = new Vector2(1, 0.5f);
            rect.anchorMax = new Vector2(1, 0.5f);
            rect.anchoredPosition = new Vector2(-120, 0);
        }
        if (Screen.orientation == ScreenOrientation.Portrait) {
            rect.anchorMin = new Vector2(0.5f, 0);
            rect.anchorMax = new Vector2(0.5f, 0);
            rect.anchoredPosition = new Vector2(0, 120);
        }
        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
            rect.anchorMin = new Vector2(0.5f, 0);
            rect.anchorMax = new Vector2(0.5f, 0);
            rect.anchoredPosition = new Vector2(0, 120);
        }
    }
}
