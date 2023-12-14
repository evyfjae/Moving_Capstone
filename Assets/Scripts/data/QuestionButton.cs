using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionButton : MonoBehaviour
{
    public WorkbookSetting workbookSetting;

    public TMP_InputField inputField_fullText;
    public TMP_InputField inputField_text1, inputField_text2, inputField_text3;
    public string fullText;
    public string text1, text2, text3;
    public int question_num;
    public Image animation_image;
    public Sprite question_image;
    private Toggle toggle;
    private Image toggleBackground;
    // Start is called before the first frame update
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        toggleBackground = toggle.GetComponent<Image>();
    }

    public void OnToggleValueChanged(bool isOn)
    {
        workbookSetting.quest_num = question_num;
        if (isOn)
        {
            Debug.Log(question_num + "Toggle이 켜졌습니다!");
            animation_image.sprite = question_image;
            inputField_fullText.text = fullText;
            inputField_text1.text = text1;
            inputField_text2.text = text2;
            inputField_text3.text = text3;


            toggleBackground.color = Color.gray;
        }
        else
        {
            Debug.Log(question_num + "Toggle이 꺼졌습니다!");
            fullText = inputField_fullText.text;

            text1 = inputField_text1.text;
            text2 = inputField_text2.text;
            text3 = inputField_text3.text;
            toggleBackground.color = Color.white;
        }
    }
}
