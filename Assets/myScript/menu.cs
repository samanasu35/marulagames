using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class menu : MonoBehaviour
{
    
    public int level;
    public float coin;
    public TextMeshProUGUI txtLvl,txtCoin;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("level")) PlayerPrefs.SetInt("level",1);
        if (!PlayerPrefs.HasKey("coin")) PlayerPrefs.SetFloat("coin",0);
        level =PlayerPrefs.GetInt("level");
        coin = PlayerPrefs.GetFloat("coin");
        txtLvl.text = "Level " + level;
        txtCoin.text = "Coin: " + coin;
    }
    
    public void startNextLvl()
    {
        int trueLevel = level % 2 == 0 ? 2 : 1;
        Debug.Log("level" + trueLevel);
        SceneManager.LoadScene("level" + trueLevel);
    }
}
