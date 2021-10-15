using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tiles : MonoBehaviour
{
    public int count = 0;
    public Rigidbody rb;
    GridMovement gridMovement;
    public BoxCollider boxCollider;
    public GameObject[] invisibleTiles;

    //public GameObject player;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent < Rigidbody>();
        gridMovement = FindObjectOfType<GridMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 2)
        {
            Debug.Log("Gravity ON");
            this.rb.isKinematic = false;
            this.rb.useGravity = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2")
        {
            count = 1;
            
            
           
        }
        if(this.gameObject.tag == "Win" && gridMovement.tileCount == 69)
        {
            Debug.Log("Win");
            SceneManager.LoadScene(0);

        }
        if (gridMovement.tileCount == 86 && this.gameObject.tag == "Win1")
        {
            Debug.Log("Win");
            SceneManager.LoadScene(0);
        }
        if (gridMovement.tileCount == 95 && this.gameObject.tag == "Win2")
        {
            Debug.Log("Win");
            SceneManager.LoadScene(0);
        }
        if (this.gameObject.tag == "ConnectTiles")
        {
            invisibleTiles[0].SetActive(true);
            invisibleTiles[1].SetActive(true);
            invisibleTiles[2].SetActive(true);
        }
        if(other.gameObject.tag == "Player" && this.gameObject.tag == "TeleportPlace")
        {
            if(gridMovement.teleportTile == false)
            {
                boxCollider.isTrigger = true;
            }

            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2")
        {
            count = 2;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }

}
