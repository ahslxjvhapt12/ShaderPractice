using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Range(0f, 360f)]
    public float viewAngle;
    public float viewRadius;

    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _enemyFindDelay = 0.3f;
    public List<Transform> visibleTargets = new List<Transform>();

    [SerializeField] private float _meshResolution;

    private void Start()
    {
        StartCoroutine(FindEnemyWithDelay(_enemyFindDelay));
    }

    private void Update()
    {
        DrawFieldOfView();
    }

    private void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(_meshResolution * viewAngle);
        float stepAngleSize = viewAngle / stepCount;

        Vector3 pos = transform.position;

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle * 0.5f + stepAngleSize * i;

            Debug.DrawLine(pos, pos + DirFromAngle(angle, true) * viewRadius, Color.red);
        }
    }

    public Vector3 DirFromAngle(float degree, bool anglesGlobal)
    {
        if (!anglesGlobal)
        {
            degree += transform.eulerAngles.y;
        }

        float rad = degree * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad));
    }

    private IEnumerator FindEnemyWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleEnemies();
        }
    }

    private void FindVisibleEnemies()
    {
        visibleTargets.Clear();

        Collider[] enemiesInview = new Collider[6];

        int cnt = Physics.OverlapSphereNonAlloc(transform.position, viewRadius, enemiesInview, _enemyMask);

        for (int i = 0; i < cnt; i++)
        {
            Transform enemy = enemiesInview[i].transform;
            Vector3 dir = enemy.position - transform.position;
            if (Vector3.Angle(transform.forward, dir) < viewAngle * 0.5f)
            {


                if (!Physics2D.Raycast(transform.position, dir, dir.magnitude, _obstacleMask))
                {
                    visibleTargets.Add(enemy);
                }
            }
        }
    }
}
