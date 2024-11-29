using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Button WinButton;
    
    public int MaxItems = 4;
    
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    private int itemsCollected=0;
 private int playerHP=10;

 public int Items
 {
 
 get{return itemsCollected;}

set
{
    itemsCollected = value;
            ItemText.text = "Items Collected:" + Items;
            
            if (itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - itemsCollected)
                + " more!";
                Debug.LogFormat("Items:{0}", itemsCollected);
            }
}
 }
 
 public int HP
{
    get{ return playerHP; }
    set{
        playerHP = value;
            
            HealthText.text = "PlayerHealth:" + HP;
            Debug.LogFormat("Lives:{0}", playerHP);
          
    }
}
    private void Start()
    {
        ItemText.text += itemsCollected;
        HealthText.text += playerHP;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
