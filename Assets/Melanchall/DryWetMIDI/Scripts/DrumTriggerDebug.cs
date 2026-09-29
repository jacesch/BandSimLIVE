using UnityEngine;

public class DrumTriggerDebug : MonoBehaviour
{
    // MIDI note for the drum (just for reference)
    public int midiNote = 38;

    // Cooldown so multiple hits in the same frame don’t spam
    public float hitCooldown = 0.1f;
    private bool readyToPlay = true;

    void OnTriggerEnter(Collider other)
    {
        if (!readyToPlay) return;
        readyToPlay = false;

        // Log everything that hits this drum
        Debug.Log($"[DEBUG] {gameObject.name} hit by {other.name}");

        // Optional: show velocity if the collider has a HandDrumCollider
        var controller = other.GetComponent<HandDrumCollider>();
        if (controller != null)
        {
            Debug.Log($"[DEBUG] {other.name} velocity magnitude: {controller.velocity.magnitude}");
        }
        else
        {
            Debug.Log($"[DEBUG] {other.name} has no HandDrumCollider");
        }

        // Reset readyToPlay after cooldown
        Invoke(nameof(ResetDrum), hitCooldown);
    }

    void ResetDrum()
    {
        readyToPlay = true;
    }
}
