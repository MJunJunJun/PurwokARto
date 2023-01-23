using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVirtualAsisten : MonoBehaviour
{
    public Transform ARCamera;
    public Transform LookAtTarget;
    public float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(LookAtTarget);
    }
    public void SetLocation()
    {

        this.transform.position = new Vector3(ARCamera.position.x+x, ARCamera.position.y+y, (ARCamera.position.z+z));
        
    }
}
