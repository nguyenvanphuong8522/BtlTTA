using CityPeople;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Target
    private List<Transform> points;
    private Vector3 target;
    [SerializeField]
    private GameObject objPoints;
    private int index;

    //Movement
    [SerializeField]
    private float speed = 5f;
    private bool pauseMove;

    //Animation
    [SerializeField]
    private AnimatorController animatorController;
    private void Awake()
    {
        Initial();
    }
    public void Initial()
    {
        index = 0;
        pauseMove = false;
        points = new List<Transform>();
        points = objPoints.GetComponentsInChildren<Transform>().ToList();
        points.RemoveAt(0);
        SetTarget(points[0].position);
    }
    private void SetTarget(Vector3 _target)
    {
        target = _target;
    }
    private void Update()
    {
        if (!pauseMove)
        {
            CheckNextTarget();
            MoveToTarget();
        }
    }
    public void CheckNextTarget()
    {
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            animatorController.PlayClip(index, true);
            NextTarget();
            StartCoroutine(DelayMove(Duration()));
        }
    }
    public void MoveToTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        transform.LookAt(target);
    }
    public void NextTarget()
    {
        if (index < points.Count - 1)
            index++;
        else
            index = 0;

        target = points[index].position;
    }
    IEnumerator DelayMove(float duration)
    {
        pauseMove = true;
        yield return new WaitForSeconds(duration);
        pauseMove = false;
        animatorController.PlayClip(index + 1, false);
    }
    public int Duration()
    {
        return animatorController.AnimationTargets[index].duration;
    }
}
