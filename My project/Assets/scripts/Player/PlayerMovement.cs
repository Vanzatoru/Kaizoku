using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float rotationSpeed = 100;
    public Slider slider;
    private float initialSpeed;
    private float initalRot;
    private bool isSinking;
    private bool stopfrt;
    private float rx, rz;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    public PlayerStatus playerStatus;

    private void Start()
    {
        
        initialSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
        isSinking = false;
        stopfrt = true;
        rb.freezeRotation = true;
        initalRot = rotationSpeed;
        rx = UnityEngine.Random.Range(320, 335);
        rz = UnityEngine.Random.Range(335, 350);
        print(transform.rotation.eulerAngles.x);
    }

    private void Update()
    {
        if (playerStatus.hp <= 0 && stopfrt == true)
        {
            sink();
            stopfrt=false;
        }

        if (isSinking)
        {
            if (transform.rotation.eulerAngles.x >= rx)
            {
                transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.Self);
            }

            if (transform.rotation.eulerAngles.z >= rz)
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.Self);
            }
        }
        else if (!Input.GetKey(KeyCode.S))
        {
            MyInput();
            Rotate();
            Shift();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = (-transform.right) * verticalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void Shift()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && moveSpeed <= initialSpeed * 2)
        {
            moveSpeed += 0.01f;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = initialSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && rotationSpeed == initalRot)
        {
            rotationSpeed /= 2;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            rotationSpeed = initalRot;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crash"))
        {
            print("Te ai scufundat frtmiu");
            
            playerStatus.enabled = false;
            slider.value = 0;
            sink();
        }

        if (collision.gameObject.CompareTag("CannonBall"))
        {
            playerStatus.hp = playerStatus.hp - 250;
            print("Ia cu dmg -250");
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }

    private void sink()
    {
        SaveScore();
        playerStatus.enabled = false;
        
        rotationSpeed = 2;
        rb.isKinematic = true;
        isSinking = true;
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void SaveScore() {
        using (StreamWriter writer = new StreamWriter("Assets/scripts/Player/score.txt", true))
        {
            
            writer.WriteLine(playerStatus.score);
        }
    }
}
