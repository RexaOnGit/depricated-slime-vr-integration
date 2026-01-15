using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Godot;
using ImuToXInput;
using SlimeImuProtocol;

namespace SlimeVRIntegration
{
    [Tool]
    public partial class SlimeVRInterface : Node
    {
        private SlimeVRClient _slimeVrClient;
        private Dictionary<string, TrackerState> _trackerList = new();
        public Dictionary<string, TrackerState> TrackerList { get => _trackerList;}
        private bool _clientIsRunning = false;
        public bool ClientIsRunning { get => _clientIsRunning; }

        public SlimeVRInterface()
        {
            _slimeVrClient = new SlimeVRClient();
            _slimeVrClient.UsesSkeletalRotation = false;
            _slimeVrClient.NewDataReceived += delegate { ClientLoop(); };
            _slimeVrClient.Start();
            
            //Prevent other classes from 
            DelayAccess().
                ContinueWith(t => Console.WriteLine(t.Exception), 
                    TaskContinuationOptions.OnlyOnFaulted);
        }

        ~SlimeVRInterface()
        {
            _slimeVrClient = new SlimeVRClient();
        }

        private async Task DelayAccess()
        {
            await Task.Delay(100);
            _clientIsRunning = true;
        }

        //update the list of trackers and their states when data is received
        public void ClientLoop()
        {
            _trackerList = _slimeVrClient.Trackers;
        }

        //try to get TrackerState from an entry in _trackerList with the dictionary lable "name"
        public bool GetTrackerState(string name, ref TrackerState state)
        {
            //wait until the client is fully initialized
            if (_clientIsRunning)
            {
                //look for the tracker with "name"
                if (!_trackerList.TryGetValue(name, out state))
                {
                    //indicate missing data
                    //replace with a signal to indicate to the engine that tracker data is missing
                    GD.Print($"Key = \"{name}\" is not found.");
                    //opperation failed because the tracker is not present
                    return false;
                }
                else
                {
                    //opperation succeeded
                    return true;
                }
            }
            else
            {
                //opperation failed because client is not yet running
                return false;
            }
        }

        public override void _EnterTree()
        {
            //GD.Print("Hello World");
        }

        public override void _ExitTree()
        {

        }
    }
}