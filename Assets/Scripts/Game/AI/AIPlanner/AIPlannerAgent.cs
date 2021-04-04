using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Semantic.Traits;
using Generated.Semantic.Traits;

public class AIPlannerAgent : MonoBehaviour
{
    PlayerHealth health;
    PlayerAmmo ammo;
    BotUtility botUtility;
    Agent traitComponent;

    void Start()
    {
        botUtility = GetComponent<BotUtility>();
        health = botUtility.GetComponent<PlayerHealth>();
        ammo = botUtility.GetComponent<PlayerAmmo>();
        traitComponent = GetComponent<Agent>();

        int uniqueId = (TryGetComponent<AIPlannerTarget>(out var target) ? target.UniqueId : -1);
        traitComponent.UniqueId = uniqueId;

        UpdateParams();
    }

    void Update()
    {
        UpdateParams();
    }

    void UpdateParams()
    {
        traitComponent.Health = health.health;
        traitComponent.Ammo = ammo.ammo;
        traitComponent.Navigating = botUtility.IsNavigating();
    }

    public IEnumerator NavigateTo(GameObject target)
    {
        if (botUtility.NavigateTo(target.transform)) {
            do {
                yield return null;
            } while (botUtility.IsNavigating());
        }
    }

    public IEnumerator NavigateToEnemy()
    {
        var target = botUtility.FindClosestPlayer();
        if (botUtility.NavigateTo(target)) {
            do {
                yield return null;
            } while (botUtility.IsNavigating() && botUtility.GetDistanceToClosestEnemy() >= 10.0f);
        }
    }

    public IEnumerator AttackEnemy()
    {
        var target = botUtility.FindClosestPlayer();
        if (botUtility.Attack(target))
            yield return new WaitForSeconds(1.0f);
    }
}
