using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oathstring
{
    public class PlayerController : MonoBehaviour
    {
        private Action SetSpeed;

        [SerializeField] private float walkSpeed; //Kecepatan berjalan
        [SerializeField] private float runSpeed; //Kecepatan berlari
        [SerializeField] private float mouseSens;

        private float currentSpeed; //Kecepatan saat ini antara menggunakan walkSpeed atau runSpeed
        private CharacterController characterController;
        private bool isJump;
        private float jumpForce = 6;
        private float gravity = -9.8f;

        float mouseX;
        float rotY;

        private Camera fpsCamera;
        private PauseMenu pauseMenu;
        private Vector3 playerMove;
        private Vector3 playerVelocity;

        // Start is called before the first frame update
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            fpsCamera = Camera.main;
            pauseMenu = GameObject.Find("Pause Menu").GetComponent<PauseMenu>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        private void Update()
        {
            pauseMenu.OnEscapePressed(Input.GetKeyDown(KeyCode.Escape));

            if (Input.GetKey(KeyCode.LeftShift)) SetSpeed = Run; //Mengganti kecepatan sekarang ke kecepatan berlari
            else SetSpeed = Walk; //Mengganti kecepatan sekarang ke kecepatan berjalan

            SetSpeed(); //Setiap saat mengupdate kecepatan 

            if (Input.GetButtonDown("Jump"))
            {
                if (IsGrounded()) isJump = true;
                else if (characterController.isGrounded)
                    isJump = true;

            }

            rotY += Input.GetAxis("Mouse X") * mouseSens;

            mouseX -= Input.GetAxis("Mouse Y") * mouseSens;

            mouseX = Mathf.Clamp(mouseX, -90, 90);

            fpsCamera.transform.localRotation = Quaternion.Euler(mouseX, 0, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, rotY, 0));

            if (characterController.velocity.y == 0) playerVelocity.y = 0;
        }

        private void FixedUpdate() 
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            playerMove = currentSpeed * Time.fixedDeltaTime * (transform.forward * vertical + transform.right * horizontal);
            characterController.Move(playerMove * Time.fixedDeltaTime);

            if (!isJump && characterController.isGrounded) playerVelocity.y = 0;
            else if (isJump)
            {
                playerVelocity.y = jumpForce;
                isJump = false;
            }
            else if (!isJump) 
            { 
                playerVelocity.y += gravity * Time.fixedDeltaTime; 
            }

            characterController.Move(playerVelocity * Time.fixedDeltaTime);
        }

        private void Run()
        {
            currentSpeed = runSpeed;
        }

        private void Walk()
        {
            currentSpeed = walkSpeed;
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, 1.4f);
        }

        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.GetComponent<LevelComplete>())
            {
                LevelComplete levelComplete = other.gameObject.GetComponent<LevelComplete>();
                LoadingScreenHandler loadingScreenHandler = GameObject.Find("UI Instantiate").GetComponent<LoadingScreenHandler>();

                loadingScreenHandler.InstantiateLoadingScreen();
                if(levelComplete.GetLevelName() != "") PlayerPrefs.SetString("Level", levelComplete.GetLevelName());
            }

            else
            {
                rotY = 0;
                mouseX = 0;
                other.gameObject.GetComponent<EmptySpaceChecker>().SetPlayerController(gameObject);
            }
        }
    }
}
