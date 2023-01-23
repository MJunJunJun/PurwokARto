using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameObject : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        ResetTEMPAT();
       // GameObject cek = GameObject.FindGameObjectsWithTag("Center");
       // target = cek.transform;
            
        //
        //Debug.Log(Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetTEMPAT()
    {
        //target.transform.rotation = Quaternion.identity;
        //target.transform.position = new Vector3(0, 0, 0);
        target.transform.rotation=Quaternion.identity;
        Debug.Log("Alhamdulillah");
    }
}
