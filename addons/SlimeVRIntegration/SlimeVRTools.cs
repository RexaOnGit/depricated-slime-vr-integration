#if TOOLS
using Godot;
using System;

namespace SlimeVRIntegration
{
	//requires [Tool] annotation so that the plugin's features are available in the editor
	[Tool]
	public partial class SlimeVRTools : EditorPlugin
	{
		public override void _EnterTree()
		{
			var script = GD.Load<Script>("res://addons/SlimeVRIntegration/SlimeVRInterface.cs");
			var texture = GD.Load<Texture2D>("res://addons/SlimeVRIntegration/Node.svg");
			AddCustomType("SlimeVRInterface", "Node", script, texture);

			script = GD.Load<Script>("res://addons/SlimeVRIntegration/SlimeVRTracker.cs");
			texture = GD.Load<Texture2D>("res://addons/SlimeVRIntegration/Node3D.svg");
			AddCustomType("SlimeVRTracker", "Node3D", script, texture);
		}

		public override void _ExitTree()
		{
			// Clean-up of the plugin goes here.
			RemoveCustomType("SlimeVRInterface");
			RemoveCustomType("SlimeVRTracker");
		}
	}
}
#endif
