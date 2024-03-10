using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class gameManagerScript : MonoBehaviour
{
    public GameObject fire, player, cross;
    public float timer, rng;
    public Vector3[] position;
    public bool spawned, power;
    public int offset;
    public AudioClip hellmusic, heavmusic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<NunScript>().gameStart)
        {
            if (!spawned)
            {
                offset = 5;
                for (int f = 0; f < 35; f++)
                {
                    if (f % 2 == 1)
                    {
                        rng = Random.Range(1, position.Length + 1);
                        for (int i = 0; i < position.Length; i++)
                        {
                            position[i].x = player.transform.position.x + offset;
                            position[i].z = -i;
                            if (rng != (i + 1))
                            {
                                Instantiate(fire, position[i], Quaternion.identity);
                            }
                        }
                    }
                    else if (f % 2 == 0)
                    {
                        rng = Random.Range(1, position.Length + 1);
                        for (int i = 0; i < position.Length; i++)
                        {
                            position[i].x = player.transform.position.x + offset;
                            position[i].z = -i;
                            if (rng == (i + 1))
                            {
                                Instantiate(cross, position[i], Quaternion.identity);
                            }
                        }
                    }
                    offset += 10;
                }
                spawned = true;
            }
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                GetComponent<AudioSource>().PlayOneShot(hellmusic, 0.4f);
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                GetComponent<AudioSource>().PlayOneShot(heavmusic, 0.4f);
            }
        }
        if (player.GetComponent<NunScript>().gameEnd)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
