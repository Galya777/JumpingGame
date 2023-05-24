using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private Vector3 startPos;
    private GameObject[] brokenPlatforms, keys, enemies, powerUps;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        brokenPlatforms = GameObject.FindGameObjectsWithTag("PlatformBroken");
        keys = GameObject.FindGameObjectsWithTag("Key");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("BottomEnd"))
        {
            setGameActive();
            print("Well, you died. Better luck next time :P");
            transform.position = startPos;
        }
    }

    private void setGameActive()
    {
        for(int i = 0; i < brokenPlatforms.Length; i++)
        {
            brokenPlatforms[i].SetActive(true);
        }

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(true);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
        }

        for (int i = 0; i < powerUps.Length; i++)
        {
            powerUps[i].SetActive(true);
        }

        gameObject.GetComponent<Health>().setHealth(3);
        gameObject.GetComponent<KeyCollect>().setCollectedKeys(0);
    }
}
