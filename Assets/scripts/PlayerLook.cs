using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //nazwa osi X i osi Y
    [SerializeField] private string mouseXInputName, mouseYInputName;

    //czułość myszy
    [SerializeField] private float mouseSens;

    //odnośnik do obiektu gracza w świecie
    [SerializeField] private Transform playerBody;

    //zablkowanie kamery, gdy patrzymy za wysoko albo za nisko
    private float xAxisClamp;

    //zawartość funkcji dzieje się od razu po załadowaniu poziomu
    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f; //patrzymy się naprzód pod kątem 0 stopni
    }

    //funkcja, która blokuje kursor po środku ekranu
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //dzieje się co klatkę gry
    private void Update()
    {
        CameraRotation(); //funkcja CameraRotation działa w każdej klatce gry
    }

    //obracanie kamerą
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSens * Time.deltaTime; //obrót względem osi X
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSens * Time.deltaTime; //obrót względem osi Y

        xAxisClamp += mouseY; //xAxisClamp mówi nam jak daleko przesuneliśmy kamerę od 0 stopni
        if (xAxisClamp > 90.0f) //jeśli patrzymy się na samą górę...
        {
            xAxisClamp = 90.0f; //to nie spojrzymy już nigdzie wyżej.
            mouseY = 0.0f;
        }
        else if (xAxisClamp < -90.0f) //jeśli patrzymy się na sam dół...
        {
            xAxisClamp = -90.0f; //to niżej nie spojrzymy.
            mouseY = 0.0f;
        }

        //wprawiamy kamerę w ruch wertykalny
        transform.Rotate(Vector3.left * mouseY);
        //i horyzontalny
        playerBody.Rotate(Vector3.up * mouseX);

    }



}
