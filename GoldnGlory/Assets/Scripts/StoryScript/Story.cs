using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public Scenes root;
    public Scenes active;
    public Datas dialogActive;

    public GameObject comingSoon;

    public static Story instance;
    
    private void Start()
    {
        active = root;
        instance = this;
        dialogActive = root.head;
    }

    public void NextDialog(Text teksStory, int choice)
    {
        if (dialogActive.pointer[choice])
        {
            dialogActive = dialogActive.pointer[choice];
            teksStory.text = dialogActive.dialog;
            if (dialogActive.scene) active = dialogActive.scene;
        }
        else
        {
            GameVariables.comingSoon = true;
            comingSoon.SetActive(true);
        }
    }
}
