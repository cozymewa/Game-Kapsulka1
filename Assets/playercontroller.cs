using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //silnik fizyczny dla obiektu gracza
    Rigidbody rb;
    //si�a skoku
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
        //mo�na pro�ciej: Vector3.right

        //zczytaj klawiatur� w osi poziomej:
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //wy�wietl w konsoli stan klawiatury
        //Debug.Log(horizontalInput);

        //wylicz przesuni�cie w osi x
        Vector3 movement = Vector3.right * horizontalInput;

        //zczytaj z klawiatury o� y
        float verticalInput = Input.GetAxisRaw("Vertical");

        //wylicz przesuni�cie w osi y i dodaj do istniej�cego przesuni�cia w osi x
        movement += Vector3.forward * verticalInput;

        //normalizujemy wektor
        movement = movement.normalized;
        //poprawka na czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomn� przez pr�dko�� ruchu
        movement *= moveSpeed;

        //przesu� gracza w osi x
        //transform.position += movement;

        //pr�bujemy u�yc translate zamiast dodawac wsp�rz�dne
        transform.Translate(movement);


    }
    //spr�bujmy obej�� problem z op�nieniem wej�cia poprzez przeniesienie go do update
    void Update()
    {
        //sprawdz czy nacisnieto spacj� (skok)
        //zwraca true je�li zacz�li�my naciska� spacj� w trakcie klatki animacji
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        //sprawdz czy znajduje si� na poziomie 0
        if (transform.position.y <= Mathf.Epsilon)
        {
            //dodaj si�� skoku
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BOOM");
    }
}

