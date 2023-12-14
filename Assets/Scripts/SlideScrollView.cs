using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SlideScrollView : MonoBehaviour
{
    [Serializable]
    public struct Item
    {
        public string Name;
        //public string Description;
        //public Sprite Icon;
    }

    [SerializeField] Item[] allItems;

    private int objectNum = 0;
    public Rect rect;
    public WorkbookSetting workbookSetting;
    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject item;

        int N = allItems.Length;

        for (int i = 0; i < N; i++)
        {
            item = Instantiate(buttonTemplate, transform);
            item.transform.GetComponent<SlideButton>().workbookSetting = workbookSetting;
            item.transform.GetComponent<SlideButton>().slide_num = i;
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Slide" + i;

            /*                item.GetComponent<Button>().onClick.AddListener(delegate ()
                            {
                                ItemClicked(i);
                            });*/
            //item.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(buttonTemplate);
    }

/*    void ItemClicked(int itemIndex)
    {
        objectNum = itemIndex;
        Debug.Log("------------item " + itemIndex + " clicked---------------");
        Debug.Log("name " + allItems[itemIndex].Name);
        //Debug.Log("desc " + allItems[itemIndex].Description);
    }*/
}
