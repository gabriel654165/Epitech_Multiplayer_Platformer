using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class godPlayerRules : MonoBehaviour
{
    [Header("Interfaces")]
    public Text speedText;
    public bool speed = false;
    private int lectureSpeed = 0;
    //private string[] speedPlatformtext = { "Speed [R]", "" };

    public Text freezeText;
    public bool freeze = false;
    private int lectureFreeze = 0;
    //private string[] freezePlayertext = { "Freeze [CLick]", "" };

    public Text invertText;
    public bool invert = false;
    private int lectureInvert = 0;
    //private string[] invertPlayertext = { "Invert [Z]", "" };

    public Text playerText;
    private string[] playertext = { "God Mode" };

    [Header("Timer")]
    public float timeActionSpeed = 4f;
    public float timeActionFreeze = 4f;
    public float timeActionInvert = 4f;

    [Header("Progress Bar")]
    public GameObject ScrollbarFreeze;
    public GameObject ScrollbarSpeed;
    public GameObject ScrollbarInvert;
    public bool colldownFreeze = false;
    public Slider sliderFreeze;
    public bool colldownSpeed = false;
    public Slider sliderSpeed;
    public bool colldownInvert = false;
    public Slider sliderInvert;
    private float progressFreeze = 0f;
    private float progressSpeed = 0f;
    private float progressInvert = 0f;

    [Header("Components")]
    public platformMoving platform;
    public player player;


    void Start() 
    {

    }

    void clickOnPlayer() {
        if (Input.GetMouseButtonDown(0) && !colldownFreeze) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.transform.root.tag == "Player") {
                freeze = true;
                hit.collider.transform.root.GetComponent<isFreeze>().freeze = true;
            }
        }
    }

    void Update()
    {
        clickOnPlayer();
        /* Time Remaining */
        if (speed)
            timeActionSpeed -= Time.deltaTime;
        if (freeze)
            timeActionFreeze -= Time.deltaTime;
        if (invert)
            timeActionInvert -= Time.deltaTime;

        /* Interface Booleans Controls */
        CoolDownsEffect();

        platformMovingFast();
        freezePlayer();
        invertDirections();

        /* Display Text */
        //playerText.text = playertext[0];
        //speedText.text = speedPlatformtext[lectureSpeed];
        //freezeText.text = freezePlayertext[lectureFreeze];
        //invertText.text = invertPlayertext[lectureInvert];
        
        /* ACTIONS */
        if (Input.GetKeyDown(KeyCode.R) && !colldownSpeed) {
            speed = true;
            platform.velocity = new Vector3(20, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Z) && !colldownInvert) {
            invert = true;
        }
    }

    void FixedUpdate()
    {
        
    }

     void platformMovingFast() 
     {
         if (speed == true && timeActionSpeed <= 0) {
            speed = false;
            colldownSpeed = true;
         }
        if (!speed) {
            platform.velocity = new Vector3(3, 0, 0);
            timeActionSpeed = 4f;
            lectureSpeed = 0;
        } else if (speed){
            lectureSpeed = 1;
        }
     }

    void freezePlayer()
    {
        if (freeze == true && timeActionFreeze <= 0) {
            freeze = false;
            colldownFreeze = true;
        }
        if (!freeze) {
            timeActionFreeze = 4f;
            lectureFreeze = 0;
        } else if (freeze){
            lectureFreeze = 1;
        }
    }

    void invertDirections()
    {
        if (invert == true && timeActionInvert <= 0) {
            invert = false;
            colldownInvert = true;
        }
        if (!invert) {
            timeActionInvert = 4f;
            lectureInvert = 0;
        } else if (invert){
            lectureInvert = 1;
        }
    }

    void CoolDownsEffect() 
    {
        if (colldownFreeze) {
            progressFreeze += Time.deltaTime;
            ScrollbarFreeze.SetActive(true);
            sliderFreeze.value = Mathf.Clamp01(progressFreeze / 10f);
        }
        if (progressFreeze >= 10) {
            ScrollbarFreeze.SetActive(false);
            progressFreeze = 0f;
            colldownFreeze = false;
            //freeze = false;
        }
        
        if (colldownSpeed) {
            progressSpeed += Time.deltaTime;
            ScrollbarSpeed.SetActive(true);
            sliderSpeed.value = Mathf.Clamp01(progressSpeed / 10f);
        }
        if (progressSpeed >= 10) {
            ScrollbarSpeed.SetActive(false);
            progressSpeed = 0f;
            colldownSpeed = false;
            //speed = false;
        }

        if (colldownInvert) {
            progressInvert += Time.deltaTime;
            ScrollbarInvert.SetActive(true);
            sliderInvert.value = Mathf.Clamp01(progressInvert / 10f);
        }
        if (progressInvert >= 10) {
            ScrollbarInvert.SetActive(false);
            progressInvert = 0f;
            colldownInvert = false;
            //invert = false;
        }
    }


    void dropMob() {}
}
