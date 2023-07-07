using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] private GameObject BG;
    [SerializeField] private Slider bar;
    [SerializeField] private Text percent;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene() {
        BG.SetActive(true);
        float timer = Random.Range(2, 3);
        timeElapsed = 0;
        StartCoroutine(Loading(timer));        
    }

    IEnumerator Loading(float timer) {
        while (timeElapsed < timer) {
            timeElapsed += Time.deltaTime;
            bar.value = timeElapsed / timer;
            percent.text = $"{bar.value * 100:F0}";
            yield return null;
        }
        BG.SetActive(false);
    }
}
