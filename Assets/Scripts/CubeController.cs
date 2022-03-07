using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    bool IsAngry { get { return _isAngry; } set { ToggleAnger(value); _isAngry = value; } }
    bool _isAngry;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
        GetComponentInChildren<ParticleSystem>().Stop(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsAngry)
        {
            IsAngry = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && IsAngry)
        {
            IsAngry = false;
        }
    }

    void ToggleAnger(bool isAngry)
    {
        if (isAngry)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            GetComponentInChildren<ParticleSystem>().Play(true);
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            GetComponentInChildren<ParticleSystem>().Stop(true);
        }
    }
}
