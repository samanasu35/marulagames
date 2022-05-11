using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelMenu : menu
{

    float kazanilan = 10,toplam;

    public TextMeshProUGUI txtKazanilan,txtToplam,txtCurLevel;

    // Start is called before the first frame update
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("level")) PlayerPrefs.SetInt("level",1);
        if (!PlayerPrefs.HasKey("coin")) PlayerPrefs.SetFloat("coin",0);
        level =PlayerPrefs.GetInt("level");
        coin = PlayerPrefs.GetFloat("coin");
        txtLvl.text = "Level " + level;
        txtCurLevel.text = "Level: " + level;
        txtCoin.text = "Coin: " + coin;
        txtKazanilan.text = "Kazanılan Coin: " + kazanilan;
        toplam = coin;
        txtToplam.text = "Toplam Coin: " + toplam;
        Debug.Log("start toplam:" + toplam);
    }

    public void earnCoin(float coin)
    {
        kazanilan += coin;
        if (kazanilan<0) kazanilan = 0;
        txtKazanilan.text = "Kazanılan Coin: " + kazanilan;
        Debug.Log("K:" + kazanilan);

    }

    public void finis()
    {
        toplam += kazanilan;
        txtToplam.text = "Toplam Coin: " + toplam;
        Debug.Log("K:" + kazanilan + ",T:" + toplam);
        PlayerPrefs.SetInt("level", level + 1);
        PlayerPrefs.SetFloat("coin",toplam);
    }
}
