using Godot;

namespace Perdition.scripts.map {
    public class MapGenerator : Node {
        MapData data;
        
        public override void _Ready() {
            data = GetNode<MapData>("../data");
        }

        public void GenerateMap() {
            data[0, 0] = new MapCell();
            data[-1, 1] = new MapCell();
            data[0, 1] = new MapCell();
            data[1, 1] = new MapCell();
            data[-1, 2] = new MapCell();
            data[0, 2] = new MapCell();
            data[1, 2] = new MapCell();
            data[1, 3] = new MapCell();
            
            data.CreateNeighbourhood();
            
            data.DrawCells();
        }
    }
}
