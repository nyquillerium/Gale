using System.Collections.Generic;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;

namespace Gale.Input
{
    public class GaleKeyBindingContainer : KeyBindingContainer<InputAction>
    {
        public GaleKeyBindingContainer(KeyCombinationMatchingMode keyCombinationMatchingMode = KeyCombinationMatchingMode.Any,
            SimultaneousBindingMode simultaneousBindingMode = SimultaneousBindingMode.All) : base(simultaneousBindingMode, keyCombinationMatchingMode)
        {
        }
        
        public override IEnumerable<KeyBinding> DefaultKeyBindings => new[]
        {
            new KeyBinding(new[] { InputKey.A }, InputAction.Left),
            new KeyBinding(new[] { InputKey.Space }, InputAction.Jump),
            new KeyBinding(new[] { InputKey.D }, InputAction.Right),
            new KeyBinding(new[] { InputKey.S }, InputAction.Down),
            new KeyBinding(new[] { InputKey.MouseLeft }, InputAction.LeftClick),
            new KeyBinding(new[] { InputKey.MouseMiddle }, InputAction.MiddleCLick),
            new KeyBinding(new[] { InputKey.MouseRight }, InputAction.RightClick),
        };
    }

    public enum InputAction
    {    
        Left,
        Right,
        Down,
        Jump,
        LeftClick,
        MiddleCLick,
        RightClick,
    }
}