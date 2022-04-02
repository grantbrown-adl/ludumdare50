using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private Vector2 inputVector;
    [SerializeField] private Vector2 moveVector;
    [SerializeField] private Vector2 startVector;
    [SerializeField] private Vector3 currentAngle;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravityScale;
    [SerializeField] private float rotateFactor;
    [SerializeField] private float angleCoefficient;

    #region Unity Functions
    private void Awake()
    {
        GetComponents();
    }

    private void Start()
    {
        InitialiseSettings();
    }

    private void Update()
    {
        GetInput();
        HandleInput();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = moveVector;
        TiltTransform();
    }
    #endregion

    #region User defined functions
    void GetInput()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical"); // Probably unneeded at the moment
        //moveVector = new Vector2(moveVector.x * moveSpeed, 0.0f);
    }

    void HandleInput()
    {
        moveVector = new Vector2(inputVector.x * moveSpeed, 0.0f);
    }

    void GetComponents()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void InitialiseSettings()
    {
        transform.position = startVector;
        rb2d.gravityScale = gravityScale;
        rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb2d.interpolation = RigidbodyInterpolation2D.Interpolate;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        currentAngle = transform.eulerAngles;
    }

    void TiltTransform()
    {
        Vector3 targetAngle = new Vector3(0.0f, 0.0f, rb2d.velocity.x * -angleCoefficient);
        currentAngle = new Vector3(0, 0, Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * rotateFactor));
        transform.eulerAngles = currentAngle;
    }
    #endregion
}
