using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbookSetting : MonoBehaviour
{
    public QuestionScrollView questionScrollView;
    public int quest_num;
    public int slide_num;
    public int lineSet_num;
    public int animation_num;

    public List<Question> questions = new List<Question>();

    private void Start()
    {
        questionScrollView.LoadQuestion(questions);
    }

}
