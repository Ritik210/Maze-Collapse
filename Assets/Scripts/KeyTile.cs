using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTile : MonoBehaviour
{
    public GameObject playerKey;
   // public GameObject playerKeyL2;
    public GameObject tileKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2")
        {
            tileKey.SetActive(false);
            playerKey.SetActive(true);
          //  playerKeyL2.SetActive(true);
            
        }
    }
}
