using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]Transform _player;
    // Update is called once per frame
    private void Update()
    {
        var position = _player.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
