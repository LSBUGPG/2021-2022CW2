using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewmodelSway : MonoBehaviour
{
    [SerializeField] Rigidbody PlayerRB;

    [Header("Viewmodel Movement")]
    [SerializeField] float Amount = 0.02f;
    [SerializeField] float MaxAmount = 0.06f;
    [SerializeField] float SmoothAmount = 6f;

    [Header("Viewmodel Rotation")]
    [SerializeField] float RotationAmount = 4f;
    [SerializeField] float MaxRotationAmount = 5f;
    [SerializeField] float SmoothRotationAmount = 12;

    [SerializeField] bool XLock;
    [SerializeField] bool YLock;
    [SerializeField] bool ZLock;

    Vector3 InitialPosition;
    Quaternion InitialRotation;

    float LookX;
    float LookY;

    float MoveX;
    float MoveY;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.localPosition;
        InitialRotation = transform.localRotation;   
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput();
        MoveViewModel();
        SwayViewModel();
    }

    void GetMouseInput()
    {
        LookX = -Input.GetAxis("Mouse X");
        LookY = -Input.GetAxis("Mouse Y");
        
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxis("Vertical");

    }

    void MoveViewModel()
    {
        float MoveX = Mathf.Clamp(LookX * Amount, -MaxAmount, MaxAmount);
        float MoveY = Mathf.Clamp(LookY * Amount, -MaxAmount, MaxAmount);

        Vector3 FinalPosition = new Vector3(MoveX, MoveY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, FinalPosition + InitialPosition, SmoothAmount * Time.deltaTime);
    }
    
    void SwayViewModel()
    {
        float VerticalDir = Mathf.Clamp(PlayerRB.velocity.y, -1, 1);

        float RotateY = Mathf.Clamp((-MoveX * 0.5f + LookX) * RotationAmount, -MaxRotationAmount, MaxRotationAmount);
        float RotateX = Mathf.Clamp((-MoveY * 0.5f + LookY + -PlayerRB.velocity.y *0.1f) * RotationAmount, -MaxRotationAmount, MaxRotationAmount);

        Quaternion FinalRotation = Quaternion.Euler(new Vector3(
                                    !XLock ? -RotateX : 0,
                                    !YLock ? RotateY : 0,
                                    !ZLock ? RotateY : 0));


        transform.localRotation = Quaternion.Slerp(transform.localRotation, FinalRotation * InitialRotation, SmoothRotationAmount * Time.deltaTime);
    }
}
