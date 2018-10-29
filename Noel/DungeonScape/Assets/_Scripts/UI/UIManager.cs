using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    //Variaveis Uties
    
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is null");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImage;
    public Text GemCountText;
    public Image[] healthBars;

    //Metodos    

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + " G";
    }

    public void UpdateGemCount(int count)
    {
        GemCountText.text = "" + count;

    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }
    

    
    //
}
