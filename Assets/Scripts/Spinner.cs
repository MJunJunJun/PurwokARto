using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float spinSpeed = 700;
    public bool doSpin = false;

    private Rigidbody rb;

    public GameObject playerGraphics;

    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = 700;
    }

    private void FixedUpdate()
    {
        if (doSpin)
        {
            playerGraphics.transform.Rotate(new Vector3(0, 700 * Time.deltaTime, 0));
        }
    }


}
