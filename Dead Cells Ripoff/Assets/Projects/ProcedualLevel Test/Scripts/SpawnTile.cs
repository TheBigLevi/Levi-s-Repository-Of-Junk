using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{

    public GameObject[] tiles;

    public Transform[] targets;

    private void Start()
    {
        if (targets != null)
        {
            for (int i = 1; i < targets.Length; i++)
            {
                Vector3 pos = targets[i-1].position;
                Vector3 end = targets[i].position;
                while (Vector3.Distance(pos, end) > 0.01f)
                {
                    int rand = Random.Range(0, tiles.Length);
                    Instantiate(tiles[rand], pos, Quaternion.identity);
                    pos = Vector3.MoveTowards(pos, end, 1.0f);
                }
            }
        }

    }

    void OnDrawGizmos()
    {
        if (targets != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            for (int i = 1; i < targets.Length; i++)
            {
                if (targets[i - 1] != null && targets[i] != null)
                {
                    Gizmos.DrawLine(targets[i - 1].position, targets[i].position);
                }
            }
        }
    }

}
