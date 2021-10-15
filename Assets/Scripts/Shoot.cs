
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public Transform spawn;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }

    void Fire()
    {
        GameObject bull=Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        Rigidbody2D rb = bull.GetComponent<Rigidbody2D>();
        rb.AddForce(speed*transform.up);
    } 
}   
