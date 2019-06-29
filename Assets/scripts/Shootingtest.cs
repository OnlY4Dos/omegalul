using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingtest : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bullet;
    public Vector3 mouseWorld;
    Vector3 mouse;
    Vector3 Target;
    void Update()
    {     
        mouse = Input.mousePosition;
        mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3 (mouse.x, mouse.y,transform.position.z));
        Debug.DrawLine(FirePoint.position,mouseWorld);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        { 
            Target = mouseWorld;
            Shot(Target);      
        }
            
    }
    void Shot(Vector3 mousePos)
    {    
        //Instantiate(bullet , FirePoint.position,FirePoint.rotation);    
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position , mousePos);
        Debug.DrawLine(FirePoint.position,mousePos,Color.red , 3f);      
        if(hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
