﻿using System.Collections.Generic;
using System.Numerics;

namespace OpenSage.Logic.Orders
{
    public sealed class OrderProcessor
    {
        private readonly Game _game;

        public OrderProcessor(Game game)
        {
            _game = game;
        }

        public void Process(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                switch (order.OrderType)
                {
                    // TODO

                    case OrderType.BuildObject:
                        var objectDefinitionId = order.Arguments[0].Value.Integer;
                        var objectDefinition = _game.ContentManager.IniDataContext.Objects[objectDefinitionId - 1];
                        var position = order.Arguments[1].Value.Position;
                        var angle = order.Arguments[2].Value.Float;
                        var gameObject = _game.Scene3D.GameObjects.Add(objectDefinition, _game.Scene3D.Players[(int)order.PlayerIndex]);
                        gameObject.Transform.Translation = position;
                        gameObject.Transform.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, angle);
                        break;

                    case OrderType.SetCameraPosition:
                        _game.Scene3D.CameraController.TerrainPosition = order.Arguments[0].Value.Position;
                        break;

                    case OrderType.Unknown27:
                        _game.EndGame();
                        break;
                }
            }
        }
    }
}
