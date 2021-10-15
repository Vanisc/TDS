using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // кол-во жизней игрока (публичное целочисленное свойство, равно 5)
    public int lives = 5;

    // скорость игрока (публичное вещественное свойство , равно 3)
    public float speed = 15;

    // компонент отвечающий за физику игрока (публичное свойство типа Rigidbody2D, значение устанавливается перетаскиванием в unity)
    public Rigidbody2D rb;

    // компонент отвечающий за камеру игрока (публичное свойство типа Camera, значение устанавливается перетаскиванием в unity)
    public Camera cam;

    // структура отвечающая за перемещения игрока (публичное свойство типа Vector2, значение устанавливается перетаскиванием в unity)
    public Vector2 movement;

    //свойcтво отвечающее за переключение следующего уровня
    public int nextLevel;

    //структура отвечающая за позицию мыши
    Vector2 _mousePos;

    //работает только на первом кадре
    void Start()
    {
    }

    //работает каждый кадр
    void Update()
    {
        if (lives <= 0)
        {
            Time.timeScale = 0;
        }
        
        // movement.x = Input.GetAxisRaw("Horizontal"); // !
        // movement.y = Input.GetAxisRaw("Vertical"); 

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
        }


        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = _mousePos - rb.position;
        rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;    
    }

    // обновление которое активируется при любом взаимодействии 2х физ. объектов - зависит не от кадров, а от физики 
    void FixedUpdate()
    {
        
    }

    // метод который вызывается при столкновении нашего игрока с любым другим физ. объектом(стена, пуля, финиш)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene(nextLevel++);
        }
    }
}