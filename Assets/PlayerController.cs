using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 3.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float Movex = Input.GetAxis("Horizontal");

        this.gameObject.transform.Translate(Movex * Time.deltaTime * Speed, 0.0f, 0.0f);
    }
}
