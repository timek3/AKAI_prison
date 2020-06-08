using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //nazwy klawiszy używanych przy sterowaniu
    [SerializeField] private string HorizontalInputName;
    [SerializeField] private string VerticalInputName;

    //prędkość gracza
    [SerializeField] private float moveSpeed;

    //odnośnik do komponentu sterującego graczem
    private CharacterController charControl;

    //zrób od razu po załadowaniu poziomu
    private void Awake()
    {
        //komponent do sterowania
        charControl = GetComponent<CharacterController>();
    }

    //zrób co klatkę
    private void Update()
    {
        PlayerMovement();
    }

    //ruch postaci
    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(VerticalInputName) * moveSpeed;
        float horiInput = Input.GetAxis(HorizontalInputName) * moveSpeed;

        //wartości ruchu przód i tył i lewo prawo w zakresie -1 do 1
        Vector3 forwardMove = transform.forward * vertInput;
        Vector3 sideMove = transform.right * horiInput;

        //wprawiamy postać w ruch
        charControl.SimpleMove(forwardMove + sideMove);
    }

}
