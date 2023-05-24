using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float range = 5.0f;
    private float current = 0.0f;
    private float step = 0.05f;
    private bool goUp;

    // Start is called before the first frame update
    void Start()
    {
        goUp = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (goUp && current < range)
        {
            current += step;
            transform.Translate(0, step, 0);
        }
        if (current >= range)
        {
            goUp = false;
            transform.Translate(0, -step, 0);
        }
        if (goUp == false && current > 0)
        {
            current -= step;
            transform.Translate(0, -step, 0);
        }
        if (current <= 0)
        {
            goUp = true;
            transform.Translate(0, step, 0);
        }

    }
}
