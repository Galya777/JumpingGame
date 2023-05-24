using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMovement : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("horizontalRight", Input.GetAxis("Horizontal"));
        anim.SetFloat("horizontalLeft", Input.GetAxis("Horizontal"));
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
    }
}
