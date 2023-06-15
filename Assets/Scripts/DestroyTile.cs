using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTile : MonoBehaviour
{
    public Tilemap destroyableTilemap;

    // Start is called before the first frame update
    void Start()
    {
        destroyableTilemap = GetComponent<Tilemap>();

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in coll.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                destroyableTilemap.SetTile(destroyableTilemap.WorldToCell(hitPosition), null);
            }
        }
    }
}
