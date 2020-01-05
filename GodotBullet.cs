using Godot;
using System;

public class GodotBullet : RigidBody2D
{
    public float MaxDistance = 600;
    public float Impulse = 1200;
    public float Life = 1;

    private Timer timer;
    private Vector2 originalPosition;

    public void LaunchBullet(){
        originalPosition = this.Position;
        this.ApplyCentralImpulse(new Vector2(this.Transform.x.Normalized() * Impulse));

        timer = new Timer();
        this.AddChild(timer);
        timer.WaitTime = this.Life;
        timer.OneShot = true;
        timer.Connect("timeout",this,nameof(OnTimeToDie));
        timer.Start();
    }

    public override void _PhysicsProcess(float delta){
        float distanceTravelled = this.Position.DistanceTo(this.originalPosition);
        if (distanceTravelled > this.MaxDistance)
            this.QueueFree();
    }

    public void OnTimeToDie(){
        this.QueueFree();
    }

}
