using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class NunScript : MonoBehaviour
{
    public Vector3 UpAndDown, storedForce, newForce, prevMovement, speed;
    public GameObject text2, timer, camero;
    public Text timerText, midText;
    public float timerValue, timer2, addBy, chargeTimer, maxSpeed, timerShow, intimer, upplim, lowlim;
    public bool gameStart, gameover, charge, levelFin;
    public int numWin, numNeed;
    public GameObject hell;
    public AudioClip super, boost, hit;

    public bool gameEnd;
    void Start()
    {
        gameStart = false;
        gameover = false;
        charge = false;
        timerShow = 30;
        numNeed = 3;
        levelFin = false;
        gameEnd = false;
    }

    
    void Update()
    {
        if (gameEnd == false)
        {
            if (timerValue <= 0 && gameover == false)
            {
                Debug.Log("Time over");
                gameover = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !charge && !gameStart)
            {
                text2.SetActive(false);
                GetComponent<AudioSource>().PlayOneShot(super, 0.5f);
                timer2 = 3;
                charge = true;
            }
            if (timer2 > 0)
            {
                timer2 -= Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.D))
                {
                    storedForce.x += 0.005f;
                }
            }
            if (timer2 <= 0 && charge == true)
            {
                Debug.Log(storedForce);
                speed = storedForce;
                GetComponent<AudioSource>().PlayOneShot(boost, 0.5f);
                gameStart = true;
                charge = false;
            }
            if (gameStart == true)
            {
                timerValue += Time.deltaTime;
                if (timerValue >= 1)
                {
                    timerValue--;
                    timerShow--;
                }
                timerText.text = timerShow.ToString();
                transform.Translate(200f * Time.deltaTime * speed);
                newForce = speed;
                newForce.x *= 0.95f;
                hell.transform.Translate(200f * Time.deltaTime * newForce);
                if (speed.x != maxSpeed)
                {
                    speed += new Vector3((maxSpeed - speed.x) / 200, 0);
                }
                if (intimer > 0)
                {
                    intimer -= Time.deltaTime;
                }
                else
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        if (GetComponent<Transform>().position.y <= upplim)
                        {
                            GetComponent<Transform>().position += UpAndDown;
                            transform.position += new Vector3(0, 0, 1);
                            camero.GetComponent<Transform>().position -= UpAndDown;
                            intimer = 0.1f;
                        }
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        if (GetComponent<Transform>().position.y >= lowlim)
                        {
                            GetComponent<Transform>().position -= UpAndDown;
                            transform.position -= new Vector3(0, 0, 1);
                            camero.GetComponent<Transform>().position += UpAndDown;
                            intimer = 0.1f;
                        }
                    }
                }
                if (timerShow <= 0 || numWin == numNeed)
                {
                    gameEnd = true;
                    gameStart = false;
                    text2.SetActive(true);
                    midText.text = "Press Space to Restart";
                }
            }
        }
        if (levelFin && gameEnd)
        {
            text2.SetActive(true);
            midText.text = "You Win! Press Space to Retry!";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "endOfLevel1")
        {
            Debug.Log("You've won!");
            storedForce.x = 0;
            newForce.x = 0;
            levelFin = true;
            gameEnd = true;
        }
        else if (collision.gameObject.tag == "Cross")
        {
            speed.x += 0.03f;
            maxSpeed += 0.01f;
            GetComponent<AudioSource>().PlayOneShot(boost, 0.5f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag != "Nun")
        {
            speed.x = 0;
            maxSpeed = 0.03f;
            GetComponent<AudioSource>().PlayOneShot(hit, 0.5f);
        }
    }
}
