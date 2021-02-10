using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class TextReader : MonoBehaviour
{
    public Text texts;
    List<string> list = new List<string>();
    public int count;
    public AudioSource audioSource;
    public GameObject NButton;
    public GameObject LButton;
    string path = @"C:\Users\hirob\The game\Assets\Txt\Script.txt";
    string[] textValue = System.IO.File.ReadAllLines(path: @"C:\Users\hirob\The game\Assets\Txt\Script.txt");

    private void Awake()
    {
        NextScene();
    }
    

    private void Start()
    {
        count = 0;
        if (textValue.Length > 0)
        {
            list.Add(textValue[count]);
        }
        audioSource = GetComponent<AudioSource>();
    }
    

    public void Next()
    {
        count++;
        

    }

    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Update()
    {
        texts.text = list[count];
        audioSource.Play();
    }
    
}
