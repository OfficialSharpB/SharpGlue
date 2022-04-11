/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SharpGlue.Core.Graphics;
using SharpGlue.Core.Input;

using System;

namespace SharpGlue.Core.Screen
{
    public abstract class GameScene
    {

        /// <summary>
        /// Initialize a new instance of <see cref="GameScene"/>
        /// </summary>
        public GameScene() { 
        }
        // A screen is a single layer that has update and draw logic, and which
        // can be combined with other layers to build up a complex menu system.
        // For instance the main menu, the options menu, the "are you sure you
        // want to quit" message box, and the main game itself are all implemented
        // as screens.
        public bool IsPopup { get; protected set; }

        protected TimeSpan TransitionOnTime
        {
            get => _transitionOnTime;
            set => _transitionOnTime = value;
        }
        private TimeSpan _transitionOnTime = TimeSpan.Zero;

        protected TimeSpan TransitionOffTime
        {
            private get => _transitionOffTime;
            set => _transitionOffTime = value;
        }
        private TimeSpan _transitionOffTime = TimeSpan.Zero;

        // Ranges from zero (fully active, no transition)
        // to one (transitioned fully off to nothing)
        protected float TransitionPosition
        {
            get => _transitionPosition;
            set => _transitionPosition = value;
        }
        private float _transitionPosition = 1;

        // Ranges from 1 (fully active, no transition)
        // to 0 (transitioned fully off to nothing)
        public float TransitionAlpha => 1f - TransitionPosition;

        // Gets the current screen transition state.
        public GameSceneState ScreenState
        {
            get => _screenState;
            protected set => _screenState = value;
        }
        private GameSceneState _screenState = GameSceneState.TransitionOn;

        // There are two possible reasons why a screen might be transitioning
        // off. It could be temporarily going away to make room for another
        // screen that is on top of it, or it could be going away for good.
        // This property indicates whether the screen is exiting for real:
        // if set, the screen will automatically remove itself as soon as the
        // transition finishes.
        public bool IsExiting
        {
            get => _isExiting;
            protected internal set => _isExiting = value;
        }
        private bool _isExiting;

        // Checks whether this screen is active and can respond to user input.
        protected bool IsActive => !_otherScreenHasFocus &&
                                   (_screenState == GameSceneState.TransitionOn ||
                                    _screenState == GameSceneState.Active);

        private bool _otherScreenHasFocus;

        public GameSceneManager ScreenManager
        {
            get => _screenManager;
            internal set => _screenManager = value;
        }
        private GameSceneManager _screenManager;

        #region Scene Methods

        // Activates the screen. Called when the screen is added to the screen manager or if the game resumes
        // from being paused or tombstoned.
        // instancePreserved is true if the game was preserved during deactivation, false if the screen is
        // just being added or if the game was tombstoned. On Xbox and Windows this will always be false.
        public virtual void LoadContent(bool instancePreserved) { }

        // Deactivates the screen. Called when the game is being deactivated due to pausing or tombstoning.
        protected virtual void Deactivate() { }

        // Unload content for the screen. Called when the screen is removed from the screen manager.
        public virtual void Unload() { }


        // Unlike HandleInput, this method is called regardless of whether the screen
        // is active, hidden, or in the middle of a transition.
        public virtual void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen) {
            _otherScreenHasFocus = otherScreenHasFocus;

            if (_isExiting) {
                // If the screen is going away to die, it should transition off.
                _screenState = GameSceneState.TransitionOff;

                if (!UpdateTransitionPosition(gameTime, _transitionOffTime, 1))
                    ScreenManager.RemoveScreen(this);    // When the transition finishes, remove the screen
            }
            else if (coveredByOtherScreen) {
                // If the screen is covered by another, it should transition off.
                _screenState = UpdateTransitionPosition(gameTime, _transitionOffTime, 1)
                    ? GameSceneState.TransitionOff
                    : GameSceneState.Hidden;
            }
            else {
                // Otherwise the screen should transition on and become active.
                _screenState = UpdateTransitionPosition(gameTime, _transitionOnTime, -1)
                    ? GameSceneState.TransitionOn
                    : GameSceneState.Active;
            }
        }

        private bool UpdateTransitionPosition(GameTime gameTime, TimeSpan time, int direction) {
            float transitionDelta;    // How much should we move by?

            if (time == TimeSpan.Zero)
                transitionDelta = 1;
            else
                transitionDelta = (float)(gameTime.Enlapsed.TotalMilliseconds / time.TotalMilliseconds);

            _transitionPosition += transitionDelta * direction;    // Update the transition position

            // Did we reach the end of the transition?
            if (direction < 0 && _transitionPosition <= 0 || direction > 0 && _transitionPosition >= 1) {
                _transitionPosition = MathHelper.Clamp(_transitionPosition, 0, 1);
                return false;
            }

            return true;    // Otherwise we are still busy transitioning
        }

        public virtual void HandleInput(GameTime gameTime, InputSystem input) { }
        public virtual void Draw(GameTime gameTime ,SpriteBatch spriteBatch) { }

        // Unlike ScreenManager.RemoveScreen, which instantly kills the screen, this method respects
        // the transition timings and will give the screen a chance to gradually transition off.
        public void ExitScreen() {
            if (TransitionOffTime == TimeSpan.Zero)
                ScreenManager.RemoveScreen(this);    // If the screen has a zero transition time, remove it immediately
            else
                _isExiting = true;    // Otherwise flag that it should transition off and then exit.
        }
        #endregion
    }
}
