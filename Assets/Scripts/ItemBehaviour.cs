using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    
    public GameBehavior GameManager;
   
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "Player")
        {
           
            Destroy(this.transform.gameObject);
           
            Debug.Log("Item collected!");
            
            GameManager.Items += 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
