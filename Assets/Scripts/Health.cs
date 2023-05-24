using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hearts;

    [SerializeField]
    private Sprite emptyHeart;

    [SerializeField]
    private Sprite fullHeart;

    private int health = 3;
    private SpriteRenderer spriteR;

    public AudioSource killSound;
    private Vector3 startPos;

    private Vignette vg;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        PostProcessVolume volume = Camera.main.GetComponent<PostProcessVolume>();
        PostProcessProfile profile = volume.profile;
        profile.TryGetSettings(out vg);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            print("Well, you died. Better luck next time :P");
            transform.position = startPos;
            health = 3;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            spriteR = hearts[i].GetComponent<SpriteRenderer>();
            if (i < health)
            {
                spriteR.sprite = fullHeart;
            }
            else
            {
                spriteR.sprite = emptyHeart;
            }
        }

        putVignette();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (!gameObject.GetComponent<PowerUp>().isPoweredUp())
            {
                Camera.main.GetComponent<CameraShake>().ShakeCamera();
                health--;
            }
            else
            {
                killSound.Play();
                collision.gameObject.SetActive(false);
            }

        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void putVignette()
    {
        if (health == 1) vg.active = true;
        else vg.active = false;
    }

    public void setHealth(int _health)
    {
        health = _health;
    }
}
