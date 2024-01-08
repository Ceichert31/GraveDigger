using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private PlayerControls playerControls;
    private PlayerControls.InteractActions interact;

    private Grave currentGrave;

    [Header("Interact Settings")]
    [SerializeField] private TextMeshProUGUI textPrompt;

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();
        interact = playerControls.Interact;
    }
    private void OnEnable()
    {
        interact.Enable();
    }
    private void OnDisable()
    {
        interact.Disable();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (other.gameObject.GetComponent<Grave>() != null)
            {
                currentGrave = other.gameObject.GetComponent<Grave>();
                textPrompt.text = currentGrave.text;
                if (interact.Interact.IsPressed())
                {
                    currentGrave.StartAnimation();
                    textPrompt.text = "";
                }
            }
            else if (other.gameObject.GetComponent<Coffin>() != null)
            {
                textPrompt.text = "[E] Collect";
                if (interact.Interact.IsPressed())
                {
                    GameManager.collected?.Invoke();
                    Destroy(other.gameObject);
                    textPrompt.text = "";
                }
            }
            else if (other.gameObject.GetComponent<House>() != null)
            {
                textPrompt.text = "[E] Enter";
                if (interact.Interact.IsPressed())
                {
                    SceneLoader.loadScene(2);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        textPrompt.text = "";
    }
}
