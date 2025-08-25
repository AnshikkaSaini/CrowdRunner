using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private CrowdSystem crowdSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectDoors();
    }

    private void DetectDoors()
    {
        Collider[] dectectedColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < dectectedColliders.Length; i++)
        {
            if (dectectedColliders[i].TryGetComponent(out Doors doors))
            {
                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType =    doors.GetBonusType(transform.position.x);

                doors.Disable();
                crowdSystem.ApplyBonus(bonusType, bonusAmount);
            }
        }
    }
}
