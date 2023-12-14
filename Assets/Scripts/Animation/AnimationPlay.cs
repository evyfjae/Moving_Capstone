using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RockVR.Video.Demo;
public class AnimationPlay : MonoBehaviour
{
    public WorkbookSetting workbookSetting;
    public VideoCaptureUI VideoCaptureUI; 
    public GameObject animationList1, animationList2, animationList3; // Assign your Canvas in the inspector
    public GameObject animationList4, animationList5, animationList6;
    public GameObject animationList7, animationList8, animationList9;

    public void OnClick()
    {
        ActivateAfterDelay();
    }
    public void ActivateAfterDelay()
    {
        StartCoroutine(RecordAfterSeconds(0f));
        StartCoroutine(ActivateAfterSeconds(animationList1, 0f));
        StartCoroutine(ActivateAfterSeconds(animationList2, 2f));
        StartCoroutine(ActivateAfterSeconds(animationList3, 4f));
        StartCoroutine(ActivateAfterSeconds(animationList4, 6f));
        StartCoroutine(ActivateAfterSeconds(animationList5, 8f));
        StartCoroutine(ActivateAfterSeconds(animationList6, 10f));
        StartCoroutine(ActivateAfterSeconds(animationList7, 12f));
        StartCoroutine(ActivateAfterSeconds(animationList8, 14f));
        StartCoroutine(ActivateAfterSeconds(animationList9, 16f));
        StartCoroutine(DeActivateAfterSeconds(18f));
        StartCoroutine(RecordAfterSeconds(18f));
    }

    IEnumerator ActivateAfterSeconds(GameObject targetObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        targetObject.SetActive(true);
    }

    IEnumerator DeActivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animationList1.SetActive(false);
        animationList2.SetActive(false);
        animationList3.SetActive(false);
        animationList4.SetActive(false);
        animationList5.SetActive(false);
        animationList6.SetActive(false);
        animationList7.SetActive(false);
        animationList8.SetActive(false);
        animationList9.SetActive(false);
    }

    IEnumerator RecordAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        VideoCaptureUI.recoredButton();
    }

}
