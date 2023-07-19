using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace LitePixel
{
    public class Window : GameWindow
    {
        public Window(int width = 1280, int height = 720, string title = "Maze Generator")
            : base(new GameWindowSettings(){
                UpdateFrequency = 60,
            },
                new NativeWindowSettings(){
                Title = title,
                Size = new Vector2i(width, height),
                WindowBorder = WindowBorder.Fixed,
                StartVisible = false,
                StartFocused = false,
                API = ContextAPI.OpenGL,
                Profile = ContextProfile.Core,
                APIVersion = new Version(3, 3)
                })
                {
            this.CenterWindow();
            SetUp();
        }

        void SetUp(){

        }
    }
}