using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameObject.layer = Physics.AllLayers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player") {
            Debug.Log("The Game Has Been Lost!");
            gameManager.resetGame();
        } else if(collider.tag == "block") {
            gameManager.addPoint();
            Destroy(collider.gameObject);
        }
    }
}
