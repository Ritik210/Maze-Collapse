using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecker : MonoBehaviour
{
    public GameObject Playerkey;
    public GameObject PlayerKeyL2;
   
    public GameObject tileLock;
    public bool isKeyRequired;
    public bool isL2KeyRequired;
   
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Playerkey.active == false)
        {
            Debug.Log("Key Required");
            isKeyRequired = true;
        }
        
        if (other.gameObject.tag == "PlayerL2" && PlayerKeyL2.active == false)
        {
            Debug.Log("Keyl2 Required");
            isL2KeyRequired = true;
        }
        if (other.gameObject.tag == "Player" && Playerkey.active == true)
        {
            Debug.Log("Key Required");
            isKeyRequired = false;
            tileLock.SetActive(false);
            Playerkey.SetActive(false);
            //PlayerKeyL2.SetActive(false);

        }
        
        if (other.gameObject.tag == "PlayerL2" && PlayerKeyL2.active == true)
        {
            Debug.Log("Key Required");
            isL2KeyRequired = false;
            tileLock.SetActive(false);
            PlayerKeyL2.SetActive(false);
            //PlayerKeyL2.SetActive(false);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && Playerkey.active == false)
        {
            Debug.Log("Key Required");
            isKeyRequired = false;
        }
       
        if (other.gameObject.tag == "PlayerL2" && PlayerKeyL2.active == false)
        {
            Debug.Log("Key Required");
            isL2KeyRequired = false;
        }
      
    }
}
