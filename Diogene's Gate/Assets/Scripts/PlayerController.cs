using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int facing;
    public float playerSpeed;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        facing = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime, 0f, 0f));
            facing = Input.GetAxisRaw("Horizontal") > 0.5f ? 1 : 3;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime, 0f));
            facing = Input.GetAxisRaw("Vertical") > 0.5f ? 2 : 0;
        }
        animator.SetInteger("Facing", facing);
        Quaternion temp = transform.rotation;
        temp.x = 0;
        temp.y = 0;
        temp.z = 0;
        transform.rotation = temp;
    }
}
