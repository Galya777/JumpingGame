using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Vector3 pos;
    public float jump = 3f, move = 0.1f;
    void FixedUpdate()
    {
        handleMovement();
    }

    
    void handleMovement()
    {
        if (canJump() == true && (Input.GetAxis("Vertical") > 0))
        {
            jumpSound.Play();
            Vector2 rigidBodyVelocity = rigidBody.velocity;
            rigidBodyVelocity.y = jump;
            rigidBody.velocity = rigidBodyVelocity;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Vector2 rigidBodyVelocity = rigidBody.velocity;
            rigidBodyVelocity.x = -move;
            rigidBody.velocity = rigidBodyVelocity;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Vector2 rigidBodyVelocity = rigidBody.velocity;
            rigidBodyVelocity.x = move;
            rigidBody.velocity = rigidBodyVelocity;
        }
    }

    bool canJump()
    {
        Vector3 boxOfPlayer = transform.position;
        boxOfPlayer.y -= 1;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(boxOfPlayer, 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("PlatformLarge")) return true;
            if (colliders[i].gameObject.CompareTag("PlatformMoving"))
            {
                return true;
            }
            if (colliders[i].gameObject.CompareTag("PlatformBroken"))
            {
                GameObject platform = colliders[i].gameObject;
                StartCoroutine(destroyPlatform(platform));
                return true;
            }
        }
        return false;
    }

    IEnumerator destroyPlatform(GameObject platform)
    {
        yield return new WaitForSeconds(1);
        platform.SetActive(false);
    }
}
