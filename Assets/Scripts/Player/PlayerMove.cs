using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public float initialRunSpeed = 3f; // Adjust the initial running movement speed
    public float maxRunSpeed = 200f; // Adjust the maximum running movement speed
    public float speedIncrementRate = 0.2f; // Adjust the speed increment rate over time
    public float swipeThreshold = 50f; // Adjust the swipe threshold
    public float movementSpeed = 10f; // Adjust the left/right movement speed
    public float targetXPosition { get; private set; }
    private bool isMoving = false; // Flag to track if the player is currently moving
    private Vector3 startPos; // Starting position of the touch or mouse input
    private LevelBoundary levelBoundary; // Reference to the LevelBoundary script
    private float runSpeed; // Current running movement speed
    void Start()
    {
        levelBoundary = GameObject.Find("LevelControl").GetComponent<LevelBoundary>();
        runSpeed = initialRunSpeed;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * runSpeed, Space.World);
        if (!isMoving)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    startPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    float swipeDelta = touch.position.x - startPos.x;
                    if (Mathf.Abs(swipeDelta) > swipeThreshold)
                    {
                        if (swipeDelta < 0f)
                        {
                            MovePlayerLeft();
                        }
                        else
                        {
                            MovePlayerRight();
                        }
                    }
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                float swipeDelta = Input.mousePosition.x - startPos.x;
                if (Mathf.Abs(swipeDelta) > swipeThreshold)
                {
                    if (swipeDelta < 0f)
                    {
                        MovePlayerLeft();
                    }
                    else
                    {
                        MovePlayerRight();
                    }
                }
            }
        }
        else
        {
            SlidePlayer();
        }
    }
    void MovePlayerLeft()
    {
        float targetX = transform.position.x - 1.5f;
        targetXPosition = Mathf.Clamp(targetX, levelBoundary.leftBoundary, levelBoundary.rightBoundary);
        isMoving = true;
    }
    void MovePlayerRight()
    {
        float targetX = transform.position.x + 1.5f;
        targetXPosition = Mathf.Clamp(targetX, levelBoundary.leftBoundary, levelBoundary.rightBoundary);
        isMoving = true;
    }
    void SlidePlayer()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetXPosition, transform.position.y, transform.position.z), step);
        if (transform.position.x == targetXPosition)
        {
            isMoving = false;
        }
    }
    void FixedUpdate()
    {
        IncreaseSpeedOverTime();
    }
    void IncreaseSpeedOverTime()
    {
        if (runSpeed < maxRunSpeed)
        {
            runSpeed += speedIncrementRate * Time.fixedDeltaTime;
            runSpeed = Mathf.Min(runSpeed, maxRunSpeed);
        }
    }
}