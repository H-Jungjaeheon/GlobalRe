using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform[] CameraPoint;

    [SerializeField]
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerChk();
    }

    void PlayerChk()
    {
        if(Player.transform.position.x >= 9.0f && Player.transform.position.x < 27.2f)
        {
            //Debug.Log("Town1");
            StartCoroutine("Town1Move");
        }

        else if (Player.transform.position.x >= 27.2f && Player.transform.position.x < 45.2f)
        {
            //Debug.Log("Town2");
            StartCoroutine("Town2Move");
        }

        else if (Player.transform.position.x >= 45.2f && Player.transform.position.x < 62.9f)
        {
            //Debug.Log("Town3");
            StartCoroutine("Town3Move");
        }
    }

    IEnumerator Town1Move()
    {
        yield return new WaitForSeconds(0.2f);

        this.transform.DOMoveX(CameraPoint[1].position.x, 0.9f);
    }

    IEnumerator Town2Move()
    {
        yield return new WaitForSeconds(0.2f);

        this.transform.DOMoveX(CameraPoint[2].position.x, 0.9f);
    }

    IEnumerator Town3Move()
    {
        yield return new WaitForSeconds(0.2f);

        this.transform.DOMoveX(CameraPoint[3].position.x, 0.9f);
    }
}
