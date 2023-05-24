using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] keysToFill;

    [SerializeField]
    private Sprite emptyKey;

    [SerializeField]
    private Sprite fullKey;

    public AudioSource keySound;

    private int collectedKeys = 0;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Component comp = gameObject.GetComponent<DecreaseHealth>()
        for (int i = 0; i < keysToFill.Length; i++)
        {
            spriteR = keysToFill[i].GetComponent<SpriteRenderer>();
            if (i < collectedKeys)
            {
                spriteR.sprite = fullKey;
            }
            else
            {
                spriteR.sprite = emptyKey;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            keySound.Play();
            other.gameObject.SetActive(false);
            collectedKeys++;
        }
    }

    private void visualizeAllKeys()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
        Debug.Log(keys.Length);
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(true);
        }
    }

    public void setCollectedKeys(int _collectedKeys)
    {
        collectedKeys = _collectedKeys;
    }
}
