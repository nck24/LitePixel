using System;
using OpenTK.Mathematics;
namespace LitePixel.OpenGL
{
    public struct VertexAttribute
    {
        public readonly string name;
        public readonly int index;
        public readonly int componentCount;
        public readonly int offset;

        public VertexAttribute(string name, int index, int componentCount, int offset){
            this.name = name;
            this.index = index;
            this.componentCount = componentCount;
            this.offset = offset;
        }
    }

    public struct VertexInfo
    {
        public readonly Type type;
        public readonly int sizeInBytes;
        public readonly VertexAttribute[] atribs;

        public VertexInfo(Type type, params VertexAttribute[] atribs){
            this.type = type;
            this.sizeInBytes = 0;
            this.atribs = atribs;

            for (int i = 0; i < this.atribs.Length; i++){
                sizeInBytes += atribs[i].componentCount * sizeof(float);
            }
        }
    }

    public struct VertexPositionColor
    {
        public readonly Vector2 Position;
        public readonly Vector4 Color;
        
        
        public static readonly VertexInfo vertInfo = new VertexInfo(typeof(VertexPositionColor),
            new VertexAttribute("Position", 0, 2, 0),
            new VertexAttribute("Color", 1, 4, 2 * sizeof(float)));

        public VertexPositionColor(Vector2 position, Vector4 color){
            this.Position = position;
            this.Color = color;
        }
    }
}