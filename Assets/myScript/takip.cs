using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takip : MonoBehaviour
{
    public GameObject character;
    Vector3 dif;

    // Start is called before the first frame update
    void Start()
    {
        dif = transform.position - character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = character.transform.position + dif;
    }
}
