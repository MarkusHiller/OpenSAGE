﻿using ImGuiNET;
using OpenSage.Audio;

namespace OpenSage.Viewer.UI.Views
{
    internal sealed class WavView : AssetView
    {
        private readonly AudioSource _source;
        private bool _playing;

        public WavView(AssetViewContext context)
        {
            _source = context.Game.Audio.GetFile(context.Entry.FilePath, true);

            AddDisposeAction(() => _source.Dispose());
        }

        public override void Draw(ref bool isGameViewFocused)
        {
            if (_playing)
            {
                if (ImGui.Button("Stop"))
                {
                    _source.Stop();
                    _playing = false;
                }
            }
            else
            {
                if (ImGui.Button("Play"))
                {
                    _source.Play();
                    _playing = true;
                }
            }
        }
    }
}
