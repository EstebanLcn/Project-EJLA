﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public Image heart1,heart2,heart3;

    public Sprite heartFull, heartEmpty, halfHeart;
    public Text gemText;
     private void Awake() 
     {
        instance = this;
     }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGemsCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthDisplay()
    {
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 6 :
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartFull;
            break;

            case 5 :
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = halfHeart;
            break;

            case 4 :
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartEmpty;
            break;

            case 3:
            heart1.sprite = heartFull;
            heart2.sprite = halfHeart;
            heart3.sprite = heartEmpty;
            break;

            case 2:
             heart1.sprite = heartFull;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
            break;

            case 1:
             heart1.sprite = halfHeart;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
            break;

             case 0:
             heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
            break;
            
        }
    }
    public void UpdateGemsCount()
    {
        gemText.text = LevelManager.instance.GemsCollected.ToString();
    }
}
