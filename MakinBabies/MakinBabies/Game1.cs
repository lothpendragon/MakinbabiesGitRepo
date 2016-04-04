﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MakinBabies
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Screen Declarations
        enum GameState { Splash, Title, Options, Gameplay };
        GameState gameState = new GameState();

        Splash splashScreen;
        Title titleScreen;
        Options optionsScreen;
        Gameplay gameplayScreen;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            #region Graphics
            int screenWidth = 1600;
            int screenHeight = 900;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            #endregion

            #region Screen Stuff
            gameState = GameState.Gameplay;

            splashScreen = new Splash(Content);
            titleScreen = new Title(Content);
            optionsScreen = new Options(Content);
            gameplayScreen = new Gameplay(Content);
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                #region Splash Update
                case GameState.Splash:
                    if (splashScreen.CheckTimer()) gameState = GameState.Title;
                    splashScreen.Update();
                    break;
                #endregion

                #region Title Update
                case GameState.Title:
                    titleScreen.Update();
                    break;
                #endregion

                #region Options Update
                case GameState.Options:
                    optionsScreen.Update();
                    break;
                #endregion

                #region Gameplay Update
                case GameState.Gameplay:
                    gameplayScreen.Update();
                    break;
                #endregion
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            switch (gameState)
            {
                #region Splash Draw
                case GameState.Splash:
                    splashScreen.Draw(spriteBatch);
                    break;
                #endregion

                #region Title Draw
                case GameState.Title:
                    GraphicsDevice.Clear(Color.Red);
                    titleScreen.Draw(spriteBatch);
                    break;
                #endregion

                #region Options Draw
                case GameState.Options:
                    GraphicsDevice.Clear(Color.Blue);
                    optionsScreen.Draw(spriteBatch);
                    break;
                #endregion

                #region Gameplay Draw
                case GameState.Gameplay:
                    GraphicsDevice.Clear(Color.White);
                    gameplayScreen.Draw(spriteBatch);
                    break;
                #endregion
            }
            base.Draw(gameTime);
        }
    }
}
