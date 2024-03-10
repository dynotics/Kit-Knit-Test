using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    public string sceneName;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<NunScript>().levelFin == true && player.GetComponent<NunScript>().gameStart == true && sceneName == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<NunScript>().levelFin == true && player.GetComponent<NunScript>().gameStart == true && sceneName == "Level2")
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<NunScript>().gameEnd == true && player.GetComponent<NunScript>().gameStart == false)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
