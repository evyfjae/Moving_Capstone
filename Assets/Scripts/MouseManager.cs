using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    public WorkbookSetting workbookSetting;
    // Start is called before the first frame update
    public bool OnAnimation = false;
    public int animationMode = 0;

    public GameObject animationList1, animationList2, animationList3; // Assign your Canvas in the inspector
    public GameObject animationList4, animationList5, animationList6;
    public GameObject animationList7, animationList8, animationList9;
    public GameObject image0, image1, image2, image3; // Assign the image you want to create in the inspector

    public bool rotation_on = false;

    //애니메이션 mode 정하기
    //해당 시점의 마우스 클릭 위치 받기
    void Update()
    {
        if(OnAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateImage(Input.mousePosition);
            }
            if (Input.GetMouseButtonDown(1))
            {
                OnAnimation = false;
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            OnAnimation = true;
        }

        if(Input.GetKey(KeyCode.R))
        {
            rotation_on = true;
        }

        if(Input.GetKey(KeyCode.T))
        {
            rotation_on = false;
        }

    }

    void CreateImage(Vector3 position)
    {
        /*        GameObject newImage = new GameObject("Created Image"); // Create a new GameObject
                newImage.transform.SetParent(canvas.transform); // Set the new GameObject's parent to the Canvas
                newImage.transform.position = position; // Set the position to the mouse position
                //newImage.AddComponent<Spawn>();
                // Add the Image component to the GameObject
                Image image = newImage.AddComponent<Image>();*/
        //image.sprite = imageToCreate; // Set the sprite of the Image component to the assigned image
       
        GameObject item;

        switch (animationMode)
        {
            case 0:
                item = Instantiate(image0);
                item.SetActive(true);
                if(workbookSetting.lineSet_num == 1)
                {
                    item.transform.SetParent(animationList1.transform);
                }
                else if (workbookSetting.lineSet_num == 2)
                {
                    item.transform.SetParent(animationList2.transform);
                }
                else if (workbookSetting.lineSet_num == 3)
                {
                    item.transform.SetParent(animationList3.transform);
                }
                else if (workbookSetting.lineSet_num == 4)
                {
                    item.transform.SetParent(animationList4.transform);
                }
                else if (workbookSetting.lineSet_num == 5)
                {
                    item.transform.SetParent(animationList5.transform);
                }
                else if (workbookSetting.lineSet_num == 6)
                {
                    item.transform.SetParent(animationList6.transform);
                }
                else if (workbookSetting.lineSet_num == 7)
                {
                    item.transform.SetParent(animationList7.transform);
                }
                else if (workbookSetting.lineSet_num == 8)
                {
                    item.transform.SetParent(animationList8.transform);
                }
                else if (workbookSetting.lineSet_num == 9)
                {
                    item.transform.SetParent(animationList9.transform);
                }
                item.transform.position = position;
                item.AddComponent<Spawn>();
                break;
            case 1:
                item = Instantiate(image1);
                item.SetActive(true);
                if (workbookSetting.lineSet_num == 1)
                {
                    item.transform.SetParent(animationList1.transform);
                }
                else if (workbookSetting.lineSet_num == 2)
                {
                    item.transform.SetParent(animationList2.transform);
                }
                else if (workbookSetting.lineSet_num == 3)
                {
                    item.transform.SetParent(animationList3.transform);
                }
                else if (workbookSetting.lineSet_num == 4)
                {
                    item.transform.SetParent(animationList4.transform);
                }
                else if (workbookSetting.lineSet_num == 5)
                {
                    item.transform.SetParent(animationList5.transform);
                }
                else if (workbookSetting.lineSet_num == 6)
                {
                    item.transform.SetParent(animationList6.transform);
                }
                else if (workbookSetting.lineSet_num == 7)
                {
                    item.transform.SetParent(animationList7.transform);
                }
                else if (workbookSetting.lineSet_num == 8)
                {
                    item.transform.SetParent(animationList8.transform);
                }
                else if (workbookSetting.lineSet_num == 9)
                {
                    item.transform.SetParent(animationList9.transform);
                }
                //item.transform.SetParent(animationList1.transform);
                item.transform.position = position;
                item.AddComponent<Spawn>();
                break;
            case 2:
                item = Instantiate(image2);
                item.SetActive(true);
                if (workbookSetting.lineSet_num == 1)
                {
                    item.transform.SetParent(animationList1.transform);
                }
                else if (workbookSetting.lineSet_num == 2)
                {
                    item.transform.SetParent(animationList2.transform);
                }
                else if (workbookSetting.lineSet_num == 3)
                {
                    item.transform.SetParent(animationList3.transform);
                }
                else if (workbookSetting.lineSet_num == 4)
                {
                    item.transform.SetParent(animationList4.transform);
                }
                else if (workbookSetting.lineSet_num == 5)
                {
                    item.transform.SetParent(animationList5.transform);
                }
                else if (workbookSetting.lineSet_num == 6)
                {
                    item.transform.SetParent(animationList6.transform);
                }
                else if (workbookSetting.lineSet_num == 7)
                {
                    item.transform.SetParent(animationList7.transform);
                }
                else if (workbookSetting.lineSet_num == 8)
                {
                    item.transform.SetParent(animationList8.transform);
                }
                else if (workbookSetting.lineSet_num == 9)
                {
                    item.transform.SetParent(animationList9.transform);
                }
                //item.transform.SetParent(animationList1.transform);
                item.transform.position = position;
                item.AddComponent<Spawn>();
                break;
            case 3:
                item = Instantiate(image3);
                item.SetActive(true);
                if (workbookSetting.lineSet_num == 1)
                {
                    item.transform.SetParent(animationList1.transform);
                }
                else if (workbookSetting.lineSet_num == 2)
                {
                    item.transform.SetParent(animationList2.transform);
                }
                else if (workbookSetting.lineSet_num == 3)
                {
                    item.transform.SetParent(animationList3.transform);
                }
                else if (workbookSetting.lineSet_num == 4)
                {
                    item.transform.SetParent(animationList4.transform);
                }
                else if (workbookSetting.lineSet_num == 5)
                {
                    item.transform.SetParent(animationList5.transform);
                }
                else if (workbookSetting.lineSet_num == 6)
                {
                    item.transform.SetParent(animationList6.transform);
                }
                else if (workbookSetting.lineSet_num == 7)
                {
                    item.transform.SetParent(animationList7.transform);
                }
                else if (workbookSetting.lineSet_num == 8)
                {
                    item.transform.SetParent(animationList8.transform);
                }
                else if (workbookSetting.lineSet_num == 9)
                {
                    item.transform.SetParent(animationList9.transform);
                }
                //item.transform.SetParent(animationList1.transform);
                item.transform.position = position;
                item.AddComponent<Spawn>();
                break;
        }
    }
}
