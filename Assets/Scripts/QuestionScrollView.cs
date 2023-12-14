using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class QuestionScrollView : MonoBehaviour
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
        //LoadQuestion();
    }

    public void LoadQuestion(List<Question> questions)
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject item;

        //int N = allItems.Length;
        int N = questions.Count;
        
        for (int i = 0; i < N; i++)
        {
            item = Instantiate(buttonTemplate, transform);
            item.transform.GetComponent<QuestionButton>().workbookSetting = workbookSetting;
            item.transform.GetComponent<QuestionButton>().question_num = i;
            item.transform.GetComponent<QuestionButton>().fullText = questions[i].fullText;
            item.transform.GetComponent<QuestionButton>().text1 = questions[i].slides[0].linesets[0].sentence;
            item.transform.GetComponent<QuestionButton>().text2 = questions[i].slides[0].linesets[1].sentence;
            item.transform.GetComponent<QuestionButton>().text3 = questions[i].slides[0].linesets[2].sentence;

            item.transform.GetComponent<QuestionButton>().question_image = questions[i].picture;

            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questions[i].number + "¹ø ¹®Ç×";

            //item.transform.GetChild(0).GetComponent<Image>().sprite = allItems[i].Icon;
            //item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = allItems[i].Description;

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
