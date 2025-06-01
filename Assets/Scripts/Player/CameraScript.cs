using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void LateUpdate()
    {
        Vector3 cameraPos;
        cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(Player.transform.position.x, minX, maxX);
        cameraPos.y = Mathf.Clamp(Player.transform.position.y, minY, maxY);
        transform.position = cameraPos;
    }
}
