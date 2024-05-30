using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    Transform _camera;

    private void LateUpdate()
    {
        transform.position = new Vector3 (_camera.position.x,_camera.position.y);
    }
}