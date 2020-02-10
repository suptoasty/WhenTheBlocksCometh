using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public float maxBlockSpeed = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(-transform.forward * maxBlockSpeed, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        // if(GetComponent<Rigidbody>().velocity.z <= 0)  GetComponent<Rigidbody>().AddForce(-transform.forward * maxBlockSpeed, ForceMode.Force);
    }
}
