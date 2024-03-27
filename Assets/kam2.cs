using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CCTVCameraController : MonoBehaviour
{
    //modyfikator pr�dko�ci obrotu
    public float turnSpeed = 5f;

    //zakres obrotu kamery w stopniach
    public float turnAngle = 90;

    //czy kamera kr�ci si� w prawo
    bool turningRight = !true;

    //obiektyw kamery
    Transform cameraLens;

    // Start is called before the first frame update
    void Start()
    {
        Transform cameraPosition = transform.Find("CameraPosition");
        cameraLens = cameraPosition.Find("Cylinder");
    }

    // Update is called once per frame
    void Update()
    {
        // mdyfikujemy rotacj� obiektu za pomoc� funkcji PingPong, kt�ra generuje warto�ci
        // oscyluj�ce pomi�dzy 0 a 9, a nast�pnie mno�ymy to przez 10 �eby uzyska� szybszy ruch
        // i na koniec odejmujemy od warto�ci otrzymanej 45 stopni aby uzyska� ruch w zakresie -45 do 45
        transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.PingPong(Time.time, 9) * 10 - 45, 0));

        CheckIfPlayerVisible();
    }

    void CheckIfPlayerVisible()
    {
        // Debug.DrawRay(cameraLens.position, cameraLens.TransformDirection(Vector3.down)*100, Color.yellow);
    }

}

