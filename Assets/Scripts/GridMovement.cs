using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridMovement : MonoBehaviour
{
    
    public AudioSource audioSource;
    public GameObject Particle;
    
    public Rigidbody rb;
    KeyChecker keyChecker;
    
    Vector3 position;
    public int tileCount = 0;
    public bool teleportTile;
    Tiles tiles;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        keyChecker = FindObjectOfType<KeyChecker>();
        tiles = FindObjectOfType<Tiles>();
       
       
    }

    public void UpButton()
    {
        if (keyChecker.isL2KeyRequired == true)
        {
            position = this.transform.position;
        }
        else

        {
            position = this.transform.position;
            position.z += 1.05f;
            this.transform.position = position;
            audioSource.Play();
            Instantiate(Particle, transform.position, Particle.transform.rotation);
        }
    }
    public void DownButton()
    {
        {
            position = this.transform.position;
            position.z -= 1.05f;
            this.transform.position = position;
            audioSource.Play();
            Instantiate(Particle, transform.position, Particle.transform.rotation);
        }
    }
    public void RightButton()
    {
        if (keyChecker.isKeyRequired == true)
        {
            position = this.transform.position;

        }
        else
        {
            position = this.transform.position;
            position.x += 1.05f;
            this.transform.position = position;
            audioSource.Play();
            Instantiate(Particle, transform.position, Particle.transform.rotation);

        }
    }
    public void LeftButton()
    {
        {
            position = this.transform.position;
            position.x -= 1.05f;
            this.transform.position = position;
            audioSource.Play();
            Instantiate(Particle, transform.position, Particle.transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
     /*   if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
       
        {
                position = this.transform.position;
                position.x -= 1.05f;
                this.transform.position = position;
            audioSource.Play();
            Instantiate(Particle, transform.position, Particle.transform.rotation);
            
        }
         if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
       
        {
          if (keyChecker.isKeyRequired == true)
            {
                position = this.transform.position;
              
            }
            else
            {
                position = this.transform.position;
                position.x += 1.05f;
                this.transform.position = position;
                audioSource.Play();
                Instantiate(Particle, transform.position, Particle.transform.rotation);

            }
            
        }
          if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
       
        {
            if (keyChecker.isL2KeyRequired == true)
            {
                position = this.transform.position;
            }
            else

            {
                position = this.transform.position;
                position.z += 1.05f;
                this.transform.position = position;
                audioSource.Play();
                Instantiate(Particle, transform.position, Particle.transform.rotation);
            }
            
        }
         if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
       
        {
           
            {
                position = this.transform.position;
                position.z -= 1.05f;
                this.transform.position = position;
                audioSource.Play();
                Instantiate(Particle, transform.position, Particle.transform.rotation);
            }
            
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Teleport")
        {
            teleportTile = true; 
            this.gameObject.transform.position = new Vector3(2.05f, 0.65f, -3.15f);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Tile")
        {
            tileCount += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Destroy")
        {
            
            Debug.Log("Working");
            
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

    

}
