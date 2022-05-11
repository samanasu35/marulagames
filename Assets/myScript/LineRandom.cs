using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineRandom : MonoBehaviour
{

    public GameObject[] barrels = new GameObject[3];
    public Transform[] transforms = new Transform[3];

    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        barrels.Shuffle();
        barrels[0].transform.position = transforms[0].transform.position;
        barrels[1].transform.position = transforms[1].transform.position;
        barrels[2].transform.position = transforms[2].transform.position;
    }

}

public static class shuffle
{
    private static System.Random rng = new System.Random();  
    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}
