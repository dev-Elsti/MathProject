using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_to_Target : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public int targed_Index = 0; Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        targed_Index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move_update();
    }

    void Move_update()
    {
        if (target.Length <= 0)
            return;
        Vector3 dir = target[targed_Index].position - tr.position;
        //print("dir\n" + " x: " + dir.x + " y: " + dir.y + " z: " + dir.z);
        dir.Normalize();
        print("dirNormal\n" + dir);
        dir = dir * speed * Time.deltaTime;
        tr.position += dir;
        //print("dirTime\n" + " x: " + dir.x + " y: " + dir.y + " z: " + dir.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == target[targed_Index])
            ChangeTarget();
    }

    void ChangeTarget()
    {
        targed_Index++;
        if (targed_Index > target.Length - 1)
            targed_Index = 0;
    }
}
