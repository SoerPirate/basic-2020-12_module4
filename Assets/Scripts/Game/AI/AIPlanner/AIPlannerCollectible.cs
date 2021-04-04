using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generated.Semantic.Traits;

public class AIPlannerCollectible : MonoBehaviour
{
    Collectible traitComponent;
    AmmoBox ammoBox;
    HealthBox healthBox;

    void Awake()
    {
        ammoBox = GetComponent<AmmoBox>();
        healthBox = GetComponent<HealthBox>();
        traitComponent = GetComponent<Collectible>();
    }

    void Start()
    {
        UpdateParams();
    }

    void Update()
    {
        UpdateParams();
    }

    void UpdateParams()
    {
        if (ammoBox != null)
            traitComponent.Active = ammoBox.IsActive;
        else if (healthBox != null)
            traitComponent.Active = healthBox.IsActive;
    }
}
