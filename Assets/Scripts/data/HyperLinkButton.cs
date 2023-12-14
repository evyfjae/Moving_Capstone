using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HyperLinkButton : MonoBehaviour
{
    public WorkbookSetting workbook;
    public int question_num;
    public int slide_num;
    public int line_num;

    public TMP_InputField inputField;
    public TMP_Text dragText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void linkButton()
    {
        workbook.questions[question_num].slides[slide_num].linesets[line_num].hyperText_name = dragText.text;
        workbook.questions[question_num].slides[slide_num].linesets[line_num].hyperText_link = inputField.text;


        dragText.text = "";
        inputField.text = "";
    }
}
