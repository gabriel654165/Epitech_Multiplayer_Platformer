using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGun : MonoBehaviour
{
    private float time;
    public GameObject bullet;
    private Color cRed;
    private Color cGreen;
    private bool fire;
    public SpriteRenderer renderer;

    void Start() {
        fire = false;
        time = 0;
        cRed = Color.red;
        cGreen = Color.green;
    }

    private void landBullet() {
        int i = Random.Range(0, 2);
        GameObject temp;
        if (!renderer.flipX) {
            temp = Instantiate(bullet, transform.Find("spawnBullet").transform.position, transform.Find("spawnBullet").transform.rotation, transform);
            temp.GetComponent<bulletScript>().init(0);
        if (i == 0)
            temp.GetComponent<bulletScript>().setColor(cRed);
        if (i == 1)
            temp.GetComponent<bulletScript>().setColor(cGreen);
        }
        if (renderer.flipX) {
            temp = Instantiate(bullet, transform.Find("spawnBullet2").transform.position, transform.Find("spawnBullet").transform.rotation, transform);
            temp.GetComponent<bulletScript>().init(1);
        if (i == 0)
            temp.GetComponent<bulletScript>().setColor(cRed);
        if (i == 1)
            temp.GetComponent<bulletScript>().setColor(cGreen);
        }
    }

    private void firebull() {
        time += Time.deltaTime;
        if (time >= 0.5) {
            time = 0;
            landBullet();
        }
    }

    void Update() {
        if (gameObject.layer == 8 && Input.GetKeyDown(KeyCode.M)) {
            time = 0.5f;
            fire = true;
        }
        else if (gameObject.layer == 9 && Input.GetKeyDown(KeyCode.S)) {
            time = 0.5f;
            fire = true;
        } else
            fire = false;
        if (fire)
            firebull();
    }
}
