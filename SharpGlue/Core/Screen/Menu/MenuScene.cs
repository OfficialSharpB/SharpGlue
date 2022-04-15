/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SharpGlue.Core.Graphics;
using SharpGlue.Core.Input;
using SharpGlue.Core.Input.Methods;
using SharpGlue.Core.Input.States.Keyboard;

using System.Collections.Generic;

namespace SharpGlue.Core.Screen.Menu
{
    /// <summary>
    /// Represents a menu scene, capable in showing, displaying, and popup.
    /// </summary>
    public class MenuScene : GameScene
    {
        Color highlighted, idle, disabled, titleColor;
        int selectedIndex = 0;
        string title;
        List<MenuSceneEntry> menuEntries = new List<MenuSceneEntry>();
        SpriteFont entryTitleFont, entryDescriptionFont;
        SpriteFont titleFont;
        MenuEntryAlignment alignment = MenuEntryAlignment.Vertical;
        Vector2 menuTitlePosition = Vector2.Zero;
        Vector2 menuEntryPosition = Vector2.Zero;

        /// <summary>
        /// The key that makes the menu move up.
        /// </summary>
        public Keys UpKey = Keys.Up;

        /// <summary>
        /// The key that makes the menu move down.
        /// </summary>
        public Keys DownKey = Keys.Down;

        /// <summary>
        /// The key that selects a menu entry.
        /// </summary>
        public Keys SelectKey = Keys.Enter;


        /// <summary>
        /// Gets or sets the color of this <see cref="MenuScene"/> title.
        /// </summary>
        public Color TitleColor
        {
            get => titleColor;
            set => titleColor = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="MenuSceneEntry"/> alignments.
        /// </summary>
        public MenuEntryAlignment Alignment
        {
            get => alignment;
            set => alignment = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="SpriteFont"/> that is used for the title of a <see cref="MenuSceneEntry"/>
        /// </summary>
        public SpriteFont EntryFont
        {
            get => entryTitleFont;
            set => entryTitleFont = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="SpriteFont"/> that is used for the description of a <see cref="MenuSceneEntry"/>
        /// </summary>
        public SpriteFont EntryFont2
        {
            get => entryDescriptionFont;
            set => entryDescriptionFont = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="SpriteFont"/> that is used for this <see cref="MenuScene.Title"/>
        /// </summary>
        public SpriteFont Font
        {
            get => titleFont;
            set => titleFont = value;
        }

        /// <summary>
        /// Gets or sets the title of this <see cref="MenuScene"/>
        /// </summary>
        public string Title
        {
            get => title;
            set => title = value;
        }

        
        /// <summary>
        /// Gets or sets the color of the <see cref="MenuSceneEntry"/>(s) that has been highlighted or hovered over.
        /// </summary>
        public Color HighlightColor
        {
            get => highlighted;
            set => highlighted = value;
        }

        /// <summary>
        /// Gets or sets the color of the <see cref="MenuSceneEntry"/>(s) that is idling, with no hover, or selection.
        /// </summary>
        public Color IdleColor
        {
            get => idle;
            set => idle = value;
        }

        /// <summary>
        /// Gets or sets the color that is used when <see cref="MenuSceneEntry.Enabled"/> is false.
        /// </summary>
        public Color DisabledColor
        {
            get => disabled;
            set => disabled = value;
        }

        /// <summary>
        /// Gets the current <see cref="List{T}"/> of menu entries.
        /// </summary>
        public List<MenuSceneEntry> MenuEntries
        {
            get => menuEntries;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="MenuScene"/>
        /// </summary>
        /// <param name="title">The title of this menu</param>
        public MenuScene(string title) {
            this.title = title;
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen) {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            if (alignment == MenuEntryAlignment.Vertical) {
                #region verticalAlignMent
                for(int i = 0; i < menuEntries.Count;i++) {
                    menuEntries[i].Position = menuEntryPosition;
                    menuEntryPosition.Y += GetItemSize(i).Height + 10;
                }
                #endregion
            }
            else {
                #region horizontal alignment.
                for (int i = 0; i < menuEntries.Count; i++) {
                    menuEntries[i].Position = menuEntryPosition;
                    menuEntryPosition.X+= GetItemSize(i).Width + 10;
                }
                #endregion
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.Begin();
            for (int i = 0; i < menuEntries.Count; i++)
                menuEntries[i].Draw(spriteBatch, entryTitleFont, entryDescriptionFont, i == selectedIndex,
                    highlighted, idle, disabled);

            spriteBatch.DrawString(titleFont, title, menuTitlePosition, titleColor);
            spriteBatch.End();
        }

        public override void HandleInput(GameTime gameTime, InputSystem input) {
            base.HandleInput(gameTime, input);
            var mouse = input.GetInput<MouseInput>();
            var keyboard = input.GetInput<KeyboardInput>();

            if(keyboard != null) {
                if(keyboard.IsKeyDown(UpKey)) {
                    if (selectedIndex <= 0)
                        selectedIndex = menuEntries.Count - 1;
                    selectedIndex -= 1;
                }
                if(keyboard.IsKeyDown(DownKey)) {
                    if (selectedIndex == menuEntries.Count - 1)
                        selectedIndex = 0;
                    selectedIndex += 1;
                }
                if (keyboard.IsKeyDown(SelectKey))
                    menuEntries[selectedIndex].OnSelectedEntry(System.EventArgs.Empty);
            }

            if(mouse != null) {
                var mouseBounds = new Rectangle(
                                                         (int)mouse.CurrentPosition.X,
                                                         (int)mouse.CurrentPosition.Y,
                                                         10, 10);
                for(int i = 0; i < menuEntries.Count;i++) {
                    var menuBounds = new Rectangle((int)menuEntries[i].Position.X, (int)menuEntries[i].Position.Y,
                                                       GetItemSize(i).Width, GetItemSize(i).Height);

                    if (mouseBounds.Interact(mouseBounds)) {
                        selectedIndex = i;
                        if (mouse.IsButtonDown(Input.States.Mouse.MouseButtons.Left))
                            menuEntries[i].OnSelectedEntry(new System.EventArgs());
                    }
                }
                
            }
        }

        #region private helpers
        Size GetItemSize(int item) {
            var menuEntry = menuEntries[item];
            return entryTitleFont.MesureString(menuEntry.Title);
        }
        #endregion
    }
}
