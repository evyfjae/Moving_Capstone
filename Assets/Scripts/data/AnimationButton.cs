using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationButton : MonoBehaviour
{
    public Animation animation;
    public List<LineSet> lineSets;
    public int lineNum = 0;
    public AddAnimation addAnimation;
    public GameObject finishButton;

    private Toggle toggle;
    private Image toggleBackground;

    public WorkbookSetting workbookSetting;
    public MouseManager mouseManager;
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        toggleBackground = toggle.GetComponent<Image>();
    }
/*    public void OnClick()
    {
        //lineSets[lineNum].animation = animation;
        Debug.Log(lineNum);
        Debug.Log(animation.time);
        addAnimation.addAnimation(animation.name);
    }*/

    public void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            if(workbookSetting.lineSet_num<9)
            {
                addAnimation.addAnimation(animation);
                finishButton.SetActive(true);
                toggleBackground.color = Color.gray;
                workbookSetting.lineSet_num++;
                mouseManager.animationMode = animation.kind;
            }
        }
        else
        {
            toggleBackground.color = Color.white;
        }
    }
}
