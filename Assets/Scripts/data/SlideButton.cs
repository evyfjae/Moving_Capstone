using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlideButton : MonoBehaviour
{
    public TMP_InputField inputField1, inputField2, inputField3;
    public WorkbookSetting workbookSetting;
    public int slide_num;
    public string slideText;
    private Toggle toggle;
    private Image toggleBackground;
    public List<Question> questions = new List<Question>();
    public AddAnimation addAnimation;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        toggleBackground = toggle.GetComponent<Image>();
    }

    public void OnToggleValueChanged(bool isOn)
    {
        questions = workbookSetting.questions;
        workbookSetting.slide_num = slide_num;
        if (isOn)
        {
            Debug.Log(slide_num + "Toggle이 켜졌습니다!");
            inputField1.text = questions[workbookSetting.quest_num].slides[slide_num].linesets[0].sentence;
            inputField2.text = questions[workbookSetting.quest_num].slides[slide_num].linesets[1].sentence;
            inputField3.text = questions[workbookSetting.quest_num].slides[slide_num].linesets[2].sentence;
            //addAnimation.LoadAnimationSet();
            toggleBackground.color = Color.gray;
        }
        else
        {
            Debug.Log(slide_num + "Toggle이 꺼졌습니다!");
            //slideText = inputField.text;
            questions[workbookSetting.quest_num].slides[slide_num].linesets[0].sentence = inputField1.text;
            questions[workbookSetting.quest_num].slides[slide_num].linesets[1].sentence = inputField2.text;
            questions[workbookSetting.quest_num].slides[slide_num].linesets[2].sentence = inputField3.text;

            toggleBackground.color = Color.white;
        }
    }

}
