using System;
using OpenTK.Mathematics;
namespace LitePixel.OpenGL
{
    // This is a attribute of a vertex
    public struct VertexAttribute
    {
        public readonly string name;
        public readonly int index;
        public readonly int componentCount;
        public readonly int offset;

        /// <summary>
        /// Creates a vertex attribute
        /// </summary>
        /// <param name="name">The name of the attribute</param>
        /// <param name="index">the index of the attribute</param>
        /// <param name="componentCount">the amount of components</param>
        /// <param name="offset">the offset from previous attributes (in bytes)</param>
        public VertexAttribute(string name, int index, int componentCount, int offset){
            this.name = name;
            this.index = index;
            this.componentCount = componentCount;
            this.offset = offset;
        }
    }

    // info of a specific vertex
    public struct VertexInfo
    {
        public readonly Type type;
        public readonly int sizeInBytes;
        public readonly VertexAttribute[] atribs;

        /// <summary>
        /// Creates the info of a specific vertex
        /// </summary>
        /// <param name="type">The type of the vertex</param>
        /// <param name="atribs">All the attributes of this vertex</param>
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

        /// <summary>
        /// Creates the VertexPosition vertex
        /// </summary>
        /// <param name="position">The position of the vertex (x, y)</param>
        /// <param name="color">The color of the vertex (RGBA)</param>
        public VertexPositionColor(Vector2 position, Vector4 color){
            this.Position = position;
            this.Color = color;
        }
    }
}