using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakinBabies
{
    class Title
    {
        #region Declarations
        private ContentManager Content;
        private KeyboardState oldKeyState;

        private List<Conveyor> belt;
        private List<Baby> babies;
        private int babyTimer;

        private Options optionsSection;
        private List<Texture2D> exitChuteParts;
        private Texture2D exitChuteEntrance;
        private Texture2D screenBacking;
        private Texture2D titleText;

        private Rectangle finishBox;

        private Button startButton;
        private Button exitButton;
        #endregion

        #region Gets/Sets
        public List<Conveyor> Belt
        {
            get { return belt; }
            set { belt = value; }
        }
        public List<Baby> Babies
        {
            get { return babies; }
            set { babies = value; }
        }
        public Button StartButton
        {
            get { return startButton; }
            set { startButton = value; }
        }
        public Button ExitButton
        {
            get { return exitButton; }
            set { exitButton = value; }
        }
        #endregion

        #region Methods
        public Title(ContentManager Content)
        {
            this.Content = Content;
            oldKeyState = Keyboard.GetState();
            startButton = new Button(Content, "StartButton", new Vector2(500, 500));
            exitButton = new Button(Content, "ExitButton", new Vector2(1000, 500));
            finishBox = new Rectangle(1587, 700, 1, 1600);

            screenBacking = Content.Load<Texture2D>("BackgroundScreen");
            titleText = Content.Load<Texture2D>("TitleText");

            #region Belts
            belt = new List<Conveyor>();
            for (int i = 0; i < 15; i++)
            {
                belt.Add(new Conveyor(Content, new Vector2(126 * i, 0)));
            }
            #endregion

            #region Babies
            babies = new List<Baby>();
            babies.Add(new Baby(Content));
            #endregion

            #region Chute
            exitChuteParts = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                exitChuteParts.Add(Content.Load<Texture2D>("VacTubeSection"));
            }
            exitChuteEntrance = Content.Load<Texture2D>("VacTubeEntrance");
            #endregion

            #region Options Area
            optionsSection = new Options(Content);
            #endregion
        }
        public void Clear()
        {
            babies.Clear();
        }
        public void Update()
        {
            KeyboardState newKeyState = Keyboard.GetState();
            startButton.Update();
            exitButton.Update();

            #region Baby Update
            babyTimer++;
            for (int i = 0; i < babies.Count; i++)
            {
                if (babies[i].Bounds.Intersects(finishBox))
                {
                    babies[i].IsStopped = true;
                    babies[i].IsUnderChute = true;
                    //Add points total code
                }
            }
            foreach (var baby in babies)
            {
                baby.Update();
            }
            if (babyTimer >= 350)
            {
                babyTimer = 0;
                babies.Add(new Baby(Content));
            }
            #endregion

            #region Buttons Update
            #endregion

            optionsSection.Update();

            oldKeyState = newKeyState;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(screenBacking, new Rectangle(0, 0, 1600, 900), Color.White);
            sb.Draw(titleText, new Rectangle(0, 0, titleText.Width, titleText.Height), Color.White);

            #region Belt Draw
            foreach (var beltPart in belt)
            {
                beltPart.Draw(sb);
            }
            #endregion

            #region Baby Draw
            foreach (var baby in babies)
            {
                baby.Draw(sb);
            }
            #endregion

            #region Chute Draw
            for (int i = 0; i < exitChuteParts.Count; i++)
            {
                sb.Draw(exitChuteParts[i], new Rectangle(1450, (exitChuteParts[i].Height * 2) * i, exitChuteParts[i].Width * 2, exitChuteParts[i].Height * 2), Color.White);
            }
            sb.Draw(exitChuteEntrance, new Rectangle(1450, 462, exitChuteEntrance.Width * 2, exitChuteEntrance.Height * 2), Color.White);
            #endregion

            #region Buttons Draw
            startButton.SpriteSheetDraw(sb);
            exitButton.SpriteSheetDraw(sb);
            #endregion
            
            optionsSection.Draw(sb);
        }
        #endregion
    }
}
