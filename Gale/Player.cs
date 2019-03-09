using System.Diagnostics;
using Gale.Input;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Bindings;
using osu.Framework.Logging;
using osu.Framework.Physics;
using osuTK;

namespace Gale
{
    public class Player : RigidBodyContainer<Drawable>, IKeyBindingHandler<InputAction>
    {
        private float constantXForce;
        
        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            Child = new Box
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(150, 150),
            };
            Position = new Vector2(500, 500);
            Size = new Vector2(200, 200);
            Rotation = 45;
            Masking = true;
        }

        private const float PLAYER_VELOCITY = 500f;

        public bool OnPressed(InputAction action)
        {
            Logger.Log(Time.Current.ToString());
            switch (action)
            {
                case InputAction.Jump:
                    Velocity = new Vector2(constantXForce, Velocity.Y - 500);
                    break;
                case InputAction.Right:
                    constantXForce += PLAYER_VELOCITY;
                    break;
                case InputAction.Left:
                    constantXForce -= PLAYER_VELOCITY;
                    break;
            }
            return true;
        }
        
        public bool OnReleased(InputAction action)
        {
            Logger.Log(Time.Current.ToString());
            switch (action)
            {
                case InputAction.Left:
                    constantXForce += PLAYER_VELOCITY;
                    break;
                case InputAction.Right:
                    constantXForce -= PLAYER_VELOCITY;
                    break;
            }
            return true;
        }
        
        protected override void Update()
        {
            base.Update();
            
            Velocity = new Vector2(constantXForce, Velocity.Y);
        }
    }
}