using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VallaLogic : MonoBehaviour
{
    // tumbar les valles

    bool _collisionDetect;

    public Vector3 initrot;
    int cont;

    // Use this for initialization
    void Start()
    {
        _collisionDetect = false;
        cont = 0;
        initrot = this.transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (_collisionDetect)
        {
            if(cont < 90)
            {
                transform.Rotate(+3, 0, 0);
                cont += 3;
            }
            else
            {
                _collisionDetect = false;
            }
            

        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _collisionDetect = true;
        }

    }


}
