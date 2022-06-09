using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject Projectile;

    public Transform Firepoint;

    public float force;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Fireball fireball1 = Instantiate(Projectile, Firepoint.position, Quaternion.identity).GetComponent<Fireball>();
            Fireball fireball = fireball1;
            Fireball P = fireball;
            P.direction = transform.forward;
            P.Speed =force;
        }
    }

    public float Speed { get; set; }
}
