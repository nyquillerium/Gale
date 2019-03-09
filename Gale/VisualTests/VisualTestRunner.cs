using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace Gale.VisualTests
{
    public class VisualTestRunner : GaleGame
    {
         [BackgroundDependencyLoader]
         private void load()
         {
             base.LoadComplete();

             Child = new DrawSizePreservingFillContainer
             {
                 Children = new Drawable[]
                 {
                     new TestBrowser("Gale"),
                     new CursorContainer(),
                 },
             };
         }

         public override void SetHost(GameHost host)
         {
             base.SetHost(host);
             host.Window.CursorState |= CursorState.Hidden;
         }
    }
}