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
        private List<SlimeSegment> _segments = null!;

        // The AnimatedSprite used when drawing each slime segment.
        private AnimatedSprite _sprite;

        /// <summary>
        /// Event that is raised if it is detected that the head segment of the slime has collided with a body segment.
        /// </summary>
        public event EventHandler BodyCollision = null!;

        public Slime(AnimatedSprite sprite)
        {
            _sprite = sprite;
        }

        public void Initialize(Vector2 startingPosition, float stride)
        {
            // Initialize the segment collection
            _segments = new List<SlimeSegment>();

            // Set the stride
            _stride = stride;

            // Create the initial head of the slime chain
            SlimeSegment head = new SlimeSegment();
            head.At = startingPosition;
            head.To = startingPosition + new Vector2(_stride, 0);
            head.Direction = Vector2.UnitX;

            // Add it to the segment collection
            _segments.Add(head);

            // Set the initial next direction as the same direction the head is moving
            _nextDirection = head.Direction;

            // Zero out the movement timer
            _movementTimer = TimeSpan.Zero;
        }

        private void HandleInput()
        {
            Vector2 potentialNextDirection = _nextDirection;

            if (GameController.MoveUp())
            {
                potentialNextDirection = -Vector2.UnitY;
            }
            else if (GameController.MoveDown())
            {
                potentialNextDirection = Vector2.UnitY;
            }
            else if (GameController.MoveLeft())
            {
                potentialNextDirection = -Vector2.UnitX;
            }
            else if (GameController.MoveRight())
            {
                potentialNextDirection = Vector2.UnitX;
            }

            // Only allow direction change if it is not reversing the current
            // direction. This prevents the slime from backing into itself
            float dot = Vector2.Dot(potentialNextDirection, _segments[0].Direction);
            if (dot >= 0)
            {
                _nextDirection = potentialNextDirection;
            }
        }
    }
}
