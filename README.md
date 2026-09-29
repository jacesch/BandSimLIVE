# BandSimLIVE

### A VR-to-MIDI Drumming Interface

BandSimLIVE is a single-user virtual reality drumming prototype built in Unity. It maps Meta Quest controller interactions and strike velocities to MIDI messages, triggering drum sounds in Ableton Live through C# and DryWetMIDI.

Developed by **Jacey Schell** for **MUE251: Electronic Production Techniques**, the project explores how virtual instruments can support expressive music performance without a physical drum kit.

## Overview

The prototype connects a virtual drum kit to a DAW-based sound engine. Players interact with drums using Meta Quest controllers, while Unity handles collision detection and movement-to-MIDI mapping. Ableton Live receives the MIDI messages and produces the drum sounds.

The broader goal is a shared virtual space for music creation. The current prototype focuses on single-user, controller-based drumming; multiplayer, controller-free hand tracking, and haptic gloves are future work.

## Features

- **Interactive virtual drum kit:** A low-poly kit built from Unity primitives.
- **Collision-based triggering:** Drum interactions map to MIDI note events.
- **Velocity-sensitive performance:** Controller strike velocities map to MIDI velocity values.
- **Unity-to-DAW routing:** C# scripts use DryWetMIDI to send messages through a virtual MIDI port.
- **Ableton sound generation:** A MIDI instrument track hosts the Corvaire Kit drum instrument.
- **Drummer-oriented panning:** Individual drums are panned to reflect the player's perspective.

## Signal Flow

```text
Meta Quest 3 controllers
          |
          v
Unity: controller tracking and drum collisions
          |
          v
C# / DryWetMIDI: MIDI note and velocity mapping
          |
          v
Virtual MIDI port
          |
          v
Ableton Live: MIDI instrument track / Corvaire Kit
          |
          v
Audio output
```

Unity handles the interaction and MIDI generation. Ableton Live handles the instrument playback and audio processing.

## Development Environment

| Component | Version or role |
| --- | --- |
| Unity | 6.2 / 6000.2.0f1 |
| Ableton Live | Suite 12.2.5 |
| Meta Quest 3 | Headset and controllers |
| C# | Interaction logic and MIDI mapping |
| DryWetMIDI | .NET MIDI library |
| Virtual MIDI port | Routing between Unity and Ableton Live |
| Corvaire Kit | Ableton drum instrument |

These are the tools used for the documented prototype. Compatibility with other versions, headsets, and DAWs has not been established.

## Setup and Routing

The following describes the prototype's routing workflow. Running it requires the Unity project and interaction scripts in addition to the Ableton session. The Ableton session and report alone are not a standalone VR application.

1. **Prepare the Unity environment.** Open the project in the documented Unity version and configure the Meta Quest headset and controllers for the project's XR workflow.
2. **Configure MIDI output.** Make DryWetMIDI available to the Unity scripts and configure their output to use an available virtual MIDI port.
3. **Prepare Ableton Live.** Open the accompanying Live Set or create a MIDI track with a drum instrument. Ensure the required instrument content is installed and any sample references resolve.
4. **Route the MIDI input.** Enable the virtual port as a MIDI track input in Ableton's MIDI settings. Select it on the drum track and enable input monitoring, or arm the track with monitoring set to Auto.
5. **Check the note mapping.** Confirm that the notes sent by the Unity drums correspond to the intended sounds in the Ableton drum instrument.
6. **Run and verify.** Start the Unity experience, strike a virtual drum, and check for incoming MIDI and audio output in Ableton. Compare softer and harder strikes to verify velocity response.
7. **Adjust audio settings.** Choose an audio buffer size that balances responsiveness and stable playback on the host computer.

Exact MIDI port names and XR configuration depend on the host setup. Follow the project's routing walkthrough for the demonstrated configuration.

## Demonstration and Technical Report

A four-minute walkthrough explains the routing process and demonstrates the prototype in operation. The accompanying technical report documents the system architecture, implementation decisions, virtual instrument construction, and development challenges.

**Report title:** *BandSimLIVE: Design and Implementation of a VR-to-MIDI Drumming Interface*

<!-- Add the published walkthrough URL and the final PDF's repository-relative link here. -->

## Scope and Limitations

- The current experience supports one player using Meta Quest controllers.
- Controller-free hand tracking, motion-tracked gloves, and multiplayer synchronization are not implemented in the documented prototype.
- Audio is generated in Ableton Live through the host computer's MIDI and audio routing; this is not a standalone Quest audio application.
- The project was designed with live responsiveness in mind, but measured end-to-end latency results are not included in the original report.
- Reproducing the experience requires the Unity implementation, MIDI routing configuration, and the appropriate Ableton instrument content.

## Future Development

- Expand the selection of playable virtual instruments.
- Add MIDI pedals for kick drum and hi-hat control.
- Explore controller-free hand tracking and motion-tracked gloves.
- Investigate haptic feedback using compatible hardware.
- Develop networking and synchronization for multi-user performance.
- Measure end-to-end latency and evaluate performance across different configurations.

## Background and Acknowledgments

BandSimLIVE was inspired in part by **WAM Jam Party** and its approach to embodied virtual instruments, presented by Michel Buffa, Marco Winckler, and Amad Mir-sadjadi at the Web Audio Conference 2025. The project explores related interaction ideas within a Unity-to-Ableton workflow.

MIDI functionality uses [DryWetMIDI](https://github.com/melanchall/drywetmidi). The original report provides additional references and context.

## Author

**Jacey Schell**  
Frost School of Music, University of Miami  
MUE251: Electronic Production Techniques - December 2025
MUE540: Music in the Metaverse - December 2025
