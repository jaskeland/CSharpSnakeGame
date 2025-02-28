﻿using SFML.Graphics;
using System.Collections.Generic;

namespace Game.Snake.Rendering
{
    public class ListOfDrawables : Drawable
    {
        private List<Drawable> _drawables;

        public ListOfDrawables()
        {
            _drawables = new List<Drawable>();
        }

        public void Add(Drawable drawable)
        {
            _drawables.Add(drawable);
        }

        public void Clear()
        {
            _drawables.Clear();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var item in _drawables)
            {
                target.Draw(item, states);
            }
        }
    }
}