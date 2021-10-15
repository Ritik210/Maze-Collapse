using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleThunderTile : MonoBehaviour
{
    public int count = 0;
    public bool isDouble = false;
    public bool isSingle = false;
    public Rigidbody rb;
    public GameObject singleThunderImage;
    public GameObject doubleThunderImage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 6)
        {
            Debug.Log("Gravity ON");
            this.rb.isKinematic = false;
            this.rb.useGravity = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2")
        {
            count = 1;
            //singleThunderImage.SetActive(false);
        }
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && isDouble == true)
        {
            count = 3;
            // isFalse = false;
        }
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && isSingle == true )
        {
            count = 5;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && isDouble == false)
        {
            count = 2;
            doubleThunderImage.SetActive(false);
            singleThunderImage.SetActive(true);
            isDouble = true;
        }
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && count == 3)
        {
            count = 4;
            singleThunderImage.SetActive(false);
            isSingle = true;
        }
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && count == 5)
        {
            count = 6;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }
}
