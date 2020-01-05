using Godot;
using System;

public class Test : Node2D
{
    private PackedScene bulletScene;

    public override void _Ready()
    {
        bulletScene = GD.Load<PackedScene>("res://GodotBullet.tscn");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        // on click, spawn bullet
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (!mouseEvent.Pressed && mouseEvent.ButtonIndex == (int)ButtonList.Left)
            {
                GodotBullet bullet = (GodotBullet)bulletScene.Instance();
                bullet.Position = mouseEvent.GlobalPosition;
                bullet.Rotation = Mathf.Deg2Rad(50);
                this.AddChild(bullet);
                bullet.LaunchBullet();
            }
        }
    }
}
