using System;
using OpenTK.Graphics.OpenGL;

namespace LitePixel.OpenGL
{
    public class VBO
    {
        const int MaxVertNumb = 100000;
        public readonly int handle;
        public readonly int VertBitSize;
        public readonly VertexInfo vertInfo;

        public VBO(int vertNumb, VertexInfo info){
            if (vertNumb > MaxVertNumb){
                throw new ArgumentException("This vertex buffer contains too many verticies");
            }

            if (vertNumb < 1){
                throw new ArgumentException("This vertex buffer contains less than 1 vertex");
            }

            this.vertInfo = info;
            this.VertBitSize = info.sizeInBytes;
            this.handle = GL.GenBuffer();
            // Create the buffer
            this.BindBuffer();
            GL.BufferData(BufferTarget.ArrayBuffer, vertNumb * VertBitSize, IntPtr.Zero, BufferUsageHint.StaticDraw);
            this.UnbindBuffer();
        }

        /// <summary>
        /// Puts the data in the buffer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">new data</param>
        /// <param name="count">the amount of new vertecies</param>
        public void SetData<T>(T[] data, int count) where T : struct{
            this.BindBuffer();
            GL.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, count * this.VertBitSize, data);
            this.UnbindBuffer();
        }

        /// <summary>
        /// Binds the buffer
        /// </summary>
        public void BindBuffer(){
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.handle);
        }

        /// <summary>
        /// Unbinds the buffer
        /// </summary>
        public void UnbindBuffer(){
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}