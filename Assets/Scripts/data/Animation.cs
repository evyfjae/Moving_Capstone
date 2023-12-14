using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public int kind;
    public string name;
    //public int action;
    public float time;

    public void action()
    {
        if(kind == 0)
        {
            appear();
        }
    }

    public void appear()
    {

    }
}
