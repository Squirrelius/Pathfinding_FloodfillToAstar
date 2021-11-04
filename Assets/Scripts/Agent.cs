using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float _speedFactor = 1;

    private Queue<Tile> _path;


    public void SetPath(Queue<Tile> path)
    {
        _path = path;
        StopAllCoroutines();
        StartCoroutine(MoveAlongPath(path));
    }

    private IEnumerator MoveAlongPath(Queue<Tile> path)
    {
        yield return new WaitForSeconds(1);
        Vector3 lastPosition = transform.position;
        while (path.Count > 0)
        {
            Tile nextTile = path.Dequeue();
            float lerpVal = 0;
            transform.LookAt(nextTile.transform, Vector3.up);

            while (lerpVal < 1)
            {
                lerpVal += Time.deltaTime * _speedFactor;
                transform.position = Vector3.Lerp(lastPosition, nextTile.transform.position, lerpVal);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.5f / _speedFactor);
            lastPosition = nextTile.transform.position;
        }
    }
}
