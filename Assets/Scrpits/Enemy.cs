using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public Path path;
        public int index = 0;
        public float speed = 1f;
        public int Damage = 1;
        private void Start()
        {
            StartCoroutine(FollowPath());
        }
        IEnumerator FollowPath()
        {
            Vector3 target; // Next target position
            while (path.TryGetPoint(index, out target))
            {
                Vector3 start = transform.position;

                // Maximum distance to travel this loop.
                float maxDistance = Mathf.Min(speed * Time.deltaTime, (target - start).magnitude);
                transform.position = Vector3.MoveTowards(start, target, maxDistance);

                // Rotate towards next point
                transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(target - start), 0.05f);

                // Target position reached, next index.
                if (transform.position == target) index++;

                // Resume execution on the next frame.
                yield return null;
            }
        }
    }

}

