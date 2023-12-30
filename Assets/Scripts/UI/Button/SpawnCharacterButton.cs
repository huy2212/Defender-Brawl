using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterButton : BaseButton
{
    [SerializeField] private ISpawnable _iSpawnable;

    private void Awake()
    {
        _iSpawnable = GetComponent<ISpawnable>();
    }

    protected override void OnClick()
    {
        _iSpawnable.Spawn();
        if (_iSpawnable.IsSucceedSpawn)
        {
            StartCoroutine(StopInteractable(_iSpawnable.CoolDownTime));
        }
    }

    private IEnumerator StopInteractable(float coolDownTime)
    {
        button.interactable = false;
        yield return new WaitForSeconds(coolDownTime);
        button.interactable = true;
    }
}
