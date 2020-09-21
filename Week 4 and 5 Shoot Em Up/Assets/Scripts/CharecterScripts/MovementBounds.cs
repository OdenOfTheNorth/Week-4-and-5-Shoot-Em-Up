using System;
using UnityEngine;

public class MovementBounds : MonoBehaviour
{
    public bool ZBound = true;
    [NonSerialized]public Vector2 screenBounds;

    private Vector2 objectSize;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectSize.x = transform.GetComponent<BoxCollider>().bounds.size.x / 2f;
        objectSize.y = transform.GetComponent<BoxCollider>().bounds.size.z * 1.5f;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -screenBounds.x + objectSize.x, screenBounds.x - objectSize.x);
        if (ZBound)
        {
            pos.z = Mathf.Clamp(pos.z, -screenBounds.y + objectSize.y, screenBounds.y - objectSize.y);    
        }
        transform.position = pos;
    }
}
