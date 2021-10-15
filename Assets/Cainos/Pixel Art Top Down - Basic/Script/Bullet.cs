using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Walls")
        {
            GameObject exp = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(exp, 2);
            Destroy(gameObject);
        }
    } 

}
