using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input;
using osu.Framework.Physics;
using osu.Framework.Testing;
using osuTK;

namespace Gale.VisualTests
{
    [TestFixture]
    public class BumpTest : TestCase
    {
        private RigidBodySimulation sim;
        private Texture texture;

        public BumpTest()
        {

        }
        
        [Test]
        public void Anime()
        {
            AddStep("Drop a cube", DropCube);
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore store, UserInputManager input)
        {
            texture = store.Get(@"osu");
        }

        private void DropCube()
        {
            Child = sim = new RigidBodySimulation { RelativeSizeAxes = Axes.Both };
            
            RigidBodyContainer<Drawable> rbc = new RigidBodyContainer<Drawable>
            {
                Child = new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(150, 150),
                    Texture = texture,
                },
                Position = new Vector2(500, 500),
                Size = new Vector2(200, 200),
                Rotation =  45,
                Masking = true,
            };
            
            sim.Add(rbc);
            
            FillFlowContainer flow;

            AddRange(new Drawable[]
            {
                new ScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new[]
                    {
                        flow = new FillFlowContainer
                        {
                            Anchor = Anchor.TopLeft,
                            AutoSizeAxes = Axes.Y,
                            RelativeSizeAxes = Axes.X,
                            Direction = FillDirection.Vertical,
                        }
                    }
                }
            });

            SpriteText test = new SpriteText
            {
                Text = @"You are now entering completely darkness...",
                Font = "Exo2.0-Regular",
                AllowMultiline = true,
                RelativeSizeAxes = Axes.X,
                TextSize = 25
            };
            
            flow.Add(test);
            
            flow.Add(new SpriteText
            {
                Text = @"That just used the font " + test.Font + "!",
                Font = "Exo2.0-RegularItalic",
                AllowMultiline = true,
                RelativeSizeAxes = Axes.X,
                TextSize = 25
            });
        }
    }
}