# SlimeVRIntegration 
A plugin for the Godot engine that allows tracking data from SlimeVR Server to be directly accessed in engine.

**DISCLIAMER: THIS PROJECT IS DECPRECATED AND INCOMPLETE. IT WILL NOT RECIEVE ANY FURTHER DEVELOPMENT OR SUPPORT. USE AT YOUR OWN RISK.**

## Plugin Installation
TBD

## How To Use This Plugin

After the plugin has been added to your Godot project, the custom nodes SlimeVRInterface and SlimeVRTracker will be available. To make use of these nodes:
1. Add the SlimeVRInterface node somewhere in the tree (On the scene you will be using it). The location is not important, but for simplicity, add it directly below the scene's root node.
2. Add a SlimeVRTracker node to the scene, under the node you want its position to be relative to (ie. a character). 
3. Set the Interface property to the SlimeVRInterface node in the scene.
4. Set the TrackerName property to the corresponding tracker in SlimeVR Server. It follows the BODY_PART format. For example, if you want this SlimeVRTracker to follow the left hand tracker in SlimeVR Server, set the property to LEFT_HAND.
5. Repeat steps 2-4 for each SlimeVRTracker you add to the scene.
