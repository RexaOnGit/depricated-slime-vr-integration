using Godot;
using ImuToXInput;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace SlimeVRIntegration
{
    [Tool]
    public partial class SlimeVRTracker : Node3D
    {
        private string _trackerName;
        //allow tracker name to be set from the editor
        [Export]
        public string TrackerName { get => _trackerName; set => _trackerName = value; }
        private TrackerState _trackerState;

        [Export]
        public SlimeVRInterface Interface { get; set; }

        public SlimeVRTracker()
        {

        }
        public override void _Process(double delta)
        {
            if (!Engine.IsEditorHint())
            {
                //extract position from the associated tracker if it is available
                if (Interface.GetTrackerState(_trackerName,ref _trackerState))
                {
                    Position = Utilities.ConvertSystemVector3ToGodot(_trackerState.Position);
                    //GD.Print(_trackerState.Position);
                }
            }
        }
    }
}
