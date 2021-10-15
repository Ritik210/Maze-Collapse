using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleThunderTIle : MonoBehaviour
{
    public int count = 0;
    public bool isFalse = false;
    public Rigidbody rb;
    public GameObject singleThunderImage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 4)
        {
            Debug.Log("Gravity ON");
            this.rb.isKinematic = false;
            this.rb.useGravity = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"|| other.gameObject.tag == "PlayerL2")
        {
            count = 1;
            //singleThunderImage.SetActive(false);
        }
       if((other.gameObject.tag == "Player"|| other.gameObject.tag == "PlayerL2") && isFalse == true)
        {
            count = 3;
           // isFalse = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && isFalse == false)
        {
            count = 2;
            singleThunderImage.SetActive(false);
            isFalse = true;
        }
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerL2") && count == 3)
        {
            count = 4;
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
