using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // pozycja gracza
    Transform player;
    // offset kamery
    Vector3 cameraOffset;
    //prêdkoœæ przesuwania kamery - nie nadajemy wartoœci - zrobi to smoothDamp
    Vector3 cameraSpeed;
    //czas wyg³adzania ruchu kamery
    float smoothTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        // znajdz gracza i pod³¹cz jego pozycjê do zmiennej transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // pobierz domyœlny offset kamery
        cameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //pozycja kamery to pozyja gracza + offset
        //transform.position = player.position + cameraOffset;



        //bardziej kulturalnie - lerp
        //policz pozycje docelow¹
        Vector3 targetPosition = player.position + cameraOffset;

        //u¿yj interpolacji liniowej
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);

        //u¿yj smooothdamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraSpeed, smoothTime);
    }
}
