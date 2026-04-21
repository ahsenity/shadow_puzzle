using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

public class hareket : MonoBehaviour
{
    Camera kamera;
    GameObject[] gölgeler;
    Vector2 baslangic_pozisyon;
    son son_script;
     private Vector3 offset;
    private bool isDragging = false;
    void Start()
    {
        kamera = GameObject.Find("camera").GetComponent<Camera>();
        gölgeler = GameObject.FindGameObjectsWithTag("gölge");
        baslangic_pozisyon = transform.position;
        son_script = GameObject.Find("son").GetComponent<son>();
    }
 void OnMouseDown()
    {
        isDragging = true;
        // Calculate offset between object's position and mouse position
        Vector3 pozisyon = kamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, kamera.WorldToScreenPoint(transform.position).z));
        offset = transform.position - pozisyon;
    }

    void OnMouseUp()
    {
        isDragging = false;

        foreach (GameObject gölge in gölgeler)
        {
            if (gameObject.name == gölge.name)
            {
                float mesafe = Vector3.Distance(gölge.transform.position, transform.position);
                if (mesafe <= 1)
                {
                    transform.position = gölge.transform.position;
                    Destroy(this);
                    son_script.level_son();
                    return;
                }
            }
        }

        transform.position = baslangic_pozisyon;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 pozisyon = kamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, kamera.WorldToScreenPoint(transform.position).z));
            pozisyon.z = transform.position.z; // Keep the z position unchanged
            transform.position = pozisyon + offset;
        }
    }
     void Update()
     {
       if(Input.GetMouseButtonDown(0))
       {
        foreach(GameObject gölge in gölgeler)
        {
            if(gameObject.name==gölge.name)
            {
                float mesafe =Vector3.Distance(gölge.transform.position, transform.position);
                if(mesafe <= 1)
                {
                    transform.position=gölge.transform.position;
                    Destroy(this);
                    son_script.level_son();

                }
                 else 
                {
                    transform.position = baslangic_pozisyon;
                }
            }
        }
       }  }
     }