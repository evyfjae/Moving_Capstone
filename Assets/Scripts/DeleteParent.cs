using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParent : MonoBehaviour
{
    public WorkbookSetting workbookSetting;
    public void destroyParent()
    {
        workbookSetting.lineSet_num--;
        Destroy(transform.parent.gameObject);
    }
}
