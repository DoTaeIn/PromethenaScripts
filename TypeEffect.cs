using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public string targetMsg;
    int index;
    public GameObject EndCursor;
    public int CharPerSec;
    Text msgText;

    public void Awake()
    {
        msgText = GetComponent<Text>();
    }
    

    public void SerMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);
        Invoke("Effecting", 1/CharPerSec);
    }
    
    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        index++;
            
        Invoke("Effecting", 1/CharPerSec);
    }
    
    void EffectEnd()
    {
        EndCursor.SetActive(true);
    }

}
