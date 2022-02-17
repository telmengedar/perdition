using Godot;
using Perdition.scripts.map;

namespace Perdition.scripts.editor {

    public class GenerateMapButton : Button {
        MapGenerator generator;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {
            generator = GetNode<MapGenerator>("../../map/generator");
        }

        public override void _Input(InputEvent @event) {
            if (@event is InputEventKey key) {
                if (key.Scancode == (int)KeyList.G)
                    generator.GenerateMap();
            }
        }

        public override void _Pressed() {
            base._Pressed();
            generator.GenerateMap();
        }
    }
}
