using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 UpAndDown, storedForce, newForce, prevMovement, speed;
    public float timerValue, timer2, addBy, chargeTimer, maxSpeed;
    public bool gameStart, gameover, charge, levelFin, gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Nun");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<NunScript>().gameStart && !gameStart && !player.GetComponent<NunScript>().gameEnd)
        {
            transform.Translate(200f * Time.deltaTime * speed);
            if (speed.x != maxSpeed)
            {
                speed += new Vector3((maxSpeed - speed.x) / 200, 0);
            }
        }
        if (charge == true)
        {
            player.GetComponent<NunScript>().numWin++;
            charge = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "endOfLevel1")
        {
            storedForce.x = 0;
            gameStart = true;
            charge = true;
        }
    }
}
