using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] _wayPoints;

    private int _currWayPointIndex = 0;

    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(_wayPoints[_currWayPointIndex].transform.position, transform.position) < 0.1f)
        {
            _currWayPointIndex++;
            if (_currWayPointIndex >= _wayPoints.Length)
            {
                _currWayPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currWayPointIndex].transform.position,
            Time.deltaTime * speed);
    }
}
