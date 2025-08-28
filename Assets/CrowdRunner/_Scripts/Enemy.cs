using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State { Idle, Run }

    [Header("Settings")]
    [SerializeField] private float searchRadius = 1f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float attackRange = 10f;

    private State state = State.Idle;
    private Transform targetRunner;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SearchRoutine());
    }

    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                // Idle behavior handled in Coroutine
                break;

            case State.Run:
                RunTowardsTarget();
                break;
        }
    }

    // Coroutine to periodically search for targets
    private IEnumerator SearchRoutine()
    {
        while (true)
        {
            if (state == State.Idle)
                SearchForTarget();
            yield return new WaitForSeconds(0.3f); // search every 0.3 seconds
        }
    }

    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);
        foreach (var collider in detectedColliders)
        {
            if (collider.TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                    continue;

                runner.SetTarget();
                targetRunner = runner.transform;

                FaceTarget(targetRunner.position); // face target immediately
                StartRunningTowardsTarget();
                break; // lock onto first valid target
            }
        }
    }

    private void StartRunningTowardsTarget()
    {
        state = State.Run;
        animator.Play("Run");
    }

    private void RunTowardsTarget()
    {
        if (targetRunner == null)
        {
            state = State.Idle;
            animator.Play("Idle");
            return;
        }

        FaceTarget(targetRunner.position);

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetRunner.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetRunner.position) <= attackRange)
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
    }

    private void FaceTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            rotationSpeed * Time.deltaTime
        );
    }

}
