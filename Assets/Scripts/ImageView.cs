using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private CurrentImage storedImage;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = storedImage.image;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void CloseView() {
        StartCoroutine(UnloadScene());
    }

    IEnumerator UnloadScene() {
        Screen.orientation = ScreenOrientation.Portrait;
        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync("FullView");
        while (!asyncOp.isDone)
        {
            yield return null;
        }
    }
}
