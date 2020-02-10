using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject block;
    public Vector3 maxSize = Vector3.one*5.0f;
    public Vector3 minSize = Vector3.one;

    public float spawnTime = 1.0f;
    private float spawnTimeCounter = 1.0f;
    public float maxBlockSpeed = 1000.0f;
    private BoxCollider box;
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 9, true);
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimeCounter <= 0.0f) spawnBlock();
        spawnTimeCounter -= Time.deltaTime;
    }

    void spawnBlock() {

        Vector3 spawnPosition = new Vector3(
        Random.Range(box.bounds.min.x, box.bounds.max.x),
        Random.Range(box.bounds.min.y, box.bounds.max.y),
        Random.Range(box.bounds.min.z, box.bounds.max.z));

        GameObject blockInstance = Instantiate(block, spawnPosition, Quaternion.identity);
        blockInstance.GetComponent<Transform>().localScale = new Vector3(Random.Range(minSize.x, maxSize.x),Random.Range(minSize.y, maxSize.y),Random.Range(minSize.z, maxSize.z));
        // blockInstance.GetComponent<Rigidbody>().AddForce(-transform.forward * Random.Range(maxBlockSpeed/3, maxBlockSpeed), ForceMode.Force);
        blockInstance.GetComponent<Rigidbody>().AddForce(-transform.forward * maxBlockSpeed, ForceMode.Force);

        spawnTimeCounter = spawnTime;
    }
}