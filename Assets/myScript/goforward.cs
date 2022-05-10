using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goforward : MonoBehaviour
{

    public int tall = 4; 
    public float speed = 3.0f;
    public GameObject barrel;
    public GameObject goddes;
    public GameObject retry,ingame,contineu;

    private bool finish=false;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-4.5f,1.39f,-0.65f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!finish && tall > 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("small"))
        {
            goddes.transform.localPosition += new Vector3(0,-0.2f,0);
            barrel.transform.localScale += new Vector3(0,-0.2f,0);
            tall--;
            Destroy(other.transform.parent.gameObject);
        }
        if (other.tag.Equals("large"))
        {
            goddes.transform.localPosition += new Vector3(0,-0.4f,0);
            barrel.transform.localScale += new Vector3(0,-0.4f,0);
            tall-=2;
            Destroy(other.transform.parent.gameObject);
        }
        if (other.tag.Equals("add"))
        {
            goddes.transform.localPosition += new Vector3(0,0.2f,0);
            barrel.transform.localScale += new Vector3(0,0.2f,0);
            tall++;
            Destroy(other.transform.parent.gameObject);
        }
        if (other.tag.Equals("Finish"))
        {
            finish = true;
            Animation animation = goddes.GetComponent<Animation>();
            animation.Play("spin");
            contineu.SetActive(true);
            ingame.SetActive(false);
        }
        if (tall <= 0)
        {
            retry.SetActive(true);
            ingame.SetActive(false);
            Animation animation = goddes.GetComponent<Animation>();
            animation.Play("pray");
        }
    }
}
