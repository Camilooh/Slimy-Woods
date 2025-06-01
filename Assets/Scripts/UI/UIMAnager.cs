using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMAnager : MonoBehaviour
{
    public PlayerMovement player;
    public TMP_Text GemText;
    public TMP_Text PowerUpText;
    public int counter = 0;
    public int powerup = 0;
    public int playerHearts = 4;
    public Image Heart1,Heart2,Heart3,Heart4;
    //public bool life1, life2, life3, life4;
    // Start is called before the first frame update
    void Start()
    {
        Color tmp = Heart1.GetComponent<Image>().color;
        tmp.a = 1f;
        Heart1.GetComponent<Image>().color = tmp;
        Color tmp1 = Heart2.GetComponent<Image>().color;
        tmp1.a = 1f;
        Heart2.GetComponent<Image>().color = tmp1;
        Color tmp2 = Heart3.GetComponent<Image>().color;
        tmp2.a = 1f;
        Heart3.GetComponent<Image>().color = tmp2;
        Color tmp3 = Heart4.GetComponent<Image>().color;
        tmp3.a = 1f; 
        Heart4.GetComponent<Image>().color = tmp3;
        GemText.text = " ";
        PowerUpText.text = " ";

    }
    private void Update()
    {
        HeartsUpdater();
        GemText.text = " " + counter;
        PowerUpText.text = " " + powerup;
        
    }
    public void HeartsUpdater()
    {
        if (player.isDead)
        {
            Color tmp = Heart1.GetComponent<Image>().color;
            tmp.a = 0.5f;
            Heart1.GetComponent<Image>().color = tmp;
            Color tmp1 = Heart2.GetComponent<Image>().color;
            tmp1.a = 0.5f;
            Heart2.GetComponent<Image>().color = tmp1;
            Color tmp2 = Heart3.GetComponent<Image>().color;
            tmp2.a = 0.5f;
            Heart3.GetComponent<Image>().color = tmp2;
            Color tmp3 = Heart4.GetComponent<Image>().color;
            tmp3.a = 0.5f;
            Heart4.GetComponent<Image>().color = tmp3;

        }
        if (player.playerHearts == 4)
        {
            Color tmp = Heart1.GetComponent<Image>().color;
            tmp.a = 1f;
            Heart1.GetComponent<Image>().color = tmp;
            Color tmp1 = Heart2.GetComponent<Image>().color;
            tmp1.a = 1f;
            Heart2.GetComponent<Image>().color = tmp1;
            Color tmp2 = Heart3.GetComponent<Image>().color;
            tmp2.a = 1f;
            Heart3.GetComponent<Image>().color = tmp2;
            Color tmp3 = Heart4.GetComponent<Image>().color;
            tmp3.a = 1f;
            Heart4.GetComponent<Image>().color = tmp3;
        }
        if (player.playerHearts == 3)
        {
            Color tmp = Heart1.GetComponent<Image>().color;
            tmp.a = 1f;
            Heart1.GetComponent<Image>().color = tmp;
            Color tmp1 = Heart2.GetComponent<Image>().color;
            tmp1.a = 1f;
            Heart2.GetComponent<Image>().color = tmp1;
            Color tmp2 = Heart3.GetComponent<Image>().color;
            tmp2.a = 1f;
            Heart3.GetComponent<Image>().color = tmp2;
            Color tmp3 = Heart4.GetComponent<Image>().color;
            tmp3.a = 0.5f;
            Heart4.GetComponent<Image>().color = tmp3;
        }
        if (player.playerHearts == 2)
        {
            Color tmp = Heart1.GetComponent<Image>().color;
            tmp.a = 1f;
            Heart1.GetComponent<Image>().color = tmp;
            Color tmp1 = Heart2.GetComponent<Image>().color;
            tmp1.a = 1f;
            Heart2.GetComponent<Image>().color = tmp1;
            Color tmp2 = Heart3.GetComponent<Image>().color;
            tmp2.a = 0.5f;
            Heart3.GetComponent<Image>().color = tmp2;
            Color tmp3 = Heart4.GetComponent<Image>().color;
            tmp3.a = 0.5f;
            Heart4.GetComponent<Image>().color = tmp3;
        }
        if (player.playerHearts == 1)
        {
            Color tmp = Heart1.GetComponent<Image>().color;
            tmp.a = 1f;
            Heart1.GetComponent<Image>().color = tmp;
            Color tmp1 = Heart2.GetComponent<Image>().color;
            tmp1.a = 0.5f;
            Heart2.GetComponent<Image>().color = tmp1;
            Color tmp2 = Heart3.GetComponent<Image>().color;
            tmp2.a = 0.5f;
            Heart3.GetComponent<Image>().color = tmp2;
            Color tmp3 = Heart4.GetComponent<Image>().color;
            tmp3.a = 0.5f;
            Heart4.GetComponent<Image>().color = tmp3;
        }
    }
    public void AddCounter()
    {
        counter++;
    }
    public void AddPowerUps()
    {
        powerup++;
    }

}
