using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //silnik fizyczny dla obiektu gracza
    Rigidbody rb;
    //siła skoku
    public float jumpForce = 5f;

    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //przypnij rigidbody gracza do zmiennej rb
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        //można prościej: Vector3.right

        //zczytaj klawiaturę w osi poziomej:
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //wyświetl w konsoli stan klawiatury
        //Debug.Log(horizontalInput);

        //wylicz przesunięcie w osi x
        Vector3 movement = Vector3.right * horizontalInput;

        //zczytaj z klawiatury oś y
        float verticalInput = Input.GetAxisRaw("Vertical");

        //wylicz przesunięcie w osi y i dodaj do istniejącego przesunięcia w osi x
        movement += Vector3.forward * verticalInput;

        //normalizujemy wektor
        movement = movement.normalized;
        //poprawka na czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomnóż przez prędkość ruchu
        movement *= moveSpeed;

        //przesuń gracza w osi x
        //transform.position += movement;

        //próbujemy użyc translate zamiast dodawac współrzędne
        transform.Translate(movement);


    }
    //spróbujmy obejść problem z opóźnieniem wejścia poprzez przeniesienie go do update
    void Update()
    {
        //sprawdz czy nacisnieto spację (skok)
        //zwraca true jeśli zaczęliśmy naciskać spację w trakcie klatki animacji
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        //sprawdz czy znajduje się na poziomie 0
        if (transform.position.y <= Mathf.Epsilon)
        {
            //dodaj siłę skoku
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //ta funkcja wykryje za każdym razem kiedy gracz wejdz w colider który jest triggerem
        //może to być kamera ale może to też byc koniec poziomu

        if (other.CompareTag("LevelEnd"))
        {
            //stanelismy a miejscu gdzie jest koniec poziomu - wygraliśmy

            //find->nazwaobiektu->nazwaskryptu->nazwa funkcji
            GameObject.Find("LevelManager").GetComponent<LevelManager>().OnWin();
        }
        if (other.CompareTag("CameraView"))
        {
            //kamera nas zobaczyła - przegraliśmy
            GameObject.Find("LevelManager").GetComponent<LevelManager>().OnLose();

        }
    }
}

