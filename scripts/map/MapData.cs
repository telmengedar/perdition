using System;
using System.Collections.Generic;
using Godot;

namespace Perdition.scripts.map {

    public class MapData : Node {
        readonly Dictionary<Vector2i, MapCell> data = new Dictionary<Vector2i, MapCell>();
        
        public MapCell this[int x, int y] {
            get => GetCell(x, y);
            set => SetCell(x, y, value);
        }

        public event Action<int, int, MapCell> CellChanged;
        
        public void SetCell(int x, int y, MapCell cell) {
            data[new Vector2i(x, y)] = cell;
            CellChanged?.Invoke(x, y, cell);
        }

        public MapCell GetCell(int x, int y) {
            data.TryGetValue(new Vector2i(x, y), out MapCell cell);
            return cell;
        }
        
        public void CreateNeighbourhood()
        {
            foreach (var entry in data)
            { 
                entry.Value.Neighbours = (int)Direction.None;

                if (GetCell(entry.Key.X - 1, entry.Key.Y) != null) 
                {
                    entry.Value.Neighbours += (int)Direction.Left;
                }
                if (GetCell(entry.Key.X + 1, entry.Key.Y) != null) 
                { 
                    entry.Value.Neighbours += (int)Direction.Right;
                }
                if (GetCell(entry.Key.X, entry.Key.Y + 1) != null)
                {
                    entry.Value.Neighbours += (int)Direction.Back;
                }
                if (GetCell(entry.Key.X, entry.Key.Y - 1) != null)
                {
                    entry.Value.Neighbours += (int)Direction.Forward;
                }
            }

        }

        public void DrawCells()
        {
            foreach (var entry in data)
            {
                CellChanged?.Invoke(entry.Key.X, entry.Key.Y, entry.Value);
            }
        }
    }
}
