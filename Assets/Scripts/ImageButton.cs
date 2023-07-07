using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CurrentImage imageStorage;

    public void OnPointerClick(PointerEventData eventData)
    {
        imageStorage.image = GetComponent<Image>().sprite;
        SceneManager.LoadScene("FullView", LoadSceneMode.Additive);
    }

    
}
