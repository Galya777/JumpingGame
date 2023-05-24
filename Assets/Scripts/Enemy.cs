using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private float move = 1f;
    private bool canMoveLeft = true, canMoveRight = true;


    // Update is called once per frame
    void Update()
    {
        if (FindTarget())
        {
            moveEnemy();
        }
    }

    private bool FindTarget()
    {
        float targetRange = 7f;
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < targetRange)
        {
            return true;
        }
        return false;
    }

    private void moveEnemy()
    {
        if (transform.position.x - GameObject.Find("Player").transform.position.x > 0 && canMoveLeft && !checkRotated())
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Vector2 rigidBodyVelocity = rigidBody.velocity;
            rigidBodyVelocity.x = -move;
            rigidBody.velocity = rigidBodyVelocity;
        } else if (transform.position.x - GameObject.Find("Player").transform.position.x < 0 && canMoveRight && !checkRotated())
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Vector2 rigidBodyVelocity = rigidBody.velocity;
            rigidBodyVelocity.x = move;
            rigidBody.velocity = rigidBodyVelocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("triggerEnemyLeft"))
        {
            canMoveLeft = false;
        }
        if (other.CompareTag("triggerEnemyRight"))
        {
            canMoveRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("triggerEnemyLeft"))
        {
            canMoveLeft = true;
        }
        if (other.CompareTag("triggerEnemyRight"))
        {
            canMoveRight = true;
        }
    }

    private bool checkRotated()
    {
        if (transform.rotation.z > 0.02f || transform.rotation.z < -0.02f) return true;
        return false;
    }
}
