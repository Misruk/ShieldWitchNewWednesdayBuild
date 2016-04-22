using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour
{

    Vector3 originalCameraPosition;
    public GameObject character1;
    //public GameObject character2;

    float shakeAmt = 0;

    bool used = false;

    public Camera mainCamera;

    void Start()
    {
       // character1 = GameObject.Find("Player_Test");
        character1 = GetComponent<GameObject>();
        //character2 = GetComponent<GameObject>();
    }
    
    void Update()
    {
        if(used == true)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            shakeAmt = coll.relativeVelocity.magnitude * .0025f;
            shakeAmt = 25 * .0025f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
            
        }

    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            pp.x += quakeAmt;
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        Debug.Log("Happened");
        CancelInvoke("CameraShake");
       // mainCamera.transform.position = character1.transform.position;
        Debug.Log("It seriously happened");
       // this.gameObject.GetComponent<Collider2D>().enabled = false;
        //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        used = true;
        //Invoke("Destroy", .05f);
        //Destroy(this.gameObject);
        //mainCamera.transform.position = originalCameraPosition;
        /* if (MenuManager.characterSelected == 0)
         {
             mainCamera.transform.position = character1.transform.position;
             Destroy(this.gameObject);
         }
         else if (MenuManager.characterSelected == 1)
         {
             mainCamera.transform.position = character2.transform.position;
             Destroy(this.gameObject);
         } */
        //mainCamera.transform.position = player.position;
    }

}