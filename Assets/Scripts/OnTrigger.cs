using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject[] gameObjects;
    DeadPhysics dp;
    Player player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DeadPhysics dp = GetComponent<DeadPhysics>();
        Player player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Mayın")
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (i == 2)
                {
                    gameObjects[2].SetActive(false); //First Main Music
                }
                else
                {
                    gameObjects[0].SetActive(true);
                }
            }
        }

        if (other.transform.name == "FireAmbarMusic")
        {
            gameObjects[1].SetActive(true);
        }

        if(other.transform.name == "HazırPatlama")
        {
            for (int i = 3; i < 7; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
}
