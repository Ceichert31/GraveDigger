using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int health = 3;
    private bool damageDelay;
    private float waitTime;

    private void Update()
    {
        switch (health)
        {
            case 3:
                sprite.color = Color.white;
                break;
            case 2:
                sprite.color = Color.red;
                break;
            case 1:
                sprite.color = Color.black;
                break;
            case 0:
                SceneLoader.loadScene(0);
                break;
        }

        //Health Regen
        if (health < 3)
        {
            waitTime += Time.deltaTime;
            if (waitTime >= 10)
            {
                health++;
                waitTime = 0;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (damageDelay)
            return;

        if (other.gameObject.layer == 9)
        {
            health--;
            waitTime = 0;
            damageDelay = true;
            Invoke(nameof(DamageReset), 1);
        }
            
    }

    private void DamageReset() => damageDelay = false;

}
