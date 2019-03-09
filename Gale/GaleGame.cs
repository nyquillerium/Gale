using System;
using Gale.Input;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using osu.Framework.IO.Stores;
using osu.Framework.Physics;
using osuTK;
using osuTK.Graphics;

namespace Gale
{
    public class GaleGame : Game
    {
        private DependencyContainer dependencies;
        
        RigidBodySimulation sim;

        public GaleGame()
        {
            Name = @"Gale";
        }
        
        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void load()
        {
            sim = new RigidBodySimulation { RelativeSizeAxes = Axes.Both };
            
            Resources.AddStore(new DllResourceStore(@"Gale.dll"));
            dependencies.Cache(Fonts = new FontStore(new GlyphStore(Resources, @"Fonts/Exo2.0-Regular")));
            Fonts.AddStore(new GlyphStore(Resources, @"Fonts/Exo2.0-RegularItalic"));
 
            sim.Add(new Player());
            
            base.Content.Add(new GaleKeyBindingContainer
            {
                sim
            });
        }
    }
}