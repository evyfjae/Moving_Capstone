using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupController : MonoBehaviour
{
    public WorkbookSetting workbookSetting;
    public GameObject animationList1, animationList2, animationList3; // Assign your Canvas in the inspector
    public GameObject animationList4, animationList5, animationList6;
    public GameObject animationList7, animationList8, animationList9;

    public ToggleGroup toggleGroup;

    public void DisableAllToggles()
    {
        foreach (Toggle toggle in toggleGroup.ActiveToggles())
        {
            toggle.isOn = false;
        }

        switch(workbookSetting.lineSet_num)
        {
            case 0:
                break;
            case 1:
                animationList1.SetActive(false);
                break;
            case 2:
                animationList2.SetActive(false);
                break;
            case 3:
                animationList3.SetActive(false);
                break;
            case 4:
                animationList4.SetActive(false);
                break;
            case 5:
                animationList5.SetActive(false);
                break;
            case 6:
                animationList6.SetActive(false);
                break;
            case 7:
                animationList7.SetActive(false);
                break;
            case 8:
                animationList8.SetActive(false);
                break;
            case 9:
                animationList9.SetActive(false);
                break;
        }

        this.gameObject.SetActive(false);
    }
}
