using UnityEngine;
using System.Collections;

public class DrumTrigger : MonoBehaviour
{
	public int midiNote = 38;
	public float minHitVelocity = 0.5f;
	public float maxHitVelocity = 4f;

	private bool readyToPlay = true;

	void OnTriggerEnter(Collider other)
	{
		HandDrumCollider hand = other.GetComponent<HandDrumCollider>();
		if (hand == null)
			return;

		float speed = hand.velocity.magnitude;
		if (speed < minHitVelocity)
			return;
		if (!readyToPlay)
			return;

		readyToPlay = false;
		Invoke(nameof(ResetDrum), 0.1f);

		int vel = Mathf.RoundToInt(Mathf.InverseLerp(minHitVelocity, maxHitVelocity, speed) * 127f);
		vel = Mathf.Clamp(vel, 1, 127);

		Debug.Log($"Triggering MIDI note {midiNote} with velocity {vel}");
		MidiOut.Instance.NoteOn(midiNote, vel);
		MidiOut.Instance.NoteOff(midiNote);
	}

	void ResetDrum()
	{
		readyToPlay = true;
	}
}
