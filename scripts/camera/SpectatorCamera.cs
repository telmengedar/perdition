using Godot;

namespace Perdition.scripts.camera {
    public class SpectatorCamera : Camera {
        
        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {
            Input.SetMouseMode(Input.MouseMode.Captured);
        }

        public override void _Input(InputEvent @event) {
            base._Input(@event);
            if (@event is InputEventMouseMotion mouseMotion) {
                Rotation += new Vector3(-mouseMotion.Relative.y * 0.008f, -mouseMotion.Relative.x * 0.008f, 0.0f);
            }

            if (@event is InputEventKey keyEvent) {
                
            }
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            Vector3 direction=Vector3.Zero;

            if (Input.IsKeyPressed((int)KeyList.A))
                direction -= Transform.basis.x;
            if (Input.IsKeyPressed((int)KeyList.D))
                direction += Transform.basis.x;
            if (Input.IsKeyPressed((int)KeyList.W))
                direction -= Transform.basis.z;
            if (Input.IsKeyPressed((int)KeyList.S))
                direction += Transform.basis.z;

            Translation += direction.Normalized() * delta * 5.0f;
        }
    }
}
