using System;
using OpenTK.Graphics.OpenGL;

namespace LitePixel.OpenGL
{
    public class VBO
    {
        const int MaxVertNumb = 100000;
        public readonly int handle;
        public readonly int VertBitSize;

        public VBO(int vertNumb, int VertBitSize){
            if (vertNumb > MaxVertNumb){
                throw new ArgumentException("This vertex buffer contains too many verticies");
            }

            if (vertNumb < 1){
                throw new ArgumentException("This vertex buffer contains less than 1 vertex");
            }

            this.VertBitSize = VertBitSize;
            this.handle = GL.GenBuffer();
            // Create the buffer
            this.BindBuffer();
            GL.BufferData(BufferTarget.ArrayBuffer, vertNumb * VertBitSize, IntPtr.Zero, BufferUsageHint.StaticDraw);
            this.UnbindBuffer();
        }

        public void BindBuffer(){
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.handle);
        }

        public void UnbindBuffer(){
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}