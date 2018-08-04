﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenSage.Data.Map;
using OpenSage.DebugOverlay;
using OpenSage.Graphics.Cameras;
using OpenSage.Graphics.ParticleSystems;
using OpenSage.Graphics.Rendering;
using OpenSage.Gui;
using OpenSage.Logic;
using OpenSage.Logic.Object;
using OpenSage.Mathematics;
using OpenSage.Scripting;
using OpenSage.Settings;

using Player = OpenSage.Logic.Player;
using Team = OpenSage.Logic.Team;

namespace OpenSage
{
    public sealed class Scene3D : DisposableBase
    {
        private readonly CameraInputMessageHandler _cameraInputMessageHandler;
        private CameraInputState _cameraInputState;

        private readonly SelectionMessageHandler _selectionMessageHandler;

        private readonly ActionMessageHandler _actionMessageHandler;

        private readonly DebugMessageHandler _debugMessageHandler;

        public SelectionGui SelectionGui { get; }

        private readonly ParticleSystemManager _particleSystemManager;

        public CameraComponent Camera { get; }

        public ICameraController CameraController { get; set; }

        public MapFile MapFile { get; set; }

        public Terrain.Terrain Terrain { get; }

        public MapScriptCollection Scripts { get; }

        public GameObjectCollection GameObjects { get; }

        public WaypointCollection Waypoints { get; set; }
        public WaypointPathCollection WaypointPaths { get; set; }

        public WorldLighting Lighting { get; }

        private readonly List<Team> _teams;
        public IReadOnlyList<Team> Teams => _teams;

        // TODO: Move these to a World class?
        // TODO: Encapsulate this into a custom collection?
        public IReadOnlyList<Player> Players => _players;
        private List<Player> _players;
        public Player LocalPlayer { get; private set; }
        public DebugOverlay.DebugOverlay DebugOverlay { get; private set; }
        public Pathfinder.Pathfinder Pathfinder { get; }

        internal IEnumerable<AttachedParticleSystem> GetAllAttachedParticleSystems()
        {
            foreach (var gameObject in GameObjects.Items)
            {
                foreach (var attachedParticleSystem in gameObject.GetAllAttachedParticleSystems())
                {
                    yield return attachedParticleSystem;
                }
            }
        }

        public Scene3D(
            Game game,
            ICameraController cameraController,
            MapFile mapFile,
            Terrain.Terrain terrain,
            MapScriptCollection scripts,
            GameObjectCollection gameObjects,
            WaypointCollection waypoints,
            WaypointPathCollection waypointPaths,
            WorldLighting lighting,
            Player[] players,
            Team[] teams)
        {
            Camera = new CameraComponent(game);
            CameraController = cameraController;

            MapFile = mapFile;
            Terrain = terrain;
            Scripts = scripts;
            GameObjects = AddDisposable(gameObjects);
            Waypoints = waypoints;
            WaypointPaths = waypointPaths;
            Lighting = lighting;

            SelectionGui = new SelectionGui();
            _selectionMessageHandler = new SelectionMessageHandler(game.Selection);
            game.InputMessageBuffer.Handlers.Add(_selectionMessageHandler);
            AddDisposeAction(() => game.InputMessageBuffer.Handlers.Remove(_selectionMessageHandler));

            _actionMessageHandler = new ActionMessageHandler(game.Action);
            game.InputMessageBuffer.Handlers.Add(_actionMessageHandler);
            AddDisposeAction(() => game.InputMessageBuffer.Handlers.Remove(_actionMessageHandler));

            _cameraInputMessageHandler = new CameraInputMessageHandler();
            game.InputMessageBuffer.Handlers.Add(_cameraInputMessageHandler);
            AddDisposeAction(() => game.InputMessageBuffer.Handlers.Remove(_cameraInputMessageHandler));

            DebugOverlay = new DebugOverlay.DebugOverlay(game, this);
            game.GameSystems.Add(DebugOverlay);
            DebugOverlay.Initialize();
            _debugMessageHandler = new DebugMessageHandler(DebugOverlay);
            game.InputMessageBuffer.Handlers.Add(_debugMessageHandler);
            AddDisposeAction(() => game.InputMessageBuffer.Handlers.Remove(_debugMessageHandler));

            _particleSystemManager = AddDisposable(new ParticleSystemManager(game, this));

            _players = players.ToList();
            _teams = teams.ToList();
            // TODO: This is completely wrong.
            LocalPlayer = _players.FirstOrDefault();

            Pathfinder = new Pathfinder.Pathfinder(mapFile);
            AddDisposeAction(() => Pathfinder.Dispose());
            Pathfinder.RemoveGridPointsForGameObjects(GameObjects);
            DebugOverlay.AddGridPoints(Pathfinder.PassabilPoints);
        }

        public void SetPlayers(IEnumerable<Player> players, Player localPlayer)
        {
            _players = players.ToList();

            if (!_players.Contains(localPlayer))
            {
                throw new ArgumentException(
                    $"Argument {nameof(localPlayer)} should be included in {nameof(players)}",
                    nameof(localPlayer));
            }

            LocalPlayer = localPlayer;

            // TODO: What to do with teams?
            // Teams refer to old Players and therefore they will not be collected by GC
            // (+ objects will have invalid owners)
        }

        internal void Update(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects.Items)
            {
                gameObject.Update(gameTime);
            }

            _particleSystemManager.Update(gameTime);

            _cameraInputMessageHandler.UpdateInputState(ref _cameraInputState);
            CameraController.UpdateCamera(Camera, _cameraInputState, gameTime);
        }

        internal void BuildRenderList(RenderList renderList, CameraComponent camera)
        {
            Terrain?.BuildRenderList(renderList);

            foreach (var gameObject in GameObjects.Items)
            {
                gameObject.BuildRenderList(renderList, camera);
            }

            _particleSystemManager.BuildRenderList(renderList);
        }

        // This is for drawing 2D elements which depend on the Scene3D, e.g tooltips and health bars.
        internal void Render(DrawingContext2D drawingContext)
        {
            SelectionGui.Draw(drawingContext, Camera);
            DebugOverlay.Draw(drawingContext, Camera);
        }
    }
}
