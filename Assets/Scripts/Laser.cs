using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed var = 8
    [SerializeField]
    private float _speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate laser up

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //if laser is > 8 on y
        // destroy laser

        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}
