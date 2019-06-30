using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject currentProjectille;

    public float shootDelay;

    public int moveSpeed;

    public Transform shootPostion; // пустой объект на дуле пушки

    private float shootDelayCounter;

    private Rigidbody2D myRigidbody;

    void Update ()
    {
        OnMouseOver ();
    }

    void OnMouseOver ()
    {
        shootDelayCounter += Time.deltaTime;

       // RotateToClick (); 

        if (Input.GetMouseButtonDown (0))
        {
            RotateToClick (); 

            if (shootDelayCounter >= shootDelay)
            {
                Instantiate (currentProjectille, shootPostion.position, shootPostion.rotation);
                shootDelayCounter = 0;
            }
        }
    }


    
    private Vector3 mousePosition;

    private float angle;

    void RotateToClick ()
    {
        float RotateSpeed = 100;
        //позиция мыши в мировых координатах
        mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        // Угол между объектами
        angle = Vector2.Angle (Vector2.right, mousePosition - transform.position); //угол между вектором от объекта к мыше и осью х

        // Мгновенное вращение
        transform.eulerAngles = new Vector3 (0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

      
    }
}
