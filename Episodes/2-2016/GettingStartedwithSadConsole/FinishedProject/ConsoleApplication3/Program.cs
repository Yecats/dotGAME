using System;
using Console = SadConsole.Consoles.Console;
using SadConsole.Consoles;
using Microsoft.Xna.Framework;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup the engine and creat the main window.
            SadConsole.Engine.Initialize("IBM.font", 80, 25);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Engine.EngineStart += Engine_EngineStart;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Engine.EngineUpdated += Engine_EngineUpdated;

            // Start the game.
            SadConsole.Engine.Run();
        }

        private static void Engine_EngineStart(object sender, EventArgs e)
        {
            var defaultConsole = (Console)SadConsole.Engine.ActiveConsole;
            defaultConsole.TextSurface = new TextSurface(80, 12);
            defaultConsole.Fill(Color.Blue, Color.Yellow, 0);
            defaultConsole.Print(1, 1, "Hello from console 1");

            var console2 = new Console(80, 13);
            console2.Position = new Point(0, 12);
            console2.Fill(Color.Yellow, Color.Blue, 0);
            console2.Print(1, 1, "Hello from console 2");

            SadConsole.Engine.ConsoleRenderStack.Add(console2);

            SadConsole.Engine.ToggleFullScreen();


        }

        private static void Engine_EngineUpdated(object sender, EventArgs e)
        {
            if (SadConsole.Engine.Keyboard.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
                SadConsole.Engine.MonoGameInstance.Exit();
        }
    }
}