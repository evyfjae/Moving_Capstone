using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SlideNumber : MonoBehaviour
{
    private TMP_Text name;
    private int number;
    // Start is called before the first frame update

    private void Start()
    {
        name = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        //name.text = "2";
        int number = transform.parent.GetSiblingIndex() + 1;
        name.text = "Slide" + number.ToString();
    }
}
