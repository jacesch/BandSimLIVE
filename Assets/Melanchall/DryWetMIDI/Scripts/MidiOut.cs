using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Common;

public class MidiOut : MonoBehaviour
{
	public int midiChannel = 0;
	public string midiDeviceName = "IAC Driver Unity MIDI";
	public static MidiOut Instance;

	private OutputDevice outputDevice;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
		
		try
		{
			outputDevice = OutputDevice.GetByName(midiDeviceName);
			outputDevice.PrepareForEventsSending();
		}
		catch
		{
			Debug.LogError("MIDI device not found: " + midiDeviceName);
		}
	}

	void OnDestroy()
	{
		outputDevice?.Dispose();
	}

	public void NoteOn(int noteNumber, int velocity = 100)
	{
		if (outputDevice == null)
			return;

		var noteOnEvent = new NoteOnEvent((SevenBitNumber)noteNumber, (SevenBitNumber)velocity)
		{
			Channel = (FourBitNumber)midiChannel
		};
		
		outputDevice.SendEvent(noteOnEvent);
	}

	public void NoteOff(int noteNumber)
	{
		if (outputDevice == null)
			return;

		var noteOffEvent = new NoteOffEvent((SevenBitNumber)noteNumber, (SevenBitNumber)0)
		{
			Channel = (FourBitNumber)midiChannel
		};

		outputDevice.SendEvent(noteOffEvent);
	}

	public void SendCC(int ccNumber, float normalizedValue)
	{
		if (outputDevice == null)
			return;
		
		int midiValue = Mathf.Clamp(Mathf.RoundToInt(normalizedValue * 127f), 0, 127);
		
		var ccEvent = new ControlChangeEvent((SevenBitNumber)ccNumber, (SevenBitNumber)midiValue)
		{
			Channel = (FourBitNumber)midiChannel
		};

		outputDevice.SendEvent(ccEvent);
	}

	public void ProgramChange(int programNumber)
	{
		if (outputDevice == null)
			return;
		
		var programEvent = new ProgramChangeEvent((SevenBitNumber)programNumber)
		{
			Channel = (FourBitNumber)midiChannel
		};

		outputDevice.SendEvent(programEvent);
	}    
}
