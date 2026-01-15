using Godot;
using System;
using System.Globalization;
using Num = System.Numerics;

namespace SlimeVRIntegration;

public static class Utilities
{
    public static Vector3 ConvertSystemVector3ToGodot(Num.Vector3 vector3)
    {
        var vectorX = vector3.X;
        var vectorY = vector3.Y;
        var vectorZ = vector3.Z;
        var godotVector3 = new Vector3(vectorX, vectorY, vectorZ);
        return godotVector3;
    }
}
