using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goforward : MonoBehaviour
{

    public int tall = 4; 
    public float speed = 3.0f, yon = 90f;
    public GameObject barrel;
    public GameObject goddes;
    public GameObject retry,ingame,contineu,skill;

    private bool finish=false;
    private float speedUpTime = 5f;
    public GameObject hitEffect,hitEffect2,finishEffect;

    public levelMenu lvlMenu;

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

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yon, 0), Time.deltaTime * speed);
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
            SpawnEffect(hitEffect);
            lvlMenu.earnCoin(-2.5f);
        }
        if (other.tag.Equals("large"))
        {
            goddes.transform.localPosition += new Vector3(0,-0.4f,0);
            barrel.transform.localScale += new Vector3(0,-0.4f,0);
            tall-=2;
            Destroy(other.transform.parent.gameObject);
            SpawnEffect(hitEffect);
            lvlMenu.earnCoin(-5f);
        }
        if (other.tag.Equals("add"))
        {
            goddes.transform.localPosition += new Vector3(0,0.2f,0);
            barrel.transform.localScale += new Vector3(0,0.2f,0);
            tall++;
            Destroy(other.transform.parent.gameObject);
            SpawnEffect(hitEffect2);
            lvlMenu.earnCoin(2.5f);
        }
        
        if (other.tag.Equals("turnLeft"))
        {
            Destroy(other);
            yon-=90;
        }
        if (other.tag.Equals("turnRight"))
        {
            Destroy(other);
            yon+=90;
        }
        if (other.tag.Equals("Finish"))
        {
            finish = true;
            Animation animation = goddes.GetComponent<Animation>();
            animation.Play("spin");
            contineu.SetActive(true);
            ingame.SetActive(false);
            SpawnEffect(finishEffect);
            lvlMenu.finis();
        }
        if (tall <= 0)
        {
            retry.SetActive(true);
            ingame.SetActive(false);
            Animation animation = goddes.GetComponent<Animation>();
            animation.Play("pray");
        }
    }

    private void SpawnEffect(GameObject effect)
    {
        effect.SetActive(true);
    }

    public void changeScene(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void speedUp()
    {
        speed = 6f;
        StartCoroutine(StartCountdown());
        skill.SetActive(false);
    }

    public IEnumerator StartCountdown(float countdownValue = 5f)
    {
        yield return new WaitForSeconds(countdownValue);
        speed = 3f;
    }
}
