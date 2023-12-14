using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public float playtime = 0; 
    // Start is called before the first frame update
    void Start()
    {
        playtime = 2.0f;
        
    }

    private void OnEnable()
    {
        Debug.Log("Enable 실행");
        loadAnimation();
/*        Image image = GetComponent<Image>();
        image.DOFade(0, 1f);*/
        //image.DOFade(1, 1f).SetDelay(1f);
    }

    private void OnDisable()
    {
        Debug.Log("Disable 실행");
        Image image = GetComponent<Image>();
        image.DOColor(Color.white, 1.5f);
    }

    public void loadAnimation()
    {
        Color color = new Color(12f / 255f, 112f / 255f, 242f / 255f);

        Image image = GetComponent<Image>();
        image.DOFade(0, 1f);
        gameObject.transform.DOScale(0, 0);
        gameObject.transform.DOScale(1, 1.5f);
        image.DOFade(1, 1f).SetDelay(1f);
        image.DOColor(color, 1.5f);
    }
}
