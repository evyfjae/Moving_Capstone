using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AddAnimation : MonoBehaviour
{
    public WorkbookSetting workbookSetting;

    GameObject buttonTemplate;
    private void Start()
    {
        //지금 최소 1개 들어있어야 복사할 수 있어서 0개 되면 버그남
        buttonTemplate = transform.GetChild(0).gameObject;
        buttonTemplate.SetActive(false);
        //Destroy(buttonTemplate);
    }
    public void addAnimation(Animation ani)
    {
        //GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject item;
        item = Instantiate(buttonTemplate, transform);
        item.SetActive(true);
        item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ani.name;
    }

    public void LoadAnimationSet()
    {
        int questionNum = workbookSetting.quest_num;
        int slideNum = workbookSetting.slide_num;
        int lineSetNum = workbookSetting.lineSet_num;
        Debug.Log(workbookSetting.questions[questionNum].slides[slideNum].linesets.Count);
        if(workbookSetting.questions[questionNum].slides[slideNum].linesets.Count > 0)
        {
            for (int i = 0; i < workbookSetting.questions[questionNum].slides[slideNum].linesets.Count; i++)
            {
                addAnimation(workbookSetting.questions[questionNum].slides[slideNum].linesets[i].animation);
            }
        }
    }

/*    [Serializable]
    public struct Item
    {
        public string Name;
        [SerializeField] public AnimationButton animationButton;
        //public Sprite Icon;
    }

    [SerializeField] Item[] allItems;

    private int objectNum = 0;
    public Rect rect;*/

/*    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject item;

        int N = allItems.Length;

        for (int i = 0; i < N; i++)
        {
            item = Instantiate(buttonTemplate, transform);
            //item.transform.GetChild(0).GetComponent<Image>().sprite = allItems[i].Icon;
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = allItems[i].Name;
            //item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = allItems[i].Description;

            *//*                item.GetComponent<Button>().onClick.AddListener(delegate ()
                            {
                                ItemClicked(i);
                            });*//*
            item.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(buttonTemplate);
    }*/

    // Update is called once per frame
/*    void Update()
    {

    }

    void ItemClicked(int itemIndex)
    {
        objectNum = itemIndex;
        Debug.Log("------------item " + itemIndex + " clicked---------------");
        Debug.Log("name " + allItems[itemIndex].Name);
        //Debug.Log("desc " + allItems[itemIndex].Description);
    }*/
}
