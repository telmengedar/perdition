using System.Collections.Generic;
using Godot;

namespace Perdition.scripts.map {

    public class CellMeshes : Spatial {
        MapData data;
        readonly Dictionary<Vector2i, MeshInstance> meshes = new Dictionary<Vector2i, MeshInstance>();

        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {
            data = GetNode<MapData>("../data");
            data.CellChanged += OnCellChanged;
        }

        void OnCellChanged(int x, int y, MapCell cell) {
            if (cell == null) {
                meshes.TryGetValue(new Vector2i(x, y), out MeshInstance mesh);
                if (mesh != null)
                    RemoveChild(mesh);
                meshes.Remove(new Vector2i(x, y));
            }
            else {
                MeshInstance mesh = GenerateMesh(cell);
                mesh.Translation = new Vector3(x, 0, y);
                meshes[new Vector2i(x, y)] = mesh;
                AddChild(mesh);
            }
        }

        MeshInstance GenerateMesh(MapCell cell) {
            SurfaceTool tool = new SurfaceTool();
            tool.Begin(Mesh.PrimitiveType.Triangles);
            
            tool.AddNormal(Vector3.Up);
            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,0.5f));

            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,0.5f));
            tool.AddUv(new Vector2(0.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,0.5f));

            tool.AddNormal(Vector3.Down);
            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,-0.5f));

            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,-0.5f));
            tool.AddUv(new Vector2(0.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,-0.5f));
            
            tool.AddNormal(Vector3.Right);
            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));

            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));
            tool.AddUv(new Vector2(0.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,-0.5f));

            tool.AddNormal(Vector3.Left);
            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,-0.5f));

            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,-0.5f));
            tool.AddUv(new Vector2(0.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,0.5f));
            
            tool.AddNormal(Vector3.Back);
            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,-0.5f));

            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,-0.5f,-0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,-0.5f));
            tool.AddUv(new Vector2(0.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,-0.5f));

            tool.AddNormal(Vector3.Forward);
            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));

            tool.AddUv(new Vector2(0.0f,0.0f));
            tool.AddVertex(new Vector3(0.5f,-0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,0.0f));
            tool.AddVertex(new Vector3(-0.5f,0.5f,0.5f));
            tool.AddUv(new Vector2(1.0f,1.0f));
            tool.AddVertex(new Vector3(0.5f,0.5f,0.5f));

            return new MeshInstance {
                Mesh = tool.Commit()
            };
        }
    }
}