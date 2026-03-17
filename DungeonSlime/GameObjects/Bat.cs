using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace DungeonSlime.GameObjects
{
    public class Bat
    {
        private const float MOVEMENT_SPEED = 5.0f;

        // The velocity of the bat that defines the direction and how much in that
        // direction to update the bats position each update cycle.
        private Vector2 _velocity;

        // The AmimatedSprite used when drawing the bat.
        private AnimatedSprite _sprite;

        // The sound effect to play when the bat bounces off the edge of the room.
        private SoundEffect _bounceSoundEffect;

        /// <summary>
        /// Gets or Sets the position of the bat.
        /// </summary>
        public Vector2 Position { get; set; }

        public Bat(AnimatedSprite sprite, SoundEffect bounceSoundEffect)
        {
            _sprite = sprite;
            _bounceSoundEffect = bounceSoundEffect;
        }

        /// <summary>
        /// Randomize the velocity of the bat.
        /// </summary>
        public void RandomizeVelocity()
        {
            // Generate a random angle
            float angle = (float)(Random.Shared.NextDouble() * MathHelper.TwoPi);

            // Convert the angle to a direction vector
            float x = (float)Math.Cos(angle);
            float y = (float)Math.Sin(angle);
            Vector2 direction = new Vector2(x, y);

            // Multiply the direction vector by the movement speed to get the final velocity
            _velocity = direction * MOVEMENT_SPEED;
        }
    }
}
