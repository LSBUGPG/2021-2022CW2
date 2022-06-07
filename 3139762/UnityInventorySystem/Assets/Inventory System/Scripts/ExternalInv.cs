using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalInv : MonoBehaviour
{
    [SerializeField] InventorySO exInv;
    [SerializeField] Transform dropPoint;
    [SerializeField] int invMaxSlots = 30;

    private void Start()
    {
        SetDropPoint();
    }
    public InventorySO GetInv()
    {
        return exInv;
    }
    void SetDropPoint()
    {
        exInv.dropP = dropPoint;
    }
}
