using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace DungeonSlime.GameObjects
{
    public class Slime
    {
        // A constant value that represent the amount of time to wait between movment updates.
        private static readonly TimeSpan s_movementTime = TimeSpan.FromMilliseconds(200);

        // The amount of time that has elapsed since the last movement update.
        private TimeSpan _movementTimer;

        // Normalized value (0-1) representing progress between movement ticks for visual interpolation.
        private float _movementProgress;

        // The next direction to apply to the head of the slime chain during the next movement update.
        private Vector2 _nextDirection;

        // The number of pixels to move the head segment during the movement cycle.
        private float _stride;

        // Tracks the segments of the slime chain.
        private List<SlimeSegment> _segments;

        // The AnimatedSprite used when drawing each slime segment.
        private AnimatedSprite _sprite;

        /// <summary>
        /// Event that is raised if it is detected that the head segment of the slime has collided with a body segment.
        /// </summary>
        public event EventHandler BodyCollision;
    }
}
