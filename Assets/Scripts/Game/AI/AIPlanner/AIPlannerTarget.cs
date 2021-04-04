using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generated.Semantic.Traits;

public class AIPlannerTarget : MonoBehaviour
{
    static int UniqueIdCounter;
    public int UniqueId { get; private set; }

    void Awake()
    {
        UniqueId = UniqueIdCounter++;
    }

    void Start()
    {
        var traitComponent = GetComponent<Target>();
        traitComponent.UniqueId = UniqueId;
    }
}
