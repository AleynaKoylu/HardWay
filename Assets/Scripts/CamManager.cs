using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField]
    Transform ChildPos;

    Vector3 distance;

    float camSpeed=10;
    [SerializeField]
    float dstnc;

    void LateUpdate()
    {
        distance = new Vector3(ChildPos.position.x, transform.position.y, ChildPos.position.z - dstnc);
        transform.position = Vector3.Lerp(transform.position, distance , camSpeed* Time.deltaTime);
    }
}
