using System.Collections.Generic;
using System.Dynamic;
using SFML.System;

public class VectorList
{

    public static List<Vector2f> PositionList { get; private set; }
    public static int index { get; set; }
    static VectorList()
    {
        PositionList = new List<Vector2f>();
        AddPositions();
    }

    public static void AddPositions()
    {
        PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.05f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.1f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.15000000000000002f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.2f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.25f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.30000000000000004f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.35000000000000003f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.4f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.45f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.5f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.55f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.6000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.65f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.7000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.75f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8500000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.9f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.05f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.05f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.1f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.15000000000000002f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.2f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.25f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.30000000000000004f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.35000000000000003f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.4f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.45f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.5f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.55f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.6000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.65f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.7000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.75f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8500000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.9f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.1f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.05f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.1f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.15000000000000002f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.2f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.25f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.30000000000000004f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.35000000000000003f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.4f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.45f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.5f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.55f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.6000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.65f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.7000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.75f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8500000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.9f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.15000000000000002f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.05f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.1f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.15000000000000002f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.2f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.25f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.30000000000000004f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.35000000000000003f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.4f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.45f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.5f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.55f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.6000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.65f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.7000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.75f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8500000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.9f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.2f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.05f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.1f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.15000000000000002f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.2f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.25f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.30000000000000004f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.35000000000000003f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.4f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.45f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.5f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.55f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.6000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.65f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.7000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.75f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8500000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.9f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.25f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.05f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.1f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.15000000000000002f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.2f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.25f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.30000000000000004f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.35000000000000003f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.4f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.45f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.5f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.55f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.6000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.65f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.7000000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.75f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.8500000000000001f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * 0.9f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *0.30000000000000004f));
    }
}