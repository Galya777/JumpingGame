using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    bool poweredUp;
    // Start is called before the first frame update
    void Start()
    {
        poweredUp = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            poweredUp = true;
            setColorPoweredUp(poweredUp);
            StartCoroutine(setPoweredUpInactive());
        }
    }

    IEnumerator setPoweredUpInactive()
    {
        yield return new WaitForSeconds(7);
        poweredUp = false;
        setColorPoweredUp(poweredUp);
    }

    private void setColorPoweredUp(bool poweredUp)
    {
        if (poweredUp) gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        else gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    public bool isPoweredUp()
    {
        return poweredUp;
    }
}
