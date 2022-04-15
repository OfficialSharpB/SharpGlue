/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SharpGlue.Core.Graphics;

using System;
using System.ComponentModel.Design.Serialization;

namespace SharpGlue.Core.Screen.Menu
{
    /// <summary>
    /// Represents a menu scene entry.
    /// </summary>
    public class MenuSceneEntry
    {
        string title, description;
        Vector2 position;

        bool enabled;


        /// <summary>
        /// Gets or sets the position of this <see cref="MenuSceneEntry"/>
        /// </summary>
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Gets or sets whether this <see cref="MenuSceneEntry"/> is enabled.
        /// </summary>
        /// <remarks>True; if enabled, otherwise false.</remarks>
        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => title;
            set => title = value;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get => description;
            set => description = value;
        }

        /// <summary>
        /// Raised when the menu entry is selected.
        /// </summary>
        public event EventHandler Selected;

        /// <summary>
        /// Initialize a new instance of <see cref="MenuSceneEntry"/>
        /// </summary>
        /// <param name="title">The title of this menu.</param>
        /// <param name="description">The description of this menu.</param>
        public MenuSceneEntry(string title, string description) {
            this.title = title;
            this.description = description;
        }


        /// <summary>
        /// Initialize a new instance of <see cref="MenuSceneEntry"/>
        /// </summary>
        /// <param name="title">The title of this menu.</param>
        public MenuSceneEntry(string title) : this(title, "") {

        }

        public virtual void Draw(SpriteBatch spriteBatch, SpriteFont font, SpriteFont descriptionFont, bool isSelected, Color highlight, Color idle, Color disabled) {
            var color = enabled ? isSelected ? highlight : idle : disabled;
            if (font == null) return;

            spriteBatch.DrawString(font, title, position, color);

            if (descriptionFont == null)
                return;

            var view = spriteBatch.GraphicsDevice.ViewPort.Height;
            var size = descriptionFont.MesureString(description);

            var height = (view - size.Height) - 10;
            var x = position.X;
            spriteBatch.DrawString(descriptionFont, description, new Vector2(x, height), idle);
        }

        /// <summary>
        /// raises <see cref="MenuSceneEntry.Selected"/> event.
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnSelectedEntry(System.EventArgs e) {
            Selected?.Invoke(this, e);
        }
    }
}
