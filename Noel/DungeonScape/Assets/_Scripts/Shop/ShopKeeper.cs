using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour {
    //Variaveis uteis
    public GameObject _shopPanel;
    public int currentItemCost;
    public int currentSelectedItem;

    private Player _player;

    // Use this for initialization
    void Start () {
       
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.tag == "Player")
            {
                _player = other.GetComponent<Player>();
                if (_player != null)
                {
                    UIManager.Instance.UpdateShop(_player._diamonds);
                    _shopPanel.SetActive(true);
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.tag == "Player")
            {
                _shopPanel.SetActive(false);
            }
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0: //flame
                UIManager.Instance.UpdateShopSelection(102);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1: //boots
                UIManager.Instance.UpdateShopSelection(-2);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2: //key
                UIManager.Instance.UpdateShopSelection(-102);
                currentSelectedItem = 2;
                currentItemCost = 1000;
                break;
        }    
    }

    public void BuyItem()
    {
        
        if (_player._diamonds >= currentItemCost)
        {
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasTheKey = true;
            }
            Debug.Log("Purchased: " + currentSelectedItem);
            _player._diamonds -= currentItemCost;
            UIManager.Instance.UpdateShop(_player._diamonds);
        } 
      else
        {
            Debug.Log("Not enough money");
            _shopPanel.SetActive(false);
        }
    }
    //
}
