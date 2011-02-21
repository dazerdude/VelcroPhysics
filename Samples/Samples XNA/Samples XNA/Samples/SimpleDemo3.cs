﻿using System.Text;
using FarseerPhysics.DebugViews;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FarseerPhysics.SamplesFramework
{
    internal class SimpleDemo3 : PhysicsGameScreen, IDemoScreen
    {
        #region IDemoScreen Members

        public string GetTitle()
        {
            return "Multiple fixtures and static bodies";
        }

        public string GetDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("This demo shows a single body with multiple shapes attached.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("This demo also shows the use of static bodies.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("GamePad:");
            sb.AppendLine("  - Rotate agent: left and right triggers");
            sb.AppendLine("  - Move agent: right thumbstick");
            sb.AppendLine("  - Move cursor: left thumbstick");
            sb.AppendLine("  - Grab object (beneath cursor): A button");
            sb.AppendLine("  - Drag grabbed object: left thumbstick");
            sb.AppendLine("  - Exit to menu: Back button");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Keyboard:");
            sb.AppendLine("  - Rotate agent: left and right arrows");
            sb.AppendLine("  - Move agent: A,S,D,W");
            sb.AppendLine("  - Exit to menu: Escape");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Mouse / Touchscreen");
            sb.AppendLine("  - Grab object (beneath cursor): Left click");
            sb.AppendLine("  - Drag grabbed object: move mouse / finger");
            return sb.ToString();
        }

        #endregion

        private Agent _agent;
        private Body[] _obstacles = new Body[5];

        public override void LoadContent()
        {
            base.LoadContent();

            World.Gravity = new Vector2(0f, 20f);

            new Border(World, ScreenManager.GraphicsDevice.Viewport);

            _agent = new Agent(World, new Vector2(-6.9f, -11f));

            LoadObstacles();

            SetUserAgent(_agent.Body, 1000f, 400f);
        }

        private void LoadObstacles()
        {
            for (int i = 0; i < 5; i++)
            {
                _obstacles[i] = BodyFactory.CreateRectangle(World, 5f, 1f, 1f);
                _obstacles[i].IsStatic = true;
                _obstacles[i].Restitution = 0.2f;
                _obstacles[i].Friction = 0.2f;
            }

            _obstacles[0].Position = new Vector2(-5f, 9f);
            _obstacles[1].Position = new Vector2(15f, 6f);
            _obstacles[2].Position = new Vector2(10f, -3f);
            _obstacles[3].Position = new Vector2(-10f, -9f);
            _obstacles[4].Position = new Vector2(-17f, 0f);
        }
    }
}