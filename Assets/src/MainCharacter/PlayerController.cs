using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Animator anim;

    private Rigidbody2D _body;
    public GameObject bulletSpawnPoint;
    private bool isFacingRight = true;

    private void Awake () 
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update () 
    {
        Vector2 InputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _body.velocity = InputAxis*10f;

        if(
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.W) || 
            Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)
        ) {
            anim.SetBool("Idle", false);
        }
        else {
            anim.SetBool("Idle", true);
        }
        
        // Flip();
    }

    
    public void Flip()
    {
        if (isFacingRight && Input.GetAxisRaw("Horizontal") < 0f || !isFacingRight && Input.GetAxisRaw("Horizontal") > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Flip2()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
